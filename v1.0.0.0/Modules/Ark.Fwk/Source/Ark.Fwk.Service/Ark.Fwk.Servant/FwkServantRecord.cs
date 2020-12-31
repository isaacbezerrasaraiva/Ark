// FwkServantRecord.cs
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
    public class FwkServantRecord : FwkServantBasic, IFwkServiceRecord
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServantRecord()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Format the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Format(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("Format", dataRecordRequest);
        }

        /// <summary>
        /// Read the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Read(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("Read", dataRecordRequest);
        }

        /// <summary>
        /// Insert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Insert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("Insert", dataRecordRequest);
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Update(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("Update", dataRecordRequest);
        }

        /// <summary>
        /// Upsert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Upsert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("Upsert", dataRecordRequest);
        }

        /// <summary>
        /// Delete the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Delete(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("Delete", dataRecordRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
