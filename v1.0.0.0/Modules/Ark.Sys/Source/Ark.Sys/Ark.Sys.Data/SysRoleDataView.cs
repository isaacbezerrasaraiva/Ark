// SysRoleDataView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 03

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
    public class SysRoleDataViewRequest : FwkDataViewRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataViewRequest()
        {
            this.scope = new SysRoleDataViewRequestScope();
            this.content = new SysRoleDataViewRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysRoleDataViewRequestScope Scope
        {
            get { return (SysRoleDataViewRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysRoleDataViewRequestContent Content
        {
            get { return (SysRoleDataViewRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysRoleDataViewRequestScope : FwkDataViewRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataViewRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysRoleDataViewRequestContent : FwkDataViewRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataViewRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysRoleDataViewResponse : FwkDataViewResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataViewResponse()
        {
            this.scope = new SysRoleDataViewResponseScope();
            this.content = new SysRoleDataViewResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysRoleDataViewResponseScope Scope
        {
            get { return (SysRoleDataViewResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysRoleDataViewResponseContent Content
        {
            get { return (SysRoleDataViewResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysRoleDataViewResponseScope : FwkDataViewResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataViewResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysRoleDataViewResponseContent : FwkDataViewResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataViewResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
