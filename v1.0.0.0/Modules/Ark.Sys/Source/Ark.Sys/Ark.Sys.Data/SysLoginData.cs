// SysLoginData.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
    public class SysLoginDataRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginDataRequest()
        {
            this.scope = new SysLoginDataRequestScope();
            this.content = new SysLoginDataRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysLoginDataRequestScope Scope
        {
            get { return (SysLoginDataRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysLoginDataRequestContent Content
        {
            get { return (SysLoginDataRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysLoginDataRequestScope : FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginDataRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysLoginDataRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginDataRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String DatabaseAlias { get; set; }

        public Int16 IdDomain { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        #endregion Properties
    }

    public class SysLoginDataResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginDataResponse()
        {
            this.scope = new SysLoginDataResponseScope();
            this.content = new SysLoginDataResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysLoginDataResponseScope Scope
        {
            get { return (SysLoginDataResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysLoginDataResponseContent Content
        {
            get { return (SysLoginDataResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysLoginDataResponseScope : FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginDataResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysLoginDataResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginDataResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Token { get; set; }

        #endregion Properties
    }
}
