// SysLoginClient.cs
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
    public partial class SysLoginClient : FwkClient
    {
        #region Events

        public event EventHandler LoginSuccess;

        #endregion Events

        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginClient()
        {
            InitializeComponent();

            InitializeComponentData();
        }

        private void InitializeComponentData()
        {
            this.labelProvider.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionProvider);
            this.labelUsername.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionUsername);
            this.labelPassword.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionPassword);
            this.buttonAccess.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionAccess);
        }

        #endregion Constructors

        #region Methods

        public SysLoginDataResponse Authenticate(SysLoginDataRequest loginDataRequest)
        {
            return (SysLoginDataResponse)InvokeServer("/Ark.Sys/SysLoginServer/Authenticate", loginDataRequest, HttpMethod.Post);
        }

        private void OnButtonAccessClick(Object sender, EventArgs e)
        {
            this.LoginSuccess?.Invoke(this, new EventArgs());
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
