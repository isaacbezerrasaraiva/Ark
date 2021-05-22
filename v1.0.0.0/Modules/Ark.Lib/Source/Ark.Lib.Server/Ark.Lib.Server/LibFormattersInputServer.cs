// LibFormattersInputServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 07

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
    public class LibFormattersInputServer : InputFormatter
    {
        public LibFormattersInputServer()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
        
        public override Boolean CanRead(InputFormatterContext context)
        {
            if (String.IsNullOrEmpty(context.HttpContext.Request.ContentType) || context.HttpContext.Request.ContentType.ToLower() == "application/json;charset=utf-8")
                return true;
            
            return false;
        }
        
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            using (StreamReader streamReader = new StreamReader(context.HttpContext.Request.Body, System.Text.Encoding.UTF8))
            {
                String content = await streamReader.ReadToEndAsync();
                return await InputFormatterResult.SuccessAsync(content);
            }
        }
    }
}
