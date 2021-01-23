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
        /// Validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public FtsIncrementDataResponse ValidateNext(FtsIncrementDataRequest incrementDataRequest)
        {
            FtsIncrementDataResponse incrementDataResponse = (FtsIncrementDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformValidateNext(incrementDataRequest, incrementDataResponse);

            this.Database.CloseConnection();

            return incrementDataResponse;
        }

        /// <summary>
        /// Generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest)
        {
            FtsIncrementDataResponse incrementDataResponse = (FtsIncrementDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformValidateNext(incrementDataRequest, incrementDataResponse);
            PerformNext(incrementDataRequest, incrementDataResponse);

            this.Database.CloseConnection();

            return incrementDataResponse;
        }

        /// <summary>
        /// Perform validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void PerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            BeforePerformValidateNext(incrementDataRequest, incrementDataResponse);

            #region Before OnValidateNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.ValidateNextPluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion Before OnValidateNext plugins

            OnValidateNext(incrementDataRequest, incrementDataResponse);

            #region After OnValidateNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.ValidateNextPluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion After OnValidateNext plugins

            AfterPerformValidateNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Perform generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void PerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            BeforePerformNext(incrementDataRequest, incrementDataResponse);

            #region Before OnNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.NextPluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion Before OnNext plugins

            OnNext(incrementDataRequest, incrementDataResponse);

            #region After OnNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.NextPluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion After OnNext plugins

            AfterPerformNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// On validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (String.IsNullOrEmpty(incrementDataRequest.Content.ControllerTableName) == true)
                throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementControllerTableNameNullOrEmpty, Properties.FtsResourcesService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableKeyFields == null || incrementDataRequest.Content.ControllerTableKeyFields.Count == 0)
                throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementControllerTableKeyFieldsNullOrZeroLenght, Properties.FtsResourcesService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableKeyFields.ContainsKey("IdDomain") == false)
                throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementControllerTableKeyFieldsIdDomainMissing, Properties.FtsResourcesService.FtsCaptionRequiredFieldMissing);

            if (LazyConvert.ToInt16(incrementDataRequest.Content.ControllerTableKeyFields["IdDomain"], -1) != this.Environment.Domain.IdDomain)
                throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementControllerTableKeyFieldsIdDomainInvalid, Properties.FtsResourcesService.FtsCaptionRequiredFieldInvalid);

            if (String.IsNullOrEmpty(incrementDataRequest.Content.ControllerTableField) == true)
                throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementControllerTableFieldNullOrEmpty, Properties.FtsResourcesService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.Range < 1)
                throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementRangeLowerThanOne, Properties.FtsResourcesService.FtsCaptionRequiredFieldInvalid);

            if (String.IsNullOrEmpty(incrementDataRequest.Content.TableName) == false)
            {
                String sql = "select IdTable from FtsIncrementTable where TableName = :TableName";
                incrementDataRequest.Content.IdTable = LazyConvert.ToInt16(this.Database.QueryValue(
                    sql, new Object[] { incrementDataRequest.Content.TableName }, new String[] { "TableName" }), -1);

                if (incrementDataRequest.Content.IdTable == -1)
                    throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementTableNameNotFound, new Object[] { incrementDataRequest.Content.TableName }, Properties.FtsResourcesService.FtsCaptionTableNotFound);
            }
            else
            {
                String sql = "select 1 from FtsIncrementControllerTable where ControllerTableName = :ControllerTableName";
                Boolean isFacilitiesTableStructure = this.Database.QueryFind(sql, new Object[] { incrementDataRequest.Content.ControllerTableName }, new String[] { "ControllerTableName" });

                if (isFacilitiesTableStructure == true)
                    throw new LibException(Properties.FtsResourcesService.FtsExceptionIncrementControllerTableNameFacilitiesStruct, new Object[] { incrementDataRequest.Content.ControllerTableName }, Properties.FtsResourcesService.FtsCaptionRequiredFieldInvalid);
            }
        }

        /// <summary>
        /// On generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (String.IsNullOrEmpty(incrementDataRequest.Content.TableName) == false)
            {
                String[] keyFields = new String[incrementDataRequest.Content.ControllerTableKeyFields.Count + 1];
                keyFields[0] = "IdTable";
                incrementDataRequest.Content.ControllerTableKeyFields.Keys.ToArray<String>().CopyTo(keyFields, 1);

                Object[] keyValues = new Object[incrementDataRequest.Content.ControllerTableKeyFields.Count + 1];
                keyValues[0] = incrementDataRequest.Content.IdTable;
                incrementDataRequest.Content.ControllerTableKeyFields.Values.ToArray<Object>().CopyTo(keyValues, 1);

                incrementDataResponse.Content.Ids = this.Database.IncrementRange(
                    incrementDataRequest.Content.ControllerTableName, 
                    keyFields, 
                    keyValues, 
                    incrementDataRequest.Content.ControllerTableField, 
                    incrementDataRequest.Content.Range);
            }
            else
            {
                incrementDataResponse.Content.Ids = this.Database.IncrementRange(
                    incrementDataRequest.Content.ControllerTableName, 
                    incrementDataRequest.Content.ControllerTableKeyFields.Keys.ToArray<String>(), 
                    incrementDataRequest.Content.ControllerTableKeyFields.Values.ToArray<Object>(), 
                    incrementDataRequest.Content.ControllerTableField, 
                    incrementDataRequest.Content.Range);
            }
        }

        /// <summary>
        /// Before perform validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// Before perform generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
