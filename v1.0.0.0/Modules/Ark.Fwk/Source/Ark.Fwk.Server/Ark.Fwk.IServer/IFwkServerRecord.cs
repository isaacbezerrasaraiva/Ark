// IFwkServerRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;

namespace Ark.Fwk.IServer
{
    public interface IFwkServerRecord : IFwkServerBasic
    {
        String Read(String dataRequestString);

        String Insert(String dataRequestString);

        String Indate(String dataRequestString);

        String Update(String dataRequestString);

        String Upsert(String dataRequestString);

        String Delete(String dataRequestString);
    }
}
