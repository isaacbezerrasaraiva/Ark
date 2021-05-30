// FwkPluginProcess.cs
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
    public class FwkPluginProcess : FwkPluginBasic, IFwkPluginProcess
    {
        #region Variables

        protected FwkPluginProcessBeforeEventHandler nextPluginProcessBeforeEventHandler;
        protected FwkPluginProcessAfterEventHandler nextPluginProcessAfterEventHandler;
        protected FwkPluginProcessBeforeEventHandler executePluginProcessBeforeEventHandler;
        protected FwkPluginProcessAfterEventHandler executePluginProcessAfterEventHandler;

        #endregion Variables

        #region Constructors

        public FwkPluginProcess()
        {
        }

        #endregion Constructors

        #region Methods

        protected virtual void OnNextPluginProcessBeforeEventHandler(Object sender, FwkPluginProcessBeforeEventArgs args)
        {
        }

        protected virtual void OnNextPluginProcessAfterEventHandler(Object sender, FwkPluginProcessAfterEventArgs args)
        {
        }

        protected virtual void OnExecutePluginProcessBeforeEventHandler(Object sender, FwkPluginProcessBeforeEventArgs args)
        {
        }

        protected virtual void OnExecutePluginProcessAfterEventHandler(Object sender, FwkPluginProcessAfterEventArgs args)
        {
        }

        #endregion Methods

        #region Properties

        public FwkPluginProcessBeforeEventHandler NextPluginProcessBeforeEventHandler { get { return this.nextPluginProcessBeforeEventHandler; } }

        public FwkPluginProcessAfterEventHandler NextPluginProcessAfterEventHandler { get { return this.nextPluginProcessAfterEventHandler; } }

        public FwkPluginProcessBeforeEventHandler ExecutePluginProcessBeforeEventHandler { get { return this.executePluginProcessBeforeEventHandler; } }

        public FwkPluginProcessAfterEventHandler ExecutePluginProcessAfterEventHandler { get { return this.executePluginProcessAfterEventHandler; } }

        #endregion Properties
    }
}