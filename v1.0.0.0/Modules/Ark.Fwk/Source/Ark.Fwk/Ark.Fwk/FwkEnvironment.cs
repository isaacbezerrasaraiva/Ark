// FwkEnvironment.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 01

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;

namespace Ark.Fwk
{
    public class FwkEnvironment
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkEnvironment()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkDomain Domain { get; set; }

        public FwkUser User { get; set; }

        public FwkUserContext UserContext { get; set; }

        public LibCulture Culture { get; set; }

        #endregion Properties
    }
}