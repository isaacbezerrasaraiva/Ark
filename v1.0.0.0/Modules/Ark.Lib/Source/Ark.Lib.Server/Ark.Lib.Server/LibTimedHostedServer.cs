// LibTimedHostedServer.cs
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
    public class LibTimedHostedServer : IHostedService, IDisposable
    {
        #region Variables

        private List<Timer> timerList;

        #endregion Variables

        #region Constructors

        public LibTimedHostedServer()
        {
            this.timerList = new List<Timer>();
        }

        #endregion Constructors

        #region Methods

        public Task StartAsync(CancellationToken stoppingToken)
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementServer in LibConfigurationServer.DynamicXml.Modules["Ark.Lib"]["Timer"].Elements)
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
                                ILibTimedWorkerServer iTimedWorkerServer = (ILibTimedWorkerServer)LazyActivator.Local.CreateInstance(Path.Combine(
                                    LibDirectory.Root.Bin.AssemblyFolder[serverAssemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, serverAssemblyFileName),
                                    serverClassFullName);

                                LibTimedWorkerData timedWorkerData = new LibTimedWorkerData();
                                timedWorkerData.ServerEnabled = serverEnabled;
                                timedWorkerData.ServerName = dynamicXmlElementServer.Key;
                                timedWorkerData.ServerAssembly = serverAssemblyFileName;
                                timedWorkerData.ServerClass = serverClassFullName;
                                timedWorkerData.InstanceEnabled = instanceEnabled;
                                timedWorkerData.InstanceName = dynamicXmlElementInstance.Key;
                                timedWorkerData.InstanceDelay = LazyConvert.ToInt32(instanceDelay, 5);
                                timedWorkerData.InstanceInterval = LazyConvert.ToInt32(instanceInterval, 300);
                                timedWorkerData.InstanceLogEnabled = instanceLogEnabled;
                                timedWorkerData.InstanceLogPath = instanceLogPath;
                                timedWorkerData.InstanceParameter = instanceParameter;

                                #region Force start at a second divisible by 5

                                Int32 internalDelay = 0;
                                while ((DateTime.Now.Second + internalDelay) % 5 != 0)
                                    internalDelay++;

                                #endregion Force start at a second divisible by 5

                                this.timerList.Add(new Timer(iTimedWorkerServer.Execute, timedWorkerData, (internalDelay + timedWorkerData.InstanceDelay) * 1000, timedWorkerData.InstanceInterval * 1000));
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