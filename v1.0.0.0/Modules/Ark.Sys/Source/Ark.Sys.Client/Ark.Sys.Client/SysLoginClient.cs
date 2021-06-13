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
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginClient()
        {
            InitializeComponent();

            InitializeGlobalization();

            InitializeData();
        }

        private void InitializeGlobalization()
        {
            this.labelEnvironment.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionEnvironment);
            this.labelUsername.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionUsername);
            this.labelPassword.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionPassword);
            this.buttonAccess.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionAccess);
        }

        private void InitializeData()
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> environment in LibConfigurationClient.DynamicXml["Ark.Lib"]["Settings"]["Environments"].Elements)
                this.comboBoxEnvironments.Items.Add(environment.Key);
            
            if (this.comboBoxEnvironments.Items.Count > 0)
                this.comboBoxEnvironments.SelectedIndex = 0;
        }

        #endregion Constructors

        #region Methods

        private void OnButtonAccessClick(Object sender, EventArgs e)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
