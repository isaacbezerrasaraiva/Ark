// LibDynamicXml.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 25

using System;
using System.Xml;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Ark.Lib
{
    public class LibDynamicXml
    {
        #region Variables

        private Dictionary<String, LibDynamicXmlElement> moduleDictionary;

        #endregion Variables

        #region Constructors

        public LibDynamicXml()
        {
            this.moduleDictionary = new Dictionary<String, LibDynamicXmlElement>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Dictionary<String, LibDynamicXmlElement> Modules
        {
            get { return this.moduleDictionary; }
        }

        #endregion Properties

        #region Indexers

        public LibDynamicXmlElement this[String module]
        {
            get
            {
                if (this.moduleDictionary.ContainsKey(module) == false)
                    this.moduleDictionary.Add(module, new LibDynamicXmlElement(module));

                return this.moduleDictionary[module];
            }
            set
            {
                if (this.moduleDictionary.ContainsKey(module) == false)
                    this.moduleDictionary.Add(module, value);
                else
                    this.moduleDictionary[module] = value;
            }
        }

        #endregion Indexers
    }
}