// LibPreflightServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Lazy;

using Ark.Lib;

namespace Ark.Lib.Server
{
    public class LibPreflightServer
    {
        #region Variables

        private readonly RequestDelegate next;
        private static ILibPreflightServer iPreflightServer;

        #endregion Variables

        #region Constructors

        public LibPreflightServer(RequestDelegate next)
        {
            this.next = next;

            if (iPreflightServer == null)
            {
                String assemblyFolderName = LibConfigurationServer.DynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Assembly"].Replace(".dll", String.Empty);
                String assemblyFileName = LibConfigurationServer.DynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Assembly"];
                String classFullName = LibConfigurationServer.DynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Class"];

                if (String.IsNullOrEmpty(assemblyFileName) == false && String.IsNullOrEmpty(classFullName) == false)
                {
                    iPreflightServer = (ILibPreflightServer)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFileName),
                        classFullName);
                }
            }
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            if (iPreflightServer != null)
                iPreflightServer.Preflight(context);

            await this.next(context);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}