// FwkHeaderStatus.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 09

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;

namespace Ark.Fwk
{
    public enum FwkHeaderStatus
    {
        [LazyDecorator("10", "Success")]
        Success = 10,
        
        [LazyDecorator("20", "Warning")]
        Warning = 20,
        
        [LazyDecorator("70", "Error")]
        Error = 70
    }
}
