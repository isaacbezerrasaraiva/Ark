// FwkServerProcess.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 15

using System;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Lazy;

using Ark.Lib;
using Ark.Lib.Server;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IServer;
using Ark.Fwk.IService;

namespace Ark.Fwk.Server
{
    [ApiController]
    [Route("Ark.Fwk/[controller]")]
    public class FwkServerProcess : FwkServerBasic, IFwkServerProcess
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServerProcess()
        {
            if (this.GetType() == typeof(FwkServerProcess))
            {
                this.DataRequestType = typeof(FwkDataProcessRequest);
                this.DataResponseType = typeof(FwkDataProcessResponse);
            }
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [Route("Next")]
        /// <summary>
        /// Next process step data
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Next([FromBody] String dataRequestString)
        {
            return InvokeService("Next", dataRequestString);
        }

        [HttpPost]
        [Route("Execute")]
        /// <summary>
        /// Execute the process
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Execute([FromBody] String dataRequestString)
        {
            return InvokeService("Execute", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
