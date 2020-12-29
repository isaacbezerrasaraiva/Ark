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
            #region Initialize database

            String databaseAlias = "Default";

            LibDynamicXmlElement dynXmlElementDatabaseSettings = LibServiceConfiguration.DynamicXml["Ark.Fwk"]["Database"][databaseAlias]["Settings"];

            String databaseDbms = dynXmlElementDatabaseSettings.Attribute["Dbms"];
            String databaseAssembly = dynXmlElementDatabaseSettings.Attribute["Assembly"];
            String databaseClass = dynXmlElementDatabaseSettings.Attribute["Class"];
            String databaseVersion = dynXmlElementDatabaseSettings.Attribute["Version"];
            String databaseConnectionString = dynXmlElementDatabaseSettings["ConnectionString"].Text;
            String assemblyFolderName = databaseAssembly.Replace(".dll", String.Empty);

            this.database = (LazyDatabase)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[databaseVersion].Lib.NetCoreApp31.Path, databaseAssembly),
                databaseClass, new Object[] { databaseConnectionString });

            #endregion Initialize database
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        protected LazyDatabase Database
        {
            get { return this.database; }
        }

        protected List<IFwkPlugin> IPlugins
        {
            get { return this.iPluginList; }
        }

        #endregion Properties
    }
}
