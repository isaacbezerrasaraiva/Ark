// LibTimerData.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 17

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Collections.Generic;

using Lazy;

namespace Ark.Lib
{
    public class LibTimerData
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public LibTimerData()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Boolean ServerEnabled { get; set; }

        public String ServerName { get; set; }

        public String ServerAssembly { get; set; }

        public String ServerClass { get; set; }

        public Boolean InstanceEnabled { get; set; }

        public String InstanceName { get; set; }

        public Int32 InstanceDelay { get; set; }

        public Int32 InstanceInterval { get; set; }

        public Boolean InstanceLogEnabled { get; set; }

        public String InstanceLogPath { get; set; }

        public String InstanceParameter { get; set; }

        #endregion Properties
    }
}
