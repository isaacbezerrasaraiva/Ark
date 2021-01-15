// IFtsIncrementService.cs
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
using Ark.Fwk.IService;
using Ark.Fts;
using Ark.Fts.Data;

namespace Ark.Fts.IService
{
    public interface IFtsIncrementService : IFwkService
    {
        /// <summary>
        /// Generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest);
    }
}
