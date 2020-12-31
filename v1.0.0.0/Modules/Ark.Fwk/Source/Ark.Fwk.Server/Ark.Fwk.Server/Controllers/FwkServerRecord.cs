// FwkServerRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

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
    public class FwkServerRecord : FwkServerBasic, IFwkServerRecord
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServerRecord()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Read the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpGet]
        [Route("Read/{dataRequestString}")]
        public String Read(String dataRequestString)
        {
            return InvokeService("Read", dataRequestString);
        }

        /// <summary>
        /// Insert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPost]
        [Route("Insert/{dataRequestString}")]
        public String Insert(String dataRequestString)
        {
            return InvokeService("Insert", dataRequestString);
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPut]
        [Route("Update/{dataRequestString}")]
        public String Update(String dataRequestString)
        {
            return InvokeService("Update", dataRequestString);
        }

        /// <summary>
        /// Upsert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPost][HttpPut]
        [Route("Upsert/{dataRequestString}")]
        public String Upsert(String dataRequestString)
        {
            return InvokeService("Upsert", dataRequestString);
        }

        /// <summary>
        /// Delete the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpDelete]
        [Route("Delete/{dataRequestString}")]
        public String Delete(String dataRequestString)
        {
            return InvokeService("Delete", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
