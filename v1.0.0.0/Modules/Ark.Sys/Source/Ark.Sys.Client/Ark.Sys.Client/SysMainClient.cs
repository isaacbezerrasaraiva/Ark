// SysMainClient.cs
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
    public partial class SysMainClient : FwkClient
    {
        #region Events

        public event EventHandler Logout;
        public event EventHandler Lock;

        #endregion Events

        #region Variables

        private SysUserControlMainHome userControlMainHome;
        private SysUserControlMainExplorer userControlMainExplorer;

        #endregion Variables

        #region Constructors

        public SysMainClient()
        {
            InitializeComponent();

            InitializeDynamicComponent();
        }

        private void InitializeDynamicComponent()
        {
            this.userControlMainHome = new SysUserControlMainHome();
            this.userControlMainHome.Dock = DockStyle.Fill;
            this.userControlMainHome.ExplorerRequested += OnUserControlMainHomeExplorerRequested;
            this.userControlMainHome.LogoutRequested += OnUserControlMainLogoutRequested;
            this.userControlMainHome.LockRequested += OnUserControlMainLockRequested;

            this.userControlMainExplorer = new SysUserControlMainExplorer();
            this.userControlMainExplorer.Dock = DockStyle.Fill;
            this.userControlMainExplorer.HomeRequested += OnUserControlMainExplorerHomeRequested;
            this.userControlMainExplorer.LogoutRequested += OnUserControlMainLogoutRequested;
            this.userControlMainExplorer.LockRequested += OnUserControlMainLockRequested;

            this.Controls.Add(this.userControlMainHome);
        }

        #endregion Constructors

        #region Methods

        private void OnUserControlMainHomeExplorerRequested(Object sender, EventArgs e)
        {
            this.Controls.Remove(this.userControlMainHome);
            this.Controls.Add(this.userControlMainExplorer);
        }

        private void OnUserControlMainExplorerHomeRequested(Object sender, EventArgs e)
        {
            this.Controls.Remove(this.userControlMainExplorer);
            this.Controls.Add(this.userControlMainHome);
        }

        private void OnUserControlMainLogoutRequested(Object sender, EventArgs e)
        {
            this.Logout?.Invoke(sender, e);
        }

        private void OnUserControlMainLockRequested(Object sender, EventArgs e)
        {
            this.Lock?.Invoke(sender, e);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
