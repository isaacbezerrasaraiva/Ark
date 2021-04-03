// SysLoginServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
    public class SysLoginServer : FwkServer, ISysLoginServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginServer()
        {
            this.DataRequestType = typeof(SysLoginDataRequest);
            this.DataResponseType = typeof(SysLoginDataResponse);
        }

        #endregion Constructors

        #region Methods
        
        [HttpPost]
        [AllowAnonymous()]
        [Route("Authenticate")]
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="loginDataRequestString">The login request data string</param>
        /// <returns>The login response data string</returns>
        public String Authenticate([FromBody] String loginDataRequestString)
        {
            return InvokeService("Authenticate", loginDataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
