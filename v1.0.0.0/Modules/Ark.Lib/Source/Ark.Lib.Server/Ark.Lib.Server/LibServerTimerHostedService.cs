// LibServerTimerHostedService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 22

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Hosting;

using Lazy;

using Ark.Lib;

namespace Ark.Lib.Server
{
    public class LibServerTimerHostedService : IHostedService, IDisposable
    {
        #region Variables

        private List<Timer> timerList;

        #endregion Variables

        #region Constructors

        public LibServerTimerHostedService()
        {
            this.timerList = new List<Timer>();
        }

        #endregion Constructors

        #region Methods

        public Task StartAsync(CancellationToken stoppingToken)
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementServer in LibServerConfiguration.DynamicXml.Modules["Ark.Lib"]["Timer"].Elements)
            {
                Boolean serverEnabled = dynamicXmlElementServer.Value.Attribute["Enabled"].ToLower() == "true" ? true : false;

                if (serverEnabled == true)
                {
                    #region Read server data

                    String serverAssemblyFolderName = dynamicXmlElementServer.Value.Attribute["Assembly"].Replace(".dll", String.Empty);
                    String serverAssemblyFileName = dynamicXmlElementServer.Value.Attribute["Assembly"];
                    String serverClassFullName = dynamicXmlElementServer.Value.Attribute["Class"];

                    #endregion Read server data

                    foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementInstance in dynamicXmlElementServer.Value.Elements)
                    {
                        Boolean instanceEnabled = dynamicXmlElementInstance.Value.Attribute["Enabled"].ToLower() == "true" ? true : false;

                        if (instanceEnabled == true)
                        {
                            #region Read instance data

                            String instanceDelay = dynamicXmlElementInstance.Value.Attribute["Delay"];
                            String instanceInterval = dynamicXmlElementInstance.Value.Attribute["Interval"];
                            Boolean instanceLogEnabled = dynamicXmlElementInstance.Value.Attribute["LogEnabled"].ToLower() == "true" ? true : false;
                            String instanceLogPath = dynamicXmlElementInstance.Value.Attribute["LogPath"];
                            String instanceParameter = dynamicXmlElementInstance.Value["Parameter"].Text;

                            #endregion Read instance data

                            #region Create timer worker

                            try
                            {
                                ILibServerTimerWorker iServerTimerWorker = (ILibServerTimerWorker)LazyActivator.Local.CreateInstance(Path.Combine(
                                    LibDirectory.Root.Bin.AssemblyFolder[serverAssemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, serverAssemblyFileName),
                                    serverClassFullName);

                                LibTimerData timerData = new LibTimerData();
                                timerData.ServerEnabled = serverEnabled;
                                timerData.ServerName = dynamicXmlElementServer.Key;
                                timerData.ServerAssembly = serverAssemblyFileName;
                                timerData.ServerClass = serverClassFullName;
                                timerData.InstanceEnabled = instanceEnabled;
                                timerData.InstanceName = dynamicXmlElementInstance.Key;
                                timerData.InstanceDelay = LazyConvert.ToInt32(instanceDelay, 5);
                                timerData.InstanceInterval = LazyConvert.ToInt32(instanceInterval, 300);
                                timerData.InstanceLogEnabled = instanceLogEnabled;
                                timerData.InstanceLogPath = instanceLogPath;
                                timerData.InstanceParameter = instanceParameter;

                                #region Force start at a second divisible by 5

                                Int32 internalDelay = 0;
                                while ((DateTime.Now.Second + internalDelay) % 5 != 0)
                                    internalDelay++;

                                #endregion Force start at a second divisible by 5

                                this.timerList.Add(new Timer(iServerTimerWorker.Execute, timerData, (internalDelay + timerData.InstanceDelay) * 1000, timerData.InstanceInterval * 1000));
                            }
                            catch
                            {
                                /* Nothing here yet */
                            }

                            #endregion Create timer worker
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            for (int i = (this.timerList.Count - 1); i >= 0; i--)
            {
                this.timerList[i]?.Change(Timeout.Infinite, 0);
                this.timerList[i].Dispose();
                this.timerList.RemoveAt(i);
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            for (int i = (this.timerList.Count - 1); i >= 0; i--)
            {
                this.timerList[i]?.Change(Timeout.Infinite, 0);
                this.timerList[i].Dispose();
                this.timerList.RemoveAt(i);
            }

            this.timerList = null;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}