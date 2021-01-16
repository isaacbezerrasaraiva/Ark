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
        FwkPluginBeforeEventHandler LoadPluginBeforeEventHandler { get; }
        FwkPluginAfterEventHandler LoadPluginAfterEventHandler { get; }
    }
}
