// FtsIncrementService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Linq;
using System.Collections.Generic;

using Lazy;
using Lazy.Database;

using Ark.Lib;
using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;
using Ark.Fwk.Service;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IPlugin;
using Ark.Fts.IService;

namespace Ark.Fts.Service
{
    public class FtsIncrementService : FwkService, IFtsIncrementService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementService(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest)
        {
            #region Create response data

            String assemblyFolderName = this.GetType().Namespace.Replace("Service", "Data");
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            FtsIncrementDataResponse incrementDataResponse = (FtsIncrementDataResponse)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Create response data

            this.Database.OpenConnection();

            PerformNext(incrementDataRequest, incrementDataResponse);

            this.Database.CloseConnection();

            return incrementDataResponse;
        }

        /// <summary>
        /// Perform generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <param name="incrementDataResponse">The increment response data</param>
        protected void PerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            #region BeforeNext

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.NextPluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(incrementDataRequest));
            }

            #endregion BeforeNext

            OnNext(incrementDataRequest, incrementDataResponse);

            #region AfterNext

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.NextPluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion AfterNext
        }

        /// <summary>
        /// Generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <param name="incrementDataResponse">The increment response data</param>
        private void OnNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (String.IsNullOrEmpty(incrementDataRequest.Content.TableName) == false)
            {
                String sql = "select IdTable from FtsIncrement where TableName = :TableName";
                Int16 idTable = LazyConvert.ToInt16(this.Database.QueryValue(sql, new Object[] { incrementDataRequest.Content.TableName }, new String[] { "TableName" }));

                String[] keyFields = new String[incrementDataRequest.Content.IncrementKeyFields.Length + 1];
                keyFields[0] = "IdTable";
                incrementDataRequest.Content.IncrementKeyFields.CopyTo(keyFields, 1);

                Object[] keyValues = new Object[incrementDataRequest.Content.IncrementKeyValues.Length + 1];
                keyValues[0] = idTable;
                incrementDataRequest.Content.IncrementKeyValues.CopyTo(keyValues, 1);

                incrementDataResponse.Content.Ids = this.Database.IncrementRange(
                    incrementDataRequest.Content.IncrementTableName, keyFields, keyValues, incrementDataRequest.Content.IncrementField, incrementDataRequest.Content.Range);
            }
            else
            {
                incrementDataResponse.Content.Ids = this.Database.IncrementRange(
                    incrementDataRequest.Content.IncrementTableName, incrementDataRequest.Content.IncrementKeyFields, incrementDataRequest.Content.IncrementKeyValues, incrementDataRequest.Content.IncrementField, incrementDataRequest.Content.Range);
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
