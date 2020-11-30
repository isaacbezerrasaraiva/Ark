// LibDynamicXmlElement.cs
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
    public class LibDynamicXmlElement
    {
        #region Variables

        private Dictionary<String, LibDynamicXmlElement> elementDictionary;

        #endregion Variables

        #region Constructors

        public LibDynamicXmlElement(String name)
        {
            this.elementDictionary = new Dictionary<String, LibDynamicXmlElement>();
            
            this.Attribute = new LibDynamicXmlAttribute();

            this.Name = name;
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Name { get; set; }

        public LibDynamicXmlAttribute Attribute { get; set; }

        public Dictionary<String, LibDynamicXmlElement> Elements
        {
            get { return this.elementDictionary; }
        }

        #endregion Properties

        #region Indexers

        public LibDynamicXmlElement this[String name]
        {
            get
            {
                if (this.elementDictionary.ContainsKey(name) == false)
                    this.elementDictionary.Add(name, new LibDynamicXmlElement(name));

                return this.elementDictionary[name];
            }
            set
            {
                if (this.elementDictionary.ContainsKey(name) == false)
                    this.elementDictionary.Add(name, value);
                else
                    this.elementDictionary[name] = value;
            }
        }

        #endregion Indexers
    }
}