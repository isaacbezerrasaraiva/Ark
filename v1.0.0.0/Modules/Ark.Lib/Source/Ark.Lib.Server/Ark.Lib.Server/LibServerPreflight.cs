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
                String preflightAssembly = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Preflight"].Attribute["Assembly"];
                String preflightClass = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Preflight"].Attribute["Class"];

                if (String.IsNullOrEmpty(preflightAssembly) == false && String.IsNullOrEmpty(preflightClass) == false)
                {
                    iServerPreflight = (ILibServerPreflight)Activator.CreateInstance(
                        Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin", preflightAssembly)).GetType(preflightClass));
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