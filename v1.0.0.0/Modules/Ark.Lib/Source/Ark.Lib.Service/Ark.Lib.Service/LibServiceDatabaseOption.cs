// LibServiceDatabaseOption.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 12

using System;
using System.IO;
using System.Xml;
using System.Data;

namespace Ark.Lib
{
    public class LibServiceDatabaseOption
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public LibServiceDatabaseOption()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Alias { get; set; }

        public String Dbms { get; set; }

        public String Assembly { get; set; }

        public String Class { get; set; }

        public String ConnectionString { get; set; }

        #endregion Properties
    }
}