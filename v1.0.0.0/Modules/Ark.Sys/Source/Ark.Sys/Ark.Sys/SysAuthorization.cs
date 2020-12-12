// SysAuthorization.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 12

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;
//using Ark.Fwk;
//using Ark.Fts;

namespace Ark.Sys
{
    public class SysAuthorizationRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationRequest()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int32 IdDomain { get; set; }

        public Int32 IdUser { get; set; }

        public String CodModule { get; set; }

        public String CodFeature { get; set; }

        public String CodAction { get; set; }

        #endregion Properties
    }

    public class SysAuthorizationResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationResponse()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Boolean Authorized { get; set; }

        #endregion Properties
    }
}