// SysAutomation.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 07

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

using Ark.Lib;
using Ark.Fwk;
//using Ark.Fts;

namespace Ark.Sys
{
    public class SysAutomation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomation()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Int16 IdDomain { get; set; }

        public Int16 IdHost { get; set; }

        public Int16 IdWorker { get; set; }

        public String Guid { get; set; }

        public Int32 Count { get; set; }

        public Int16 IdFeature { get; set; }

        public String CodModule { get; set; }

        public String CodFeature { get; set; }

        public Int32 IdUser { get; set; }

        public String Culture { get; set; }

        public Char History { get; set; }

        public String Request { get; set; }

        public Int16 IntervalTime { get; set; }

        public DateTime NextExecution { get; set; }

        public DateTime LastExecution { get; set; }

        public Char Status { get; set; }

        public String Response { get; set; }

        #endregion Properties
    }

    public class SysAutomationWorkerStatus
    {
        #region Variables

        private Dictionary<String, Boolean> statusDictionary;

        #endregion Variables

        #region Constructors

        public SysAutomationWorkerStatus()
        {
            this.statusDictionary = new Dictionary<String, Boolean>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Boolean this[String guid]
        {
            get
            {
                if (this.statusDictionary.ContainsKey(guid) == false)
                    this.statusDictionary.Add(guid, false);

                return this.statusDictionary[guid];
            }
            set
            {
                if (this.statusDictionary.ContainsKey(guid) == false)
                    this.statusDictionary.Add(guid, value);
                else
                    this.statusDictionary[guid] = value;
            }
        }

        #endregion Properties
    }

    public static class SysAutomationWorkerController
    {
        #region Variables

        private static SysAutomationWorkerStatus automationWorkerStatus;

        #endregion Variables

        #region Methods
        #endregion Methods

        #region Properties

        public static SysAutomationWorkerStatus Status
        {
            get
            {
                if (automationWorkerStatus == null)
                    automationWorkerStatus = new SysAutomationWorkerStatus();

                return automationWorkerStatus;
            }
        }

        #endregion Properties
    }
}