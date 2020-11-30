// LibDynamicXmlAttribute.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 25

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

namespace Ark.Lib
{
    public class LibDynamicXmlAttribute
    {
        #region Variables

        private Dictionary<String, String> attributeDictionary;

        #endregion Variables

        #region Constructors

        public LibDynamicXmlAttribute()
        {
            this.attributeDictionary = new Dictionary<String, String>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Dictionary<String, String> Collection
        {
            get { return this.attributeDictionary; }
        }

        #endregion Properties

        #region Indexers

        public String this[String name]
        {
            get
            {
                if (this.attributeDictionary.ContainsKey(name) == false)
                    this.attributeDictionary.Add(name, String.Empty);

                return this.attributeDictionary[name];
            }
            set
            {
                if (this.attributeDictionary.ContainsKey(name) == false)
                    this.attributeDictionary.Add(name, value);
                else
                    this.attributeDictionary[name] = value;
            }
        }

        #endregion Indexers
    }
}