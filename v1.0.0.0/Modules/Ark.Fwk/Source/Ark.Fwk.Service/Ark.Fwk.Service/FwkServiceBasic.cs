// FwkServiceBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

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
//using Ark.Lib.Service;
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

        public FwkServiceBasic()
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
            #region Create response data

            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";
            String assemblyPath = LibDirectory.Root.Bin.Path + this.GetType().Namespace.Replace("Service", "Data") + ".dll";

            FwkDataBasicResponse dataBasicResponse = (FwkDataBasicResponse)LazyActivator.Local.CreateInstance(assemblyPath, classFullName);

            #endregion Create response data

            PerformLoad(dataBasicRequest, dataBasicResponse);

            return dataBasicResponse;
        }

        /// <summary>
        /// Load the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataBasicResponse Load(FwkDataBasicRequest dataBasicRequest)
        {
            #region Create response data

            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";
            String assemblyPath = LibDirectory.Root.Bin.Path + this.GetType().Namespace.Replace("Service", "Data") + ".dll";

            FwkDataBasicResponse dataBasicResponse = (FwkDataBasicResponse)LazyActivator.Local.CreateInstance(assemblyPath, classFullName);

            #endregion Create response data

            PerformLoad(dataBasicRequest, dataBasicResponse);

            return dataBasicResponse;
        }

        /// <summary>
        /// Perform service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected void PerformLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
            #region BeforeLoad

            if (this.iPluginList != null)
            {
                foreach (IFwkPluginBasic iPluginBasic in this.iPluginList)
                    iPluginBasic.BeforeLoadEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataBasicRequest));
            }

            #endregion BeforeLoad

            OnLoad(dataBasicRequest, dataBasicResponse);

            #region AfterLoad

            if (this.iPluginList != null)
            {
                foreach (IFwkPluginBasic iPluginBasic in this.iPluginList)
                    iPluginBasic.AfterLoadEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataBasicRequest, dataBasicResponse));
            }

            #endregion AfterLoad
        }

        /// <summary>
        /// Load the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected virtual void OnLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
            dataBasicResponse.Test = "Tested";
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
