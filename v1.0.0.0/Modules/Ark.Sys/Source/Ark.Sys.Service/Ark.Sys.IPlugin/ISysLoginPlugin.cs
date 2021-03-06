﻿// ISysLoginPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
    public interface ISysLoginPlugin : IFwkPlugin
    {
        FwkPluginBeforeEventHandler AuthenticatePluginBeforeEventHandler { get; }
        FwkPluginAfterEventHandler AuthenticatePluginAfterEventHandler { get; }
    }
}
