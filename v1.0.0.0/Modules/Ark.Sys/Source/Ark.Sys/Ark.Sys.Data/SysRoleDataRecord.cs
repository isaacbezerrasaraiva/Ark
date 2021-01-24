// SysRoleDataRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 18

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
    public class SysRoleDataRecordRequest : FwkDataRecordRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataRecordRequest()
        {
            this.scope = new SysRoleDataRecordRequestScope();
            this.content = new SysRoleDataRecordRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysRoleDataRecordRequestScope Scope
        {
            get { return (SysRoleDataRecordRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysRoleDataRecordRequestContent Content
        {
            get { return (SysRoleDataRecordRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysRoleDataRecordRequestScope : FwkDataRecordRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataRecordRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysRoleDataRecordRequestContent : FwkDataRecordRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataRecordRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysRoleDataRecordResponse : FwkDataRecordResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataRecordResponse()
        {
            this.scope = new SysRoleDataRecordResponseScope();
            this.content = new SysRoleDataRecordResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysRoleDataRecordResponseScope Scope
        {
            get { return (SysRoleDataRecordResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysRoleDataRecordResponseContent Content
        {
            get { return (SysRoleDataRecordResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysRoleDataRecordResponseScope : FwkDataRecordResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataRecordResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysRoleDataRecordResponseContent : FwkDataRecordResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysRoleDataRecordResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
