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
                this.scope = new FwkDataViewRequestScope();
                this.content = new FwkDataViewRequestContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataViewRequestScope Scope
        {
            get { return (FwkDataViewRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataViewRequestContent Content
        {
            get { return (FwkDataViewRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataViewRequestScope : FwkDataBasicRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewRequestScope()
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

        [JsonConverter(typeof(LazyJsonConverterDataSet))]
        public DataSet DataSet { get; set; }

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
                this.scope = new FwkDataViewResponseScope();
                this.content = new FwkDataViewResponseContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataViewResponseScope Scope
        {
            get { return (FwkDataViewResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataViewResponseContent Content
        {
            get { return (FwkDataViewResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataViewResponseScope : FwkDataBasicResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataViewResponseScope()
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
