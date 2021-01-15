// IFtsIncrementPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fts;
using Ark.Fts.Data;

namespace Ark.Fts.IPlugin
{
    public interface IFtsIncrementPlugin : IFwkPlugin
    {
        FwkPluginBeforeEventHandler BeforeNextEventHandler { get; }
        FwkPluginAfterEventHandler AfterNextEventHandler { get; }
    }
}
