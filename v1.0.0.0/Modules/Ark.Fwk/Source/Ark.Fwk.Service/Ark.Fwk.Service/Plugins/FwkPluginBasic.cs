// FwkPluginBasic.cs
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
    public class FwkPluginBasic : FwkPlugin, IFwkPluginBasic
    {
        #region Variables

        protected FwkPluginBasicBeforeEventHandler loadPluginBasicBeforeEventHandler;
        protected FwkPluginBasicAfterEventHandler loadPluginBasicAfterEventHandler;

        #endregion Variables

        #region Constructors

        public FwkPluginBasic()
        {
        }

        #endregion Constructors

        #region Methods

        protected virtual void OnLoadPluginBasicBeforeEventHandler(Object sender, FwkPluginBasicBeforeEventArgs args)
        {
        }

        protected virtual void OnLoadPluginBasicAfterEventHandler(Object sender, FwkPluginBasicAfterEventArgs args)
        {
        }

        #endregion Methods

        #region Properties

        public FwkPluginBasicBeforeEventHandler LoadPluginBasicBeforeEventHandler { get { return this.loadPluginBasicBeforeEventHandler; } }

        public FwkPluginBasicAfterEventHandler LoadPluginBasicAfterEventHandler { get { return this.loadPluginBasicAfterEventHandler; } }

        #endregion Properties
    }
}