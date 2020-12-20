// Program.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 14

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Ark.Lib;

namespace Ark.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += ArkAssemblyResolve;

            CreateHostBuilder(args).Build().Run();
        }

        private static Assembly ArkAssemblyResolve(Object sender, ResolveEventArgs args)
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

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
