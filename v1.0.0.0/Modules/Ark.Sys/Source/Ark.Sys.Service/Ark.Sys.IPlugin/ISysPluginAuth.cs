// ISysPluginAuth.cs
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
//using Ark.Fts;
//using Ark.Fts.Data;
//using Ark.Fts.IPlugin;
using Ark.Sys;
using Ark.Sys.Data;

namespace Ark.Sys.IPlugin
{
    public interface ISysPluginAuth : IFwkPlugin
    {
        FwkPluginBeforeEventHandler BeforeAuthenticateEventHandler { get; }
        FwkPluginAfterEventHandler AfterAuthenticateEventHandler { get; }

        SysPluginBeforeEncryptTokenEventHandler BeforeEncryptTokenEventHandler { get; }
        SysPluginAfterDecryptTokenEventHandler AfterDecryptTokenEventHandler { get; }

        FwkPluginBeforeEventHandler BeforeAuthorizeEventHandler { get; }
        FwkPluginAfterEventHandler AfterAuthorizeEventHandler { get; }
    }

    #region EventArgs

    public class SysPluginBeforeEncryptTokenEventArgs : FwkPluginBeforeEventArgs
    {
        public SysPluginBeforeEncryptTokenEventArgs(SysDataAuthRequest dataAuthRequest, Dictionary<String, String> publicPayload, Dictionary<String, String> privatePayload) : base(dataAuthRequest)
        {
            this.PublicPayload = publicPayload;
            this.PrivatePayload = privatePayload;
        }

        public Dictionary<String, String> PublicPayload { get; set; }
        public Dictionary<String, String> PrivatePayload { get; set; }
    }

    public class SysPluginAfterDecryptTokenEventArgs : FwkPluginAfterEventArgs
    {
        public SysPluginAfterDecryptTokenEventArgs(SysDataAuthRequest dataAuthRequest, SysDataAuthResponse dataAuthResponse, Dictionary<String, String> publicPayload, Dictionary<String, String> privatePayload) : base(dataAuthRequest, dataAuthResponse)
        {
            this.PublicPayload = publicPayload;
            this.PrivatePayload = privatePayload;
        }

        public Dictionary<String, String> PublicPayload { get; set; }
        public Dictionary<String, String> PrivatePayload { get; set; }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void SysPluginBeforeEncryptTokenEventHandler(Object sender, SysPluginBeforeEncryptTokenEventArgs args);

    public delegate void SysPluginAfterDecryptTokenEventHandler(Object sender, SysPluginAfterDecryptTokenEventArgs args);

    #endregion EventHandlers
}
