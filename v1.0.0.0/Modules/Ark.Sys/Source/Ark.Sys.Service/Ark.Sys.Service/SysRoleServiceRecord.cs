// SysRoleServiceRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 18

using System;
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
using Ark.Fwk.Service;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IPlugin;
using Ark.Fts.IService;
using Ark.Fts.Service;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IPlugin;
using Ark.Sys.IService;

namespace Ark.Sys.Service
{
    public class SysRoleServiceRecord : FwkServiceRecord, ISysRoleServiceRecord
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleServiceRecord(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected override void OnLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
            base.OnLoad(dataBasicRequest, dataBasicResponse);
        }

        /// <summary>
        /// OnFormat
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnFormat(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            base.OnFormat(dataRecordRequest, dataRecordResponse);
        }

        /// <summary>
        /// OnValidateRead
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnValidateRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            if (dataRecordRequest.Content.DataSet.Tables.Contains("FwkRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissing, Properties.SysResourcesService.SysCaptionDataTableMissing);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count == 0)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingRows, Properties.SysResourcesService.SysCaptionDataTableMissingRow);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdDomain") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdDomain, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdRole, Properties.SysResourcesService.SysCaptionDataTableMissingField);
        }

        /// <summary>
        /// OnValidateInsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnValidateInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            if (dataRecordRequest.Content.DataSet.Tables.Contains("FwkRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissing, Properties.SysResourcesService.SysCaptionDataTableMissing);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count == 0)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingRows, Properties.SysResourcesService.SysCaptionDataTableMissingRow);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdDomain") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdDomain, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("Name") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldName, Properties.SysResourcesService.SysCaptionDataTableMissingField);
        }

        /// <summary>
        /// OnValidateIndate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnValidateIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            if (dataRecordRequest.Content.DataSet.Tables.Contains("FwkRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissing, Properties.SysResourcesService.SysCaptionDataTableMissing);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count == 0)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingRows, Properties.SysResourcesService.SysCaptionDataTableMissingRow);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdDomain") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdDomain, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdRole, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("Name") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldName, Properties.SysResourcesService.SysCaptionDataTableMissingField);
        }

        /// <summary>
        /// OnValidateUpdate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnValidateUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            if (dataRecordRequest.Content.DataSet.Tables.Contains("FwkRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissing, Properties.SysResourcesService.SysCaptionDataTableMissing);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count == 0)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingRows, Properties.SysResourcesService.SysCaptionDataTableMissingRow);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdDomain") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdDomain, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdRole, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("Name") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldName, Properties.SysResourcesService.SysCaptionDataTableMissingField);
        }

        /// <summary>
        /// OnValidateUpsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnValidateUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            if (dataRecordRequest.Content.DataSet.Tables.Contains("FwkRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissing, Properties.SysResourcesService.SysCaptionDataTableMissing);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count == 0)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingRows, Properties.SysResourcesService.SysCaptionDataTableMissingRow);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdDomain") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdDomain, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdRole, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("Name") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldName, Properties.SysResourcesService.SysCaptionDataTableMissingField);
        }

        /// <summary>
        /// OnValidateDelete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnValidateDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            if (dataRecordRequest.Content.DataSet.Tables.Contains("FwkRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissing, Properties.SysResourcesService.SysCaptionDataTableMissing);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count == 0)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingRows, Properties.SysResourcesService.SysCaptionDataTableMissingRow);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdDomain") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdDomain, Properties.SysResourcesService.SysCaptionDataTableMissingField);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdRole") == false)
                throw new LibException(Properties.SysResourcesService.SysExceptionDataTableRoleMissingFieldIdRole, Properties.SysResourcesService.SysCaptionDataTableMissingField);
        }

        /// <summary>
        /// OnRead
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnRead(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            DataTable dataTableRole = dataRecordRequest.Content.DataSet.Tables["FwkRole"];
            dataTableRole.PrimaryKey = new DataColumn[] { dataTableRole.Columns["IdDomain"], dataTableRole.Columns["IdRole"] };
            dataTableRole = this.Database.SelectAll("FwkRole", dataTableRole);

            dataRecordResponse.Content.DataSet = new DataSet();
            dataRecordResponse.Content.DataSet.Tables.Add(dataTableRole);
        }

        /// <summary>
        /// OnInsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnInsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            #region Generate increment IdRole

            FtsIncrementDataRequest incrementDataRequest = new FtsIncrementDataRequest();
            incrementDataRequest.Content.TableName = "FwkRole";
            incrementDataRequest.Content.ControllerTableName = "FtsIncrementByDomain";
            incrementDataRequest.Content.ControllerTableKeyFields = new Dictionary<String, Object>();
            incrementDataRequest.Content.ControllerTableKeyFields.Add("IdDomain", this.Environment.Domain.IdDomain);
            incrementDataRequest.Content.ControllerTableField = "IdLastIncrement";
            incrementDataRequest.Content.Range = dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count;

            FtsIncrementService incrementService = new FtsIncrementService(this.Environment);
            FtsIncrementDataResponse incrementDataResponse = incrementService.Next(incrementDataRequest);

            if (dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Contains("IdRole") == false)
            {
                dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns.Add(new DataColumn("IdRole", typeof(Int32)));
                dataRecordRequest.Content.DataSet.Tables["FwkRole"].Columns["IdRole"].SetOrdinal(1);
            }

            for (int i = 0; i < dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows.Count; i++)
                dataRecordRequest.Content.DataSet.Tables["FwkRole"].Rows[i]["IdRole"] = incrementDataResponse.Content.Ids[i];

            #endregion Generate increment IdRole

            DataTable dataTableRole = dataRecordRequest.Content.DataSet.Tables["FwkRole"];
            dataTableRole.PrimaryKey = new DataColumn[] { dataTableRole.Columns["IdDomain"], dataTableRole.Columns["IdRole"] };
            dataRecordResponse.Scope.RecordsAffected = this.Database.InsertAll("FwkRole", dataTableRole);

            dataTableRole.AcceptChanges();
            dataTableRole = this.Database.SelectAll("FwkRole", dataTableRole);

            dataRecordResponse.Content.DataSet = new DataSet();
            dataRecordResponse.Content.DataSet.Tables.Add(dataTableRole);
        }

        /// <summary>
        /// OnIndate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnIndate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            DataTable dataTableRole = dataRecordRequest.Content.DataSet.Tables["FwkRole"];
            dataTableRole.PrimaryKey = new DataColumn[] { dataTableRole.Columns["IdDomain"], dataTableRole.Columns["IdRole"] };
            dataRecordResponse.Scope.RecordsAffected = this.Database.IndateAll("FwkRole", dataTableRole);

            dataTableRole.AcceptChanges();
            dataTableRole = this.Database.SelectAll("FwkRole", dataTableRole);

            dataRecordResponse.Content.DataSet = new DataSet();
            dataRecordResponse.Content.DataSet.Tables.Add(dataTableRole);
        }

        /// <summary>
        /// OnUpdate
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnUpdate(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            DataTable dataTableRole = dataRecordRequest.Content.DataSet.Tables["FwkRole"];
            dataTableRole.PrimaryKey = new DataColumn[] { dataTableRole.Columns["IdDomain"], dataTableRole.Columns["IdRole"] };
            dataRecordResponse.Scope.RecordsAffected = this.Database.UpdateAll("FwkRole", dataTableRole);

            dataTableRole.AcceptChanges();
            dataTableRole = this.Database.SelectAll("FwkRole", dataTableRole);

            dataRecordResponse.Content.DataSet = new DataSet();
            dataRecordResponse.Content.DataSet.Tables.Add(dataTableRole);
        }

        /// <summary>
        /// OnUpsert
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnUpsert(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            DataTable dataTableRole = dataRecordRequest.Content.DataSet.Tables["FwkRole"];
            dataTableRole.PrimaryKey = new DataColumn[] { dataTableRole.Columns["IdDomain"], dataTableRole.Columns["IdRole"] };
            dataRecordResponse.Scope.RecordsAffected = this.Database.UpsertAll("FwkRole", dataTableRole);

            dataTableRole.AcceptChanges();
            dataTableRole = this.Database.SelectAll("FwkRole", dataTableRole);

            dataRecordResponse.Content.DataSet = new DataSet();
            dataRecordResponse.Content.DataSet.Tables.Add(dataTableRole);
        }

        /// <summary>
        /// OnDelete
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <param name="dataRecordResponse">The response data</param>
        protected override void OnDelete(FwkDataRecordRequest dataRecordRequest, FwkDataRecordResponse dataRecordResponse)
        {
            DataTable dataTableRole = dataRecordRequest.Content.DataSet.Tables["FwkRole"];
            dataTableRole.PrimaryKey = new DataColumn[] { dataTableRole.Columns["IdDomain"], dataTableRole.Columns["IdRole"] };
            dataRecordResponse.Scope.RecordsAffected = this.Database.DeleteAll("FwkRole", dataTableRole);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
