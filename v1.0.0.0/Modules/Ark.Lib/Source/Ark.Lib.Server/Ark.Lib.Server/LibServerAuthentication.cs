// LibServerAuthentication.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

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
    public class LibServerAuthentication
    {
        #region Variables

        private readonly RequestDelegate next;
        private static ILibServerAuthentication iServerAuthentication;

        #endregion Variables

        #region Constructors

        public LibServerAuthentication(RequestDelegate next)
        {
            this.next = next;

            if (iServerAuthentication == null)
            {
                String assemblyFolderName = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Assembly"].Replace(".dll", String.Empty);
                String assemblyFileName = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Assembly"];
                String classFullName = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Class"];

                if (String.IsNullOrEmpty(assemblyFileName) == false && String.IsNullOrEmpty(classFullName) == false)
                {
                    iServerAuthentication = (ILibServerAuthentication)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFileName),
                        classFullName);
                }
            }
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            if (iServerAuthentication != null)
                iServerAuthentication.Authenticate(context);

            await this.next(context);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}