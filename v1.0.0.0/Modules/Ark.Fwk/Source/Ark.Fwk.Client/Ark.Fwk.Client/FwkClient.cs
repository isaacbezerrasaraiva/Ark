// FwkClient.cs
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
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using Lazy;
using Lazy.Forms.Win;

using Ark.Lib;
using Ark.Lib.Client;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.Client;
using Ark.Fwk.IServer;

namespace Ark.Fwk.Client
{
    public partial class FwkClient : LazyUserControl
    {
        #region Variables

        private Type dataResponseType;

        #endregion Variables

        #region Constructors

        public FwkClient()
        {
            InitializeComponent();

            #region Initialize data response type

            String assemblyFolderName = this.GetType().Namespace.Replace("Client", "Data");
            String classFullName = this.GetType().FullName.Replace("Client", "Data") + "Response";

            this.dataResponseType = LazyActivator.Local.GetType(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                classFullName);

            #endregion Initialize data response type
        }

        #endregion Constructors

        #region Methods

        protected FwkDataResponse InvokeServer(String endPoint, FwkDataRequest dataRequest, HttpMethod httpMethod)
        {
            String serverUrl = LibConfigurationClient.DynamicXml["Ark.Fwk"]["Providers"][LibSessionClient.Provider]["Server"].Attribute["Url"];
            String authenticationMode = LibConfigurationClient.DynamicXml["Ark.Fwk"]["Providers"][LibSessionClient.Provider]["Authentication"].Attribute["Mode"];

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serverUrl);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Culture", LibGlobalization.Culture.Code);

            if (authenticationMode.ToLower() == "token")
            {
                httpClient.DefaultRequestHeaders.Add("Token", LibSessionClient.Token);
            }
            else if (authenticationMode.ToLower() == "credential")
            {
                String databaseAlias = LibConfigurationClient.DynamicXml["Ark.Fwk"]["Providers"][LibSessionClient.Provider]["Database"].Attribute["Alias"];
                String domainCode = LibConfigurationClient.DynamicXml["Ark.Fwk"]["Providers"][LibSessionClient.Provider]["Domain"].Attribute["Code"];

                httpClient.DefaultRequestHeaders.Add("DatabaseAlias", databaseAlias);
                httpClient.DefaultRequestHeaders.Add("DomainCode", domainCode);
                httpClient.DefaultRequestHeaders.Add("Username", LibSessionClient.Username);
                httpClient.DefaultRequestHeaders.Add("Password", LibSessionClient.Password);
            }
            
            String dataRequestString = (String)JsonConvert.SerializeObject(dataRequest, dataRequest.GetType(), null);
            ByteArrayContent dataRequestByteArrayContent = new ByteArrayContent(Encoding.UTF8.GetBytes(dataRequestString));

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, endPoint);
            httpRequestMessage.Content = dataRequestByteArrayContent;

            Task<HttpResponseMessage> httpResponseMessage = httpClient.SendAsync(httpRequestMessage);

            String dataResponseString = httpResponseMessage.Result.Content.ReadAsStringAsync().Result;
            return (FwkDataResponse)JsonConvert.DeserializeObject(dataResponseString, this.dataResponseType);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
