// SysAuthenticationData.cs
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
    public class SysAuthenticationDataRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationDataRequest()
        {
            this.scope = new SysAuthenticationDataRequestScope();
            this.content = new SysAuthenticationDataRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAuthenticationDataRequestScope Scope
        {
            get { return (SysAuthenticationDataRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAuthenticationDataRequestContent Content
        {
            get { return (SysAuthenticationDataRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAuthenticationDataRequestScope : FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationDataRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAuthenticationDataRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationDataRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Token { get; set; }

        public String DatabaseAlias { get; set; }

        public Int32 IdDomain { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        #endregion Properties
    }

    public class SysAuthenticationDataResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationDataResponse()
        {
            this.scope = new SysAuthenticationDataResponseScope();
            this.content = new SysAuthenticationDataResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAuthenticationDataResponseScope Scope
        {
            get { return (SysAuthenticationDataResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAuthenticationDataResponseContent Content
        {
            get { return (SysAuthenticationDataResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAuthenticationDataResponseScope : FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationDataResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAuthenticationDataResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationDataResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String DatabaseAlias { get; set; }

        public Int32 IdDomain { get; set; }

        public Int32 IdUser { get; set; }

        public String Token { get; set; }

        #endregion Properties
    }
}
