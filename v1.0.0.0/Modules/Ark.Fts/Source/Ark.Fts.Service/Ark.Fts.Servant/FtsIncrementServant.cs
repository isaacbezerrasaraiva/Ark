// FtsIncrementServant.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

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

namespace Ark.Fts.Servant
{
    public class FtsIncrementServant : FwkServant, IFtsIncrementService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementServant(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse ValidateNext(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeService("ValidateNext", incrementDataRequest);
        }

        /// <summary>
        /// Generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeService("Next", incrementDataRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
