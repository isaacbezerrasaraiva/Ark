// FwkDataProcess.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 15

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;
using Lazy.Json;

using Ark.Lib;
using Ark.Fwk;

namespace Ark.Fwk.Data
{
    public class FwkDataProcessRequest : FwkDataBasicRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataProcessRequest()
        {
            if (this.GetType() == typeof(FwkDataProcessRequest))
            {
                this.scope = new FwkDataProcessRequestScope();
                this.content = new FwkDataProcessRequestContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataProcessRequestScope Scope
        {
            get { return (FwkDataProcessRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataProcessRequestContent Content
        {
            get { return (FwkDataProcessRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataProcessRequestScope : FwkDataBasicRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataProcessRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataProcessRequestContent : FwkDataBasicRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataProcessRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataProcessResponse : FwkDataBasicResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataProcessResponse()
        {
            if (this.GetType() == typeof(FwkDataProcessResponse))
            {
                this.scope = new FwkDataProcessResponseScope();
                this.content = new FwkDataProcessResponseContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataProcessResponseScope Scope
        {
            get { return (FwkDataProcessResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataProcessResponseContent Content
        {
            get { return (FwkDataProcessResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataProcessResponseScope : FwkDataBasicResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataProcessResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataProcessResponseContent : FwkDataBasicResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataProcessResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
