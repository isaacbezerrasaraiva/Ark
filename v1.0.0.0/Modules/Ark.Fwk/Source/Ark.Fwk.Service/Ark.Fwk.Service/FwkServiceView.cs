// FwkServiceView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

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
    public class FwkServiceView : FwkServiceBasic, IFwkServiceView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServiceView()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public override FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataViewResponse dataViewResponse = (FwkDataViewResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data
            
            FwkDataViewRequest dataViewRequest = (FwkDataViewRequest)dataBasicRequest;
            
            PerformLoad(dataViewRequest, dataViewResponse);
            PerformFormat(dataViewRequest, dataViewResponse);
            PerformRead(dataViewRequest, dataViewResponse);
            
            return dataViewResponse;
        }

        /// <summary>
        /// Format the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Format(FwkDataViewRequest dataViewRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataViewResponse dataViewResponse = (FwkDataViewResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformFormat(dataViewRequest, dataViewResponse);

            return dataViewResponse;
        }

        /// <summary>
        /// Read the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Read(FwkDataViewRequest dataViewRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataViewResponse dataViewResponse = (FwkDataViewResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformRead(dataViewRequest, dataViewResponse);

            return dataViewResponse;
        }

        /// <summary>
        /// Perform format view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected void PerformFormat(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
            #region BeforeFormat

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.BeforeFormatEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataViewRequest));
            }

            #endregion BeforeFormat

            OnFormat(dataViewRequest, dataViewResponse);

            #region AfterFormat

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.AfterFormatEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion AfterFormat
        }

        /// <summary>
        /// Perform read view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected void PerformRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
            #region BeforeRead

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.BeforeReadEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataViewRequest));
            }

            #endregion BeforeRead

            OnRead(dataViewRequest, dataViewResponse);

            #region AfterRead

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.AfterReadEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion AfterRead
        }

        /// <summary>
        /// Format the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected virtual void OnFormat(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// Read the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected virtual void OnRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
