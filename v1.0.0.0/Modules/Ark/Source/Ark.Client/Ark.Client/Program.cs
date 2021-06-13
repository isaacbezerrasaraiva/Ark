// Program.cs
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

namespace Ark.Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += LibAssemblyResolve.Resolve;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String assemblyFolderName = LibConfigurationClient.DynamicXml["Ark.Lib"]["Launcher"]["Client"].Attribute["Assembly"].Replace(".dll", String.Empty);
            String assemblyFileName = LibConfigurationClient.DynamicXml["Ark.Lib"]["Launcher"]["Client"].Attribute["Assembly"];
            String classFullName = LibConfigurationClient.DynamicXml["Ark.Lib"]["Launcher"]["Client"].Attribute["Class"];

            if (String.IsNullOrEmpty(assemblyFileName) == false && String.IsNullOrEmpty(classFullName) == false)
            {
                try
                {
                    FwkClient launcherClient = (FwkClient)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFileName), 
                        classFullName);

                    launcherClient.Dock = DockStyle.Fill;

                    FormWindowState windowState = FormWindowState.Normal;
                    if (Enum.TryParse<FormWindowState>(LibConfigurationClient.DynamicXml["Ark.Lib"]["Settings"]["Initialization"]["WindowState"].Text, true, out windowState) == false)
                        windowState = FormWindowState.Maximized;

                    FormMain formMain = new FormMain();
                    formMain.Controls.Add(launcherClient);
                    formMain.StartPosition = FormStartPosition.CenterScreen;
                    formMain.WindowState = windowState;
                    
                    Application.Run(formMain);
                }
                catch
                {
                    MessageBox.Show(LibGlobalization.GetTranslation(Properties.ResourcesClient.MessageLauncherIsNotFwkClient), LibGlobalization.GetTranslation(Properties.ResourcesClient.CaptionFail), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(LibGlobalization.GetTranslation(Properties.ResourcesClient.MessageLauncherNotFound), LibGlobalization.GetTranslation(Properties.ResourcesClient.CaptionFail), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
