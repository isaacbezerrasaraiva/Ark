// SysAuthData.cs
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
    public class SysAuthDataRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthDataRequest()
        {
            this.scope = new SysAuthDataRequestScope();
            this.content = new SysAuthDataRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAuthDataRequestScope Scope
        {
            get { return (SysAuthDataRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAuthDataRequestContent Content
        {
            get { return (SysAuthDataRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAuthDataRequestScope : FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthDataRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAuthDataRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthDataRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public SysAuthenticationRequest AuthenticationRequest { get; set; }

        public SysAuthorizationRequest AuthorizationRequest { get; set; }

        #endregion Properties
    }

    public class SysAuthDataResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthDataResponse()
        {
            this.scope = new SysAuthDataResponseScope();
            this.content = new SysAuthDataResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAuthDataResponseScope Scope
        {
            get { return (SysAuthDataResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAuthDataResponseContent Content
        {
            get { return (SysAuthDataResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAuthDataResponseScope : FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthDataResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAuthDataResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthDataResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public SysAuthenticationResponse AuthenticationResponse { get; set; }

        public SysAuthorizationResponse AuthorizationResponse { get; set; }

        #endregion Properties
    }
}
