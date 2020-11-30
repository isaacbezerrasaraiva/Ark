// SysDataAuth.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

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
    public class SysDataAuthRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthRequest()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public SysAuthenticationRequest AuthenticationRequest { get; set; }

        #endregion Properties
    }

    public class SysDataAuthResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthResponse()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public SysAuthenticationResponse AuthenticationResponse { get; set; }

        #endregion Properties
    }
}
