// IFwkPluginBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;

namespace Ark.Fwk.IPlugin
{
    public interface IFwkPluginBasic : IFwkPlugin
    {
        FwkPluginBasicBeforeEventHandler LoadPluginBasicBeforeEventHandler { get; }
        FwkPluginBasicAfterEventHandler LoadPluginBasicAfterEventHandler { get; }
    }

    #region EventArgs

    public class FwkPluginBasicBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public FwkPluginBasicBeforeEventArgs()
        {
        }

        public FwkPluginBasicBeforeEventArgs(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
            : base(dataBasicRequest, dataBasicResponse)
        {
        }
    }

    public class FwkPluginBasicAfterEventArgs : FwkPluginAfterEventArgs
    {
        public FwkPluginBasicAfterEventArgs()
        {
        }

        public FwkPluginBasicAfterEventArgs(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
            : base(dataBasicRequest, dataBasicResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void FwkPluginBasicBeforeEventHandler(Object sender, FwkPluginBasicBeforeEventArgs args);

    public delegate void FwkPluginBasicAfterEventHandler(Object sender, FwkPluginBasicAfterEventArgs args);

    #endregion EventHandlers
}
