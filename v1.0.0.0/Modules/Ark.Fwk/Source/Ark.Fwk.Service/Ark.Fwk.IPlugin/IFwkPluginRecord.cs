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
        FwkPluginBeforeEventHandler BeforeFormatEventHandler { get; }
        FwkPluginAfterEventHandler AfterFormatEventHandler { get; }
        
        FwkPluginBeforeEventHandler BeforeReadEventHandler { get; }
        FwkPluginAfterEventHandler AfterReadEventHandler { get; }

        FwkPluginBeforeEventHandler BeforeInsertEventHandler { get; }
        FwkPluginAfterEventHandler AfterInsertEventHandler { get; }

        FwkPluginBeforeEventHandler BeforeIndateEventHandler { get; }
        FwkPluginAfterEventHandler AfterIndateEventHandler { get; }

        FwkPluginBeforeEventHandler BeforeUpdateEventHandler { get; }
        FwkPluginAfterEventHandler AfterUpdateEventHandler { get; }

        FwkPluginBeforeEventHandler BeforeUpsertEventHandler { get; }
        FwkPluginAfterEventHandler AfterUpsertEventHandler { get; }

        FwkPluginBeforeEventHandler BeforeDeleteEventHandler { get; }
        FwkPluginAfterEventHandler AfterDeleteEventHandler { get; }
    }
}
