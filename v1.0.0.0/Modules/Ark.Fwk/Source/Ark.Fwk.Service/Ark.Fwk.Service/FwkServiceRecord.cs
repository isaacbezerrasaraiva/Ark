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

        public FwkServiceRecord(FwkEnvironment environment)
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
        public override FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            FwkDataRecordRequest dataRecordRequest = (FwkDataRecordRequest)dataBasicRequest;
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformLoad(dataRecordRequest, dataRecordResponse);
            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateRead(dataRecordRequest, dataRecordResponse);
            PerformRead(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Format the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Format(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Validate read the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateRead(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateRead(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Validate insert the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateInsert(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateInsert(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Validate indate the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateIndate(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateIndate(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Validate update the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateUpdate(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateUpdate(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Validate upsert the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateUpsert(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateUpsert(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Validate delete the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateDelete(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateDelete(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Read the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Read(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateRead(dataRecordRequest, dataRecordResponse);
            PerformRead(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Insert the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Insert(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateInsert(dataRecordRequest, dataRecordResponse);
            PerformInsert(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Indate the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Indate(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateIndate(dataRecordRequest, dataRecordResponse);
            PerformIndate(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Update the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Update(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateUpdate(dataRecordRequest, dataRecordResponse);
            PerformUpdate(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Upsert the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Upsert(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateUpsert(dataRecordRequest, dataRecordResponse);
            PerformUpsert(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Delete the service
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Delete(FwkDataRecordRequest dataRecordRequest)
        {
            FwkDataRecordResponse dataRecordResponse = (FwkDataRecordResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataRecordRequest, dataRecordResponse);
            PerformValidateDelete(dataRecordRequest, dataRecordResponse);
            PerformDelete(dataRecordRequest, dataRecordResponse);

            this.Database.CloseConnection();

            return dataRecordResponse;
        }

        /// <summary>
        /// Perform service format
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformFormat(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformFormat(dataRecordRequest, dataRecordResponse);

            #region Before OnFormat plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.FormatPluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnFormat plugins

            OnFormat(dataRecordRequest, dataRecordResponse);

            #region After OnFormat plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.FormatPluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnFormat plugins

            AfterPerformFormat(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service validate read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformValidateRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformValidateRead(dataRecordRequest, dataRecordResponse);

            #region Before OnValidateRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateReadPluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnValidateRead plugins

            OnValidateRead(dataRecordRequest, dataRecordResponse);

            #region After OnValidateRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateReadPluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnValidateRead plugins

            AfterPerformValidateRead(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service validate insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformValidateInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformValidateInsert(dataRecordRequest, dataRecordResponse);

            #region Before OnValidateInsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateInsertPluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnValidateInsert plugins

            OnValidateInsert(dataRecordRequest, dataRecordResponse);

            #region After OnValidateInsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateInsertPluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnValidateInsert plugins

            AfterPerformValidateInsert(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service validate indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformValidateIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformValidateIndate(dataRecordRequest, dataRecordResponse);

            #region Before OnValidateIndate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateIndatePluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnValidateIndate plugins

            OnValidateIndate(dataRecordRequest, dataRecordResponse);

            #region After OnValidateIndate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateIndatePluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnValidateIndate plugins

            AfterPerformValidateIndate(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service validate update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformValidateUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformValidateUpdate(dataRecordRequest, dataRecordResponse);

            #region Before OnValidateUpdate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateUpdatePluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnValidateUpdate plugins

            OnValidateUpdate(dataRecordRequest, dataRecordResponse);

            #region After OnValidateUpdate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateUpdatePluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnValidateUpdate plugins

            AfterPerformValidateUpdate(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service validate upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformValidateUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformValidateUpsert(dataRecordRequest, dataRecordResponse);

            #region Before OnValidateUpsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateUpsertPluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnValidateUpsert plugins

            OnValidateUpsert(dataRecordRequest, dataRecordResponse);

            #region After OnValidateUpsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateUpsertPluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnValidateUpsert plugins

            AfterPerformValidateUpsert(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service validate delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformValidateDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformValidateDelete(dataRecordRequest, dataRecordResponse);

            #region Before OnValidateDelete plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateDeletePluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnValidateDelete plugins

            OnValidateDelete(dataRecordRequest, dataRecordResponse);

            #region After OnValidateDelete plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ValidateDeletePluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnValidateDelete plugins

            AfterPerformValidateDelete(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformRead(dataRecordRequest, dataRecordResponse);

            #region Before OnRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ReadPluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnRead plugins

            OnRead(dataRecordRequest, dataRecordResponse);

            #region After OnRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.ReadPluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnRead plugins

            AfterPerformRead(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformInsert(dataRecordRequest, dataRecordResponse);

            #region Before OnInsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.InsertPluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnInsert plugins

            OnInsert(dataRecordRequest, dataRecordResponse);

            #region After OnInsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.InsertPluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnInsert plugins

            AfterPerformInsert(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformIndate(dataRecordRequest, dataRecordResponse);

            #region Before OnIndate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.IndatePluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnIndate plugins

            OnIndate(dataRecordRequest, dataRecordResponse);

            #region After OnIndate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.IndatePluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnIndate plugins

            AfterPerformIndate(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformUpdate(dataRecordRequest, dataRecordResponse);

            #region Before OnUpdate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.UpdatePluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnUpdate plugins

            OnUpdate(dataRecordRequest, dataRecordResponse);

            #region After OnUpdate plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.UpdatePluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnUpdate plugins

            AfterPerformUpdate(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformUpsert(dataRecordRequest, dataRecordResponse);

            #region Before OnUpsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.UpsertPluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnUpsert plugins

            OnUpsert(dataRecordRequest, dataRecordResponse);

            #region After OnUpsert plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.UpsertPluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnUpsert plugins

            AfterPerformUpsert(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// Perform service delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected void PerformDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            BeforePerformDelete(dataRecordRequest, dataRecordResponse);

            #region Before OnDelete plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.DeletePluginRecordBeforeEventHandler?.Invoke(this, new FwkPluginRecordBeforeEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion Before OnDelete plugins

            OnDelete(dataRecordRequest, dataRecordResponse);

            #region After OnDelete plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginRecord iPluginRecord in this.IPlugins)
                    iPluginRecord.DeletePluginRecordAfterEventHandler?.Invoke(this, new FwkPluginRecordAfterEventArgs(dataRecordRequest, dataRecordResponse));
            }

            #endregion After OnDelete plugins

            AfterPerformDelete(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// On service format
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnFormat(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service validate read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnValidateRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service validate insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnValidateInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service validate indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnValidateIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service validate update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnValidateUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service validate upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnValidateUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service validate delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnValidateDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// On service delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected virtual void OnDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service format
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformFormat(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service format
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformFormat(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service validate read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformValidateRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service validate read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformValidateRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service validate insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformValidateInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service validate insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformValidateInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service validate indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformValidateIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service validate indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformValidateIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service validate update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformValidateUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service validate update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformValidateUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service validate upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformValidateUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service validate upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformValidateUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service validate delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformValidateDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service validate delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformValidateDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service read
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service insert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service indate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service update
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service upsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// Before perform service delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void BeforePerformDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        /// <summary>
        /// After perform service delete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        private void AfterPerformDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
