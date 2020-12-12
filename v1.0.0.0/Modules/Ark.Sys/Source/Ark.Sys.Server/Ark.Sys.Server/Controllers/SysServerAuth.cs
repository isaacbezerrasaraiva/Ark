// SysServerAuth.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

using Lazy;

using Ark.Lib;
using Ark.Lib.Server;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IServer;
using Ark.Fwk.IService;
using Ark.Fwk.Server;
using Ark.Fts;
//using Ark.Fts.Data;
//using Ark.Fts.IServer;
//using Ark.Fts.IService;
using Ark.Fts.Server;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IServer;
using Ark.Sys.IService;

namespace Ark.Sys.Server
{
    [ApiController]
    [Route("[controller]")]
    public class SysServerAuth : FwkServer, ISysServerAuth, ILibServerAuthentication, ILibServerAuthorization
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServerAuth()
        {
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
                SysDataAuthRequest dataAuthRequest = new SysDataAuthRequest();
                dataAuthRequest.AuthenticationRequest = new SysAuthenticationRequest();
                dataAuthRequest.AuthenticationRequest.Token = headerToken;

                SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authenticate", dataAuthRequest);

                if (dataAuthResponse.AuthenticationResponse.IdDomain > -1 && dataAuthResponse.AuthenticationResponse.IdUser > -1)
                {
                    context.Items["IdDomain"] = dataAuthResponse.AuthenticationResponse.IdDomain;
                    context.Items["IdUser"] = dataAuthResponse.AuthenticationResponse.IdUser;
                }
            }
            else
            {
                Int32 headerIdDomain = LazyConvert.ToInt32(LazyConvert.ToString(context.Request.Headers["IdDomain"], "-1"));
                String headerCredential = LazyConvert.ToString(context.Request.Headers["Credential"], null);

                if (headerIdDomain > -1 && String.IsNullOrEmpty(headerCredential) == false)
                {
                    SysDataAuthRequest dataAuthRequest = new SysDataAuthRequest();
                    dataAuthRequest.AuthenticationRequest = new SysAuthenticationRequest();
                    dataAuthRequest.AuthenticationRequest.IdDomain = headerIdDomain;
                    dataAuthRequest.AuthenticationRequest.Credential = headerCredential;

                    SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authenticate", dataAuthRequest);

                    if (dataAuthResponse.AuthenticationResponse.IdDomain > -1 && dataAuthResponse.AuthenticationResponse.IdUser > -1)
                    {
                        context.Items["IdDomain"] = dataAuthResponse.AuthenticationResponse.IdDomain;
                        context.Items["IdUser"] = dataAuthResponse.AuthenticationResponse.IdUser;
                        context.Response.Headers["Token"] = dataAuthResponse.AuthenticationResponse.Token;
                    }
                }
            }
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="context">The request context</param>
        public void Authorize(AuthorizationFilterContext context)
        {
            Int32 IdDomain = LazyConvert.ToInt32(context.HttpContext.Items["IdDomain"], -1);
            Int32 IdUser = LazyConvert.ToInt32(context.HttpContext.Items["IdUser"], -1);

            if (IdDomain > -1 && IdUser > -1)
            {
                SysDataAuthRequest dataAuthRequest = new SysDataAuthRequest();
                SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authorize", dataAuthRequest);
            }
            else
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
