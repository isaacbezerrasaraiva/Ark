// SysPreflightService.cs
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
using Lazy.Database;

using Ark.Lib;
using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;
using Ark.Fwk.Service;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IPlugin;
using Ark.Fts.IService;
using Ark.Fts.Service;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IPlugin;
using Ark.Sys.IService;

namespace Ark.Sys.Service
{
    public class SysPreflightService : FwkService, ISysPreflightService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysPreflightService(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysPreflightDataResponse Preflight(SysPreflightDataRequest preflightDataRequest)
        {
            SysPreflightDataResponse preflightDataResponse = new SysPreflightDataResponse();

            // this.Database.OpenConnection(); // Must remove this because in this service the inherit database object will always be null

            PerformPreflight(preflightDataRequest, preflightDataResponse);

            // this.Database.CloseConnection(); // Must remove this because in this service the inherit database object will always be null

            return preflightDataResponse;
        }

        /// <summary>
        /// Perform service preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <param name="preflightDataResponse">The response data</param>
        protected void PerformPreflight(SysPreflightDataRequest preflightDataRequest, SysPreflightDataResponse preflightDataResponse)
        {
            #region BeforePreflight

            if (this.IPlugins != null)
            {
                foreach (ISysPreflightPlugin iPreflightPlugin in this.IPlugins)
                    iPreflightPlugin.PreflightPluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(preflightDataRequest, preflightDataResponse));
            }

            #endregion BeforePreflight

            OnPreflight(preflightDataRequest, preflightDataResponse);

            #region AfterPreflight

            if (this.IPlugins != null)
            {
                foreach (ISysPreflightPlugin iPreflightPlugin in this.IPlugins)
                    iPreflightPlugin.PreflightPluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(preflightDataRequest, preflightDataResponse));
            }

            #endregion AfterPreflight
        }

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <param name="preflightDataResponse">The response data</param>
        protected virtual void OnPreflight(SysPreflightDataRequest preflightDataRequest, SysPreflightDataResponse preflightDataResponse)
        {
            LibDynamicXmlElement dynamicXmlElementPreflight = LibConfigurationService.DynamicXml["Ark.Sys"]["Security"]["Preflight"]["Response"]["Headers"];

            foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementPreflightHeader in dynamicXmlElementPreflight.Elements)
            {
                preflightDataResponse.Content.HttpResponseHeaders.Add(
                    dynamicXmlElementPreflightHeader.Value.Attribute["HeaderKey"],
                    dynamicXmlElementPreflightHeader.Value.Attribute["HeaderValue"]);
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
