// IFwkServiceView.cs
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

namespace Ark.Fwk.IService
{
    public interface IFwkServiceView : IFwkServiceBasic
    {
        FwkDataViewResponse Format(FwkDataViewRequest dataViewRequest);

        FwkDataViewResponse ValidateRead(FwkDataViewRequest dataViewRequest);

        FwkDataViewResponse Read(FwkDataViewRequest dataViewRequest);
    }
}
