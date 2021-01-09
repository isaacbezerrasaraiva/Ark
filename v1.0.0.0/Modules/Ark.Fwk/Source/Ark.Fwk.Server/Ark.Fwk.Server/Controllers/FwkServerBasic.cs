// FwkServerBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

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
    public class FwkServerBasic : FwkServer, IFwkServerBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServerBasic()
        {
            if (this.GetType() == typeof(FwkServerBasic))
            {
                this.DataRequestType = typeof(FwkDataBasicRequest);
                this.DataResponseType = typeof(FwkDataBasicResponse);
            }
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPost]
        [Route("Init")]
        public String Init([FromBody] String dataRequestString)
        {
            return InvokeService("Init", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
