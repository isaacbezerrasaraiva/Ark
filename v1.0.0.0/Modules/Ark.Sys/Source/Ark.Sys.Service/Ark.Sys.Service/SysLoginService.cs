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
            SysAuthenticationDataRequest authenticationDataRequest = new SysAuthenticationDataRequest();
            authenticationDataRequest.Content.IdDomain = loginDataRequest.Content.IdDomain;
            authenticationDataRequest.Content.Credential = String.Join(';', loginDataRequest.Content.Username, loginDataRequest.Content.Password);

            SysAuthenticationService authenticationService = new SysAuthenticationService(this.Environment);
            SysAuthenticationDataResponse authenticationDataResponse = authenticationService.Authenticate(authenticationDataRequest);

            loginDataResponse.Content.Token = authenticationDataResponse.Content.Token;

            if (loginDataResponse.Content.Token == null)
                throw new LibException(Properties.SysResourcesService.SysExceptionAuthenticationFailed, Properties.SysResourcesService.SysCaptionDenied);
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
