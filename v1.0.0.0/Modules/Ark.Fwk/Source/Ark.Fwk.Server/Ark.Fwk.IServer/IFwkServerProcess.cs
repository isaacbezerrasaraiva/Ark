// IFwkServerProcess.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 15

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;

namespace Ark.Fwk.IServer
{
    public interface IFwkServerProcess : IFwkServerBasic
    {
        String Next(String dataRequestString);

        String Execute(String dataRequestString);
    }
}
