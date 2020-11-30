// LibServerConfiguration.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 25

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;

namespace Ark.Lib.Server
{
    public static class LibServerConfiguration
    {
        #region Consts

        private const string ARK_LIB_SERVER_XML = "Ark.Lib.Server.xml";

        #endregion Consts

        #region Variables

        private static LibDynamicXml dynamicXml;

        #endregion Variables

        #region Methods

        /// <summary>
        /// Load the configuration from file
        /// </summary>
        public static void Load()
        {
            #region Initialize configuration file

            // If configuration file not exists will be created a new one with default values
            if (File.Exists(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVER_XML)) == false)
                Save();

            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            #endregion Initialize configuration file

            LoadDynamicXml();
        }

        /// <summary>
        /// Save the configuration to file
        /// </summary>
        public static void Save()
        {
            #region Initialize default values

            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            if (dynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Lib.Server"]["Security"]["Authentication"].Attribute["Class"] = String.Empty;

            if (dynamicXml["Ark.Lib.Server"]["Security"]["Authorization"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Lib.Server"]["Security"]["Authorization"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Lib.Server"]["Security"]["Authorization"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Lib.Server"]["Security"]["Authorization"].Attribute["Class"] = String.Empty;

            #endregion Initialize default values

            SaveDynamicXml();
        }

        /// <summary>
        /// Load dynamic xml
        /// </summary>
        private static void LoadDynamicXml()
        {
            LazyXml xml = new LazyXml();

            xml.Open(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVER_XML));

            XmlNodeList xmlNodeModuleList = xml.ReadNodeChildList("/Ark.Lib.Server/DynamicXml");
            
            foreach (XmlNode xmlNodeModule in xmlNodeModuleList)
            {
                LoadDynamicXmlNode(xml, xmlNodeModule, dynamicXml[xmlNodeModule.Name]);
                
                XmlAttributeCollection xmlAttributeCollection = xml.ReadNodeAttributeList(xmlNodeModule);
                foreach (XmlAttribute attribute in xmlAttributeCollection)
                    dynamicXml[xmlNodeModule.Name].Attribute[attribute.Name] = attribute.Value;
            }

            xmlNodeModuleList = null;
            xml = null;
        }

        /// <summary>
        /// Load dynamic xml node
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNode">The xml node</param>
        /// <param name="element">The dynamic xml element</param>
        private static void LoadDynamicXmlNode(LazyXml xml, XmlNode xmlNode, LibDynamicXmlElement element)
        {
            XmlNodeList xmlNodeElementList = xml.ReadNodeChildList(xmlNode);

            foreach (XmlNode xmlNodeElement in xmlNodeElementList)
            {
                LoadDynamicXmlNode(xml, xmlNodeElement, element[xmlNodeElement.Name]);

                XmlAttributeCollection xmlAttributeCollection = xml.ReadNodeAttributeList(xmlNodeElement);
                foreach (XmlAttribute attribute in xmlAttributeCollection)
                    element[xmlNodeElement.Name].Attribute[attribute.Name] = attribute.Value;
            }

            xmlNodeElementList = null;
        }

        /// <summary>
        /// Save dynamic xml
        /// </summary>
        private static void SaveDynamicXml()
        {
            LazyXml xml = new LazyXml();

            xml.New();

            XmlNode xmlNodeRoot = xml.WriteRoot("Ark.Lib.Server");
            XmlNode xmlNodeDynamicXml = xml.WriteNode(xmlNodeRoot, "DynamicXml");

            foreach (KeyValuePair<String, LibDynamicXmlElement> module in dynamicXml.Modules)
            {
                XmlNode xmlNodeModule = xml.WriteNode(xmlNodeDynamicXml, module.Key);
                
                SaveDynamicXmlNode(xml, xmlNodeModule, module.Value);

                foreach (KeyValuePair<String, String> attribute in module.Value.Attribute.Collection)
                    xml.WriteNodeAttribute(xmlNodeModule, attribute.Key, attribute.Value);
            }

            xml.Save(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVER_XML));

            xmlNodeDynamicXml = null;
            xmlNodeRoot = null;
            xml = null;
        }

        /// <summary>
        /// Save dynamic xml node
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNode">The xml node</param>
        /// <param name="element">The dynamic xml element</param>
        private static void SaveDynamicXmlNode(LazyXml xml, XmlNode xmlNode, LibDynamicXmlElement element)
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> childElement in element.Elements)
            {
                XmlNode xmlNodeChildElement = xml.WriteNode(xmlNode, childElement.Key);
                
                SaveDynamicXmlNode(xml, xmlNodeChildElement, childElement.Value);

                foreach (KeyValuePair<String, String> attribute in childElement.Value.Attribute.Collection)
                    xml.WriteNodeAttribute(xmlNodeChildElement, attribute.Key, attribute.Value);
            }
        }

        #endregion Methods

        #region Properties

        public static LibDynamicXml DynamicXml
        {
            get
            {
                if (dynamicXml == null)
                    Load();

                return dynamicXml;
            }
            set { dynamicXml = value; }
        }

        #endregion Properties
    }
}
