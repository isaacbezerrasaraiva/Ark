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

        private SysUserControlMainHomeTop userControlMainHomeTop;
        private SysUserControlMainHomeContent userControlMainHomeContent;
        private SysUserControlMainExplorerLeft userControlMainExplorerLeft;
        private SysUserControlMainExplorerContent userControlMainExplorerContent;

        #endregion Variables

        #region Constructors

        public SysMainClient()
        {
            InitializeComponent();

            InitializeDynamicComponent();
        }

        private void InitializeDynamicComponent()
        {
            this.userControlMainHomeTop = new SysUserControlMainHomeTop();
            this.userControlMainHomeTop.Dock = DockStyle.Top;
            this.userControlMainHomeTop.MouseClick += OnMouseClick; // **** REMOVER

            this.userControlMainHomeContent = new SysUserControlMainHomeContent();
            this.userControlMainHomeContent.Dock = DockStyle.Fill;
            this.userControlMainHomeContent.MouseClick += OnMouseClick; // **** REMOVER
            this.userControlMainHomeContent.Logout += OnUserControlMainHomeContentLogout;
            this.userControlMainHomeContent.Lock += OnUserControlMainHomeContentLock;

            this.userControlMainExplorerLeft = new SysUserControlMainExplorerLeft();
            this.userControlMainExplorerLeft.Dock = DockStyle.Left;
            this.userControlMainExplorerLeft.MouseClick += OnMouseClick; // **** REMOVER

            this.userControlMainExplorerContent = new SysUserControlMainExplorerContent();
            this.userControlMainExplorerContent.Dock = DockStyle.Fill;
            this.userControlMainExplorerContent.MouseClick += OnMouseClick; // **** REMOVER
            this.userControlMainExplorerContent.Logout += OnUserControlMainHomeContentLogout;
            this.userControlMainExplorerContent.Lock += OnUserControlMainHomeContentLock;

            this.Controls.Add(this.userControlMainHomeContent);
            this.Controls.Add(this.userControlMainHomeTop);
        }

        #endregion Constructors

        #region Methods
        
        private void OnUserControlMainHomeContentLogout(Object sender, EventArgs e)
        {
            this.Logout?.Invoke(sender, e);
        }

        private void OnUserControlMainHomeContentLock(Object sender, EventArgs e)
        {
            this.Lock?.Invoke(sender, e);
        }

        private void OnMouseClick(Object Sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                this.Controls.Remove(this.userControlMainHomeContent);
                this.Controls.Remove(this.userControlMainHomeTop);
                this.Controls.Add(this.userControlMainExplorerContent);
                this.Controls.Add(this.userControlMainExplorerLeft);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Controls.Remove(this.userControlMainExplorerContent);
                this.Controls.Remove(this.userControlMainExplorerLeft);
                this.Controls.Add(this.userControlMainHomeContent);
                this.Controls.Add(this.userControlMainHomeTop);
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
