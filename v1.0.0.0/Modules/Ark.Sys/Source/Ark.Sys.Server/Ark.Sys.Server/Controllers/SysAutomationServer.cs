// SysAutomationServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 21

using System;
using System.Xml;
using System.Data;
using System.Threading;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
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
    public class SysAutomationServer : FwkServer, ISysAutomationServer, ILibServerTimerWorker
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationServer()
        {
            this.DataRequestType = typeof(SysAutomationDataRequest);
            this.DataResponseType = typeof(SysAutomationDataResponse);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Execute automation
        /// </summary>
        /// <param name="data">Timer data</param>
        public void Execute(Object data)
        {
            InvokeService("Execute", ((LibTimerData)data).InstanceParameter, new FwkEnvironment());
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
