// SysDataCors.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
//using Ark.Fts;
//using Ark.Fts.Data;
using Ark.Sys;

namespace Ark.Sys.Data
{
    public class SysDataCorsRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataCorsRequest()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysDataCorsResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataCorsResponse()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        
        public SysPreflightResponse PreflightResponse { get; set; }

        #endregion Properties
    }
}
