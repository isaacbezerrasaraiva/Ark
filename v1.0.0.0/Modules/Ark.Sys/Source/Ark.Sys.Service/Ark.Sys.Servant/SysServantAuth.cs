// SysServantAuth.cs
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
//using Ark.Fts;
//using Ark.Fts.Data;
//using Ark.Fts.IService;
//using Ark.Fts.Servant;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IService;

namespace Ark.Sys.Servant
{
    public class SysServantAuth : FwkServant, ISysServiceAuth
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysServantAuth(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysDataAuthResponse Authenticate(SysDataAuthRequest dataAuthRequest)
        {
            return (SysDataAuthResponse)InvokeService("Authenticate", dataAuthRequest);
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="dataAuthRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysDataAuthResponse Authorize(SysDataAuthRequest dataAuthRequest)
        {
            return (SysDataAuthResponse)InvokeService("Authorize", dataAuthRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
