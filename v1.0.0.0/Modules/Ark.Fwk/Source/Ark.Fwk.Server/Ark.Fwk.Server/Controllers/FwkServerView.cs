// FwkServerView.cs
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
    public class FwkServerView : FwkServerBasic, IFwkServerView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServerView()
        {
            if (this.GetType() == typeof(FwkServerView))
            {
                this.DataRequestType = typeof(FwkDataViewRequest);
                this.DataResponseType = typeof(FwkDataViewResponse);
            }
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [Route("ValidateRead")]
        /// <summary>
        /// Validate read the view
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateRead([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateRead", dataRequestString);
        }

        [HttpPost]
        [Route("Read")]
        /// <summary>
        /// Read the view
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Read([FromBody] String dataRequestString)
        {
            return InvokeService("Read", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
