// LibServerAuthorization.cs
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

using Microsoft.AspNetCore.Mvc.Filters;

using Lazy;

using Ark.Lib;

namespace Ark.Lib.Server
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LibServerAuthorization : Attribute, IAuthorizationFilter
    {
        #region Variables

        private static ILibServerAuthorization iServerAuthorization;

        #endregion Variables

        #region Constructors

        public LibServerAuthorization()
        {
            if (iServerAuthorization == null)
            {
                String assemblyFolderName = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authorization"].Attribute["Assembly"].Replace(".dll", String.Empty);
                String assemblyFileName = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authorization"].Attribute["Assembly"];
                String classFullName = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authorization"].Attribute["Class"];

                if (String.IsNullOrEmpty(assemblyFileName) == false && String.IsNullOrEmpty(classFullName) == false)
                {
                    iServerAuthorization = (ILibServerAuthorization)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFileName),
                        classFullName);
                }
            }
        }

        #endregion Constructors

        #region Methods

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (iServerAuthorization != null)
                iServerAuthorization.Authorize(context);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}