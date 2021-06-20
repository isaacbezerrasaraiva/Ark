// SysUserControlMainHome.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, June 15

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
    public partial class SysUserControlMainHome : LazyUserControl
    {
        #region Events

        public event EventHandler ExplorerRequested;
        public event EventHandler LogoutRequested;
        public event EventHandler LockRequested;

        #endregion Events

        #region Variables

        private SysControlMainHomeQuickLauncher controlMainHomeQuickLauncher;

        #endregion Variables

        #region Constructors

        public SysUserControlMainHome()
        {
            InitializeComponent();

            InitializeComponentDynamic();

            InitializeComponentData();
        }

        private void InitializeComponentDynamic()
        {
            this.controlMainHomeQuickLauncher = new SysControlMainHomeQuickLauncher();
            this.controlMainHomeQuickLauncher.Dock = DockStyle.Right;
            this.controlMainHomeQuickLauncher.ItemSize = new Size(175, 175);
            this.controlMainHomeQuickLauncher.RemoveItemRequested += OnControlMainHomeQuickLauncherRemoveItemRequested;

            this.panelTopQuickLauncher.Controls.Add(this.controlMainHomeQuickLauncher);
        }

        private void InitializeComponentData()
        {
            this.buttonLogout.Image = Properties.SysResourcesClient.Shutdown_01_Black_x024;
            this.buttonLock.Image = Properties.SysResourcesClient.Lock_01_Black_x024;
        }

        #endregion Constructors

        #region Methods

        private void OnControlMainHomeQuickLauncherRemoveItemRequested(Object sender, EventArgs e)
        {
        }

        private void OnExplorerRequested(Object sender, EventArgs e)
        {
            this.ExplorerRequested?.Invoke(sender, e);
        }

        private void OnButtonLogoutClick(Object sender, EventArgs e)
        {
            this.LogoutRequested?.Invoke(sender, e);
        }

        private void OnButtonLockClick(Object sender, EventArgs e)
        {
            this.LockRequested?.Invoke(sender, e);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
