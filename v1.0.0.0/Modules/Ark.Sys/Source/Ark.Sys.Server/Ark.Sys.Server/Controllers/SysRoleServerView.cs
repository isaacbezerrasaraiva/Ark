// SysRoleServerView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 03

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

using Lazy;

using Ark.Lib;
using Ark.Lib.Server;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IServer;
using Ark.Fwk.IService;
using Ark.Fwk.Server;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IServer;
using Ark.Fts.IService;
using Ark.Fts.Server;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IServer;
using Ark.Sys.IService;

namespace Ark.Sys.Server
{
    [ApiController]
    [Route("Ark.Sys/[controller]")]
    public class SysRoleServerView : FwkServerView, ISysRoleServerView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleServerView()
        {
            this.DataRequestType = typeof(SysRoleDataViewRequest);
            this.DataResponseType = typeof(SysRoleDataViewResponse);
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
