// LibAssemblyResolve.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, June 13

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;

using Lazy;

namespace Ark.Lib
{
    public static class LibAssemblyResolve
    {
        #region Variables
        #endregion Variables

        #region Methods

        public static Assembly Resolve(Object sender, ResolveEventArgs args)
        {
            String assemblyFolderName = args.Name.Substring(0, args.Name.IndexOf(','));
            String assemblyVersion = args.Name.Substring(args.Name.IndexOf("Version=") + 8);
            assemblyVersion = assemblyVersion.Substring(0, assemblyVersion.IndexOf(','));
            assemblyVersion = assemblyVersion.Substring(0, assemblyVersion.LastIndexOf('.'));
            String assemblyPath = null;

            if (Directory.Exists(Path.Combine(LibDirectory.Root.Bin.Path, assemblyFolderName)) == true)
            {
                assemblyPath = Path.Combine(LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[assemblyVersion].Lib.NetCoreApp31.Path, assemblyFolderName) + ".dll";

                if (File.Exists(assemblyPath) == true)
                {
                    return Assembly.LoadFrom(assemblyPath);
                }
                else
                {
                    assemblyPath = Path.Combine(LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[assemblyVersion].Lib.NetStandard20.Path, assemblyFolderName) + ".dll";

                    if (File.Exists(assemblyPath) == true)
                    {
                        return Assembly.LoadFrom(assemblyPath);
                    }
                }
            }

            return null;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
