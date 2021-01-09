// SysDataPreflight.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
//using Ark.Fts;
//using Ark.Fts.Data;
using Ark.Sys;

namespace Ark.Sys.Data
{
    public class SysDataPreflightRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataPreflightRequest()
        {
            this.header = new SysDataPreflightRequestHeader();
            this.content = new SysDataPreflightRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysDataPreflightRequestHeader Header
        {
            get { return (SysDataPreflightRequestHeader)this.header; }
            set { this.header = value; }
        }

        public new SysDataPreflightRequestContent Content
        {
            get { return (SysDataPreflightRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysDataPreflightRequestHeader : FwkDataRequestHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataPreflightRequestHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysDataPreflightRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataPreflightRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysDataPreflightResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataPreflightResponse()
        {
            this.header = new SysDataPreflightResponseHeader();
            this.content = new SysDataPreflightResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysDataPreflightResponseHeader Header
        {
            get { return (SysDataPreflightResponseHeader)this.header; }
            set { this.header = value; }
        }

        public new SysDataPreflightResponseContent Content
        {
            get { return (SysDataPreflightResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysDataPreflightResponseHeader : FwkDataResponseHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataPreflightResponseHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysDataPreflightResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataPreflightResponseContent()
        {
            this.HttpResponseHeaders = new Dictionary<String, String>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Dictionary<String, String> HttpResponseHeaders;

        #endregion Properties
    }
}
