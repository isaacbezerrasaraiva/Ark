// SysAuthorizationServer.cs
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
    public class SysAuthorizationServer : FwkServer, ISysAuthorizationServer, ILibServerAuthorization
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationServer()
        {
            this.DataRequestType = typeof(SysAuthorizationDataRequest);
            this.DataResponseType = typeof(SysAuthorizationDataResponse);
        }

        #endregion Constructors

        #region Methods
        
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

                    SysAuthorizationDataRequest authorizationDataRequest = new SysAuthorizationDataRequest();
                    authorizationDataRequest.Content.IdDomain = idDomain;
                    authorizationDataRequest.Content.IdUser = idUser;
                    authorizationDataRequest.Content.CodModule = controllerPath[0];
                    authorizationDataRequest.Content.CodFeature = controllerPath[1];
                    authorizationDataRequest.Content.CodAction = controllerPath[2];

                    SysAuthorizationDataResponse authorizationDataResponse = (SysAuthorizationDataResponse)InvokeService("Authorize", authorizationDataRequest, context.HttpContext);

                    if (authorizationDataResponse.Content.Authorized == false)
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
