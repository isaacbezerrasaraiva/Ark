﻿// SysUserControlMainHome.cs
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
            this.controlMainHomeQuickLauncher.LaunchItemRequested += OnControlMainHomeQuickLauncherLaunchItemRequested;
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

        private void OnPanelMenuItemMouseClick(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem toolStripMenuItemAddQuickLauncher = new ToolStripMenuItem();
                toolStripMenuItemAddQuickLauncher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                toolStripMenuItemAddQuickLauncher.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionAddQuickLauncher);
                toolStripMenuItemAddQuickLauncher.Image = Properties.SysResourcesClient.Add_01_Black_x016;
                toolStripMenuItemAddQuickLauncher.Tag = sender;
                toolStripMenuItemAddQuickLauncher.MouseEnter += OnToolStripMenuItemAddQuickLauncherMouseEnter;
                toolStripMenuItemAddQuickLauncher.MouseLeave += OnToolStripMenuItemAddQuickLauncherMouseLeave;
                toolStripMenuItemAddQuickLauncher.MouseUp += OnToolStripMenuItemAddQuickLauncherMouseUp;

                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                contextMenuStrip.Items.Add(toolStripMenuItemAddQuickLauncher);
                contextMenuStrip.Show((Control)sender, e.Location);
            }
        }

        private void OnToolStripMenuItemAddQuickLauncherMouseEnter(Object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Image = Properties.SysResourcesClient.Add_01_Green_x016;
        }

        private void OnToolStripMenuItemAddQuickLauncherMouseLeave(Object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Image = Properties.SysResourcesClient.Add_01_Black_x016;
        }

        private void OnToolStripMenuItemAddQuickLauncherMouseUp(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
            }
        }

        private void OnControlMainHomeQuickLauncherLaunchItemRequested(Object sender, EventArgs e)
        {
            this.ExplorerRequested?.Invoke(sender, e);
        }

        private void OnControlMainHomeQuickLauncherRemoveItemRequested(Object sender, EventArgs e)
        {
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
