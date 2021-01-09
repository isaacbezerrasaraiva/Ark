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
