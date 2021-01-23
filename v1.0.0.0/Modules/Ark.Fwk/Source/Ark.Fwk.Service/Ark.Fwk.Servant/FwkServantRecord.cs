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

        public FwkServantRecord(FwkEnvironment environment)
            : base(environment)
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
        /// Validate Read the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateRead(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("ValidateRead", dataRecordRequest);
        }

        /// <summary>
        /// Validate Insert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateInsert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("ValidateInsert", dataRecordRequest);
        }

        /// <summary>
        /// Validate Indate the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateIndate(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("ValidateIndate", dataRecordRequest);
        }

        /// <summary>
        /// Validate Update the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateUpdate(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("ValidateUpdate", dataRecordRequest);
        }

        /// <summary>
        /// Validate Upsert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateUpsert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("ValidateUpsert", dataRecordRequest);
        }

        /// <summary>
        /// Validate Delete the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateDelete(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("ValidateDelete", dataRecordRequest);
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
        /// Indate the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Indate(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeService("Indate", dataRecordRequest);
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
