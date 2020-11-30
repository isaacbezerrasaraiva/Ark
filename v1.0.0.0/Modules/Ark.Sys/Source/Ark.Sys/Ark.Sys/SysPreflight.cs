// SysPreflight.cs
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
    public class SysPreflightResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysPreflightResponse()
        {
            this.Headers = new Dictionary<String, String>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Dictionary<String, String> Headers;

        #endregion Properties
    }
}