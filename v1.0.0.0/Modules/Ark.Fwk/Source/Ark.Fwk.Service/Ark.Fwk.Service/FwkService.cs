// FwkService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

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
    public class FwkService : IFwkService
    {
        #region Variables

        private LazyDatabase database;
        private List<IFwkPlugin> iPluginList;

        #endregion Variables

        #region Constructors

        public FwkService()
        {
            this.database = (LazyDatabase)LazyActivator.Local.CreateInstance(Path.Combine(LibDirectory.Root.Bin.Path,
                LibServiceConfiguration.DynamicXml["Ark.Fwk.Service"]["Database"]["Option"]["Settings"].Attribute["Assembly"]),
                LibServiceConfiguration.DynamicXml["Ark.Fwk.Service"]["Database"]["Option"]["Settings"].Attribute["Class"], new Object[] {
                    LibServiceConfiguration.DynamicXml["Ark.Fwk.Service"]["Database"]["Option"]["Settings"]["ConnectionString"].Attribute["Value"] });
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        protected LazyDatabase Database
        {
            get { return this.database; }
        }

        protected List<IFwkPlugin> PluginList
        {
            get { return this.iPluginList; }
        }

        #endregion Properties
    }
}
