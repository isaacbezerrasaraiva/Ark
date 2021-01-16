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

        protected FwkDataRequestScope scope;
        protected FwkDataRequestContent content;

        #endregion Variables

        #region Constructors

        public FwkDataRequest()
        {
            if (this.GetType() == typeof(FwkDataRequest))
            {
                this.scope = new FwkDataRequestScope();
                this.content = new FwkDataRequestContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkDataRequestScope Scope
        {
            get { return this.scope; }
            set { this.scope = value; }
        }

        public FwkDataRequestContent Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataRequestScope()
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

        protected FwkDataResponseScope scope;
        protected FwkDataResponseContent content;

        #endregion Variables

        #region Constructors

        public FwkDataResponse()
        {
            if (this.GetType() == typeof(FwkDataResponse))
            {
                this.scope = new FwkDataResponseScope();
                this.content = new FwkDataResponseContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkDataResponseScope Scope
        {
            get { return this.scope; }
            set { this.scope = value; }
        }

        public FwkDataResponseContent Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String StatusCode { get; set; }

        public String StatusName { get; set; }

        public String StatusCaption { get; set; }

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
