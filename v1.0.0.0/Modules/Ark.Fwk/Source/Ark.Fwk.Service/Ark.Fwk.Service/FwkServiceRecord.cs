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
            this.Operation = "Init";

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
            this.Operation = "Format";

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
            this.Operation = "ValidateRead";

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
            this.Operation = "ValidateInsert";

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
            this.Operation = "ValidateIndate";

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
            this.Operation = "ValidateUpdate";

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
            this.Operation = "ValidateUpsert";

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
            this.Operation = "ValidateDelete";

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
            this.Operation = "Read";

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
            this.Operation = "Insert";

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
            this.Operation = "Indate";

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
            this.Operation = "Update";

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
            this.Operation = "Upsert";

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
            this.Operation = "Delete";

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
            dataRecordResponse.Content.Format = new FwkFormatRecord();
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
            if (dataRecordResponse.Content.Format != null)
            {
                #region Validate required dataset

                if (dataRecordRequest.Content.DataSet == null)
                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataSetMissing, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                #endregion Validate required dataset

                if (dataRecordResponse.Content.Format.RecordTableList != null)
                {
                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataRecordRequest.Content.DataSet.Tables.Contains(formatRecordTable.Key) == false)
                        {
                            #region Validate required table

                            if (formatRecordTable.Value.Required == true)
                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableMissing, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                            #endregion Validate required table

                            #region Create inexistence non required table

                            dataRecordRequest.Content.DataSet.Tables.Add(formatRecordTable.Key);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                {
                                    if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                }
                            }

                            #endregion Create inexistence non required table
                        }
                        else
                        {
                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows.Count == 0)
                            {
                                #region Validate required table empty

                                if (formatRecordTable.Value.Required == true)
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableEmpty, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                #endregion Validate required table empty

                                #region Create inexistence non required table key fields

                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        {
                                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                        }
                                    }
                                }

                                #endregion Create inexistence non required table key fields
                            }
                            else
                            {
                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        {
                                            #region Validate required key field

                                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldMissing, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                                            #endregion Validate required key field

                                            foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                            {
                                                #region Validate required key field empty

                                                if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldEmpty, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                                #endregion Validate required key field empty

                                                #region Execute custom validations

                                                foreach (FwkFormatRecordFieldValidation formatRecordFieldValidation in formatRecordField.Value.Validations)
                                                {
                                                    if (formatRecordFieldValidation.Validate(dataRow[formatRecordField.Key], formatRecordField.Key) == false)
                                                        throw new LibException(formatRecordFieldValidation.Reason, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                }

                                                #endregion Execute custom validations

                                                #region Execute custom transformations

                                                foreach (FwkFormatRecordFieldTransformation formatRecordFieldTransformation in formatRecordField.Value.Transformations)
                                                    dataRow[formatRecordField.Key] = formatRecordFieldTransformation.Transform(dataRow[formatRecordField.Key]);

                                                #endregion Execute custom transformations
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            if (dataRecordResponse.Content.Format != null)
            {
                #region Validate required dataset

                if (dataRecordRequest.Content.DataSet == null)
                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataSetMissing, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                #endregion Validate required dataset

                if (dataRecordResponse.Content.Format.RecordTableList != null)
                {
                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataRecordRequest.Content.DataSet.Tables.Contains(formatRecordTable.Key) == false)
                        {
                            #region Validate required table

                            if (formatRecordTable.Value.Required == true)
                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableMissing, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                            #endregion Validate required table

                            #region Create inexistence non required table

                            dataRecordRequest.Content.DataSet.Tables.Add(formatRecordTable.Key);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                            }

                            #endregion Create inexistence non required table
                        }
                        else
                        {
                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows.Count == 0)
                            {
                                #region Validate required table empty

                                if (formatRecordTable.Value.Required == true)
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableEmpty, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                #endregion Validate required table empty

                                #region Create inexistence non required table key fields

                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                            dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                    }
                                }

                                #endregion Create inexistence non required table key fields
                            }
                            else
                            {
                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        #region Validate attributes

                                        if (formatRecordField.Value.Attributes.SkipValidations == false)
                                        {
                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey || (formatRecordField.Value.Attributes.Nullable == FwkBooleanEnum.False && formatRecordField.Value.Attributes.Constraint != FwkConstraintEnum.IncrementKey))
                                            {
                                                #region Validate required field

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldMissing, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                                                #endregion Validate required field

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values

                                                    #region Validate required field empty

                                                    if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                        throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordRequiredFieldEmpty, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                                    #endregion Validate required field empty
                                                }
                                            }
                                            else
                                            {
                                                #region Create inexistence non required field

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);

                                                #endregion Create inexistence non required field

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values
                                                }
                                            }
                                            
                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey && formatRecordField.Value.Attributes.UniqueKeys != null && formatRecordField.Value.Attributes.UniqueKeys.Length > 0)
                                            {
                                                #region Validate unique key

                                                String UniqueKeysString = String.Empty;
                                                List<DataColumn> dataColumnUniqueKeys = new List<DataColumn>();
                                                for (int i = 0; i < formatRecordField.Value.Attributes.UniqueKeys.Length; i++)
                                                {
                                                    UniqueKeysString += formatRecordField.Value.Attributes.UniqueKeys[i] + ",";
                                                    dataColumnUniqueKeys.Add(dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns[formatRecordField.Value.Attributes.UniqueKeys[i]]);
                                                }
                                                UniqueKeysString = UniqueKeysString.Remove(UniqueKeysString.Length - 1, 1);

                                                try { dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].PrimaryKey = dataColumnUniqueKeys.ToArray(); }
                                                catch { throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedRequest, new Object[] { UniqueKeysString }, Properties.FwkResourcesService.FwkCaptionDuplicatedData); }

                                                DataTable dataTableUniqueKeys = this.Database.SelectAll(formatRecordTable.Key, dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key], DataRowState.Added, formatRecordField.Value.Attributes.UniqueKeys);

                                                if (dataTableUniqueKeys.Rows.Count > 0)
                                                {
                                                    String duplicatedValues = String.Empty;
                                                    foreach (DataColumn dataColumn in dataTableUniqueKeys.Columns)
                                                        duplicatedValues += LazyConvert.ToString(dataTableUniqueKeys.Rows[0][dataColumn], String.Empty) + ",";
                                                    duplicatedValues = duplicatedValues.Remove(duplicatedValues.Length - 1, 1);

                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedDatabase, new Object[] { UniqueKeysString, duplicatedValues }, Properties.FwkResourcesService.FwkCaptionDuplicatedData);
                                                }

                                                #endregion Validate unique key
                                            }
                                        }

                                        #endregion Validate attributes

                                        foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                        {
                                            #region Execute custom validations

                                            foreach (FwkFormatRecordFieldValidation formatRecordFieldValidation in formatRecordField.Value.Validations)
                                            {
                                                if (formatRecordFieldValidation.Validate(dataRow[formatRecordField.Key], formatRecordField.Key) == false)
                                                    throw new LibException(formatRecordFieldValidation.Reason, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                            }

                                            #endregion Execute custom validations

                                            #region Execute custom transformations

                                            foreach (FwkFormatRecordFieldTransformation formatRecordFieldTransformation in formatRecordField.Value.Transformations)
                                                dataRow[formatRecordField.Key] = formatRecordFieldTransformation.Transform(dataRow[formatRecordField.Key]);

                                            #endregion Execute custom transformations
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            if (dataRecordResponse.Content.Format != null)
            {
                #region Validate required DataSet

                if (dataRecordRequest.Content.DataSet == null)
                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataSetMissing, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                #endregion Validate required DataSet

                if (dataRecordResponse.Content.Format.RecordTableList != null)
                {
                    #region Read original records

                    DataSet dataSetReceived = dataRecordRequest.Content.DataSet;
                    DataSet dataSetOriginalKeys = new DataSet();
                    DataSet dataSetFaithfulRecords = null;

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataSetReceived.Tables.Contains(formatRecordTable.Key) == true)
                        {
                            #region Create DataTable original keys

                            DataTable dataTableOriginalKeys = new DataTable(formatRecordTable.Key);
                            dataSetOriginalKeys.Tables.Add(dataTableOriginalKeys);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                {
                                    if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        dataTableOriginalKeys.Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                }
                            }

                            #endregion Create DataTable original keys

                            #region Extract DataTable original keys values

                            foreach (DataRow dataRowReceived in dataSetReceived.Tables[formatRecordTable.Key].Rows)
                            {
                                DataRow dataRowOriginalKeys = dataTableOriginalKeys.NewRow();
                                dataTableOriginalKeys.Rows.Add(dataRowOriginalKeys);

                                foreach (DataColumn dataColumnKey in dataTableOriginalKeys.Columns)
                                {
                                    if (dataSetReceived.Tables[formatRecordTable.Key].Columns.Contains(dataColumnKey.ColumnName) == true)
                                        dataRowOriginalKeys[dataColumnKey] = dataRowReceived[dataColumnKey.ColumnName];
                                }
                            }

                            dataTableOriginalKeys.AcceptChanges();

                            #endregion Extract DataTable original keys values
                        }
                    }

                    #region Perform read original records

                    String dataRecordRequestOriginalString = (String)Newtonsoft.Json.JsonConvert.SerializeObject(dataRecordRequest, dataRecordRequest.GetType(), null);
                    FwkDataRecordRequest dataRecordRequestOriginal = (FwkDataRecordRequest)Newtonsoft.Json.JsonConvert.DeserializeObject(dataRecordRequestOriginalString, dataRecordRequest.GetType());
                    dataRecordRequestOriginal.Content.DataSet = dataSetOriginalKeys;

                    String dataRecordResponseOriginalString = (String)Newtonsoft.Json.JsonConvert.SerializeObject(dataRecordResponse, dataRecordResponse.GetType(), null);
                    FwkDataRecordResponse dataRecordResponseOriginal = (FwkDataRecordResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(dataRecordResponseOriginalString, dataRecordResponse.GetType());

                    PerformValidateRead(dataRecordRequestOriginal, dataRecordResponseOriginal);
                    PerformRead(dataRecordRequestOriginal, dataRecordResponseOriginal);

                    dataSetFaithfulRecords = dataRecordResponseOriginal.Content.DataSet;

                    #endregion Perform read original records

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataSetReceived.Tables.Contains(formatRecordTable.Key) == true)
                        {
                            foreach (DataRow dataRowReceived in dataSetReceived.Tables[formatRecordTable.Key].Rows)
                            {
                                #region Create record key filter

                                String recordKeyFilter = String.Empty;
                                foreach (DataColumn dataColumnKey in dataSetOriginalKeys.Tables[formatRecordTable.Key].Columns)
                                    recordKeyFilter += dataColumnKey.ColumnName + " = '" + dataRowReceived[dataColumnKey.ColumnName] + "' and ";
                                recordKeyFilter = recordKeyFilter.Remove(recordKeyFilter.Length - 5, 5);

                                #endregion Create record key filter

                                #region Select faithful record that matchs received record

                                DataRow[] dataRowArray = dataSetFaithfulRecords.Tables[formatRecordTable.Key].Select(recordKeyFilter);

                                if (dataRowArray.Length == 0)
                                {
                                    dataSetFaithfulRecords.Tables[formatRecordTable.Key].ImportRow(dataRowReceived);
                                }
                                else
                                {
                                    DataRow dataRowFaithfulRecord = dataRowArray[0];

                                    #region Modify faithful record with received record changes

                                    foreach (DataColumn dataColumnReceived in dataSetReceived.Tables[formatRecordTable.Key].Columns)
                                    {
                                        if (dataSetFaithfulRecords.Tables[formatRecordTable.Key].Columns.Contains(dataColumnReceived.ColumnName) == true)
                                            dataRowFaithfulRecord[dataColumnReceived.ColumnName] = dataRowReceived[dataColumnReceived.ColumnName];
                                    }

                                    #endregion Modify faithful record with received record changes
                                }

                                #endregion Select faithful record that matchs received record
                            }

                            DataTable dataTableFaithful = dataSetFaithfulRecords.Tables[formatRecordTable.Key];
                            dataSetFaithfulRecords.Tables.Remove(formatRecordTable.Key);
                            dataSetReceived.Tables.Remove(formatRecordTable.Key);
                            dataSetReceived.Tables.Add(dataTableFaithful);
                        }
                    }

                    #endregion Read original records

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataRecordRequest.Content.DataSet.Tables.Contains(formatRecordTable.Key) == false)
                        {
                            #region Validate required table

                            if (formatRecordTable.Value.Required == true)
                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableMissing, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                            #endregion Validate required table

                            #region Create inexistence non required table

                            dataRecordRequest.Content.DataSet.Tables.Add(formatRecordTable.Key);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                            }

                            #endregion Create inexistence non required table
                        }
                        else
                        {
                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows.Count == 0)
                            {
                                #region Validate required table empty

                                if (formatRecordTable.Value.Required == true)
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableEmpty, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                #endregion Validate required table empty

                                #region Create inexistence non required table key fields

                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                            dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                    }
                                }

                                #endregion Create inexistence non required table key fields
                            }
                            else
                            {
                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        #region Validate attributes

                                        if (formatRecordField.Value.Attributes.SkipValidations == false)
                                        {
                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey || formatRecordField.Value.Attributes.Nullable == FwkBooleanEnum.False)
                                            {
                                                #region Validate required field missing

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldMissing, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                                                #endregion Validate required field missing

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values

                                                    #region Validate required field empty

                                                    if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                        throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordRequiredFieldEmpty, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                                    #endregion Validate required field empty

                                                    #region Validate non editable field

                                                    if (formatRecordField.Value.Attributes.Editable == FwkBooleanEnum.False)
                                                    {
                                                        if (dataRow.RowState == DataRowState.Modified)
                                                        {
                                                            if (LazyConvert.ToString(dataRow[formatRecordField.Key], String.Empty) != LazyConvert.ToString(dataRow[formatRecordField.Key, DataRowVersion.Original], String.Empty))
                                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordNonEditableFieldModified, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                        }
                                                    }

                                                    #endregion Validate non editable field
                                                }
                                            }
                                            else
                                            {
                                                #region Create inexistence non required field

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);

                                                #endregion Create inexistence non required field

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values

                                                    #region Validate non editable field

                                                    if (formatRecordField.Value.Attributes.Editable == FwkBooleanEnum.False)
                                                    {
                                                        if (dataRow.RowState == DataRowState.Modified)
                                                        {
                                                            if (LazyConvert.ToString(dataRow[formatRecordField.Key], String.Empty) != LazyConvert.ToString(dataRow[formatRecordField.Key, DataRowVersion.Original], String.Empty))
                                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordNonEditableFieldModified, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                        }
                                                    }

                                                    #endregion Validate non editable field
                                                }
                                            }

                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey && formatRecordField.Value.Attributes.UniqueKeys != null && formatRecordField.Value.Attributes.UniqueKeys.Length > 0)
                                            {
                                                #region Validate unique key

                                                String dataColumnUniqueKeyString = String.Empty;
                                                List<DataColumn> dataColumnUniqueKeyList = new List<DataColumn>();
                                                for (int i = 0; i < formatRecordField.Value.Attributes.UniqueKeys.Length; i++)
                                                {
                                                    dataColumnUniqueKeyString += formatRecordField.Value.Attributes.UniqueKeys[i] + ",";
                                                    dataColumnUniqueKeyList.Add(dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns[formatRecordField.Value.Attributes.UniqueKeys[i]]);
                                                }
                                                dataColumnUniqueKeyString = dataColumnUniqueKeyString.Remove(dataColumnUniqueKeyString.Length - 1, 1);

                                                try { dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].PrimaryKey = dataColumnUniqueKeyList.ToArray(); }
                                                catch { throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedRequest, new Object[] { dataColumnUniqueKeyString }, Properties.FwkResourcesService.FwkCaptionDuplicatedData); }



                                                List<String> keyList = new List<String>();
                                                List<String> primaryKeyList = new List<String>();
                                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordFieldPrimaryKey in formatRecordTable.Value.RecordFields)
                                                {
                                                    if (formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                                    {
                                                        keyList.Add(formatRecordFieldPrimaryKey.Key);
                                                        primaryKeyList.Add(formatRecordFieldPrimaryKey.Key);
                                                    }
                                                    else if (formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey)
                                                    {
                                                        keyList.Add(formatRecordFieldPrimaryKey.Key);
                                                    }
                                                }



                                                DataTable dataTableAlreadyExistingKeys = dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Copy();
                                                dataTableAlreadyExistingKeys.AcceptChanges();
                                                dataTableAlreadyExistingKeys = this.Database.SelectAll(formatRecordTable.Key, dataTableAlreadyExistingKeys, keyList.ToArray());

                                                foreach (DataRow dataRowAlreadyExistingKeys in dataTableAlreadyExistingKeys.Rows)
                                                {
                                                    String alreadyExistingKeyFilter = String.Empty;
                                                    foreach (DataColumn dataColumnUniqueKey in dataColumnUniqueKeyList)
                                                        alreadyExistingKeyFilter += dataColumnUniqueKey.ColumnName + " = '" + dataRowAlreadyExistingKeys[dataColumnUniqueKey.ColumnName] + "' and ";
                                                    alreadyExistingKeyFilter = alreadyExistingKeyFilter.Remove(alreadyExistingKeyFilter.Length - 5, 5);

                                                    DataRow[] dataRow = dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Select(alreadyExistingKeyFilter);

                                                    if (dataRow.Length > 0)
                                                    {
                                                        foreach (String primaryKey in primaryKeyList)
                                                        {
                                                            String primaryKeyValue = dataRow[0].RowState == DataRowState.Added ? LazyConvert.ToString(dataRow[0][primaryKey], String.Empty) : LazyConvert.ToString(dataRow[0][primaryKey, DataRowVersion.Original], String.Empty);

                                                            if (LazyConvert.ToString(dataRowAlreadyExistingKeys[primaryKey], String.Empty) != primaryKeyValue)
                                                            {
                                                                String duplicatedValues = String.Empty;
                                                                foreach (DataColumn dataColumnUniqueKey in dataColumnUniqueKeyList)
                                                                    duplicatedValues += LazyConvert.ToString(dataRowAlreadyExistingKeys[dataColumnUniqueKey.ColumnName], String.Empty) + ",";
                                                                duplicatedValues = duplicatedValues.Remove(duplicatedValues.Length - 1, 1);

                                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedDatabase, new Object[] { dataColumnUniqueKeyString, duplicatedValues }, Properties.FwkResourcesService.FwkCaptionDuplicatedData);
                                                            }
                                                        }
                                                    }
                                                }

                                                #endregion Validate unique key
                                            }
                                        }

                                        #endregion Validate attributes

                                        foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                        {
                                            #region Execute custom validations

                                            foreach (FwkFormatRecordFieldValidation formatRecordFieldValidation in formatRecordField.Value.Validations)
                                            {
                                                if (formatRecordFieldValidation.Validate(dataRow[formatRecordField.Key], formatRecordField.Key) == false)
                                                    throw new LibException(formatRecordFieldValidation.Reason, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                            }

                                            #endregion Execute custom validations

                                            #region Execute custom transformations

                                            foreach (FwkFormatRecordFieldTransformation formatRecordFieldTransformation in formatRecordField.Value.Transformations)
                                                dataRow[formatRecordField.Key] = formatRecordFieldTransformation.Transform(dataRow[formatRecordField.Key]);

                                            #endregion Execute custom transformations
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            if (dataRecordResponse.Content.Format != null)
            {
                #region Validate required DataSet

                if (dataRecordRequest.Content.DataSet == null)
                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataSetMissing, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                #endregion Validate required DataSet

                if (dataRecordResponse.Content.Format.RecordTableList != null)
                {
                    #region Read original records

                    DataSet dataSetReceived = dataRecordRequest.Content.DataSet;
                    DataSet dataSetOriginalKeys = new DataSet();
                    DataSet dataSetFaithfulRecords = null;

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataSetReceived.Tables.Contains(formatRecordTable.Key) == true)
                        {
                            #region Create DataTable original keys

                            DataTable dataTableOriginalKeys = new DataTable(formatRecordTable.Key);
                            dataSetOriginalKeys.Tables.Add(dataTableOriginalKeys);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                {
                                    if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        dataTableOriginalKeys.Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                }
                            }

                            #endregion Create DataTable original keys

                            #region Extract DataTable original keys values

                            foreach (DataRow dataRowReceived in dataSetReceived.Tables[formatRecordTable.Key].Rows)
                            {
                                DataRow dataRowOriginalKeys = dataTableOriginalKeys.NewRow();
                                dataTableOriginalKeys.Rows.Add(dataRowOriginalKeys);

                                foreach (DataColumn dataColumnKey in dataTableOriginalKeys.Columns)
                                {
                                    if (dataSetReceived.Tables[formatRecordTable.Key].Columns.Contains(dataColumnKey.ColumnName) == true)
                                        dataRowOriginalKeys[dataColumnKey] = dataRowReceived[dataColumnKey.ColumnName, DataRowVersion.Original];
                                }
                            }

                            dataTableOriginalKeys.AcceptChanges();

                            #endregion Extract DataTable original keys values
                        }
                    }

                    #region Perform read original records

                    String dataRecordRequestOriginalString = (String)Newtonsoft.Json.JsonConvert.SerializeObject(dataRecordRequest, dataRecordRequest.GetType(), null);
                    FwkDataRecordRequest dataRecordRequestOriginal = (FwkDataRecordRequest)Newtonsoft.Json.JsonConvert.DeserializeObject(dataRecordRequestOriginalString, dataRecordRequest.GetType());
                    dataRecordRequestOriginal.Content.DataSet = dataSetOriginalKeys;

                    String dataRecordResponseOriginalString = (String)Newtonsoft.Json.JsonConvert.SerializeObject(dataRecordResponse, dataRecordResponse.GetType(), null);
                    FwkDataRecordResponse dataRecordResponseOriginal = (FwkDataRecordResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(dataRecordResponseOriginalString, dataRecordResponse.GetType());

                    PerformValidateRead(dataRecordRequestOriginal, dataRecordResponseOriginal);
                    PerformRead(dataRecordRequestOriginal, dataRecordResponseOriginal);

                    dataSetFaithfulRecords = dataRecordResponseOriginal.Content.DataSet;

                    #endregion Perform read original records

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataSetReceived.Tables.Contains(formatRecordTable.Key) == true)
                        {
                            foreach (DataRow dataRowReceived in dataSetReceived.Tables[formatRecordTable.Key].Rows)
                            {
                                #region Create record key filter

                                String recordKeyFilter = String.Empty;
                                foreach (DataColumn dataColumnKey in dataSetOriginalKeys.Tables[formatRecordTable.Key].Columns)
                                    recordKeyFilter += dataColumnKey.ColumnName + " = '" + dataRowReceived[dataColumnKey.ColumnName, DataRowVersion.Original] + "' and ";
                                recordKeyFilter = recordKeyFilter.Remove(recordKeyFilter.Length - 5, 5);

                                #endregion Create record key filter

                                #region Select faithful record that matchs received record

                                DataRow[] dataRowArray = dataSetFaithfulRecords.Tables[formatRecordTable.Key].Select(recordKeyFilter);

                                if (dataRowArray.Length == 0)
                                {
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordOriginalKeyNotFound, new Object[] { recordKeyFilter.Replace("and", "|") }, Properties.FwkResourcesService.FwkCaptionNotFound);
                                }
                                else
                                {
                                    DataRow dataRowFaithfulRecord = dataRowArray[0];

                                    #region Modify faithful record with received record changes

                                    foreach (DataColumn dataColumnReceived in dataSetReceived.Tables[formatRecordTable.Key].Columns)
                                    {
                                        if (dataSetFaithfulRecords.Tables[formatRecordTable.Key].Columns.Contains(dataColumnReceived.ColumnName) == true)
                                            dataRowFaithfulRecord[dataColumnReceived.ColumnName] = dataRowReceived[dataColumnReceived.ColumnName];
                                    }

                                    #endregion Modify faithful record with received record changes
                                }

                                #endregion Select faithful record that matchs received record
                            }

                            DataTable dataTableFaithful = dataSetFaithfulRecords.Tables[formatRecordTable.Key];
                            dataSetFaithfulRecords.Tables.Remove(formatRecordTable.Key);
                            dataSetReceived.Tables.Remove(formatRecordTable.Key);
                            dataSetReceived.Tables.Add(dataTableFaithful);
                        }
                    }

                    #endregion Read original records

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataRecordRequest.Content.DataSet.Tables.Contains(formatRecordTable.Key) == false)
                        {
                            #region Validate required table

                            if (formatRecordTable.Value.Required == true)
                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableMissing, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                            #endregion Validate required table

                            #region Create inexistence non required table

                            dataRecordRequest.Content.DataSet.Tables.Add(formatRecordTable.Key);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                            }

                            #endregion Create inexistence non required table
                        }
                        else
                        {
                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows.Count == 0)
                            {
                                #region Validate required table empty

                                if (formatRecordTable.Value.Required == true)
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableEmpty, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                #endregion Validate required table empty

                                #region Create inexistence non required table key fields

                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                            dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                    }
                                }

                                #endregion Create inexistence non required table key fields
                            }
                            else
                            {
                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        #region Validate attributes

                                        if (formatRecordField.Value.Attributes.SkipValidations == false)
                                        {
                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey || formatRecordField.Value.Attributes.Nullable == FwkBooleanEnum.False)
                                            {
                                                #region Validate required field missing

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldMissing, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                                                #endregion Validate required field missing

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values

                                                    #region Validate required field empty

                                                    if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                        throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordRequiredFieldEmpty, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                                    #endregion Validate required field empty

                                                    #region Validate non editable field

                                                    if (formatRecordField.Value.Attributes.Editable == FwkBooleanEnum.False)
                                                    {
                                                        if (LazyConvert.ToString(dataRow[formatRecordField.Key], String.Empty) != LazyConvert.ToString(dataRow[formatRecordField.Key, DataRowVersion.Original], String.Empty))
                                                            throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordNonEditableFieldModified, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                    }

                                                    #endregion Validate non editable field
                                                }
                                            }
                                            else
                                            {
                                                #region Create inexistence non required field

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);

                                                #endregion Create inexistence non required field

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values

                                                    #region Validate non editable field

                                                    if (formatRecordField.Value.Attributes.Editable == FwkBooleanEnum.False)
                                                    {
                                                        if (LazyConvert.ToString(dataRow[formatRecordField.Key], String.Empty) != LazyConvert.ToString(dataRow[formatRecordField.Key, DataRowVersion.Original], String.Empty))
                                                            throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordNonEditableFieldModified, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                    }

                                                    #endregion Validate non editable field
                                                }
                                            }

                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey && formatRecordField.Value.Attributes.UniqueKeys != null && formatRecordField.Value.Attributes.UniqueKeys.Length > 0)
                                            {
                                                #region Validate unique key

                                                String dataColumnUniqueKeyString = String.Empty;
                                                List<DataColumn> dataColumnUniqueKeyList = new List<DataColumn>();
                                                for (int i = 0; i < formatRecordField.Value.Attributes.UniqueKeys.Length; i++)
                                                {
                                                    dataColumnUniqueKeyString += formatRecordField.Value.Attributes.UniqueKeys[i] + ",";
                                                    dataColumnUniqueKeyList.Add(dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns[formatRecordField.Value.Attributes.UniqueKeys[i]]);
                                                }
                                                dataColumnUniqueKeyString = dataColumnUniqueKeyString.Remove(dataColumnUniqueKeyString.Length - 1, 1);

                                                try { dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].PrimaryKey = dataColumnUniqueKeyList.ToArray(); }
                                                catch { throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedRequest, new Object[] { dataColumnUniqueKeyString }, Properties.FwkResourcesService.FwkCaptionDuplicatedData); }



                                                List<String> keyList = new List<String>();
                                                List<String> primaryKeyList = new List<String>();
                                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordFieldPrimaryKey in formatRecordTable.Value.RecordFields)
                                                {
                                                    if (formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                                    {
                                                        keyList.Add(formatRecordFieldPrimaryKey.Key);
                                                        primaryKeyList.Add(formatRecordFieldPrimaryKey.Key);
                                                    }
                                                    else if (formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey)
                                                    {
                                                        keyList.Add(formatRecordFieldPrimaryKey.Key);
                                                    }
                                                }



                                                DataTable dataTableAlreadyExistingKeys = dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Copy();
                                                dataTableAlreadyExistingKeys.AcceptChanges();
                                                dataTableAlreadyExistingKeys = this.Database.SelectAll(formatRecordTable.Key, dataTableAlreadyExistingKeys, keyList.ToArray());

                                                foreach (DataRow dataRowAlreadyExistingKeys in dataTableAlreadyExistingKeys.Rows)
                                                {
                                                    String alreadyExistingKeyFilter = String.Empty;
                                                    foreach (DataColumn dataColumnUniqueKey in dataColumnUniqueKeyList)
                                                        alreadyExistingKeyFilter += dataColumnUniqueKey.ColumnName + " = '" + dataRowAlreadyExistingKeys[dataColumnUniqueKey.ColumnName] + "' and ";
                                                    alreadyExistingKeyFilter = alreadyExistingKeyFilter.Remove(alreadyExistingKeyFilter.Length - 5, 5);

                                                    DataRow[] dataRow = dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Select(alreadyExistingKeyFilter);

                                                    if (dataRow.Length > 0)
                                                    {
                                                        foreach (String primaryKey in primaryKeyList)
                                                        {
                                                            if (LazyConvert.ToString(dataRowAlreadyExistingKeys[primaryKey], String.Empty) != LazyConvert.ToString(dataRow[0][primaryKey, DataRowVersion.Original], String.Empty))
                                                            {
                                                                String duplicatedValues = String.Empty;
                                                                foreach (DataColumn dataColumnUniqueKey in dataColumnUniqueKeyList)
                                                                    duplicatedValues += LazyConvert.ToString(dataRowAlreadyExistingKeys[dataColumnUniqueKey.ColumnName], String.Empty) + ",";
                                                                duplicatedValues = duplicatedValues.Remove(duplicatedValues.Length - 1, 1);

                                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedDatabase, new Object[] { dataColumnUniqueKeyString, duplicatedValues }, Properties.FwkResourcesService.FwkCaptionDuplicatedData);
                                                            }
                                                        }
                                                    }
                                                }

                                                #endregion Validate unique key
                                            }
                                        }

                                        #endregion Validate attributes

                                        foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                        {
                                            #region Execute custom validations

                                            foreach (FwkFormatRecordFieldValidation formatRecordFieldValidation in formatRecordField.Value.Validations)
                                            {
                                                if (formatRecordFieldValidation.Validate(dataRow[formatRecordField.Key], formatRecordField.Key) == false)
                                                    throw new LibException(formatRecordFieldValidation.Reason, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                            }

                                            #endregion Execute custom validations

                                            #region Execute custom transformations

                                            foreach (FwkFormatRecordFieldTransformation formatRecordFieldTransformation in formatRecordField.Value.Transformations)
                                                dataRow[formatRecordField.Key] = formatRecordFieldTransformation.Transform(dataRow[formatRecordField.Key]);

                                            #endregion Execute custom transformations
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            if (dataRecordResponse.Content.Format != null)
            {
                #region Validate required DataSet

                if (dataRecordRequest.Content.DataSet == null)
                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataSetMissing, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                #endregion Validate required DataSet

                if (dataRecordResponse.Content.Format.RecordTableList != null)
                {
                    #region Read original records

                    DataSet dataSetReceived = dataRecordRequest.Content.DataSet;
                    DataSet dataSetOriginalKeys = new DataSet();
                    DataSet dataSetFaithfulRecords = null;

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataSetReceived.Tables.Contains(formatRecordTable.Key) == true)
                        {
                            #region Create DataTable original keys

                            DataTable dataTableOriginalKeys = new DataTable(formatRecordTable.Key);
                            dataSetOriginalKeys.Tables.Add(dataTableOriginalKeys);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                {
                                    if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        dataTableOriginalKeys.Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                }
                            }

                            #endregion Create DataTable original keys

                            #region Extract DataTable original keys values

                            foreach (DataRow dataRowReceived in dataSetReceived.Tables[formatRecordTable.Key].Rows)
                            {
                                DataRow dataRowOriginalKeys = dataTableOriginalKeys.NewRow();
                                dataTableOriginalKeys.Rows.Add(dataRowOriginalKeys);

                                foreach (DataColumn dataColumnKey in dataTableOriginalKeys.Columns)
                                {
                                    if (dataSetReceived.Tables[formatRecordTable.Key].Columns.Contains(dataColumnKey.ColumnName) == true)
                                        dataRowOriginalKeys[dataColumnKey] = dataRowReceived[dataColumnKey.ColumnName, DataRowVersion.Original];
                                }
                            }

                            dataTableOriginalKeys.AcceptChanges();

                            #endregion Extract DataTable original keys values
                        }
                    }

                    #region Perform read original records

                    String dataRecordRequestOriginalString = (String)Newtonsoft.Json.JsonConvert.SerializeObject(dataRecordRequest, dataRecordRequest.GetType(), null);
                    FwkDataRecordRequest dataRecordRequestOriginal = (FwkDataRecordRequest)Newtonsoft.Json.JsonConvert.DeserializeObject(dataRecordRequestOriginalString, dataRecordRequest.GetType());
                    dataRecordRequestOriginal.Content.DataSet = dataSetOriginalKeys;

                    String dataRecordResponseOriginalString = (String)Newtonsoft.Json.JsonConvert.SerializeObject(dataRecordResponse, dataRecordResponse.GetType(), null);
                    FwkDataRecordResponse dataRecordResponseOriginal = (FwkDataRecordResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(dataRecordResponseOriginalString, dataRecordResponse.GetType());

                    PerformValidateRead(dataRecordRequestOriginal, dataRecordResponseOriginal);
                    PerformRead(dataRecordRequestOriginal, dataRecordResponseOriginal);

                    dataSetFaithfulRecords = dataRecordResponseOriginal.Content.DataSet;

                    #endregion Perform read original records

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataSetReceived.Tables.Contains(formatRecordTable.Key) == true)
                        {
                            foreach (DataRow dataRowReceived in dataSetReceived.Tables[formatRecordTable.Key].Rows)
                            {
                                #region Create record key filter

                                String recordKeyFilter = String.Empty;
                                foreach (DataColumn dataColumnKey in dataSetOriginalKeys.Tables[formatRecordTable.Key].Columns)
                                    recordKeyFilter += dataColumnKey.ColumnName + " = '" + dataRowReceived[dataColumnKey.ColumnName, DataRowVersion.Original] + "' and ";
                                recordKeyFilter = recordKeyFilter.Remove(recordKeyFilter.Length - 5, 5);

                                #endregion Create record key filter

                                #region Select faithful record that matchs received record

                                DataRow[] dataRowArray = dataSetFaithfulRecords.Tables[formatRecordTable.Key].Select(recordKeyFilter);

                                if (dataRowArray.Length == 0)
                                {
                                    dataSetFaithfulRecords.Tables[formatRecordTable.Key].ImportRow(dataRowReceived);
                                    dataSetFaithfulRecords.Tables[formatRecordTable.Key].Rows[dataSetFaithfulRecords.Tables[formatRecordTable.Key].Rows.Count - 1].AcceptChanges();
                                    dataSetFaithfulRecords.Tables[formatRecordTable.Key].Rows[dataSetFaithfulRecords.Tables[formatRecordTable.Key].Rows.Count - 1].SetAdded();
                                }
                                else
                                {
                                    DataRow dataRowFaithfulRecord = dataRowArray[0];

                                    #region Modify faithful record with received record changes

                                    foreach (DataColumn dataColumnReceived in dataSetReceived.Tables[formatRecordTable.Key].Columns)
                                    {
                                        if (dataSetFaithfulRecords.Tables[formatRecordTable.Key].Columns.Contains(dataColumnReceived.ColumnName) == true)
                                            dataRowFaithfulRecord[dataColumnReceived.ColumnName] = dataRowReceived[dataColumnReceived.ColumnName];
                                    }

                                    #endregion Modify faithful record with received record changes
                                }

                                #endregion Select faithful record that matchs received record
                            }

                            DataTable dataTableFaithful = dataSetFaithfulRecords.Tables[formatRecordTable.Key];
                            dataSetFaithfulRecords.Tables.Remove(formatRecordTable.Key);
                            dataSetReceived.Tables.Remove(formatRecordTable.Key);
                            dataSetReceived.Tables.Add(dataTableFaithful);
                        }
                    }

                    #endregion Read original records

                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataRecordRequest.Content.DataSet.Tables.Contains(formatRecordTable.Key) == false)
                        {
                            #region Validate required table

                            if (formatRecordTable.Value.Required == true)
                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableMissing, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                            #endregion Validate required table

                            #region Create inexistence non required table

                            dataRecordRequest.Content.DataSet.Tables.Add(formatRecordTable.Key);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                            }

                            #endregion Create inexistence non required table
                        }
                        else
                        {
                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows.Count == 0)
                            {
                                #region Validate required table empty

                                if (formatRecordTable.Value.Required == true)
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableEmpty, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                #endregion Validate required table empty

                                #region Create inexistence non required table key fields

                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                            dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                    }
                                }

                                #endregion Create inexistence non required table key fields
                            }
                            else
                            {
                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        #region Validate attributes

                                        if (formatRecordField.Value.Attributes.SkipValidations == false)
                                        {
                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey || formatRecordField.Value.Attributes.Nullable == FwkBooleanEnum.False)
                                            {
                                                #region Validate required field missing

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldMissing, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                                                #endregion Validate required field missing

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values

                                                    #region Validate required field empty

                                                    if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                        throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordRequiredFieldEmpty, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                                    #endregion Validate required field empty

                                                    #region Validate non editable field

                                                    if (formatRecordField.Value.Attributes.Editable == FwkBooleanEnum.False)
                                                    {
                                                        if (dataRow.RowState == DataRowState.Modified)
                                                        {
                                                            if (LazyConvert.ToString(dataRow[formatRecordField.Key], String.Empty) != LazyConvert.ToString(dataRow[formatRecordField.Key, DataRowVersion.Original], String.Empty))
                                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordNonEditableFieldModified, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                        }
                                                    }

                                                    #endregion Validate non editable field
                                                }
                                            }
                                            else
                                            {
                                                #region Create inexistence non required field

                                                if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                    dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);

                                                #endregion Create inexistence non required field

                                                foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                                {
                                                    #region Set default values

                                                    if (formatRecordField.Value.Attributes.DefaultValue != null)
                                                    {
                                                        if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key], null)) == true)
                                                            dataRow[formatRecordField.Key] = formatRecordField.Value.Attributes.DefaultValue;
                                                    }

                                                    #endregion Set default values

                                                    #region Validate non editable field

                                                    if (formatRecordField.Value.Attributes.Editable == FwkBooleanEnum.False)
                                                    {
                                                        if (dataRow.RowState == DataRowState.Modified)
                                                        {
                                                            if (LazyConvert.ToString(dataRow[formatRecordField.Key], String.Empty) != LazyConvert.ToString(dataRow[formatRecordField.Key, DataRowVersion.Original], String.Empty))
                                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordNonEditableFieldModified, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                        }
                                                    }

                                                    #endregion Validate non editable field
                                                }
                                            }

                                            if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey && formatRecordField.Value.Attributes.UniqueKeys != null && formatRecordField.Value.Attributes.UniqueKeys.Length > 0)
                                            {
                                                #region Validate unique key

                                                String dataColumnUniqueKeyString = String.Empty;
                                                List<DataColumn> dataColumnUniqueKeyList = new List<DataColumn>();
                                                for (int i = 0; i < formatRecordField.Value.Attributes.UniqueKeys.Length; i++)
                                                {
                                                    dataColumnUniqueKeyString += formatRecordField.Value.Attributes.UniqueKeys[i] + ",";
                                                    dataColumnUniqueKeyList.Add(dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns[formatRecordField.Value.Attributes.UniqueKeys[i]]);
                                                }
                                                dataColumnUniqueKeyString = dataColumnUniqueKeyString.Remove(dataColumnUniqueKeyString.Length - 1, 1);

                                                try { dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].PrimaryKey = dataColumnUniqueKeyList.ToArray(); }
                                                catch { throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedRequest, new Object[] { dataColumnUniqueKeyString }, Properties.FwkResourcesService.FwkCaptionDuplicatedData); }



                                                List<String> keyList = new List<String>();
                                                List<String> primaryKeyList = new List<String>();
                                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordFieldPrimaryKey in formatRecordTable.Value.RecordFields)
                                                {
                                                    if (formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                                    {
                                                        keyList.Add(formatRecordFieldPrimaryKey.Key);
                                                        primaryKeyList.Add(formatRecordFieldPrimaryKey.Key);
                                                    }
                                                    else if (formatRecordFieldPrimaryKey.Value.Attributes.Constraint == FwkConstraintEnum.UniqueKey)
                                                    {
                                                        keyList.Add(formatRecordFieldPrimaryKey.Key);
                                                    }
                                                }



                                                DataTable dataTableAlreadyExistingKeys = dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Copy();
                                                dataTableAlreadyExistingKeys.AcceptChanges();
                                                dataTableAlreadyExistingKeys = this.Database.SelectAll(formatRecordTable.Key, dataTableAlreadyExistingKeys, keyList.ToArray());

                                                foreach (DataRow dataRowAlreadyExistingKeys in dataTableAlreadyExistingKeys.Rows)
                                                {
                                                    String alreadyExistingKeyFilter = String.Empty;
                                                    foreach (DataColumn dataColumnUniqueKey in dataColumnUniqueKeyList)
                                                        alreadyExistingKeyFilter += dataColumnUniqueKey.ColumnName + " = '" + dataRowAlreadyExistingKeys[dataColumnUniqueKey.ColumnName] + "' and ";
                                                    alreadyExistingKeyFilter = alreadyExistingKeyFilter.Remove(alreadyExistingKeyFilter.Length - 5, 5);

                                                    DataRow[] dataRow = dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Select(alreadyExistingKeyFilter);

                                                    if (dataRow.Length > 0)
                                                    {
                                                        foreach (String primaryKey in primaryKeyList)
                                                        {
                                                            String primaryKeyValue = dataRow[0].RowState == DataRowState.Added ? LazyConvert.ToString(dataRow[0][primaryKey], String.Empty) : LazyConvert.ToString(dataRow[0][primaryKey, DataRowVersion.Original], String.Empty);

                                                            if (LazyConvert.ToString(dataRowAlreadyExistingKeys[primaryKey], String.Empty) != primaryKeyValue)
                                                            {
                                                                String duplicatedValues = String.Empty;
                                                                foreach (DataColumn dataColumnUniqueKey in dataColumnUniqueKeyList)
                                                                    duplicatedValues += LazyConvert.ToString(dataRowAlreadyExistingKeys[dataColumnUniqueKey.ColumnName], String.Empty) + ",";
                                                                duplicatedValues = duplicatedValues.Remove(duplicatedValues.Length - 1, 1);

                                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordUniqueFieldDuplicatedDatabase, new Object[] { dataColumnUniqueKeyString, duplicatedValues }, Properties.FwkResourcesService.FwkCaptionDuplicatedData);
                                                            }
                                                        }
                                                    }
                                                }

                                                #endregion Validate unique key
                                            }
                                        }

                                        #endregion Validate attributes

                                        foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                        {
                                            #region Execute custom validations

                                            foreach (FwkFormatRecordFieldValidation formatRecordFieldValidation in formatRecordField.Value.Validations)
                                            {
                                                if (formatRecordFieldValidation.Validate(dataRow[formatRecordField.Key], formatRecordField.Key) == false)
                                                    throw new LibException(formatRecordFieldValidation.Reason, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                            }

                                            #endregion Execute custom validations

                                            #region Execute custom transformations

                                            foreach (FwkFormatRecordFieldTransformation formatRecordFieldTransformation in formatRecordField.Value.Transformations)
                                                dataRow[formatRecordField.Key] = formatRecordFieldTransformation.Transform(dataRow[formatRecordField.Key]);

                                            #endregion Execute custom transformations
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            if (dataRecordResponse.Content.Format != null)
            {
                #region Validate required dataset

                if (dataRecordRequest.Content.DataSet == null)
                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataSetMissing, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                #endregion Validate required dataset

                if (dataRecordResponse.Content.Format.RecordTableList != null)
                {
                    foreach (KeyValuePair<String, FwkFormatRecordTable> formatRecordTable in dataRecordResponse.Content.Format.RecordTableList)
                    {
                        if (dataRecordRequest.Content.DataSet.Tables.Contains(formatRecordTable.Key) == false)
                        {
                            #region Validate required table

                            if (formatRecordTable.Value.Required == true)
                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableMissing, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                            #endregion Validate required table

                            #region Create inexistence non required table

                            dataRecordRequest.Content.DataSet.Tables.Add(formatRecordTable.Key);

                            if (formatRecordTable.Value.RecordFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                {
                                    if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                }
                            }

                            #endregion Create inexistence non required table
                        }
                        else
                        {
                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows.Count == 0)
                            {
                                #region Validate required table empty

                                if (formatRecordTable.Value.Required == true)
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordDataTableEmpty, new Object[] { formatRecordTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                #endregion Validate required table empty

                                #region Create inexistence non required table key fields

                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        {
                                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Add(formatRecordField.Key, formatRecordField.Value.Attributes.Type);
                                        }
                                    }
                                }

                                #endregion Create inexistence non required table key fields
                            }
                            else
                            {
                                if (formatRecordTable.Value.RecordFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatRecordField> formatRecordField in formatRecordTable.Value.RecordFields)
                                    {
                                        if (formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.PrimaryKey || formatRecordField.Value.Attributes.Constraint == FwkConstraintEnum.IncrementKey)
                                        {
                                            #region Validate required key field

                                            if (dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Columns.Contains(formatRecordField.Key) == false)
                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldMissing, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                                            #endregion Validate required key field

                                            foreach (DataRow dataRow in dataRecordRequest.Content.DataSet.Tables[formatRecordTable.Key].Rows)
                                            {
                                                #region Validate required key field empty

                                                if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatRecordField.Key, DataRowVersion.Original], null)) == true)
                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionRecordKeyFieldEmpty, new Object[] { formatRecordField.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                                #endregion Validate required key field empty

                                                #region Execute custom validations

                                                foreach (FwkFormatRecordFieldValidation formatRecordFieldValidation in formatRecordField.Value.Validations)
                                                {
                                                    if (formatRecordFieldValidation.Validate(dataRow[formatRecordField.Key, DataRowVersion.Original], formatRecordField.Key) == false)
                                                        throw new LibException(formatRecordFieldValidation.Reason, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                }

                                                #endregion Execute custom validations

                                                #region Execute custom transformations

                                                // Unable to transform a deleted DataRow cause DataRowVersion.Original is Read-Only

                                                #endregion Execute custom transformations
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            if (this.Operation != "Init")
                dataRecordResponse.Content.Format = null;
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
            dataRecordResponse.Content.Format = null;
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
            dataRecordResponse.Content.Format = null;
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
            dataRecordResponse.Content.Format = null;
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
            dataRecordResponse.Content.Format = null;
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
            dataRecordResponse.Content.Format = null;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
