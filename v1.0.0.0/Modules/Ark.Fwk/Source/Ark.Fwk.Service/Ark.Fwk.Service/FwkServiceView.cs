// FwkServiceView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;
using Lazy.Database;

using Ark.Lib;
using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;

namespace Ark.Fwk.Service
{
    public class FwkServiceView : FwkServiceBasic, IFwkServiceView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServiceView(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public override FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            FwkDataViewRequest dataViewRequest = (FwkDataViewRequest)dataBasicRequest;
            FwkDataViewResponse dataViewResponse = (FwkDataViewResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformLoad(dataViewRequest, dataViewResponse);
            PerformFormat(dataViewRequest, dataViewResponse);
            PerformValidateRead(dataViewRequest, dataViewResponse);
            PerformRead(dataViewRequest, dataViewResponse);

            this.Database.CloseConnection();

            return dataViewResponse;
        }

        /// <summary>
        /// Format the service
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Format(FwkDataViewRequest dataViewRequest)
        {
            FwkDataViewResponse dataViewResponse = (FwkDataViewResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataViewRequest, dataViewResponse);

            this.Database.CloseConnection();

            return dataViewResponse;
        }

        /// <summary>
        /// Validate read the service
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse ValidateRead(FwkDataViewRequest dataViewRequest)
        {
            FwkDataViewResponse dataViewResponse = (FwkDataViewResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataViewRequest, dataViewResponse);
            PerformValidateRead(dataViewRequest, dataViewResponse);

            this.Database.CloseConnection();

            return dataViewResponse;
        }

        /// <summary>
        /// Read the service
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Read(FwkDataViewRequest dataViewRequest)
        {
            FwkDataViewResponse dataViewResponse = (FwkDataViewResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            this.Database.OpenConnection();

            PerformFormat(dataViewRequest, dataViewResponse);
            PerformValidateRead(dataViewRequest, dataViewResponse);
            PerformRead(dataViewRequest, dataViewResponse);

            this.Database.CloseConnection();

            return dataViewResponse;
        }

        /// <summary>
        /// Perform service format
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected void PerformFormat(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
            BeforePerformFormat(dataViewRequest, dataViewResponse);

            #region Before OnFormat plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.FormatPluginViewBeforeEventHandler?.Invoke(this, new FwkPluginViewBeforeEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion Before OnFormat plugins

            OnFormat(dataViewRequest, dataViewResponse);

            #region After OnFormat plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.FormatPluginViewAfterEventHandler?.Invoke(this, new FwkPluginViewAfterEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion After OnFormat plugins

            AfterPerformFormat(dataViewRequest, dataViewResponse);
        }

        /// <summary>
        /// Perform service validate read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected void PerformValidateRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
            BeforePerformValidateRead(dataViewRequest, dataViewResponse);

            #region Before OnValidateRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.ValidateReadPluginViewBeforeEventHandler?.Invoke(this, new FwkPluginViewBeforeEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion Before OnValidateRead plugins

            OnValidateRead(dataViewRequest, dataViewResponse);

            #region After OnValidateRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.ValidateReadPluginViewAfterEventHandler?.Invoke(this, new FwkPluginViewAfterEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion After OnValidateRead plugins

            AfterPerformValidateRead(dataViewRequest, dataViewResponse);
        }

        /// <summary>
        /// Perform service read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected void PerformRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
            BeforePerformRead(dataViewRequest, dataViewResponse);

            #region Before OnRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.ReadPluginViewBeforeEventHandler?.Invoke(this, new FwkPluginViewBeforeEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion Before OnRead plugins

            OnRead(dataViewRequest, dataViewResponse);

            #region After OnRead plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginView iPluginView in this.IPlugins)
                    iPluginView.ReadPluginViewAfterEventHandler?.Invoke(this, new FwkPluginViewAfterEventArgs(dataViewRequest, dataViewResponse));
            }

            #endregion After OnRead plugins

            AfterPerformRead(dataViewRequest, dataViewResponse);
        }

        /// <summary>
        /// On service format
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected virtual void OnFormat(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// On service validate read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected virtual void OnValidateRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// On service read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        protected virtual void OnRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// Before perform service format
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        private void BeforePerformFormat(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// After perform service format
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        private void AfterPerformFormat(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// Before perform service validate read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        private void BeforePerformValidateRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// After perform service validate read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        private void AfterPerformValidateRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// Before perform service read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        private void BeforePerformRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        /// <summary>
        /// After perform service read
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <param name="dataViewResponse">The response data</param>
        private void AfterPerformRead(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
