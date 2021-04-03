// SysLoginService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
    public class SysLoginService : FwkService, ISysLoginService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginService(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysLoginDataResponse Authenticate(SysLoginDataRequest loginDataRequest)
        {
            this.Operation = "Authenticate";

            SysLoginDataResponse loginDataResponse = (SysLoginDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformAuthenticate(loginDataRequest, loginDataResponse);

            this.Database.CloseConnection();

            return loginDataResponse;
        }

        /// <summary>
        /// Perform authentication
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        protected void PerformAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
            BeforePerformAuthenticate(loginDataRequest, loginDataResponse);

            #region Before OnAuthenticate plugins

            if (this.IPlugins != null)
            {
                foreach (ISysLoginPlugin iLoginPlugin in this.IPlugins)
                    iLoginPlugin.AuthenticatePluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(loginDataRequest, loginDataResponse));
            }

            #endregion Before OnAuthenticate plugins

            OnAuthenticate(loginDataRequest, loginDataResponse);

            #region After OnAuthenticate plugins

            if (this.IPlugins != null)
            {
                foreach (ISysLoginPlugin iLoginPlugin in this.IPlugins)
                    iLoginPlugin.AuthenticatePluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(loginDataRequest, loginDataResponse));
            }

            #endregion After OnAuthenticate plugins

            AfterPerformAuthenticate(loginDataRequest, loginDataResponse);
        }

        /// <summary>
        /// On authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        protected virtual void OnAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
            SysAuthDataRequest authDataRequest = new SysAuthDataRequest();
            authDataRequest.Content.AuthenticationRequest = new SysAuthenticationRequest();
            authDataRequest.Content.AuthenticationRequest.IdDomain = loginDataRequest.Content.IdDomain;
            authDataRequest.Content.AuthenticationRequest.Credential = String.Join(';', loginDataRequest.Content.Username, loginDataRequest.Content.Password);

            SysAuthService authService = new SysAuthService(this.Environment);
            SysAuthDataResponse authDataResponse = authService.Authenticate(authDataRequest);

            loginDataResponse.Content.Token = authDataResponse.Content.AuthenticationResponse.Token;
        }

        /// <summary>
        /// Before perform authentication
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        private void BeforePerformAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
        }

        /// <summary>
        /// After perform authentication
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        private void AfterPerformAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
