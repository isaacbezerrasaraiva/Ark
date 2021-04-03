// SysLoginServant.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IService;
using Ark.Fts.Servant;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IService;

namespace Ark.Sys.Servant
{
    public class SysLoginServant : FwkServant, ISysLoginService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginServant(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="loginDataRequest">The login request data</param>
        /// <returns>The login response data</returns>
        public SysLoginDataResponse Authenticate(SysLoginDataRequest loginDataRequest)
        {
            return (SysLoginDataResponse)InvokeService("Authenticate", loginDataRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
