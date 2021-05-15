// FwkServantProcess.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 15

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
    public class FwkServantProcess : FwkServantBasic, IFwkServiceProcess
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServantProcess(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Next process step data
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataProcessResponse Next(FwkDataProcessRequest dataProcessRequest)
        {
            return (FwkDataProcessResponse)InvokeService("Next", dataProcessRequest);
        }

        /// <summary>
        /// Execute the process
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataProcessResponse Execute(FwkDataProcessRequest dataProcessRequest)
        {
            return (FwkDataProcessResponse)InvokeService("Execute", dataProcessRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
