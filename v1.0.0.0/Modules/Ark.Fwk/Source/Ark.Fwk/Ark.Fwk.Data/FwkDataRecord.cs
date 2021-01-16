// FwkDataRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Lazy;
using Lazy.Json;

using Ark.Lib;
using Ark.Fwk;

namespace Ark.Fwk.Data
{
    public class FwkDataRecordRequest : FwkDataBasicRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRecordRequest()
        {
            if (this.GetType() == typeof(FwkDataRecordRequest))
            {
                this.scope = new FwkDataRecordRequestScope();
                this.content = new FwkDataRecordRequestContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataRecordRequestScope Scope
        {
            get { return (FwkDataRecordRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataRecordRequestContent Content
        {
            get { return (FwkDataRecordRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataRecordRequestScope : FwkDataBasicRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRecordRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Boolean ReturnRecords { get; set; }

        #endregion Properties
    }

    public class FwkDataRecordRequestContent : FwkDataBasicRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRecordRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        [JsonConverter(typeof(LazyJsonConverterDataSet))]
        public DataSet DataSet { get; set; }

        #endregion Properties
    }

    public class FwkDataRecordResponse : FwkDataBasicResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRecordResponse()
        {
            if (this.GetType() == typeof(FwkDataRecordResponse))
            {
                this.scope = new FwkDataRecordResponseScope();
                this.content = new FwkDataRecordResponseContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataRecordResponseScope Scope
        {
            get { return (FwkDataRecordResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataRecordResponseContent Content
        {
            get { return (FwkDataRecordResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataRecordResponseScope : FwkDataBasicResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRecordResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int32? RecordsAffected { get; set; }

        #endregion Properties
    }

    public class FwkDataRecordResponseContent : FwkDataBasicResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRecordResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        [JsonConverter(typeof(LazyJsonConverterDataSet))]
        public DataSet DataSet { get; set; }

        #endregion Properties
    }
}
