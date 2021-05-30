// FwkPluginView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 29

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;
using Lazy.Database;

using Ark.Lib;
using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;

namespace Ark.Fwk.Service
{
    public class FwkPluginView : FwkPluginBasic, IFwkPluginView
    {
        #region Variables

        protected FwkPluginViewBeforeEventHandler formatPluginViewBeforeEventHandler;
        protected FwkPluginViewAfterEventHandler formatPluginViewAfterEventHandler;
        protected FwkPluginViewBeforeEventHandler validateReadPluginViewBeforeEventHandler;
        protected FwkPluginViewAfterEventHandler validateReadPluginViewAfterEventHandler;
        protected FwkPluginViewBeforeEventHandler readPluginViewBeforeEventHandler;
        protected FwkPluginViewAfterEventHandler readPluginViewAfterEventHandler;

        #endregion Variables

        #region Constructors

        public FwkPluginView()
        {
        }

        #endregion Constructors

        #region Methods

        protected virtual void OnFormatPluginViewBeforeEventHandler(Object sender, FwkPluginViewBeforeEventArgs args)
        {
        }

        protected virtual void OnFormatPluginViewAfterEventHandler(Object sender, FwkPluginViewAfterEventArgs args)
        {
        }

        protected virtual void OnValidateReadPluginViewBeforeEventHandler(Object sender, FwkPluginViewBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateReadPluginViewAfterEventHandler(Object sender, FwkPluginViewAfterEventArgs args)
        {
        }

        protected virtual void OnReadPluginViewBeforeEventHandler(Object sender, FwkPluginViewBeforeEventArgs args)
        {
        }

        protected virtual void OnReadPluginViewAfterEventHandler(Object sender, FwkPluginViewAfterEventArgs args)
        {
        }

        #endregion Methods

        #region Properties

        public FwkPluginViewBeforeEventHandler FormatPluginViewBeforeEventHandler { get { return this.formatPluginViewBeforeEventHandler; } }

        public FwkPluginViewAfterEventHandler FormatPluginViewAfterEventHandler { get { return this.formatPluginViewAfterEventHandler; } }

        public FwkPluginViewBeforeEventHandler ValidateReadPluginViewBeforeEventHandler { get { return this.validateReadPluginViewBeforeEventHandler; } }

        public FwkPluginViewAfterEventHandler ValidateReadPluginViewAfterEventHandler { get { return this.validateReadPluginViewAfterEventHandler; } }

        public FwkPluginViewBeforeEventHandler ReadPluginViewBeforeEventHandler { get { return this.readPluginViewBeforeEventHandler; } }

        public FwkPluginViewAfterEventHandler ReadPluginViewAfterEventHandler { get { return this.readPluginViewAfterEventHandler; } }

        #endregion Properties
    }
}