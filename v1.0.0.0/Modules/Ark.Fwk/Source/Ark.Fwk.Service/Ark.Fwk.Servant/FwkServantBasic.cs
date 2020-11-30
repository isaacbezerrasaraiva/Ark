// FwkServantBasic.cs
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

namespace Ark.Fwk.Servant
{
    public class FwkServantBasic : FwkServant, IFwkServiceBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServantBasic()
        {
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            return (FwkDataBasicResponse)InvokeService("Init", dataBasicRequest);
        }
        
        /// <summary>
        /// Load the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataBasicResponse Load(FwkDataBasicRequest dataBasicRequest)
        {
            return (FwkDataBasicResponse)InvokeService("Load", dataBasicRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
