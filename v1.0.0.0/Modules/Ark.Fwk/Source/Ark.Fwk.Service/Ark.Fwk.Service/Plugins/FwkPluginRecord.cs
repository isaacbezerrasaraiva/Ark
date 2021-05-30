// FwkPluginRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 29

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
    public class FwkPluginRecord : FwkPluginBasic, IFwkPluginRecord
    {
        #region Variables

        protected FwkPluginRecordBeforeEventHandler formatPluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler formatPluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler validateReadPluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler validateReadPluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler validateInsertPluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler validateInsertPluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler validateIndatePluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler validateIndatePluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler validateUpdatePluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler validateUpdatePluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler validateUpsertPluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler validateUpsertPluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler validateDeletePluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler validateDeletePluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler readPluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler readPluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler insertPluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler insertPluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler indatePluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler indatePluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler updatePluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler updatePluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler upsertPluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler upsertPluginRecordAfterEventHandler;
        protected FwkPluginRecordBeforeEventHandler deletePluginRecordBeforeEventHandler;
        protected FwkPluginRecordAfterEventHandler deletePluginRecordAfterEventHandler;

        #endregion Variables

        #region Constructors

        public FwkPluginRecord()
        {
        }

        #endregion Constructors

        #region Methods

        protected virtual void OnFormatPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnFormatPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnValidateReadPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateReadPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnValidateInsertPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateInsertPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnValidateIndatePluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateIndatePluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnValidateUpdatePluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateUpdatePluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnValidateUpsertPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateUpsertPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnValidateDeletePluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateDeletePluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnReadPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnReadPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnInsertPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnInsertPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnIndatePluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnIndatePluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnUpdatePluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnUpdatePluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnUpsertPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnUpsertPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        protected virtual void OnDeletePluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args)
        {
        }

        protected virtual void OnDeletePluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args)
        {
        }

        #endregion Methods

        #region Properties

        public FwkPluginRecordBeforeEventHandler FormatPluginRecordBeforeEventHandler { get { return this.formatPluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler FormatPluginRecordAfterEventHandler { get { return this.formatPluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler ValidateReadPluginRecordBeforeEventHandler { get { return this.validateReadPluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler ValidateReadPluginRecordAfterEventHandler { get { return this.validateReadPluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler ValidateInsertPluginRecordBeforeEventHandler { get { return this.validateInsertPluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler ValidateInsertPluginRecordAfterEventHandler { get { return this.validateInsertPluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler ValidateIndatePluginRecordBeforeEventHandler { get { return this.validateIndatePluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler ValidateIndatePluginRecordAfterEventHandler { get { return this.validateIndatePluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler ValidateUpdatePluginRecordBeforeEventHandler { get { return this.validateUpdatePluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler ValidateUpdatePluginRecordAfterEventHandler { get { return this.validateUpdatePluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler ValidateUpsertPluginRecordBeforeEventHandler { get { return this.validateUpsertPluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler ValidateUpsertPluginRecordAfterEventHandler { get { return this.validateUpsertPluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler ValidateDeletePluginRecordBeforeEventHandler { get { return this.validateDeletePluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler ValidateDeletePluginRecordAfterEventHandler { get { return this.validateDeletePluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler ReadPluginRecordBeforeEventHandler { get { return this.readPluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler ReadPluginRecordAfterEventHandler { get { return this.readPluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler InsertPluginRecordBeforeEventHandler { get { return this.insertPluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler InsertPluginRecordAfterEventHandler { get { return this.insertPluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler IndatePluginRecordBeforeEventHandler { get { return this.indatePluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler IndatePluginRecordAfterEventHandler { get { return this.indatePluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler UpdatePluginRecordBeforeEventHandler { get { return this.updatePluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler UpdatePluginRecordAfterEventHandler { get { return this.updatePluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler UpsertPluginRecordBeforeEventHandler { get { return this.upsertPluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler UpsertPluginRecordAfterEventHandler { get { return this.upsertPluginRecordAfterEventHandler; } }

        public FwkPluginRecordBeforeEventHandler DeletePluginRecordBeforeEventHandler { get { return this.deletePluginRecordBeforeEventHandler; } }

        public FwkPluginRecordAfterEventHandler DeletePluginRecordAfterEventHandler { get { return this.deletePluginRecordAfterEventHandler; } }

        #endregion Properties
    }
}