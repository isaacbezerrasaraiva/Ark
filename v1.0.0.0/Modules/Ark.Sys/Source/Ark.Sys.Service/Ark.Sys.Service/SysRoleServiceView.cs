// SysRoleServiceView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 03

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
    public class SysRoleServiceView : FwkServiceView, ISysRoleServiceView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleServiceView(FwkEnvironment environment)
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
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected override void OnFormat(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
            dataViewResponse.Content.Format.SetTable("FwkRole");

            dataViewResponse.Content.Format.SetField("IdDomain");
            dataViewResponse.Content.Format.SetFieldAttributes(typeof(Int16), LibGlobalization.GetTranslation(Properties.SysResourcesService.SysCaptionIdDomain, this.Environment.Culture),
                visible: FwkBooleanEnum.False, constraint: FwkConstraintEnum.ParentKey);
            dataViewResponse.Content.Format.SetFieldValidation(new FwkFormatViewFieldValidationAllowedValues(this.Environment.Culture, new Object[] { this.Environment.Domain.IdDomain }));

            dataViewResponse.Content.Format.SetField("IdRole");
            dataViewResponse.Content.Format.SetFieldAttributes(typeof(Int16), LibGlobalization.GetTranslation(Properties.SysResourcesService.SysCaptionIdRole, this.Environment.Culture),
                visible: FwkBooleanEnum.False, constraint: FwkConstraintEnum.PrimaryKey);

            dataViewResponse.Content.Format.SetField("Name");
            dataViewResponse.Content.Format.SetFieldAttributes(typeof(String), LibGlobalization.GetTranslation(Properties.SysResourcesService.SysCaptionName, this.Environment.Culture),
                visible: FwkBooleanEnum.True, constraint: FwkConstraintEnum.None);
            dataViewResponse.Content.Format.SetFieldTransformation(new FwkFormatViewFieldTransformationTruncate(32));
        }

        /// <summary>
        /// OnValidateRead
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected override void OnValidateRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// OnRead
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected override void OnRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
            DataTable dataTableRole = dataViewRequest.Content.DataSet.Tables["FwkRole"];
            dataTableRole.PrimaryKey = new DataColumn[] { dataTableRole.Columns["IdDomain"] };
            dataTableRole = this.Database.SelectAll("FwkRole", dataTableRole);

            dataViewResponse.Content.DataSet = new DataSet();
            dataViewResponse.Content.DataSet.Tables.Add(dataTableRole);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
