﻿// ISysPreflightService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IService;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IService;
using Ark.Sys;
using Ark.Sys.Data;

namespace Ark.Sys.IService
{
    public interface ISysPreflightService : IFwkService
    {
        SysPreflightDataResponse Preflight(SysPreflightDataRequest preflightDataRequest);
    }
}
