// FwkServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

        private IFwkService iService;

        #endregion Variables

        #region Constructors

        public FwkServer()
        {
            if (this.GetType() == typeof(FwkServer))
            {
                this.DataRequestType = typeof(FwkDataRequest);
                this.DataResponseType = typeof(FwkDataResponse);
            }
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
            return InvokeService(methodName, dataRequestString, this.HttpContext);
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequestString">The service method request data string</param>
        /// <param name="context">The http context</param>
        /// <returns>The service method response data string</returns>
        protected String InvokeService(String methodName, String dataRequestString, HttpContext context)
        {
            CreateService(CreateEnvironment(context));

            MethodInfo methodInfo = this.iService.GetType().GetMethod(methodName);
            Object dataRequest = JsonConvert.DeserializeObject(dataRequestString, this.DataRequestType, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            Object dataResponse = methodInfo.Invoke(this.iService, new Object[] { dataRequest });
            return (String)JsonConvert.SerializeObject(dataResponse, this.DataResponseType, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequest">The service method request data</param>
        /// <returns>The service method response data</returns>
        protected FwkDataResponse InvokeService(String methodName, FwkDataRequest dataRequest)
        {
            return InvokeService(methodName, dataRequest, this.HttpContext);
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequest">The service method request data</param>
        /// <param name="context">The http context</param>
        /// <returns>The service method response data</returns>
        protected FwkDataResponse InvokeService(String methodName, FwkDataRequest dataRequest, HttpContext context)
        {
            CreateService(CreateEnvironment(context));

            MethodInfo methodInfo = this.iService.GetType().GetMethod(methodName);
            return (FwkDataResponse)methodInfo.Invoke(this.iService, new Object[] { dataRequest });
        }

        /// <summary>
        /// Create environment
        /// </summary>
        /// <param name="context"></param>
        private FwkEnvironment CreateEnvironment(HttpContext context)
        {
            FwkEnvironment environment = new FwkEnvironment();

            if (context.Items.ContainsKey("IdDomain") == true)
            {
                environment.Domain = new FwkDomain();
                environment.Domain.IdDomain = LazyConvert.ToInt16(context.Items["IdDomain"]);

                if (context.Items.ContainsKey("IdUser") == true)
                {
                    environment.User = new FwkUser();
                    environment.User.IdDomain = environment.Domain.IdDomain;
                    environment.User.IdUser = LazyConvert.ToInt32(context.Items["IdUser"]);

                    environment.UserContext = new FwkUserContext();
                    environment.UserContext["IdDomain"].ValueInt16 = environment.Domain.IdDomain;
                }
            }

            return environment;
        }

        /// <summary>
        /// Create service
        /// </summary>
        /// <param name="context">The http context</param>
        private void CreateService(FwkEnvironment environment)
        {
            String assemblyFolderName = String.Empty;
            String classFullName = String.Empty;

            assemblyFolderName = this.GetType().Namespace.Replace("Server", "Service");
            classFullName = this.GetType().FullName.Replace("Server", "Service");

            this.iService = (IFwkService)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName, new Object[] { environment });
        }

        #endregion Methods

        #region Properties

        protected Type DataRequestType { get; set; }

        protected Type DataResponseType { get; set; }

        #endregion Properties
    }
}
