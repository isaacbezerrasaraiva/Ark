// LibDirectory.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

using System;
using System.IO;
using System.Xml;
using System.Data;

namespace Ark.Lib
{
    public static class LibDirectory
    {
        #region Variables
        #endregion Variables

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region InternalClass

        public static class Root
        {
            #region Variables
            #endregion Variables

            #region Methods
            #endregion Methods

            #region Properties

            public static String Path
            {
                get { return AppDomain.CurrentDomain.BaseDirectory; }
            }

            #endregion Properties

            #region InternalClass

            public static class Bin
            {
                #region Variables
                #endregion Variables

                #region Methods
                #endregion Methods

                #region Properties

                public static String Path
                {
                    get { return AppDomain.CurrentDomain.BaseDirectory + "Bin\\"; }
                }

                #endregion Properties

                #region InternalClass
                #endregion InternalClass
            }

            public static class Dat
            {
                #region Variables
                #endregion Variables

                #region Methods
                #endregion Methods

                #region Properties

                public static String Path
                {
                    get { return AppDomain.CurrentDomain.BaseDirectory + "Dat\\"; }
                }

                #endregion Properties

                #region InternalClass
                #endregion InternalClass
            }

            #endregion InternalClass
        }

        #endregion InternalClass
    }
}