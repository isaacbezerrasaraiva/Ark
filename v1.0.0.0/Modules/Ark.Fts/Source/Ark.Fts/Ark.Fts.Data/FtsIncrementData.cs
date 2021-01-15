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
            this.header = new FtsIncrementDataRequestHeader();
            this.content = new FtsIncrementDataRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FtsIncrementDataRequestHeader Header
        {
            get { return (FtsIncrementDataRequestHeader)this.header; }
            set { this.header = value; }
        }

        public new FtsIncrementDataRequestContent Content
        {
            get { return (FtsIncrementDataRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FtsIncrementDataRequestHeader : FwkDataRequestHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataRequestHeader()
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

        public String TableName { get; set; }

        public String IncrementTableName { get; set; }

        public String[] IncrementKeyFields { get; set; }

        public Object[] IncrementKeyValues { get; set; }

        public String IncrementField { get; set; }

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
            this.header = new FtsIncrementDataResponseHeader();
            this.content = new FtsIncrementDataResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FtsIncrementDataResponseHeader Header
        {
            get { return (FtsIncrementDataResponseHeader)this.header; }
            set { this.header = value; }
        }

        public new FtsIncrementDataResponseContent Content
        {
            get { return (FtsIncrementDataResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FtsIncrementDataResponseHeader : FwkDataResponseHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementDataResponseHeader()
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
