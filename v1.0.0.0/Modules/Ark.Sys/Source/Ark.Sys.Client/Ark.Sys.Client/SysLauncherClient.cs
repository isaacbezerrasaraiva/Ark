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
using System.Net.Http;
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
        #region Variables

        private SysLoginClient loginClient;
        private SysMainClient mainClient;

        #endregion Variables

        #region Constructors

        public SysLauncherClient()
        {
            InitializeComponent();

            InitializeDynamicComponent();
        }

        private void InitializeDynamicComponent()
        {
            this.loginClient = new SysLoginClient();
            this.loginClient.DockOnCenter = true;
            this.loginClient.LoginSuccess += OnLoginClientLoginSuccess;

            this.panelContent.Controls.Add(this.loginClient);
        }

        private void OnLoginClientLoginSuccess(Object sender, EventArgs e)
        {
            if (this.mainClient == null)
            {
                this.mainClient = new SysMainClient();
                this.mainClient.Dock = DockStyle.Fill;
                this.mainClient.Logout += OnMainClientLogout;
                this.mainClient.Lock += OnMainClientLock;
            }
            
            this.PanelTop.Visible = false;
            this.panelContent.Controls.Remove(this.loginClient);
            this.panelContent.Controls.Add(this.mainClient);
        }

        private void OnMainClientLogout(Object sender, EventArgs e)
        {
            this.PanelTop.Visible = true;
            this.panelContent.Controls.Remove(this.mainClient);
            this.panelContent.Controls.Add(this.loginClient);

            this.mainClient.Dispose();
            this.mainClient = null;
        }

        private void OnMainClientLock(Object sender, EventArgs e)
        {
            this.PanelTop.Visible = true;
            this.panelContent.Controls.Remove(this.mainClient);
            this.panelContent.Controls.Add(this.loginClient);
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
