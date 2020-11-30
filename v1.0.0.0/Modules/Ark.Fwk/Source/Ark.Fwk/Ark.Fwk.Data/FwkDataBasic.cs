// FwkDataBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;

namespace Ark.Fwk.Data
{
    public class FwkDataBasicRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicRequest()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataBasicResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicResponse()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Test { get; set; }

        #endregion Properties
    }
}
