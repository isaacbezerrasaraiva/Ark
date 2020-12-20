// LibEnvironment.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 20

using System;
using System.Xml;
using System.Data;
using System.Reflection;

namespace Ark.Lib
{
    public static class LibEnvironment
    {
        #region Variables
        #endregion Variables

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region InternalClass

        public static class Version
        {
            #region Variables

            private static String assemblyVersion;
            private static String packageVersion;

            #endregion Variables

            #region Methods
            #endregion Methods

            #region Properties

            public static String Assembly
            {
                get
                {
                    if (String.IsNullOrEmpty(assemblyVersion) == true)
                        assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                    return assemblyVersion;
                }
            }

            public static String Package
            {
                get
                {
                    if (String.IsNullOrEmpty(packageVersion) == true)
                        packageVersion = Assembly.Substring(0, Assembly.LastIndexOf('.'));

                    return packageVersion;
                }
            }

            #endregion Properties
        }

        #endregion InternalClass
    }
}
