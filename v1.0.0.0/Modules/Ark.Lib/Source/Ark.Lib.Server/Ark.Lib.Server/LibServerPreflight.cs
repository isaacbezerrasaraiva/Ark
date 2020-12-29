// LibServerPreflight.cs
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
    public class LibServerPreflight
    {
        #region Variables

        private readonly RequestDelegate next;
        private static ILibServerPreflight iServerPreflight;

        #endregion Variables

        #region Constructors

        public LibServerPreflight(RequestDelegate next)
        {
            this.next = next;

            if (iServerPreflight == null)
            {
                String assemblyFolderName = LibServerConfiguration.DynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Assembly"].Replace(".dll", String.Empty);
                String assemblyFileName = LibServerConfiguration.DynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Assembly"];
                String classFullName = LibServerConfiguration.DynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Class"];

                if (String.IsNullOrEmpty(assemblyFileName) == false && String.IsNullOrEmpty(classFullName) == false)
                {
                    iServerPreflight = (ILibServerPreflight)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFileName),
                        classFullName);
                }
            }
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            if (iServerPreflight != null)
                iServerPreflight.Preflight(context);

            await this.next(context);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}