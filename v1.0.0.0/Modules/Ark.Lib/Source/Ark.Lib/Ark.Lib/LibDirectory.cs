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
using System.Collections.Generic;

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

                private static LibDirectoryAssemblyFolder assemblyFolder;

                #endregion Variables

                #region Methods
                #endregion Methods

                #region Properties

                public static String Path
                {
                    get { return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin"); }
                }

                public static LibDirectoryAssemblyFolder AssemblyFolder
                {
                    get
                    {
                        if (assemblyFolder == null)
                            assemblyFolder = new LibDirectoryAssemblyFolder(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin"));

                        return assemblyFolder;
                    }
                }

                #endregion Properties
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
                    get { return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dat"); }
                }

                #endregion Properties

                #region InternalClass
                #endregion InternalClass
            }

            #endregion InternalClass
        }

        #endregion InternalClass
    }

    public class LibDirectoryAssemblyFolder
    {
        #region Variables

        private String path;
        private Dictionary<String, LibDirectoryAssemblyFolderItem> assemblyFolderItemDictionary;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyFolder(String path)
        {
            this.path = path;
            this.assemblyFolderItemDictionary = new Dictionary<String, LibDirectoryAssemblyFolderItem>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public LibDirectoryAssemblyFolderItem this[String name]
        {
            get
            {
                if (this.assemblyFolderItemDictionary.ContainsKey(name) == false)
                    this.assemblyFolderItemDictionary.Add(name, new LibDirectoryAssemblyFolderItem(System.IO.Path.Combine(this.path, name)));

                return this.assemblyFolderItemDictionary[name];
            }
        }

        #endregion Indexers
    }

    public class LibDirectoryAssemblyFolderItem
    {
        #region Variables

        private String path;
        private LibDirectoryAssemblyVersion assemblyVersion;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyFolderItem(String path)
        {
            this.path = path;
            this.assemblyVersion = new LibDirectoryAssemblyVersion(this.path);
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Path
        {
            get { return this.path; }
        }

        public LibDirectoryAssemblyVersion Version
        {
            get { return this.assemblyVersion; }
        }

        public LibDirectoryAssemblyVersionItem CurrentVersion
        {
            get { return Version[LibEnvironment.Version.Package]; }
        }

        #endregion Properties
    }

    public class LibDirectoryAssemblyVersion
    {
        #region Variables

        private String path;
        private Dictionary<String, LibDirectoryAssemblyVersionItem> assemblyVersionItemDictionary;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersion(String path)
        {
            this.path = path;
            this.assemblyVersionItemDictionary = new Dictionary<String, LibDirectoryAssemblyVersionItem>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public LibDirectoryAssemblyVersionItem this[String value]
        {
            get
            {
                if (this.assemblyVersionItemDictionary.ContainsKey(value) == false)
                    this.assemblyVersionItemDictionary.Add(value, new LibDirectoryAssemblyVersionItem(System.IO.Path.Combine(this.path, value)));

                return this.assemblyVersionItemDictionary[value];
            }
        }

        #endregion Indexers
    }

    public class LibDirectoryAssemblyVersionItem
    {
        #region Variables

        private String path;
        private LibDirectoryAssemblyVersionLib assemblyVersionLib;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersionItem(String path)
        {
            this.path = path;
            this.assemblyVersionLib = new LibDirectoryAssemblyVersionLib(System.IO.Path.Combine(this.path, "lib"));
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Path
        {
            get { return this.path; }
        }

        public LibDirectoryAssemblyVersionLib Lib
        {
            get { return this.assemblyVersionLib; }
        }

        #endregion Properties
    }

    public class LibDirectoryAssemblyVersionLib
    {
        #region Variables

        private String path;
        private LibDirectoryAssemblyVersionLibItem netCoreApp31;
        private LibDirectoryAssemblyVersionLibItem netStandard20;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersionLib(String path)
        {
            this.path = path;
            this.netCoreApp31 = new LibDirectoryAssemblyVersionLibItem(System.IO.Path.Combine(path, "netcoreapp3.1"));
            this.netStandard20 = new LibDirectoryAssemblyVersionLibItem(System.IO.Path.Combine(path, "netstandard2.0"));
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public LibDirectoryAssemblyVersionLibItem NetCoreApp31
        {
            get { return this.netCoreApp31; }
        }

        public LibDirectoryAssemblyVersionLibItem NetStandard20
        {
            get { return this.netStandard20; }
        }

        #endregion Properties
    }

    public class LibDirectoryAssemblyVersionLibItem
    {
        #region Variables

        private String path;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersionLibItem(String path)
        {
            this.path = path;
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Path
        {
            get { return this.path; }
        }

        #endregion Properties
    }
}