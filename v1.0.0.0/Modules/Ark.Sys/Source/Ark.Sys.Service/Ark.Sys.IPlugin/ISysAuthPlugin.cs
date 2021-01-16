// ISysAuthPlugin.cs
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

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IPlugin;
using Ark.Sys;
using Ark.Sys.Data;

namespace Ark.Sys.IPlugin
{
    public interface ISysAuthPlugin : IFwkPlugin
    {
        FwkPluginBeforeEventHandler AuthenticatePluginBeforeEventHandler { get; }
        FwkPluginAfterEventHandler AuthenticatePluginAfterEventHandler { get; }

        SysEncryptTokenPluginBeforeEventHandler EncryptTokenPluginBeforeEventHandler { get; }
        SysDecryptTokenPluginAfterEventHandler DecryptTokenPluginAfterEventHandler { get; }

        FwkPluginBeforeEventHandler AuthorizePluginBeforeEventHandler { get; }
        FwkPluginAfterEventHandler AuthorizePluginAfterEventHandler { get; }
    }

    #region EventArgs

    public class SysEncryptTokenPluginBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public SysEncryptTokenPluginBeforeEventArgs(SysAuthDataRequest authDataRequest, Dictionary<String, String> publicPayload, Dictionary<String, String> privatePayload)
            : base(authDataRequest)
        {
            this.PublicPayload = publicPayload;
            this.PrivatePayload = privatePayload;
        }

        public Dictionary<String, String> PublicPayload { get; set; }
        public Dictionary<String, String> PrivatePayload { get; set; }
    }

    public class SysDecryptTokenPluginAfterEventArgs : FwkPluginAfterEventArgs
    {
        public SysDecryptTokenPluginAfterEventArgs(SysAuthDataRequest authDataRequest, SysAuthDataResponse authDataResponse, Dictionary<String, String> publicPayload, Dictionary<String, String> privatePayload)
            : base(authDataRequest, authDataResponse)
        {
            this.PublicPayload = publicPayload;
            this.PrivatePayload = privatePayload;
        }

        public Dictionary<String, String> PublicPayload { get; set; }
        public Dictionary<String, String> PrivatePayload { get; set; }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void SysEncryptTokenPluginBeforeEventHandler(Object sender, SysEncryptTokenPluginBeforeEventArgs args);

    public delegate void SysDecryptTokenPluginAfterEventHandler(Object sender, SysDecryptTokenPluginAfterEventArgs args);

    #endregion EventHandlers
}
