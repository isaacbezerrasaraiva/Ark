// FwkUserContext.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 01

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;

namespace Ark.Fwk
{
    public class FwkUserContext
    {
        #region Variables

        private Dictionary<String, FwkUserContextValue> fieldDictionary;

        #endregion Variables

        #region Constructors

        public FwkUserContext()
        {
            this.fieldDictionary = new Dictionary<String, FwkUserContextValue>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public FwkUserContextValue this[String field]
        {
            get
            {
                if (fieldDictionary.ContainsKey(field) == false)
                    fieldDictionary.Add(field, new FwkUserContextValue());

                return fieldDictionary[field];
            }
        }

        #endregion Indexers
    }

    public class FwkUserContextValue
    {
        #region Variables

        private Int16 valueInt16;
        private Int32 valueInt32;
        private String valueString;

        #endregion Variables

        #region Constructors

        public FwkUserContextValue()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int16 ValueInt16
        {
            get { return this.valueInt16; }
            set { this.valueInt16 = value; }
        }

        public Int32 ValueInt32
        {
            get { return this.valueInt32; }
            set { this.valueInt32 = value; }
        }

        public String ValueString
        {
            get { return this.valueString; }
            set { this.valueString = value; }
        }

        #endregion Properties
    }
}