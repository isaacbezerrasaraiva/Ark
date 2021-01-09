// FwkServant.cs
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

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IService;

namespace Ark.Fwk.Servant
{
    public class FwkServant : IFwkService
    {
        #region Variables

        private IFwkService iService;

        #endregion Variables

        #region Constructors

        public FwkServant(FwkEnvironment environment)
        {
            #region Create service

            String assemblyFolderName = this.GetType().Namespace.Replace("Servant", "Service");
            String classFullName = this.GetType().FullName.Replace("Servant", "Service");

            this.iService = (IFwkService)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName, new Object[] { environment });

            #endregion Create service
        }

        #endregion Constructors

        #region Methods

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
