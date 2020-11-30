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
                String authenticationAssembly = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Assembly"];
                String authenticationClass = LibServerConfiguration.DynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Class"];

                if (String.IsNullOrEmpty(authenticationAssembly) == false && String.IsNullOrEmpty(authenticationClass) == false)
                {
                    iServerAuthentication = (ILibServerAuthentication)Activator.CreateInstance(
                        Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin", authenticationAssembly)).GetType(authenticationClass));
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