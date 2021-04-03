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
            this.Operation = "Init";

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
            this.Operation = "Format";

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
            this.Operation = "ValidateRead";

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
            this.Operation = "Read";

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
            dataViewResponse.Content.Format = new FwkFormatView();
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
            if (dataViewResponse.Content.Format != null)
            {
                #region Validate required dataset

                if (dataViewRequest.Content.DataSet == null)
                    throw new LibException(Properties.FwkResourcesService.FwkExceptionViewDataSetMissing, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                #endregion Validate required dataset

                if (dataViewResponse.Content.Format.ViewTableList != null)
                {
                    foreach (KeyValuePair<String, FwkFormatViewTable> formatViewTable in dataViewResponse.Content.Format.ViewTableList)
                    {
                        if (dataViewRequest.Content.DataSet.Tables.Contains(formatViewTable.Key) == false)
                        {
                            #region Validate required table

                            if (formatViewTable.Value.Required == true)
                                throw new LibException(Properties.FwkResourcesService.FwkExceptionViewDataTableMissing, new Object[] { formatViewTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                            #endregion Validate required table

                            #region Create inexistence non required table

                            dataViewRequest.Content.DataSet.Tables.Add(formatViewTable.Key);

                            if (formatViewTable.Value.ViewFields != null)
                            {
                                foreach (KeyValuePair<String, FwkFormatViewField> formatViewField in formatViewTable.Value.ViewFields)
                                {
                                    if (formatViewField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey)
                                        dataViewRequest.Content.DataSet.Tables[formatViewTable.Key].Columns.Add(formatViewField.Key, formatViewField.Value.Attributes.Type);
                                }
                            }

                            #endregion Create inexistence non required table
                        }
                        else
                        {
                            if (dataViewRequest.Content.DataSet.Tables[formatViewTable.Key].Rows.Count == 0)
                            {
                                #region Validate required table empty

                                if (formatViewTable.Value.Required == true)
                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionViewDataTableEmpty, new Object[] { formatViewTable.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                #endregion Validate required table empty

                                #region Create inexistence non required table key fields

                                if (formatViewTable.Value.ViewFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatViewField> formatViewField in formatViewTable.Value.ViewFields)
                                    {
                                        if (formatViewField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey)
                                        {
                                            if (dataViewRequest.Content.DataSet.Tables[formatViewTable.Key].Columns.Contains(formatViewField.Key) == false)
                                                dataViewRequest.Content.DataSet.Tables[formatViewTable.Key].Columns.Add(formatViewField.Key, formatViewField.Value.Attributes.Type);
                                        }
                                    }
                                }

                                #endregion Create inexistence non required table key fields
                            }
                            else
                            {
                                if (formatViewTable.Value.ViewFields != null)
                                {
                                    foreach (KeyValuePair<String, FwkFormatViewField> formatViewField in formatViewTable.Value.ViewFields)
                                    {
                                        if (formatViewField.Value.Attributes.Constraint == FwkConstraintEnum.ParentKey)
                                        {
                                            #region Validate required key field

                                            if (dataViewRequest.Content.DataSet.Tables[formatViewTable.Key].Columns.Contains(formatViewField.Key) == false)
                                                throw new LibException(Properties.FwkResourcesService.FwkExceptionViewKeyFieldMissing, new Object[] { formatViewField.Key }, Properties.FwkResourcesService.FwkCaptionMissingProperty);

                                            #endregion Validate required key field

                                            foreach (DataRow dataRow in dataViewRequest.Content.DataSet.Tables[formatViewTable.Key].Rows)
                                            {
                                                #region Validate required key field empty

                                                if (String.IsNullOrEmpty(LazyConvert.ToString(dataRow[formatViewField.Key], null)) == true)
                                                    throw new LibException(Properties.FwkResourcesService.FwkExceptionViewKeyFieldEmpty, new Object[] { formatViewField.Key }, Properties.FwkResourcesService.FwkCaptionMissingData);

                                                #endregion Validate required key field empty

                                                #region Execute custom validations

                                                foreach (FwkFormatViewFieldValidation formatViewFieldValidation in formatViewField.Value.Validations)
                                                {
                                                    if (formatViewFieldValidation.Validate(dataRow[formatViewField.Key], formatViewField.Key) == false)
                                                        throw new LibException(formatViewFieldValidation.Reason, Properties.FwkResourcesService.FwkCaptionInvalidData);
                                                }

                                                #endregion Execute custom validations

                                                #region Execute custom transformations

                                                foreach (FwkFormatViewFieldTransformation formatViewFieldTransformation in formatViewField.Value.Transformations)
                                                    dataRow[formatViewField.Key] = formatViewFieldTransformation.Transform(dataRow[formatViewField.Key]);

                                                #endregion Execute custom transformations
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            if (this.Operation != "Init")
                dataViewResponse.Content.Format = null;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
