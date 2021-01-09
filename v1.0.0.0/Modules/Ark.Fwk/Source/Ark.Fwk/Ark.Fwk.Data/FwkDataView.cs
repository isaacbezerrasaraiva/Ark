// FwkDataView.cs
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
    public class FwkDataViewRequest : FwkDataBasicRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewRequest()
        {
            if (this.GetType() == typeof(FwkDataViewRequest))
            {
                this.header = new FwkDataViewRequestHeader();
                this.content = new FwkDataViewRequestContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataViewRequestHeader Header
        {
            get { return (FwkDataViewRequestHeader)this.header; }
            set { this.header = value; }
        }

        public new FwkDataViewRequestContent Content
        {
            get { return (FwkDataViewRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataViewRequestHeader : FwkDataBasicRequestHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewRequestHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataViewRequestContent : FwkDataBasicRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Dictionary<String, Object> ParentKey { get; set; }

        #endregion Properties
    }

    public class FwkDataViewResponse : FwkDataBasicResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewResponse()
        {
            if (this.GetType() == typeof(FwkDataViewResponse))
            {
                this.header = new FwkDataViewResponseHeader();
                this.content = new FwkDataViewResponseContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataViewResponseHeader Header
        {
            get { return (FwkDataViewResponseHeader)this.header; }
            set { this.header = value; }
        }

        public new FwkDataViewResponseContent Content
        {
            get { return (FwkDataViewResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataViewResponseHeader : FwkDataBasicResponseHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewResponseHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataViewResponseContent : FwkDataBasicResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewResponseContent()
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
