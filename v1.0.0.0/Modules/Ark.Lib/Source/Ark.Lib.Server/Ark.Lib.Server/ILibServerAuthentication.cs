// ILibServerAuthentication.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;

using Microsoft.AspNetCore.Http;

using Lazy;

using Ark.Lib;

namespace Ark.Lib.Server
{
    public interface ILibServerAuthentication
    {
        void Authenticate(HttpContext context);
    }
}