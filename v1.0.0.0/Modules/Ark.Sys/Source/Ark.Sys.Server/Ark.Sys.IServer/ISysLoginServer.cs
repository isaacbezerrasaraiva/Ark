﻿// ISysLoginServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IServer;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IServer;
using Ark.Sys;
using Ark.Sys.Data;

namespace Ark.Sys.IServer
{
    public interface ISysLoginServer : IFwkServer
    {
        String Authenticate(String loginDataRequestString);
    }
}
