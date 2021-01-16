// SysAuthServant.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

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
    public class SysAuthServant : FwkServant, ISysAuthService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthServant(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysAuthDataResponse Authenticate(SysAuthDataRequest authDataRequest)
        {
            return (SysAuthDataResponse)InvokeService("Authenticate", authDataRequest);
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="authDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysAuthDataResponse Authorize(SysAuthDataRequest authDataRequest)
        {
            return (SysAuthDataResponse)InvokeService("Authorize", authDataRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
