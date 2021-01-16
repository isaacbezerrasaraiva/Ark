// SysAuthServer.cs
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
    [ApiController]
    [Route("Ark.Sys/[controller]")]
    public class SysAuthServer : FwkServer, ISysAuthServer, ILibServerAuthentication, ILibServerAuthorization
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthServer()
        {
            this.DataRequestType = typeof(SysAuthDataRequest);
            this.DataResponseType = typeof(SysAuthDataResponse);
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
                SysAuthDataRequest authDataRequest = new SysAuthDataRequest();
                authDataRequest.Content.AuthenticationRequest = new SysAuthenticationRequest();
                authDataRequest.Content.AuthenticationRequest.Token = headerToken;

                SysAuthDataResponse authDataResponse = (SysAuthDataResponse)InvokeService("Authenticate", authDataRequest, context);

                if (authDataResponse.Content.AuthenticationResponse.IdDomain > -1 && authDataResponse.Content.AuthenticationResponse.IdUser > -1)
                {
                    context.Items["IdDomain"] = authDataResponse.Content.AuthenticationResponse.IdDomain;
                    context.Items["IdUser"] = authDataResponse.Content.AuthenticationResponse.IdUser;
                }
            }
            else
            {
                Int32 headerIdDomain = LazyConvert.ToInt32(LazyConvert.ToString(context.Request.Headers["IdDomain"], "-1"), -1);
                String headerCredential = LazyConvert.ToString(context.Request.Headers["Credential"], null);

                if (headerIdDomain > -1 && String.IsNullOrEmpty(headerCredential) == false)
                {
                    SysAuthDataRequest authDataRequest = new SysAuthDataRequest();
                    authDataRequest.Content.AuthenticationRequest = new SysAuthenticationRequest();
                    authDataRequest.Content.AuthenticationRequest.IdDomain = headerIdDomain;
                    authDataRequest.Content.AuthenticationRequest.Credential = headerCredential;

                    SysAuthDataResponse authDataResponse = (SysAuthDataResponse)InvokeService("Authenticate", authDataRequest, context);

                    if (authDataResponse.Content.AuthenticationResponse.IdDomain > -1 && authDataResponse.Content.AuthenticationResponse.IdUser > -1)
                    {
                        context.Items["IdDomain"] = authDataResponse.Content.AuthenticationResponse.IdDomain;
                        context.Items["IdUser"] = authDataResponse.Content.AuthenticationResponse.IdUser;
                        context.Response.Headers["Token"] = authDataResponse.Content.AuthenticationResponse.Token;
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

                    SysAuthDataRequest authDataRequest = new SysAuthDataRequest();
                    authDataRequest.Content.AuthorizationRequest = new SysAuthorizationRequest();
                    authDataRequest.Content.AuthorizationRequest.IdDomain = idDomain;
                    authDataRequest.Content.AuthorizationRequest.IdUser = idUser;
                    authDataRequest.Content.AuthorizationRequest.CodModule = controllerPath[0];
                    authDataRequest.Content.AuthorizationRequest.CodFeature = controllerPath[1];
                    authDataRequest.Content.AuthorizationRequest.CodAction = controllerPath[2];

                    SysAuthDataResponse authDataResponse = (SysAuthDataResponse)InvokeService("Authorize", authDataRequest, context.HttpContext);

                    if (authDataResponse.Content.AuthorizationResponse.Authorized == false)
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
