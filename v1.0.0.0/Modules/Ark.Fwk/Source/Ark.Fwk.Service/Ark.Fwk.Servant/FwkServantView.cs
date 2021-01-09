// FwkServantView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

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
    public class FwkServantView : FwkServantBasic, IFwkServiceView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServantView(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Format the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Format(FwkDataViewRequest dataViewRequest)
        {
            return (FwkDataViewResponse)InvokeService("Format", dataViewRequest);
        }

        /// <summary>
        /// Read the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Read(FwkDataViewRequest dataViewRequest)
        {
            return (FwkDataViewResponse)InvokeService("Read", dataViewRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
