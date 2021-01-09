// FwkData.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;

namespace Ark.Fwk.Data
{
    public class FwkDataRequest
    {
        #region Variables

        protected FwkDataRequestHeader header;
        protected FwkDataRequestContent content;

        #endregion Variables

        #region Constructors

        public FwkDataRequest()
        {
            if (this.GetType() == typeof(FwkDataRequest))
            {
                this.header = new FwkDataRequestHeader();
                this.content = new FwkDataRequestContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkDataRequestHeader Header
        {
            get { return this.header; }
            set { this.header = value; }
        }

        public FwkDataRequestContent Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataRequestHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRequestHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataResponse
    {
        #region Variables

        protected FwkDataResponseHeader header;
        protected FwkDataResponseContent content;

        #endregion Variables

        #region Constructors

        public FwkDataResponse()
        {
            if (this.GetType() == typeof(FwkDataResponse))
            {
                this.header = new FwkDataResponseHeader();
                this.content = new FwkDataResponseContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkDataResponseHeader Header
        {
            get { return this.header; }
            set { this.header = value; }
        }

        public FwkDataResponseContent Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataResponseHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataResponseHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String StatusCode { get; set; }

        public String StatusName { get; set; }

        public String StatusMessage { get; set; }

        #endregion Properties
    }

    public class FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
