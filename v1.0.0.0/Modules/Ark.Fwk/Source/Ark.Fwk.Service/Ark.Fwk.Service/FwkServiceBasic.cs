// FwkServiceBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.IO;
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

namespace Ark.Fwk.Service
{
    public class FwkServiceBasic : FwkService, IFwkServiceBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServiceBasic(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public virtual FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            FwkDataBasicResponse dataBasicResponse = (FwkDataBasicResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformLoad(dataBasicRequest, dataBasicResponse);

            this.Database.CloseConnection();

            return dataBasicResponse;
        }
        
        /// <summary>
        /// Load the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataBasicResponse Load(FwkDataBasicRequest dataBasicRequest)
        {
            FwkDataBasicResponse dataBasicResponse = (FwkDataBasicResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformLoad(dataBasicRequest, dataBasicResponse);

            this.Database.CloseConnection();

            return dataBasicResponse;
        }

        /// <summary>
        /// Perform service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected void PerformLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
            BeforePerformLoad(dataBasicRequest, dataBasicResponse);

            #region Before OnLoad plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginBasic iPluginBasic in this.IPlugins)
                    iPluginBasic.LoadPluginBasicBeforeEventHandler?.Invoke(this, new FwkPluginBasicBeforeEventArgs(dataBasicRequest, dataBasicResponse));
            }

            #endregion Before OnLoad plugins

            OnLoad(dataBasicRequest, dataBasicResponse);

            #region After OnLoad plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginBasic iPluginBasic in this.IPlugins)
                    iPluginBasic.LoadPluginBasicAfterEventHandler?.Invoke(this, new FwkPluginBasicAfterEventArgs(dataBasicRequest, dataBasicResponse));
            }

            #endregion After OnLoad plugins

            AfterPerformLoad(dataBasicRequest, dataBasicResponse);
        }

        /// <summary>
        /// On service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected virtual void OnLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
        }

        /// <summary>
        /// Before perform service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        private void BeforePerformLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
        }

        /// <summary>
        /// After perform service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        private void AfterPerformLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
