// FwkService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;
//using Lazy.Database;
//using Lazy.Database.Db2;
//using Lazy.Database.MySql;
//using Lazy.Database.Oracle;
//using Lazy.Database.Postgre;
//using Lazy.Database.SqlServer;

using Ark.Lib;
//using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;

namespace Ark.Fwk.Service
{
    public class FwkService : IFwkService
    {
        #region Variables

        protected List<IFwkPlugin> iPluginList;

        #endregion Variables

        #region Constructors

        public FwkService()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
