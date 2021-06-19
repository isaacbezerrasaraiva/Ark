// LibGlobalization.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 15

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

namespace Ark.Lib
{
    public static class LibGlobalization
    {
        #region Variables

        private static LibCulture culture;
        private static Dictionary<String, Dictionary<String, Dictionary<String, LazyXml>>> languageDictionary;

        #endregion Variables

        #region Methods

        public static String GetTranslation(String xPath)
        {
            return GetTranslation(xPath, Culture);
        }

        public static String GetTranslation(String xPath, LibCulture culture)
        {
            if (String.IsNullOrEmpty(xPath) == true)
                return xPath;

            if (xPath.StartsWith('/') == false)
                return xPath;

            xPath = String.Format(xPath, culture.Code);

            String fileName = xPath.Split('/', StringSplitOptions.RemoveEmptyEntries)[0] + ".xml";

            String[] fileNameArray = fileName.Split(".Language.", StringSplitOptions.RemoveEmptyEntries);
            if (fileNameArray.Length < 2)
                return xPath;

            String module = fileNameArray[0];

            fileNameArray = fileName.Split("." + culture.Code + ".", StringSplitOptions.RemoveEmptyEntries);
            if (fileNameArray.Length < 2)
                return xPath;

            String file = fileNameArray[1];

            if (languageDictionary == null)
                languageDictionary = new Dictionary<string, Dictionary<String, Dictionary<String, LazyXml>>>();

            if (languageDictionary.ContainsKey(module) == false)
                languageDictionary.Add(module, new Dictionary<String, Dictionary<String, LazyXml>>());

            if (languageDictionary[module].ContainsKey(culture.Code) == false)
                languageDictionary[module].Add(culture.Code, new Dictionary<String, LazyXml>());

            if (languageDictionary[module][culture.Code].ContainsKey(file) == false)
            {
                if (File.Exists(Path.Combine(LibDirectory.Root.Res.Languages.Path, fileName)) == false)
                    return xPath;

                LazyXml xmlFile = new LazyXml();
                try { xmlFile.Open(Path.Combine(LibDirectory.Root.Res.Languages.Path, fileName)); }
                catch { return xPath; }

                languageDictionary[module][culture.Code].Add(file, xmlFile);
            }

            String translation = null;
            try { translation = languageDictionary[module][culture.Code][file].ReadNodeInnerText(xPath); }
            catch { return xPath; }

            return translation;
        }

        #endregion Methods

        #region Properties

        public static LibCulture Culture
        {
            get
            {
                if (culture == null)
                    culture = new LibCulture();

                return culture;
            }
        }

        #endregion Properties
    }
}
