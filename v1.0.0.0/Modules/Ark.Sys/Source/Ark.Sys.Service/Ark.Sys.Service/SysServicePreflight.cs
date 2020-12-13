// SysServicePreflight.cs
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
    public class SysServicePreflight : FwkService, ISysServicePreflight
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServicePreflight()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="dataPreflightRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysDataPreflightResponse Preflight(SysDataPreflightRequest dataPreflightRequest)
        {
            SysDataPreflightResponse dataPreflightResponse = new SysDataPreflightResponse();

            PerformPreflight(dataPreflightRequest, dataPreflightResponse);

            return dataPreflightResponse;
        }

        /// <summary>
        /// Perform service preflight
        /// </summary>
        /// <param name="dataPreflightRequest">The request data</param>
        /// <param name="dataPreflightResponse">The response data</param>
        protected void PerformPreflight(SysDataPreflightRequest dataPreflightRequest, SysDataPreflightResponse dataPreflightResponse)
        {
            #region BeforePreflight

            if (this.PluginList != null)
            {
                foreach (ISysPluginPreflight iPluginPreflight in this.PluginList)
                    iPluginPreflight.BeforePreflightEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataPreflightRequest));
            }

            #endregion BeforePreflight

            OnPreflight(dataPreflightRequest, dataPreflightResponse);

            #region AfterPreflight

            if (this.PluginList != null)
            {
                foreach (ISysPluginPreflight iPluginPreflight in this.PluginList)
                    iPluginPreflight.AfterPreflightEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataPreflightRequest, dataPreflightResponse));
            }

            #endregion AfterPreflight
        }

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="dataPreflightRequest">The request data</param>
        /// <param name="dataPreflightResponse">The response data</param>
        protected virtual void OnPreflight(SysDataPreflightRequest dataPreflightRequest, SysDataPreflightResponse dataPreflightResponse)
        {
            LibDynamicXmlElement dynamicXmlElementPreflight = LibServiceConfiguration.DynamicXml["Ark.Sys.Service"]["Security"]["Preflight"]["Response"]["Headers"];

            foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementPreflightHeader in dynamicXmlElementPreflight.Elements)
            {
                dataPreflightResponse.Headers.Add(
                    dynamicXmlElementPreflightHeader.Value.Attribute["HeaderKey"],
                    dynamicXmlElementPreflightHeader.Value.Attribute["HeaderValue"]);
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
