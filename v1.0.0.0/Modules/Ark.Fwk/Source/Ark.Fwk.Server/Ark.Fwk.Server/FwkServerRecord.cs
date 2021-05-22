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
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        [Route("Format")]
        /// <summary>
        /// Format the record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Format([FromBody] String dataRequestString)
        {
            return InvokeService("Format", dataRequestString);
        }

        [HttpPost]
        [Route("ValidateRead")]
        /// <summary>
        /// Validate read the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateRead([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateRead", dataRequestString);
        }

        [HttpPut]
        [Route("ValidateInsert")]
        /// <summary>
        /// Validate insert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateInsert([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateInsert", dataRequestString);
        }

        [HttpPut]
        [Route("ValidateIndate")]
        /// <summary>
        /// Validate indate the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateIndate([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateIndate", dataRequestString);
        }

        [HttpPut]
        [Route("ValidateUpdate")]
        /// <summary>
        /// Validate update the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateUpdate([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateUpdate", dataRequestString);
        }

        [HttpPut]
        [Route("ValidateUpsert")]
        /// <summary>
        /// Validate upsert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateUpsert([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateUpsert", dataRequestString);
        }

        [HttpDelete]
        [Route("ValidateDelete")]
        /// <summary>
        /// Validate delete the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateDelete([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateDelete", dataRequestString);
        }

        [HttpPost]
        [Route("Read")]
        /// <summary>
        /// Read the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Read([FromBody] String dataRequestString)
        {
            return InvokeService("Read", dataRequestString);
        }

        [HttpPut]
        [Route("Insert")]
        /// <summary>
        /// Insert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Insert([FromBody] String dataRequestString)
        {
            return InvokeService("Insert", dataRequestString);
        }

        [HttpPut]
        [Route("Indate")]
        /// <summary>
        /// Indate the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Indate([FromBody] String dataRequestString)
        {
            return InvokeService("Indate", dataRequestString);
        }

        [HttpPut]
        [Route("Update")]
        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Update([FromBody] String dataRequestString)
        {
            return InvokeService("Update", dataRequestString);
        }

        [HttpPut]
        [Route("Upsert")]
        /// <summary>
        /// Upsert the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Upsert([FromBody] String dataRequestString)
        {
            return InvokeService("Upsert", dataRequestString);
        }

        [HttpDelete]
        [Route("Delete")]
        /// <summary>
        /// Delete the Record
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Delete([FromBody] String dataRequestString)
        {
            return InvokeService("Delete", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
