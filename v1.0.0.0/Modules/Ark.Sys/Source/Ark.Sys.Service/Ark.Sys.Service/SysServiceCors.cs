// SysServiceCors.cs
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

using Lazy;
//using Lazy.Database;
//using Lazy.Database.Db2;
//using Lazy.Database.MySql;
//using Lazy.Database.Oracle;
//using Lazy.Database.Postgre;
//using Lazy.Database.SqlServer;

using Ark.Lib;
using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;
using Ark.Fwk.Service;
//using Ark.Fts;
//using Ark.Fts.Data;
//using Ark.Fts.IPlugin;
//using Ark.Fts.IService;
//using Ark.Fts.Service;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IPlugin;
using Ark.Sys.IService;

namespace Ark.Sys.Service
{
    public class SysServiceCors : FwkService, ISysServiceCors
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServiceCors()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="dataCorsRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysDataCorsResponse Preflight(SysDataCorsRequest dataCorsRequest)
        {
            SysDataCorsResponse dataCorsResponse = new SysDataCorsResponse();

            PerformPreflight(dataCorsRequest, dataCorsResponse);

            return dataCorsResponse;
        }

        /// <summary>
        /// Perform service preflight
        /// </summary>
        /// <param name="dataCorsRequest">The request data</param>
        /// <param name="dataCorsResponse">The response data</param>
        protected void PerformPreflight(SysDataCorsRequest dataCorsRequest, SysDataCorsResponse dataCorsResponse)
        {
            #region BeforePreflight

            if (this.iPluginList != null)
            {
                foreach (ISysPluginCors iPluginCors in this.iPluginList)
                    iPluginCors.BeforePreflightEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataCorsRequest));
            }

            #endregion BeforePreflight

            OnPreflight(dataCorsRequest, dataCorsResponse);

            #region AfterPreflight

            if (this.iPluginList != null)
            {
                foreach (ISysPluginCors iPluginCors in this.iPluginList)
                    iPluginCors.AfterPreflightEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataCorsRequest, dataCorsResponse));
            }

            #endregion AfterPreflight
        }

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="dataCorsRequest">The request data</param>
        /// <param name="dataCorsResponse">The response data</param>
        protected virtual void OnPreflight(SysDataCorsRequest dataCorsRequest, SysDataCorsResponse dataCorsResponse)
        {
            dataCorsResponse.PreflightResponse = new SysPreflightResponse();

            LibDynamicXmlElement dynamicXmlElementCors = LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["Cors"]["PreflightResponse"]["Headers"];
            
            foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementCorsHeader in dynamicXmlElementCors.Elements)
            {
                dataCorsResponse.PreflightResponse.Headers.Add(
                    dynamicXmlElementCorsHeader.Value.Attribute["HeaderKey"], dynamicXmlElementCorsHeader.Value.Attribute["HeaderValue"]);
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
