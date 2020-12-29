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
            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            #region Initialize configuration file

            // If configuration file not exists will be created a new one with default values
            if (File.Exists(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVER_XML)) == false)
                Save();

            #endregion Initialize configuration file

            #region Load xml

            LazyXml xml = new LazyXml();

            xml.Open(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVER_XML));

            LoadDynamicXml(xml);

            xml = null;

            #endregion Load xml
        }

        /// <summary>
        /// Save the configuration to file
        /// </summary>
        public static void Save()
        {
            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            #region Initialize default values

            #region DynamicXml

            #region Ark.Lib/Security/Preflight

            if (dynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Lib"]["Security"]["Preflight"].Attribute["Class"] = String.Empty;

            #endregion Ark.Lib/Security/Preflight

            #region Ark.Lib/Security/Authentication

            if (dynamicXml["Ark.Lib"]["Security"]["Authentication"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Lib"]["Security"]["Authentication"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Lib"]["Security"]["Authentication"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Lib"]["Security"]["Authentication"].Attribute["Class"] = String.Empty;

            #endregion Ark.Lib/Security/Authentication

            #region Ark.Lib/Security/Authorization

            if (dynamicXml["Ark.Lib"]["Security"]["Authorization"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Lib"]["Security"]["Authorization"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Lib"]["Security"]["Authorization"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Lib"]["Security"]["Authorization"].Attribute["Class"] = String.Empty;

            #endregion Ark.Lib/Security/Authorization

            #endregion DynamicXml

            #endregion Initialize default values

            #region Save xml

            LazyXml xml = new LazyXml();

            xml.New();

            XmlNode xmlNodeRoot = xml.WriteRoot("Ark.Lib.Server");

            SaveDynamicXml(xml, xmlNodeRoot);

            xml.Save(Path.Combine(LibDirectory.Root.Dat.Path, ARK_LIB_SERVER_XML));

            xmlNodeRoot = null;
            xml = null;

            #endregion Save xml
        }

        /// <summary>
        /// Load dynamic xml
        /// </summary>
        /// <param name="xml">The xml</param>
        private static void LoadDynamicXml(LazyXml xml)
        {
            dynamicXml.LoadDynamicXml(xml, "/Ark.Lib.Server/DynamicXml");
        }

        /// <summary>
        /// Save dynamic xml
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNodeRoot">The xml root node</param>
        private static void SaveDynamicXml(LazyXml xml, XmlNode xmlNodeRoot)
        {
            XmlNode xmlNodeDynamicXml = xml.WriteNode(xmlNodeRoot, "DynamicXml");

            dynamicXml.SaveDynamicXml(xml, xmlNodeDynamicXml);

            xmlNodeDynamicXml = null;
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
