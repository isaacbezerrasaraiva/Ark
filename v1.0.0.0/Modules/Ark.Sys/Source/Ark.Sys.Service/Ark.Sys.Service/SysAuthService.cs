// SysAuthService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

using Lazy;
using Lazy.Database;

using Ark.Lib;
using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;
using Ark.Fwk.Service;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IPlugin;
using Ark.Fts.IService;
using Ark.Fts.Service;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IPlugin;
using Ark.Sys.IService;

namespace Ark.Sys.Service
{
    public class SysAuthService : FwkService, ISysAuthService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthService(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysAuthDataResponse Authenticate(SysAuthDataRequest authDataRequest)
        {
            SysAuthDataResponse authDataResponse = new SysAuthDataResponse();

            PerformAuthenticate(authDataRequest, authDataResponse);

            return authDataResponse;
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysAuthDataResponse Authorize(SysAuthDataRequest authDataRequest)
        {
            SysAuthDataResponse authDataResponse = new SysAuthDataResponse();

            PerformAuthorize(authDataRequest, authDataResponse);

            return authDataResponse;
        }

        /// <summary>
        /// Perform service authentication
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <param name="authDataResponse">The response data</param>
        protected void PerformAuthenticate(SysAuthDataRequest authDataRequest, SysAuthDataResponse authDataResponse)
        {
            #region BeforeAuthenticate

            if (this.IPlugins != null)
            {
                foreach (ISysAuthPlugin iAuthPlugin in this.IPlugins)
                    iAuthPlugin.AuthenticatePluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(authDataRequest, authDataResponse));
            }

            #endregion BeforeAuthenticate

            OnAuthenticate(authDataRequest, authDataResponse);

            #region AfterAuthenticate

            if (this.IPlugins != null)
            {
                foreach (ISysAuthPlugin iAuthPlugin in this.IPlugins)
                    iAuthPlugin.AuthenticatePluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(authDataRequest, authDataResponse));
            }

            #endregion AfterAuthenticate
        }

        /// <summary>
        /// Perform service authorization
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <param name="authDataResponse">The response data</param>
        protected void PerformAuthorize(SysAuthDataRequest authDataRequest, SysAuthDataResponse authDataResponse)
        {
            #region BeforeAuthorize

            if (this.IPlugins != null)
            {
                foreach (ISysAuthPlugin iAuthPlugin in this.IPlugins)
                    iAuthPlugin.AuthorizePluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(authDataRequest, authDataResponse));
            }

            #endregion BeforeAuthorize

            OnAuthorize(authDataRequest, authDataResponse);

            #region AfterAuthorize

            if (this.IPlugins != null)
            {
                foreach (ISysAuthPlugin iAuthPlugin in this.IPlugins)
                    iAuthPlugin.AuthorizePluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(authDataRequest, authDataResponse));
            }

            #endregion AfterAuthorize
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <param name="authDataResponse">The response data</param>
        protected virtual void OnAuthenticate(SysAuthDataRequest authDataRequest, SysAuthDataResponse authDataResponse)
        {
            authDataResponse.Content.AuthenticationResponse = new SysAuthenticationResponse();
            authDataResponse.Content.AuthenticationResponse.IdDomain = -1;
            authDataResponse.Content.AuthenticationResponse.IdUser = -1;

            if (authDataRequest.Content.AuthenticationRequest.Token != null)
            {
                Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary = DecryptTokenJWT(authDataRequest.Content.AuthenticationRequest.Token);
                Dictionary<String, String> publicPayloadDictionary = tuplePayloadDictionary.Item1;
                Dictionary<String, String> privatePayloadDictionary = tuplePayloadDictionary.Item2;

                authDataResponse.Content.AuthenticationResponse.IdDomain = LazyConvert.ToInt32(privatePayloadDictionary["IdDomain"]);
                authDataResponse.Content.AuthenticationResponse.IdUser = LazyConvert.ToInt32(privatePayloadDictionary["IdUser"]);
            }
            else if (authDataRequest.Content.AuthenticationRequest.Credential != null)
            {
                String[] credentialArray = authDataRequest.Content.AuthenticationRequest.Credential.Split(';');

                #region Authenticate on database

                this.Database.OpenConnection();

                String sql = "select IdUser, Password, DisplayName from FwkUser where IdDomain = :IdDomain and Username = :Username";
                DataTable dataTableUser = this.Database.QueryTable(sql, "FwkUser", new Object[] { authDataRequest.Content.AuthenticationRequest.IdDomain, credentialArray[0] });

                if (dataTableUser.Rows.Count > 0)
                {
                    String hashedPassword = LazySecurity.Hash.SHA384.Generate(credentialArray[1]);

                    if (LazyConvert.ToString(dataTableUser.Rows[0]["Password"]) == hashedPassword)
                    {
                        Dictionary<String, String> publicPayloadDictionary = new Dictionary<String, String>();
                        Dictionary<String, String> privatePayloadDictionary = new Dictionary<String, String>();
                        Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary =
                            new Tuple<Dictionary<String, String>, Dictionary<String, String>>(publicPayloadDictionary, privatePayloadDictionary);

                        publicPayloadDictionary.Add("User", LazyConvert.ToString(dataTableUser.Rows[0]["DisplayName"]));
                        privatePayloadDictionary.Add("IdDomain", LazyConvert.ToString(authDataRequest.Content.AuthenticationRequest.IdDomain));
                        privatePayloadDictionary.Add("IdUser", LazyConvert.ToString(dataTableUser.Rows[0]["IdUser"]));

                        authDataResponse.Content.AuthenticationResponse.IdDomain = authDataRequest.Content.AuthenticationRequest.IdDomain;
                        authDataResponse.Content.AuthenticationResponse.IdUser = LazyConvert.ToInt32(dataTableUser.Rows[0]["IdUser"]);
                        authDataResponse.Content.AuthenticationResponse.Token = EncryptTokenJWT(tuplePayloadDictionary);
                    }
                }

                this.Database.CloseConnection();

                #endregion Authenticate on database
            }
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <param name="authDataResponse">The response data</param>
        protected virtual void OnAuthorize(SysAuthDataRequest authDataRequest, SysAuthDataResponse authDataResponse)
        {
            authDataResponse.Content.AuthorizationResponse = new SysAuthorizationResponse();

            #region Authorization Query

            String sqlAuthorization = @"
                select 1 
                from FwkBranchRoleUser 
	                inner join FwkBranchRoleAction 
		                on FwkBranchRoleUser.IdDomain = FwkBranchRoleAction.IdDomain 
                        and FwkBranchRoleUser.IdBranch = FwkBranchRoleAction.IdBranch 
                        and FwkBranchRoleUser.IdRole = FwkBranchRoleAction.IdRole 
	                inner join FwkUserContext 
		                on FwkBranchRoleUser.IdDomain = FwkUserContext.IdDomain 
                        and FwkBranchRoleUser.IdBranch = FwkUserContext.ValueInt16 
                        and FwkBranchRoleUser.IdUser = FwkUserContext.IdUser 
                where FwkBranchRoleUser.IdDomain = :IdDomain 
	                and FwkUserContext.Field = 'IdBranch' 
                    and FwkBranchRoleUser.IdUser = :IdUser 
                    and FwkBranchRoleAction.CodModule = :CodModule 
                    and FwkBranchRoleAction.CodFeature = :CodFeature 
                    and FwkBranchRoleAction.CodAction = :CodAction ";

            #endregion Authorization Query

            this.Database.OpenConnection();

            authDataResponse.Content.AuthorizationResponse.Authorized =
                this.Database.QueryFind(sqlAuthorization, new Object[] {
                    authDataRequest.Content.AuthorizationRequest.IdDomain,
                    authDataRequest.Content.AuthorizationRequest.IdUser,
                    authDataRequest.Content.AuthorizationRequest.CodModule,
                    authDataRequest.Content.AuthorizationRequest.CodFeature,
                    authDataRequest.Content.AuthorizationRequest.CodAction });

            this.Database.CloseConnection();
        }

        /// <summary>
        /// Decrypt from JWT Token
        /// </summary>
        /// <param name="token">The token to be decrypted</param>
        /// <returns>The payload dictionaries tuple</returns>
        private Tuple<Dictionary<String, String>, Dictionary<String, String>> DecryptTokenJWT(String token)
        {
            ValidateSecrets();

            String secretKey = LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretKey"].Text;
            String secretVector = LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretVector"].Text;

            Byte[] keyArray = Encoding.ASCII.GetBytes(secretKey);

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters();
            tokenValidationParameters.ValidateIssuerSigningKey = true;
            tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(keyArray);
            tokenValidationParameters.ValidateIssuer = false;
            tokenValidationParameters.ValidateAudience = false;
            tokenValidationParameters.ClockSkew = TimeSpan.Zero;

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            JwtSecurityToken jwtSecurityToken = (JwtSecurityToken)validatedToken;

            String publicPayload = jwtSecurityToken.Payload["public"].ToString();
            String privatePayload = jwtSecurityToken.Payload["private"].ToString();
            privatePayload = LazySecurity.Cryptography.Aes.Decrypt(privatePayload, secretKey, secretVector);

            Dictionary<String, String> publicPayloadDictionary = new Dictionary<String, String>();
            Dictionary<String, String> privatePayloadDictionary = new Dictionary<String, String>();
            Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary =
                new Tuple<Dictionary<String, String>, Dictionary<String, String>>(publicPayloadDictionary, privatePayloadDictionary);

            String[] publicPayloadArray = publicPayload.Split(';');
            foreach (String publicPayloadPair in publicPayloadArray)
            {
                String[] keyValue = publicPayloadPair.Split(':');
                publicPayloadDictionary.Add(keyValue[0], keyValue[1]);
            }

            String[] privatePayloadArray = privatePayload.Split(';');
            foreach (String privatePayloadPair in privatePayloadArray)
            {
                String[] keyValue = privatePayloadPair.Split(':');
                privatePayloadDictionary.Add(keyValue[0], keyValue[1]);
            }

            return tuplePayloadDictionary;
        }

        /// <summary>
        /// Encrypt to JWT token
        /// </summary>
        /// <param name="payloadDictionariesTuple">The payload dictionaries tuple</param>
        /// <returns>The encrypted token</returns>
        private String EncryptTokenJWT(Tuple<Dictionary<String, String>, Dictionary<String, String>> payloadDictionariesTuple)
        {
            ValidateSecrets();

            String secretKey = LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretKey"].Text;
            String secretVector = LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretVector"].Text;

            String publicPayload = String.Empty;
            String privatePayload = String.Empty;

            #region Generate public payload

            foreach (KeyValuePair<String, String> publicPayloadPair in payloadDictionariesTuple.Item1)
                publicPayload += publicPayloadPair.Key + ":" + publicPayloadPair.Value + ";";

            if (publicPayload.Length > 0)
                publicPayload = publicPayload.Remove(publicPayload.Length - 1, 1);

            #endregion Generate public payload

            #region Generate private payload

            foreach (KeyValuePair<String, String> privatePayloadPair in payloadDictionariesTuple.Item2)
                privatePayload += privatePayloadPair.Key + ":" + privatePayloadPair.Value + ";";

            if (privatePayload.Length > 0)
                privatePayload = privatePayload.Remove(privatePayload.Length - 1, 1);

            privatePayload = LazySecurity.Cryptography.Aes.Encrypt(privatePayload, secretKey, secretVector);

            #endregion Generate private payload

            Byte[] keyArray = Encoding.ASCII.GetBytes(secretKey);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(keyArray);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim("public", publicPayload), new Claim("private", privatePayload) });
            securityTokenDescriptor.NotBefore = DateTime.Now;
            securityTokenDescriptor.Expires = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            securityTokenDescriptor.SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// Validate secrets used for encryption and decryption
        /// </summary>
        private void ValidateSecrets()
        {
            if (String.IsNullOrEmpty(LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretKey"].Text) == true ||
                String.IsNullOrEmpty(LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretVector"].Text) == true)
            {
                LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretKey"].Text = Guid.NewGuid().ToString().Replace("-", String.Empty);
                LibServiceConfiguration.DynamicXml["Ark.Sys"]["Security"]["Secrets"]["SecretVector"].Text = Guid.NewGuid().ToString().Replace("-", String.Empty).Substring(0, 16);

                LibServiceConfiguration.Save();
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
