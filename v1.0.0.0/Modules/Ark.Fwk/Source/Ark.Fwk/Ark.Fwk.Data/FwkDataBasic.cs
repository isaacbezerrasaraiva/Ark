// FwkDataBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;

using Lazy;

using Ark.Lib;
using Ark.Fwk;

namespace Ark.Fwk.Data
{
    public class FwkDataBasicRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicRequest()
        {
            if (this.GetType() == typeof(FwkDataBasicRequest))
            {
                this.scope = new FwkDataBasicRequestScope();
                this.content = new FwkDataBasicRequestContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataBasicRequestScope Scope
        {
            get { return (FwkDataBasicRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataBasicRequestContent Content
        {
            get { return (FwkDataBasicRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataBasicRequestScope : FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataBasicRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataBasicResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicResponse()
        {
            if (this.GetType() == typeof(FwkDataBasicResponse))
            {
                this.scope = new FwkDataBasicResponseScope();
                this.content = new FwkDataBasicResponseContent();
            }
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new FwkDataBasicResponseScope Scope
        {
            get { return (FwkDataBasicResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new FwkDataBasicResponseContent Content
        {
            get { return (FwkDataBasicResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class FwkDataBasicResponseScope : FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkDataBasicResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkDataBasicResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
