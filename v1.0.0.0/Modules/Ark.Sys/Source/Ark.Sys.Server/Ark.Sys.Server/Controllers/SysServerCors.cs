// SysServerCors.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

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
    public class SysServerCors : FwkServer, ISysServerCors, ILibServerCors
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServerCors()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="context">The request context</param>
        public void Preflight(HttpContext context)
        {
            SysDataCorsRequest dataCorsRequest = new SysDataCorsRequest();

            SysDataCorsResponse dataCorsResponse = (SysDataCorsResponse)InvokeService("Preflight", dataCorsRequest);

            foreach (KeyValuePair<String, String> header in dataCorsResponse.PreflightResponse.Headers)
                context.Response.Headers.Add(header.Key, header.Value);

            context.Response.StatusCode = StatusCodes.Status200OK;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
