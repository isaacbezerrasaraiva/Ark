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
    [Route("Ark.Sys/[controller]")]
    public class SysServerAuth : FwkServer, ISysServerAuth, ILibServerAuthentication, ILibServerAuthorization
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServerAuth()
        {
            this.DataRequestType = typeof(SysDataAuthRequest);
            this.DataResponseType = typeof(SysDataAuthResponse);
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
                dataAuthRequest.Content.AuthenticationRequest = new SysAuthenticationRequest();
                dataAuthRequest.Content.AuthenticationRequest.Token = headerToken;

                SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authenticate", dataAuthRequest, context);

                if (dataAuthResponse.Content.AuthenticationResponse.IdDomain > -1 && dataAuthResponse.Content.AuthenticationResponse.IdUser > -1)
                {
                    context.Items["IdDomain"] = dataAuthResponse.Content.AuthenticationResponse.IdDomain;
                    context.Items["IdUser"] = dataAuthResponse.Content.AuthenticationResponse.IdUser;
                }
            }
            else
            {
                Int32 headerIdDomain = LazyConvert.ToInt32(LazyConvert.ToString(context.Request.Headers["IdDomain"], "-1"), -1);
                String headerCredential = LazyConvert.ToString(context.Request.Headers["Credential"], null);

                if (headerIdDomain > -1 && String.IsNullOrEmpty(headerCredential) == false)
                {
                    SysDataAuthRequest dataAuthRequest = new SysDataAuthRequest();
                    dataAuthRequest.Content.AuthenticationRequest = new SysAuthenticationRequest();
                    dataAuthRequest.Content.AuthenticationRequest.IdDomain = headerIdDomain;
                    dataAuthRequest.Content.AuthenticationRequest.Credential = headerCredential;

                    SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authenticate", dataAuthRequest, context);

                    if (dataAuthResponse.Content.AuthenticationResponse.IdDomain > -1 && dataAuthResponse.Content.AuthenticationResponse.IdUser > -1)
                    {
                        context.Items["IdDomain"] = dataAuthResponse.Content.AuthenticationResponse.IdDomain;
                        context.Items["IdUser"] = dataAuthResponse.Content.AuthenticationResponse.IdUser;
                        context.Response.Headers["Token"] = dataAuthResponse.Content.AuthenticationResponse.Token;
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
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().ToList().Count == 0)
            {
                Int32 idDomain = LazyConvert.ToInt32(context.HttpContext.Items["IdDomain"], -1);
                Int32 idUser = LazyConvert.ToInt32(context.HttpContext.Items["IdUser"], -1);

                if (idDomain > -1 && idUser > -1)
                {
                    String[] controllerPath = context.HttpContext.Request.Path.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);

                    SysDataAuthRequest dataAuthRequest = new SysDataAuthRequest();
                    dataAuthRequest.Content.AuthorizationRequest = new SysAuthorizationRequest();
                    dataAuthRequest.Content.AuthorizationRequest.IdDomain = idDomain;
                    dataAuthRequest.Content.AuthorizationRequest.IdUser = idUser;
                    dataAuthRequest.Content.AuthorizationRequest.CodModule = controllerPath[0];
                    dataAuthRequest.Content.AuthorizationRequest.CodFeature = controllerPath[1];
                    dataAuthRequest.Content.AuthorizationRequest.CodAction = controllerPath[2];

                    SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authorize", dataAuthRequest, context.HttpContext);

                    if (dataAuthResponse.Content.AuthorizationResponse.Authorized == false)
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    }
                }
                else
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
