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
            Object validationInfo = context.Request.Headers["Token"];

            if (String.IsNullOrEmpty(validationInfo.ToString()) == false)
            {
                SysDataAuthRequest dataAuthRequest = new SysDataAuthRequest();
                dataAuthRequest.AuthenticationRequest = new SysAuthenticationRequest();
                dataAuthRequest.AuthenticationRequest.Token = validationInfo.ToString();

                SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authenticate", dataAuthRequest);

                if (dataAuthResponse.AuthenticationResponse.User != null)
                    context.Items["User"] = dataAuthResponse.AuthenticationResponse.User;
            }
            else
            {
                validationInfo = context.Request.Headers["Credential"];

                if (String.IsNullOrEmpty(validationInfo.ToString()) == false)
                {
                    SysDataAuthRequest dataAuthRequest = new SysDataAuthRequest();
                    dataAuthRequest.AuthenticationRequest = new SysAuthenticationRequest();
                    dataAuthRequest.AuthenticationRequest.Credential = validationInfo.ToString();

                    SysDataAuthResponse dataAuthResponse = (SysDataAuthResponse)InvokeService("Authenticate", dataAuthRequest);

                    if (dataAuthResponse.AuthenticationResponse.User != null)
                    {
                        context.Items["User"] = dataAuthResponse.AuthenticationResponse.User;
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
            Object user = context.HttpContext.Items["User"];

            if (user != null)
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
