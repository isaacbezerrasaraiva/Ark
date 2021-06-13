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
            AppDomain.CurrentDomain.AssemblyResolve += LibAssemblyResolve.Resolve;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
