// SysServantPreflight.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

using System;
using System.Xml;
using System.Data;
using System.Reflection;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IService;
using Ark.Fwk.Servant;
//using Ark.Fts;
//using Ark.Fts.Data;
//using Ark.Fts.IService;
//using Ark.Fts.Servant;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IService;

namespace Ark.Sys.Servant
{
    public class SysServantPreflight : FwkServant, ISysServicePreflight
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServantPreflight(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="dataPreflightRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysDataPreflightResponse Preflight(SysDataPreflightRequest dataPreflightRequest)
        {
            return (SysDataPreflightResponse)InvokeService("Preflight", dataPreflightRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
