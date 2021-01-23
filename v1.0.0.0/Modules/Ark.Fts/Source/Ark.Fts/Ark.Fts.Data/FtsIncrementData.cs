// FtsIncrementData.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fts;

namespace Ark.Fts.Data
{
    public class FtsIncrementDataRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataRequest()
        {
            this.scope = new FtsIncrementDataRequestScope();
            this.content = new FtsIncrementDataRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FtsIncrementDataRequestScope Scope
        {
            get { return (FtsIncrementDataRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new FtsIncrementDataRequestContent Content
        {
            get { return (FtsIncrementDataRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FtsIncrementDataRequestScope : FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FtsIncrementDataRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int16 IdTable { get; set; }

        public String TableName { get; set; }

        public String ControllerTableName { get; set; }

        public Dictionary<String,Object> ControllerTableKeyFields { get; set; }

        public String ControllerTableField { get; set; }

        public Int32 Range { get; set; }

        #endregion Properties
    }

    public class FtsIncrementDataResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataResponse()
        {
            this.scope = new FtsIncrementDataResponseScope();
            this.content = new FtsIncrementDataResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FtsIncrementDataResponseScope Scope
        {
            get { return (FtsIncrementDataResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new FtsIncrementDataResponseContent Content
        {
            get { return (FtsIncrementDataResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FtsIncrementDataResponseScope : FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FtsIncrementDataResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int32[] Ids { get; set; }

        #endregion Properties
    }
}
