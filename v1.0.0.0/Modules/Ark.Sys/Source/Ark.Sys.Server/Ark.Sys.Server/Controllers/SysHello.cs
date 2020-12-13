// SysHello.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 14

using System;
using System.Xml;
using System.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Ark.Sys.Server
{
    [ApiController]
    [Route("Ark.Sys/[controller]")]
    public class SysHello : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public String Get()
        {
            return "Hello Ark.Sys.Server!";
        }
    }
}
