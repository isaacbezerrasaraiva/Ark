// ILibServerTimerWorker.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 17

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;

namespace Ark.Lib.Server
{
    public interface ILibServerTimerWorker
    {
        void Execute(Object data);
    }
}