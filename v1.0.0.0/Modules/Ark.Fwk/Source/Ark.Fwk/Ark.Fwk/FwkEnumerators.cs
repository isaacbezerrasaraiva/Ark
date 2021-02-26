// FwkEnumerators.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 27

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;

namespace Ark.Fwk
{
    public enum FwkScopeStatus
    {
        [LazyDecorator("10", "Success")]
        Success = 10,

        [LazyDecorator("20", "Warning")]
        Warning = 20,

        [LazyDecorator("70", "Error")]
        Error = 70
    }

    public enum FwkBooleanEnum
    {
        [LazyDecorator("F", "False")]
        False = 0,

        [LazyDecorator("T", "True")]
        True = 1
    }

    public enum FwkConstraintEnum
    {
        [LazyDecorator("PA", "ParentKey")]
        ParentKey = 10,

        [LazyDecorator("PK", "PrimaryKey")]
        PrimaryKey = 20,

        [LazyDecorator("IK", "IncrementKey")]
        IncrementKey = 30,

        [LazyDecorator("UK", "UniqueKey")]
        UniqueKey = 40,

        [LazyDecorator("NN", "None")]
        None = 70
    }
}
