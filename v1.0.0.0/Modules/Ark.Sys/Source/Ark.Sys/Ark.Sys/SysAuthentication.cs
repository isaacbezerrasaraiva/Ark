// SysAuthentication.cs
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
//using Ark.Fwk;
//using Ark.Fts;

namespace Ark.Sys
{
    public class SysAuthenticationRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationRequest()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        
        public String Token { get; set; }
        
        public Int32 IdDomain { get; set; }
        
        public String Credential { get; set; }

        #endregion Properties
    }

    public class SysAuthenticationResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationResponse()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int32 IdDomain { get; set; }

        public Int32 IdUser { get; set; }

        public String Token { get; set; }

        #endregion Properties
    }
}