// LibFormattersOutputServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 10

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Threading.Tasks;

using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Http;

using Lazy;

using Ark.Lib;

namespace Ark.Lib.Server
{
    public class LibFormattersOutputServer : OutputFormatter
    {
        public LibFormattersOutputServer()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
        
        public override Boolean CanWriteResult(OutputFormatterCanWriteContext context)
        {
            if (String.IsNullOrEmpty(context.HttpContext.Request.ContentType) || context.HttpContext.Request.ContentType.ToLower() == "application/json;charset=utf-8")
                return true;
            
            return false;
        }
        
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            return context.HttpContext.Response.WriteAsync(context.Object.ToString());
        }
    }
}
