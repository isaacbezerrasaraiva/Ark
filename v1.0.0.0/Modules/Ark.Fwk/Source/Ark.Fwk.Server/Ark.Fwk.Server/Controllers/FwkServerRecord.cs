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
            if (this.GetType() == typeof(FwkServerRecord))
            {
                this.DataRequestType = typeof(FwkDataRecordRequest);
                this.DataResponseType = typeof(FwkDataRecordResponse);
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Read the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPost]
        [Route("Read")]
        public String Read([FromBody] String dataRequestString)
        {
            return InvokeService("Read", dataRequestString);
        }

        /// <summary>
        /// Insert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPut]
        [Route("Insert")]
        public String Insert([FromBody] String dataRequestString)
        {
            return InvokeService("Insert", dataRequestString);
        }

        /// <summary>
        /// Indate the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPut]
        [Route("Indate")]
        public String Indate([FromBody] String dataRequestString)
        {
            return InvokeService("Indate", dataRequestString);
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPut]
        [Route("Update")]
        public String Update([FromBody] String dataRequestString)
        {
            return InvokeService("Update", dataRequestString);
        }

        /// <summary>
        /// Upsert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpPut]
        [Route("Upsert")]
        public String Upsert([FromBody] String dataRequestString)
        {
            return InvokeService("Upsert", dataRequestString);
        }

        /// <summary>
        /// Delete the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        [HttpDelete]
        [Route("Delete")]
        public String Delete([FromBody] String dataRequestString)
        {
            return InvokeService("Delete", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
