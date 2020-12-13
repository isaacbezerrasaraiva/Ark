// LibServiceConfiguration.cs
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

namespace Ark.Lib.Service
{
    public static class LibServiceConfiguration
    {
        #region Consts

        private const string ARK_LIB_SERVICE_XML = "Ark.Lib.Service.xml";

        #endregion Consts

        #region Variables

        private static Dictionary<String, LibDatabaseOption> databaseOptionDictionary;
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
            if (File.Exists(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVICE_XML)) == false)
                Save();

            if (databaseOptionDictionary == null)
                databaseOptionDictionary = new Dictionary<String, LibDatabaseOption>();

            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            #endregion Initialize configuration file

            LazyXml xml = new LazyXml();

            xml.Open(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVICE_XML));

            LoadDatabase(xml);

            LoadDynamicXml(xml);

            xml = null;
        }

        /// <summary>
        /// Save the configuration to file
        /// </summary>
        public static void Save()
        {
            #region Initialize default values

            if (databaseOptionDictionary == null)
                databaseOptionDictionary = new Dictionary<String, LibDatabaseOption>();

            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            #endregion Initialize default values

            LazyXml xml = new LazyXml();

            xml.New();

            XmlNode xmlNodeRoot = xml.WriteRoot("Ark.Lib.Service");

            SaveDatabase(xml, xmlNodeRoot);

            SaveDynamicXml(xml, xmlNodeRoot);

            xml.Save(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVICE_XML));

            xmlNodeRoot = null;
            xml = null;
        }

        /// <summary>
        /// Load database
        /// </summary>
        private static void LoadDatabase(LazyXml xml)
        {
            XmlNodeList xmlNodeOptionList = xml.ReadNodeChildList("/Ark.Lib.Service/Database");

            foreach (XmlNode xmlNodeOption in xmlNodeOptionList)
            {
                XmlNode xmlNodeSettings = xml.ReadNodeChild(xmlNodeOption, "Settings");
                XmlNode xmlNodeConnectionString = xml.ReadNodeChild(xmlNodeSettings, "ConnectionString");
                
                LibDatabaseOption databaseOption = new LibDatabaseOption();
                databaseOption.Alias = xml.ReadNodeAttributeValue(xmlNodeOption, "Alias");
                databaseOption.Dbms = xml.ReadNodeAttributeValue(xmlNodeSettings, "Dbms");
                databaseOption.Assembly = xml.ReadNodeAttributeValue(xmlNodeSettings, "Assembly");
                databaseOption.Class = xml.ReadNodeAttributeValue(xmlNodeSettings, "Class");
                databaseOption.ConnectionString = xml.ReadNodeInnerText(xmlNodeConnectionString);

                databaseOptionDictionary.Add(databaseOption.Alias, databaseOption);
            }
        }

        /// <summary>
        /// Save database
        /// </summary>
        private static void SaveDatabase(LazyXml xml, XmlNode xmlNodeRoot)
        {
            XmlNode xmlNodeDatabase = xml.WriteNode(xmlNodeRoot, "Database");

            foreach (KeyValuePair<String, LibDatabaseOption> databaseOption in databaseOptionDictionary)
            {
                XmlNode xmlNodeOption = xml.WriteNode(xmlNodeDatabase, "Option");
                xml.WriteNodeAttribute(xmlNodeOption, "Alias", databaseOption.Value.Alias);

                XmlNode xmlNodeSettings = xml.WriteNode(xmlNodeOption, "Settings");
                xml.WriteNodeAttribute(xmlNodeSettings, "Dbms", databaseOption.Value.Dbms);
                xml.WriteNodeAttribute(xmlNodeSettings, "Assembly", databaseOption.Value.Assembly);
                xml.WriteNodeAttribute(xmlNodeSettings, "Class", databaseOption.Value.Class);

                XmlNode xmlNodeConnectionString = xml.WriteNode(xmlNodeSettings, "ConnectionString");
                xml.WriteNodeInnerText(xmlNodeConnectionString, databaseOption.Value.ConnectionString);
                
                xmlNodeConnectionString = null;
                xmlNodeSettings = null;
                xmlNodeOption = null;
            }

            xmlNodeDatabase = null;
        }

        /// <summary>
        /// Load dynamic xml
        /// </summary>
        private static void LoadDynamicXml(LazyXml xml)
        {
            XmlNodeList xmlNodeModuleList = xml.ReadNodeChildList("/Ark.Lib.Service/DynamicXml");

            foreach (XmlNode xmlNodeModule in xmlNodeModuleList)
            {
                LoadDynamicXmlNode(xml, xmlNodeModule, dynamicXml[xmlNodeModule.Name]);
                
                XmlAttributeCollection xmlAttributeCollection = xml.ReadNodeAttributeList(xmlNodeModule);
                foreach (XmlAttribute attribute in xmlAttributeCollection)
                    dynamicXml[xmlNodeModule.Name].Attribute[attribute.Name] = attribute.Value;
            }

            xmlNodeModuleList = null;
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
        private static void SaveDynamicXml(LazyXml xml, XmlNode xmlNodeRoot)
        {
            XmlNode xmlNodeDynamicXml = xml.WriteNode(xmlNodeRoot, "DynamicXml");

            foreach (KeyValuePair<String, LibDynamicXmlElement> module in dynamicXml.Modules)
            {
                XmlNode xmlNodeModule = xml.WriteNode(xmlNodeDynamicXml, module.Key);
                
                SaveDynamicXmlNode(xml, xmlNodeModule, module.Value);
                
                foreach (KeyValuePair<String, String> attribute in module.Value.Attribute.Collection)
                    xml.WriteNodeAttribute(xmlNodeModule, attribute.Key, attribute.Value);
            }

            xmlNodeDynamicXml = null;
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

        public static Dictionary<String, LibDatabaseOption> DatabaseOptionDictionary
        {
            get
            {
                if (databaseOptionDictionary == null)
                    Load();

                return databaseOptionDictionary;
            }
            set { databaseOptionDictionary = value; }
        }

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
