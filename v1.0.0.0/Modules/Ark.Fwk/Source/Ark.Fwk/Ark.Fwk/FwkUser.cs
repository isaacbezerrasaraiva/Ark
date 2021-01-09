// FwkUser.cs
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
    public class FwkUser
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkUser()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int16 IdDomain { get; set; }

        public Int32 IdUser { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        public String DisplayName { get; set; }

        #endregion Properties
    }
}