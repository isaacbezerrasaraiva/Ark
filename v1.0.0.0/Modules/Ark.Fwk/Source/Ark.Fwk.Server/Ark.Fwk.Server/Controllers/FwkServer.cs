﻿// FwkServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

using System;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Lazy;

using Ark.Lib;
using Ark.Lib.Server;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IServer;
using Ark.Fwk.IService;

namespace Ark.Fwk.Server
{
    [ApiController]
    [Route("Ark.Fwk/[controller]")]
    public class FwkServer : ControllerBase, IFwkServer
    {
        #region Variables
        
        private Type typeDataRequest;
        private Type typeDataResponse;

        private IFwkService iService;

        #endregion Variables

        #region Constructors

        public FwkServer()
        {
            #region Create data types
            
            Assembly assembly = Assembly.LoadFrom(LibDirectory.Root.Bin.Path + this.GetType().Namespace.Replace("Server", "Data") + ".dll");
            
            this.typeDataRequest = assembly.GetType(this.GetType().FullName.Replace("Server", "Data") + "Request");
            this.typeDataResponse = assembly.GetType(this.GetType().FullName.Replace("Server", "Data") + "Response");
            
            assembly = null;
            
            #endregion Create data types
            
            #region Create service
            
            String classFullName = this.GetType().FullName.Replace("Server", "Service");
            String assemblyPath = LibDirectory.Root.Bin.Path + this.GetType().Namespace.Replace("Server", "Service") + ".dll";
            
            this.iService = (IFwkService)LazyActivator.Local.CreateInstance(assemblyPath, classFullName);
            
            #endregion Create service
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequestString">The service method request data string</param>
        /// <returns>The service method response data string</returns>
        protected String InvokeService(String methodName, String dataRequestString)
        {
            MethodInfo methodInfo = this.iService.GetType().GetMethod(methodName);
            Object dataRequest = JsonConvert.DeserializeObject(dataRequestString, this.typeDataRequest);
            Object dataResponse = methodInfo.Invoke(this.iService, new Object[] { dataRequest });
            return (String)JsonConvert.SerializeObject(dataResponse, this.typeDataResponse, null);
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequest">The service method request data</param>
        /// <returns>The service method response data</returns>
        protected FwkDataResponse InvokeService(String methodName, FwkDataRequest dataRequest)
        {
            MethodInfo methodInfo = this.iService.GetType().GetMethod(methodName);
            return (FwkDataResponse)methodInfo.Invoke(this.iService, new Object[] { dataRequest });
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
