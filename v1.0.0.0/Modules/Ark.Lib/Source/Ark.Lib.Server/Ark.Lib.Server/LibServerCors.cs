// LibServerCors.cs
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
    public class LibServerCors
    {
        #region Variables

        private readonly RequestDelegate next;
        private static ILibServerCors iServerCors;

        #endregion Variables

        #region Constructors

        public LibServerCors(RequestDelegate next)
        {
            this.next = next;

            if (iServerCors == null)
            {
                String corsAssembly = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Cors"].Attribute["Assembly"];
                String corsClass = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Cors"].Attribute["Class"];

                if (String.IsNullOrEmpty(corsAssembly) == false && String.IsNullOrEmpty(corsClass) == false)
                {
                    iServerCors = (ILibServerCors)Activator.CreateInstance(
                        Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin", corsAssembly)).GetType(corsClass));
                }
            }
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            if (iServerCors != null)
                iServerCors.Preflight(context);

            await this.next(context);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}