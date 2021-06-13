// SysLauncherClient.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, June 12

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Lazy;
using Lazy.Forms.Win;

using Ark.Lib;
using Ark.Lib.Client;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.Client;
using Ark.Fwk.IServer;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IServer;

namespace Ark.Sys.Client
{
    public partial class SysLauncherClient : FwkClient
    {
        #region Clients
        
        private SysLoginClient loginClient;
        private SysMainClient mainClient;
        private SysSettingsClient settingsClient;

        #endregion Clients

        #region Variables
        #endregion Variables

        #region Constructors

        public SysLauncherClient()
        {
            InitializeComponent();

            this.loginClient = new SysLoginClient();
            this.panelContent.Controls.Add(this.loginClient);
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
