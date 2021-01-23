// IFtsIncrementServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

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

namespace Ark.Fts.IServer
{
    public interface IFtsIncrementServer : IFwkServer
    {
        String ValidateNext(String incrementDataRequestString);

        String Next(String incrementDataRequestString);
    }
}
