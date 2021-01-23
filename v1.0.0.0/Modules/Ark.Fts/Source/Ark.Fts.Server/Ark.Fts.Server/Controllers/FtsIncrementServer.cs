// FtsIncrementServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

using System;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;

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

namespace Ark.Fts.Server
{
    [ApiController]
    [Route("Ark.Fts/[controller]")]
    public class FtsIncrementServer : FwkServer, IFtsIncrementServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementServer()
        {
            this.DataRequestType = typeof(FtsIncrementDataRequest);
            this.DataResponseType = typeof(FtsIncrementDataResponse);
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [Route("ValidateNext")]
        /// <summary>
        /// Validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequestString">The increment request data string</param>
        /// <returns>The increment response data string</returns>
        public String ValidateNext([FromBody] String incrementDataRequestString)
        {
            return InvokeService("ValidateNext", incrementDataRequestString);
        }

        [HttpPost]
        [Route("Next")]
        /// <summary>
        /// Generate next ids
        /// </summary>
        /// <param name="incrementDataRequestString">The increment request data string</param>
        /// <returns>The increment response data string</returns>
        public String Next([FromBody] String incrementDataRequestString)
        {
            return InvokeService("Next", incrementDataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
