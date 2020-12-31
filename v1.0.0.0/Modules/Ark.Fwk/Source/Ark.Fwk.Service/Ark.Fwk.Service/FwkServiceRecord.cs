// FwkServiceRecord.cs
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
    public class FwkServiceRecord : FwkServiceBasic, IFwkServiceRecord
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServiceRecord()
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

            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"), 
                classFullName);

            #endregion Create response data

            FwkDataRecordRequest dataRecordRequest = (FwkDataRecordRequest)dataBasicRequest;
            
            PerformLoad(dataRecordRequest, dataRecordResponse);
            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformRead(dataRecordRequest, dataRecordResponse);
            
            return dataRecordResponse;
        }

        /// <summary>
        /// Format the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Format(FwkDataRecordRequest dataRecordRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformFormat(dataRecordRequest, dataRecordResponse);

            return dataRecordResponse;
        }

        /// <summary>
        /// Read the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Read(FwkDataRecordRequest dataRecordRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformRead(dataRecordRequest, dataRecordResponse);

            return dataRecordResponse;
        }

        /// <summary>
        /// Insert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Insert(FwkDataRecordRequest dataRecordRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformInsert(dataRecordRequest, dataRecordResponse);

            return dataRecordResponse;
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Update(FwkDataRecordRequest dataRecordRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformUpdate(dataRecordRequest, dataRecordResponse);

            return dataRecordResponse;
        }

        /// <summary>
        /// Upsert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Upsert(FwkDataRecordRequest dataRecordRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformUpsert(dataRecordRequest, dataRecordResponse);

            return dataRecordResponse;
        }

        /// <summary>
        /// Delete the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Delete(FwkDataRecordRequest dataRecordRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            PerformDelete(dataRecordRequest, dataRecordResponse);

            return dataRecordResponse;
        }

        /// <summary>
        /// Perform format Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformFormat(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            #region BeforeFormat

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.BeforeFormatEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataRecordRequest));
            }

            #endregion BeforeFormat

            OnFormat(dataRecordRequest, dataRecordResponse);

            #region AfterFormat

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.AfterFormatEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion AfterFormat
        }

        /// <summary>
        /// Perform read Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            #region BeforeRead

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.BeforeReadEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataRecordRequest));
            }

            #endregion BeforeRead

            OnRead(dataRecordRequest, dataRecordResponse);

            #region AfterRead

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.AfterReadEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion AfterRead
        }

        /// <summary>
        /// Perform insert Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            #region BeforeInsert

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.BeforeInsertEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataRecordRequest));
            }

            #endregion BeforeInsert

            OnInsert(dataRecordRequest, dataRecordResponse);

            #region AfterInsert

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.AfterInsertEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion AfterInsert
        }

        /// <summary>
        /// Perform update Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            #region BeforeUpdate

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.BeforeUpdateEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataRecordRequest));
            }

            #endregion BeforeUpdate

            OnUpdate(dataRecordRequest, dataRecordResponse);

            #region AfterUpdate

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.AfterUpdateEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion AfterUpdate
        }

        /// <summary>
        /// Perform upsert Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            #region BeforeUpsert

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.BeforeUpsertEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataRecordRequest));
            }

            #endregion BeforeUpsert

            OnUpsert(dataRecordRequest, dataRecordResponse);

            #region AfterUpsert

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.AfterUpsertEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion AfterUpsert
        }

        /// <summary>
        /// Perform delete Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            #region BeforeDelete

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.BeforeDeleteEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(dataRecordRequest));
            }

            #endregion BeforeDelete

            OnDelete(dataRecordRequest, dataRecordResponse);

            #region AfterDelete

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.AfterDeleteEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion AfterDelete
        }

        /// <summary>
        /// Format the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnFormat(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Read the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Insert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Upsert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Delete the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
