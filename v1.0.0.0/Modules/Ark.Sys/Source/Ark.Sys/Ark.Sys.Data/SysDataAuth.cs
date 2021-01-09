// SysDataAuth.cs
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
//using Ark.Fts;
//using Ark.Fts.Data;
using Ark.Sys;

namespace Ark.Sys.Data
{
    public class SysDataAuthRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthRequest()
        {
            this.header = new SysDataAuthRequestHeader();
            this.content = new SysDataAuthRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysDataAuthRequestHeader Header
        {
            get { return (SysDataAuthRequestHeader)this.header; }
            set { this.header = value; }
        }

        public new SysDataAuthRequestContent Content
        {
            get { return (SysDataAuthRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysDataAuthRequestHeader : FwkDataRequestHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthRequestHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysDataAuthRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthRequestContent()
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

    public class SysDataAuthResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthResponse()
        {
            this.header = new SysDataAuthResponseHeader();
            this.content = new SysDataAuthResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysDataAuthResponseHeader Header
        {
            get { return (SysDataAuthResponseHeader)this.header; }
            set { this.header = value; }
        }

        public new SysDataAuthResponseContent Content
        {
            get { return (SysDataAuthResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysDataAuthResponseHeader : FwkDataResponseHeader
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthResponseHeader()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysDataAuthResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysDataAuthResponseContent()
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
