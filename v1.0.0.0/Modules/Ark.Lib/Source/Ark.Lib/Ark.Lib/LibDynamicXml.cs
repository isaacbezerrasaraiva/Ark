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

using Lazy;

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

        /// <summary>
        /// Load dynamic xml
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xPathDynamicXml">The xPath of the dynamic xml element</param>
        public void LoadDynamicXml(LazyXml xml, String xPathDynamicXml)
        {
            XmlNodeList xmlNodeModuleList = xml.ReadNodeChildList(xPathDynamicXml);

            foreach (XmlNode xmlNodeModule in xmlNodeModuleList)
            {
                LoadDynamicXmlNode(xml, xmlNodeModule, this[xmlNodeModule.Name]);

                XmlAttributeCollection xmlAttributeCollection = xml.ReadNodeAttributeList(xmlNodeModule);
                foreach (XmlAttribute attribute in xmlAttributeCollection)
                    this[xmlNodeModule.Name].Attribute[attribute.Name] = attribute.Value;
            }

            xmlNodeModuleList = null;
        }

        /// <summary>
        /// Load dynamic xml node
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNode">The xml node</param>
        /// <param name="element">The dynamic xml element</param>
        private void LoadDynamicXmlNode(LazyXml xml, XmlNode xmlNode, LibDynamicXmlElement element)
        {
            XmlNodeList xmlNodeElementList = xml.ReadNodeChildList(xmlNode);

            if (xmlNodeElementList.Count > 0)
            {
                if (xmlNodeElementList[0].NodeType == XmlNodeType.Text)
                {
                    element.Text = xmlNode.InnerText;
                }
                else
                {
                    foreach (XmlNode xmlNodeElement in xmlNodeElementList)
                    {
                        LoadDynamicXmlNode(xml, xmlNodeElement, element[xmlNodeElement.Name]);

                        XmlAttributeCollection xmlAttributeCollection = xml.ReadNodeAttributeList(xmlNodeElement);
                        foreach (XmlAttribute attribute in xmlAttributeCollection)
                            element[xmlNodeElement.Name].Attribute[attribute.Name] = attribute.Value;
                    }
                }
            }

            xmlNodeElementList = null;
        }

        /// <summary>
        /// Save dynamic xml
        /// </summary>
        public void SaveDynamicXml(LazyXml xml, XmlNode xmlNodeDynamicXml)
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> module in this.moduleDictionary)
            {
                XmlNode xmlNodeModule = xml.WriteNode(xmlNodeDynamicXml, module.Key);

                SaveDynamicXmlNode(xml, xmlNodeModule, module.Value);

                foreach (KeyValuePair<String, String> attribute in module.Value.Attribute.Collection)
                    xml.WriteNodeAttribute(xmlNodeModule, attribute.Key, attribute.Value);
            }
        }

        /// <summary>
        /// Save dynamic xml node
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNode">The xml node</param>
        /// <param name="element">The dynamic xml element</param>
        private void SaveDynamicXmlNode(LazyXml xml, XmlNode xmlNode, LibDynamicXmlElement element)
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> childElement in element.Elements)
            {
                XmlNode xmlNodeChildElement = xml.WriteNode(xmlNode, childElement.Key);

                SaveDynamicXmlNode(xml, xmlNodeChildElement, childElement.Value);

                if (childElement.Value.NodeType == XmlNodeType.Text)
                    xmlNodeChildElement.InnerText = childElement.Value.Text;

                foreach (KeyValuePair<String, String> attribute in childElement.Value.Attribute.Collection)
                    xml.WriteNodeAttribute(xmlNodeChildElement, attribute.Key, attribute.Value);
            }
        }

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