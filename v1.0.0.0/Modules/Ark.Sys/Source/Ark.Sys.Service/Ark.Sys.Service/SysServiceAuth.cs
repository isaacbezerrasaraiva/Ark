// SysServiceAuth.cs
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
//using Ark.Fts;
//using Ark.Fts.Data;
//using Ark.Fts.IPlugin;
//using Ark.Fts.IService;
//using Ark.Fts.Service;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IPlugin;
using Ark.Sys.IService;

namespace Ark.Sys.Service
{
    public class SysServiceAuth : FwkService, ISysServiceAuth
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServiceAuth()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysDataAuthResponse Authenticate(SysDataAuthRequest dataAuthRequest)
        {
            SysDataAuthResponse dataAuthResponse = new SysDataAuthResponse();

            PerformAuthenticate(dataAuthRequest, dataAuthResponse);

            return dataAuthResponse;
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysDataAuthResponse Authorize(SysDataAuthRequest dataAuthRequest)
        {
            SysDataAuthResponse dataAuthResponse = new SysDataAuthResponse();

            PerformAuthorize(dataAuthRequest, dataAuthResponse);

            return dataAuthResponse;
        }

        /// <summary>
        /// Perform service authentication
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <param name="dataAuthResponse">The response data</param>
        protected void PerformAuthenticate(SysDataAuthRequest dataAuthRequest, SysDataAuthResponse dataAuthResponse)
        {
            #region BeforeAuthenticate

            if (this.PluginList != null)
            {
                foreach (ISysPluginAuth iPluginAuth in this.PluginList)
                    iPluginAuth.BeforeAuthenticateEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataAuthRequest));
            }

            #endregion BeforeAuthenticate

            OnAuthenticate(dataAuthRequest, dataAuthResponse);

            #region AfterAuthenticate

            if (this.PluginList != null)
            {
                foreach (ISysPluginAuth iPluginAuth in this.PluginList)
                    iPluginAuth.AfterAuthenticateEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataAuthRequest, dataAuthResponse));
            }

            #endregion AfterAuthenticate
        }

        /// <summary>
        /// Perform service authorization
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <param name="dataAuthResponse">The response data</param>
        protected void PerformAuthorize(SysDataAuthRequest dataAuthRequest, SysDataAuthResponse dataAuthResponse)
        {
            #region BeforeAuthorize

            if (this.PluginList != null)
            {
                foreach (ISysPluginAuth iPluginAuth in this.PluginList)
                    iPluginAuth.BeforeAuthorizeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataAuthRequest));
            }

            #endregion BeforeAuthorize

            OnAuthorize(dataAuthRequest, dataAuthResponse);

            #region AfterAuthorize

            if (this.PluginList != null)
            {
                foreach (ISysPluginAuth iPluginAuth in this.PluginList)
                    iPluginAuth.AfterAuthorizeEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataAuthRequest, dataAuthResponse));
            }

            #endregion AfterAuthorize
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <param name="dataAuthResponse">The response data</param>
        protected virtual void OnAuthenticate(SysDataAuthRequest dataAuthRequest, SysDataAuthResponse dataAuthResponse)
        {
            dataAuthResponse.AuthenticationResponse = new SysAuthenticationResponse();
            dataAuthResponse.AuthenticationResponse.IdDomain = -1;
            dataAuthResponse.AuthenticationResponse.IdUser = -1;

            if (dataAuthRequest.AuthenticationRequest.Token != null)
            {
                Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary = DecryptTokenJWT(dataAuthRequest.AuthenticationRequest.Token);
                Dictionary<String, String> publicPayloadDictionary = tuplePayloadDictionary.Item1;
                Dictionary<String, String> privatePayloadDictionary = tuplePayloadDictionary.Item2;

                #region AfterDecryptToken

                if (this.PluginList != null)
                {
                    foreach (ISysPluginAuth iPluginAuth in this.PluginList)
                        iPluginAuth.AfterDecryptTokenEventHandler?.Invoke(this, new SysPluginAfterDecryptTokenEventArgs(dataAuthRequest, dataAuthResponse, publicPayloadDictionary, privatePayloadDictionary));
                }

                #endregion AfterDecryptToken

                dataAuthResponse.AuthenticationResponse.IdDomain = LazyConvert.ToInt32(privatePayloadDictionary["IdDomain"]);
                dataAuthResponse.AuthenticationResponse.IdUser = LazyConvert.ToInt32(privatePayloadDictionary["IdUser"]);
            }
            else if (dataAuthRequest.AuthenticationRequest.Credential != null)
            {
                String[] credentialArray = dataAuthRequest.AuthenticationRequest.Credential.Split(';');

                #region Authenticate on database

                this.Database.OpenConnection();

                String sql = "select IdUser, Password, DisplayName from FwkUser where IdDomain = :IdDomain and Username = :Username";
                DataTable dataTableUser = this.Database.QueryTable(sql, "FwkUser", new Object[] { dataAuthRequest.AuthenticationRequest.IdDomain, credentialArray[0] });

                if (dataTableUser.Rows.Count > 0)
                {
                    if (LazyConvert.ToString(dataTableUser.Rows[0]["Password"]) == credentialArray[1])
                    {
                        Dictionary<String, String> publicPayloadDictionary = new Dictionary<String, String>();
                        Dictionary<String, String> privatePayloadDictionary = new Dictionary<String, String>();
                        Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary =
                            new Tuple<Dictionary<String, String>, Dictionary<String, String>>(publicPayloadDictionary, privatePayloadDictionary);
                        
                        publicPayloadDictionary.Add("User", LazyConvert.ToString(dataTableUser.Rows[0]["DisplayName"]));
                        privatePayloadDictionary.Add("IdDomain", LazyConvert.ToString(dataAuthRequest.AuthenticationRequest.IdDomain));
                        privatePayloadDictionary.Add("IdUser", LazyConvert.ToString(dataTableUser.Rows[0]["IdUser"]));
                        
                        #region BeforeEncryptToken

                        if (this.PluginList != null)
                        {
                            foreach (ISysPluginAuth iPluginAuth in this.PluginList)
                                iPluginAuth.BeforeEncryptTokenEventHandler?.Invoke(this, new SysPluginBeforeEncryptTokenEventArgs(dataAuthRequest, publicPayloadDictionary, privatePayloadDictionary));
                        }

                        #endregion BeforeEncryptToken

                        dataAuthResponse.AuthenticationResponse.IdDomain = dataAuthRequest.AuthenticationRequest.IdDomain;
                        dataAuthResponse.AuthenticationResponse.IdUser = LazyConvert.ToInt32(dataTableUser.Rows[0]["IdUser"]);
                        dataAuthResponse.AuthenticationResponse.Token = EncryptTokenJWT(tuplePayloadDictionary);
                    }
                }

                this.Database.CloseConnection();

                #endregion Authenticate on database
            }
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <param name="dataAuthResponse">The response data</param>
        protected virtual void OnAuthorize(SysDataAuthRequest dataAuthRequest, SysDataAuthResponse dataAuthResponse)
        {
        }

        /// <summary>
        /// Decrypt from JWT Token
        /// </summary>
        /// <param name="token">The token to be decrypted</param>
        /// <returns>The payload dictionaries tuple</returns>
        private Tuple<Dictionary<String, String>, Dictionary<String, String>> DecryptTokenJWT(String token)
        {
            ValidateSecrets();

            String secretKey = LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretKey"].Attribute["Value"];
            String secretVector = LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretVector"].Attribute["Value"];

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

            String secretKey = LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretKey"].Attribute["Value"];
            String secretVector = LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretVector"].Attribute["Value"];

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
            securityTokenDescriptor.Expires = DateTime.Now.AddDays(7);
            securityTokenDescriptor.SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// Validate secrets used for encryption and decryption
        /// </summary>
        private void ValidateSecrets()
        {
            if (LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretKey"].Attribute["Value"] == String.Empty || LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretVector"].Attribute["Value"] == String.Empty)
            {
                LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretKey"].Attribute["Value"] = Guid.NewGuid().ToString().Replace("-", String.Empty);
                LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["SecretVector"].Attribute["Value"] = Guid.NewGuid().ToString().Replace("-", String.Empty).Substring(0, 16);

                LibServiceConfiguration.Save();
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
