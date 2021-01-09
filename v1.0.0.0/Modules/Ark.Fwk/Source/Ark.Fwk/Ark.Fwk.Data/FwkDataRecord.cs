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
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        [JsonConverter(typeof(LazyJsonConverterDataSet))]
        public DataSet DataSet { get; set; }

        public Int32? RowsAffected { get; set; }

        #endregion Properties
    }
}
