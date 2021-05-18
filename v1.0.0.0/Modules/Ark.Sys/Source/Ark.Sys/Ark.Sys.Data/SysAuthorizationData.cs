// SysAuthorizationData.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Sys;

namespace Ark.Sys.Data
{
    public class SysAuthorizationDataRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationDataRequest()
        {
            this.scope = new SysAuthorizationDataRequestScope();
            this.content = new SysAuthorizationDataRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAuthorizationDataRequestScope Scope
        {
            get { return (SysAuthorizationDataRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAuthorizationDataRequestContent Content
        {
            get { return (SysAuthorizationDataRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAuthorizationDataRequestScope : FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationDataRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAuthorizationDataRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationDataRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int32 IdDomain { get; set; }

        public Int32 IdUser { get; set; }

        public String CodModule { get; set; }

        public String CodFeature { get; set; }

        public String CodAction { get; set; }

        #endregion Properties
    }

    public class SysAuthorizationDataResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationDataResponse()
        {
            this.scope = new SysAuthorizationDataResponseScope();
            this.content = new SysAuthorizationDataResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAuthorizationDataResponseScope Scope
        {
            get { return (SysAuthorizationDataResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAuthorizationDataResponseContent Content
        {
            get { return (SysAuthorizationDataResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAuthorizationDataResponseScope : FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationDataResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAuthorizationDataResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationDataResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Boolean Authorized { get; set; }

        #endregion Properties
    }
}
