// SysAuthenticationServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

using Lazy;

using Ark.Lib;
using Ark.Lib.Server;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IServer;
using Ark.Fwk.IService;
using Ark.Fwk.Server;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IServer;
using Ark.Fts.IService;
using Ark.Fts.Server;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IServer;
using Ark.Sys.IService;

namespace Ark.Sys.Server
{
    public class SysAuthenticationServer : FwkServer, ISysAuthenticationServer, ILibAuthenticationServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationServer()
        {
            this.DataRequestType = typeof(SysAuthenticationDataRequest);
            this.DataResponseType = typeof(SysAuthenticationDataResponse);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="context">The request context</param>
        public void Authenticate(HttpContext context)
        {
            String headerToken = LazyConvert.ToString(context.Request.Headers["Token"], null);

            if (String.IsNullOrEmpty(headerToken) == false)
            {
                SysAuthenticationDataRequest authenticationDataRequest = new SysAuthenticationDataRequest();
                authenticationDataRequest.Content.Token = headerToken;

                SysAuthenticationDataResponse authenticationDataResponse = (SysAuthenticationDataResponse)InvokeService("Authenticate", authenticationDataRequest, context);

                if (authenticationDataResponse.Scope.StatusCode == LazyDecorator.GetCustomAttributeFromEnumValue(FwkScopeStatus.Success).Code)
                {
                    if (authenticationDataResponse.Content.IdDomain > -1 && authenticationDataResponse.Content.IdUser > -1)
                    {
                        context.Items["IdDomain"] = authenticationDataResponse.Content.IdDomain;
                        context.Items["IdUser"] = authenticationDataResponse.Content.IdUser;
                    }
                }
            }
            else
            {
                Int32 headerIdDomain = LazyConvert.ToInt32(LazyConvert.ToString(context.Request.Headers["IdDomain"], "-1"), -1);
                String headerCredential = LazyConvert.ToString(context.Request.Headers["Credential"], null);

                if (headerIdDomain > -1 && String.IsNullOrEmpty(headerCredential) == false)
                {
                    SysAuthenticationDataRequest authenticationDataRequest = new SysAuthenticationDataRequest();
                    authenticationDataRequest.Content.IdDomain = headerIdDomain;
                    authenticationDataRequest.Content.Credential = headerCredential;

                    SysAuthenticationDataResponse authenticationDataResponse = (SysAuthenticationDataResponse)InvokeService("Authenticate", authenticationDataRequest, context);

                    if (authenticationDataResponse.Scope.StatusCode == LazyDecorator.GetCustomAttributeFromEnumValue(FwkScopeStatus.Success).Code)
                    {
                        if (authenticationDataResponse.Content.IdDomain > -1 && authenticationDataResponse.Content.IdUser > -1)
                        {
                            context.Items["IdDomain"] = authenticationDataResponse.Content.IdDomain;
                            context.Items["IdUser"] = authenticationDataResponse.Content.IdUser;
                            context.Response.Headers["Token"] = authenticationDataResponse.Content.Token;
                        }
                    }
                }
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
