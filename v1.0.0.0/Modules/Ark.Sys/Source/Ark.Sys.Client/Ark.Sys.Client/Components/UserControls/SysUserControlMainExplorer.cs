// SysUserControlMainExplorer.cs
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
    public partial class SysUserControlMainExplorer : LazyUserControl
    {
        #region Events
        
        public event EventHandler HomeRequested;
        public event EventHandler LogoutRequested;
        public event EventHandler LockRequested;

        #endregion Events

        #region Variables
        #endregion Variables

        #region Constructors

        public SysUserControlMainExplorer()
        {
            InitializeComponent();

            InitializeComponentData();
        }

        private void InitializeComponentData()
        {
            this.buttonHome.Thumbnail = Properties.SysResourcesClient.Home_01_Black_x016;
            this.buttonBack.Thumbnail = Properties.SysResourcesClient.Back_01_Black_x016;
            this.buttonLogout.Image = Properties.SysResourcesClient.Shutdown_01_Black_x024;
            this.buttonLock.Image = Properties.SysResourcesClient.Lock_01_Black_x024;
        }

        #endregion Constructors

        #region Methods

        private void OnButtonHomeClick(Object sender, EventArgs e)
        {
            this.HomeRequested?.Invoke(sender, e);
        }

        private void OnButtonBackClick(Object sender, EventArgs e)
        {
            this.HomeRequested?.Invoke(sender, e);
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
