// IFwkPluginRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;

namespace Ark.Fwk.IPlugin
{
    public interface IFwkPluginRecord : IFwkPluginBasic
    {
        FwkPluginRecordBeforeEventHandler FormatPluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler FormatPluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler ValidateReadPluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler ValidateReadPluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler ValidateInsertPluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler ValidateInsertPluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler ValidateIndatePluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler ValidateIndatePluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler ValidateUpdatePluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler ValidateUpdatePluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler ValidateUpsertPluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler ValidateUpsertPluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler ValidateDeletePluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler ValidateDeletePluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler ReadPluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler ReadPluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler InsertPluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler InsertPluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler IndatePluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler IndatePluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler UpdatePluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler UpdatePluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler UpsertPluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler UpsertPluginRecordAfterEventHandler { get; }

        FwkPluginRecordBeforeEventHandler DeletePluginRecordBeforeEventHandler { get; }
        FwkPluginRecordAfterEventHandler DeletePluginRecordAfterEventHandler { get; }
    }

    #region EventArgs

    public class FwkPluginRecordBeforeEventArgs : FwkPluginBasicBeforeEventArgs
    {
        public FwkPluginRecordBeforeEventArgs()
        {
        }

        public FwkPluginRecordBeforeEventArgs(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
            : base(dataRecordRequest, dataRecordResponse)
        {
        }
    }

    public class FwkPluginRecordAfterEventArgs : FwkPluginBasicAfterEventArgs
    {
        public FwkPluginRecordAfterEventArgs()
        {
        }

        public FwkPluginRecordAfterEventArgs(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
            : base(dataRecordRequest, dataRecordResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void FwkPluginRecordBeforeEventHandler(Object sender, FwkPluginRecordBeforeEventArgs args);

    public delegate void FwkPluginRecordAfterEventHandler(Object sender, FwkPluginRecordAfterEventArgs args);

    #endregion EventHandlers
}
