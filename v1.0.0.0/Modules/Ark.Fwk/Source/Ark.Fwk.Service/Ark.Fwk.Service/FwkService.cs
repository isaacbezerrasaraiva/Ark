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

        private String operation;
        private LazyDatabase database;
        private FwkEnvironment environment;
        private List<IFwkPlugin> iPluginList;
        private Type dataResponseType;

        #endregion Variables

        #region Constructors

        public FwkService(FwkEnvironment environment)
        {
            this.environment = environment;

            #region Initialize database

            String databaseAlias = "Default";

            LibDynamicXmlElement dynXmlElementDatabaseSettings = LibConfigurationService.DynamicXml["Ark.Fwk"]["Database"][databaseAlias]["Settings"];

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

            #region Initialize environment

            String sql = null;
            DataTable dataTable = null;

            if (this.environment.Domain != null)
            {
                this.database.OpenConnection();

                #region Initialize domain

                sql = "select CodDomain, Name from FwkDomain where IdDomain = :IdDomain";
                dataTable = this.database.QueryTable(sql, "FwkDomain", new Object[] { this.environment.Domain.IdDomain });

                if (dataTable.Rows.Count > 0)
                {
                    this.environment.Domain.CodDomain = LazyConvert.ToString(dataTable.Rows[0]["CodDomain"]);
                    this.environment.Domain.Name = LazyConvert.ToString(dataTable.Rows[0]["Name"]);
                }

                #endregion Initialize domain

                if (this.environment.User != null)
                {
                    #region Initialize user

                    sql = "select Username, DisplayName from FwkUser where IdDomain = :IdDomain and IdUser = :IdUser";
                    dataTable = this.database.QueryTable(sql, "FwkUser", new Object[] { this.environment.User.IdDomain, this.environment.User.IdUser });

                    if (dataTable.Rows.Count > 0)
                    {
                        this.environment.User.Username = LazyConvert.ToString(dataTable.Rows[0]["Username"]);
                        this.environment.User.DisplayName = LazyConvert.ToString(dataTable.Rows[0]["DisplayName"]);
                    }

                    #endregion Initialize user

                    #region Initialize user context

                    sql = "select Field, ValueInt16, ValueInt32, ValueString from FwkUserContext where IdDomain = :IdDomain and IdUser = :IdUser";
                    dataTable = this.database.QueryTable(sql, "FwkUserContext", new Object[] { this.environment.User.IdDomain, this.environment.User.IdUser });

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        String field = LazyConvert.ToString(dataRow["Field"]);

                        this.environment.UserContext[field].ValueInt16 = LazyConvert.ToInt16(dataRow["ValueInt16"], 0);
                        this.environment.UserContext[field].ValueInt32 = LazyConvert.ToInt32(dataRow["ValueInt32"], 0);
                        this.environment.UserContext[field].ValueString = LazyConvert.ToString(dataRow["ValueString"], null);
                    }

                    #endregion Initialize user context
                }

                this.database.CloseConnection();
            }

            #endregion Initialize environment

            #region Initialize data response type

            assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            this.dataResponseType = LazyActivator.Local.GetType(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Initialize data response type
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        protected String Operation
        {
            get { return this.operation; }
            set { this.operation = value; }
        }

        protected LazyDatabase Database
        {
            get { return this.database; }
        }

        protected FwkEnvironment Environment
        {
            get { return this.environment; }
        }

        protected List<IFwkPlugin> IPlugins
        {
            get { return this.iPluginList; }
        }

        protected Type DataResponseType
        {
            get { return this.dataResponseType; }
        }

        #endregion Properties
    }
}
