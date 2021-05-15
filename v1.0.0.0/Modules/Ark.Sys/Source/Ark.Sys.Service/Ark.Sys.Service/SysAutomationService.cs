// SysAutomationService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 21

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Threading;
using System.Collections.Generic;

using Newtonsoft.Json;

using Lazy;
using Lazy.Database;

using Ark.Lib;
using Ark.Lib.Service;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.IPlugin;
using Ark.Fwk.IService;
using Ark.Fwk.Service;
using Ark.Fts;
using Ark.Fts.Data;
using Ark.Fts.IPlugin;
using Ark.Fts.IService;
using Ark.Fts.Service;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IPlugin;
using Ark.Sys.IService;

namespace Ark.Sys.Service
{
    public class SysAutomationService : FwkService, ISysAutomationService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationService(FwkEnvironment environment)
            : base(environment)
        {
            environment.Culture = LibGlobalization.Culture;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Execute the service
        /// </summary>
        /// <param name="automationDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysAutomationDataResponse Execute(SysAutomationDataRequest automationDataRequest)
        {
            this.Operation = "Execute";

            SysAutomationDataResponse automationDataResponse = (SysAutomationDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

            // this.Database.OpenConnection(); // Must remove this because in this service the inherit database object is useless

            PerformExecute(automationDataRequest, automationDataResponse);

            // this.Database.CloseConnection(); // Must remove this because in this service the inherit database object is useless

            return automationDataResponse;
        }

        /// <summary>
        /// Perform service execute
        /// </summary>
        /// <param name="automationDataRequest">The request data</param>
        /// <param name="automationDataResponse">The response data</param>
        protected void PerformExecute(SysAutomationDataRequest automationDataRequest, SysAutomationDataResponse automationDataResponse)
        {
            BeforePerformExecute(automationDataRequest, automationDataResponse);

            #region Before OnExecute plugins

            if (this.IPlugins != null)
            {
                foreach (ISysAutomationPlugin iAutomationPlugin in this.IPlugins)
                    iAutomationPlugin.ExecutePluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(automationDataRequest, automationDataResponse));
            }

            #endregion Before OnExecute plugins

            OnExecute(automationDataRequest, automationDataResponse);

            #region After OnExecute plugins

            if (this.IPlugins != null)
            {
                foreach (ISysAutomationPlugin iAutomationPlugin in this.IPlugins)
                    iAutomationPlugin.ExecutePluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(automationDataRequest, automationDataResponse));
            }

            #endregion After OnExecute plugins

            AfterPerformExecute(automationDataRequest, automationDataResponse);
        }

        /// <summary>
        /// On service execute
        /// </summary>
        /// <param name="automationDataRequest">The request data</param>
        /// <param name="automationDataResponse">The response data</param>
        protected virtual void OnExecute(SysAutomationDataRequest automationDataRequest, SysAutomationDataResponse automationDataResponse)
        {
            #region Queries

            const string SQL_EXECUTION_CLEAN = @"
                select 
	                SysAutomationExecution.IdDomain, 
                    SysAutomationExecution.IdFeature, 
                    SysAutomationExecution.NextExecution 
                from SysAutomationHost 
	                inner join SysAutomationExecution 
		                on SysAutomationExecution.IdDomain = SysAutomationHost.IdDomain 
                        and SysAutomationExecution.IdHost = SysAutomationHost.IdHost 
                where SysAutomationHost.Identifier = :Identifier 
	                and SysAutomationHost.Enabled = '1' 
                    and SysAutomationExecution.NextExecution not in (
		                select NextExecution 
                        from SysAutomationScheduler 
                        where SysAutomationScheduler.IdDomain = SysAutomationExecution.IdDomain 
			                and SysAutomationScheduler.IdFeature = SysAutomationExecution.IdFeature 
                    ) ";

            const string SQL_SCHEDULER = @"
                select 
	                SysAutomationScheduler.IdDomain, 
                    SysAutomationScheduler.IdFeature, 
                    SysAutomationScheduler.NextExecution, 
                    SysAutomationHost.IdHost 
                from SysAutomationHost 
	                inner join SysAutomationFeature 
		                on SysAutomationFeature.IdDomain = SysAutomationHost.IdDomain 
	                inner join SysAutomationScheduler 
		                on SysAutomationScheduler.IdDomain = SysAutomationFeature.IdDomain 
                        and SysAutomationScheduler.IdFeature = SysAutomationFeature.IdFeature 
                where SysAutomationHost.Identifier = :Identifier 
	                and SysAutomationHost.Enabled = '1' 
                    and SysAutomationFeature.Enabled = '1' 
                    and SysAutomationScheduler.NextExecution > SysAutomationScheduler.LastExecution 
                    and SysAutomationScheduler.NextExecution <= :Now 
                    and SysAutomationScheduler.NextExecution not in ( 
		                select NextExecution 
                        from SysAutomationExecution 
                        where SysAutomationExecution.IdDomain = SysAutomationScheduler.IdDomain 
			                and SysAutomationExecution.IdFeature = SysAutomationScheduler.IdFeature 
	                ) ";

            const string SQL_WORKERS = @"
                select 
	                SysAutomationWorker.IdDomain, 
                    SysAutomationWorker.IdHost, 
                    SysAutomationWorker.IdWorker, 
                    SysAutomationWorker.Guid, 
                    SysAutomationWorker.Count, 
                    SysAutomationReservation.IdFeature, 
                    SysAutomationReservation.Exclusive 
                from SysAutomationHost 
	                inner join SysAutomationWorker 
		                on SysAutomationWorker.IdDomain = SysAutomationHost.IdDomain 
                        and SysAutomationWorker.IdHost = SysAutomationHost.IdHost 
	                left join SysAutomationReservation 
		                on SysAutomationReservation.IdDomain = SysAutomationWorker.IdDomain 
                        and SysAutomationReservation.IdHost = SysAutomationWorker.IdHost 
                        and SysAutomationReservation.IdWorker = SysAutomationWorker.IdWorker 
                        and SysAutomationReservation.Enabled = '1' 
                where SysAutomationHost.Identifier = :Identifier 
	                and SysAutomationHost.Enabled = '1' 
                    and SysAutomationWorker.Enabled = '1' 
                order by 
	                /* IdFeature must be filtered first to grant that reserved workers be process before non-reserved workers */
	                SysAutomationReservation.IdFeature desc, 
                    SysAutomationWorker.IdWorker ";

            const string SQL_EXECUTIONS = @"
                select 
	                SysAutomationExecution.IdDomain, 
                    SysAutomationExecution.IdFeature, 
                    SysAutomationExecution.NextExecution, 
                    SysAutomationExecution.IdHost, 
                    SysAutomationFeature.CodModule, 
                    SysAutomationFeature.CodFeature, 
                    SysAutomationFeature.IdUser, 
                    SysAutomationFeature.Culture, 
                    SysAutomationFeature.History, 
                    SysAutomationFeature.Request, 
                    SysAutomationScheduler.IntervalTime, 
                    SysAutomationScheduler.LastExecution, 
                    SysAutomationReservation.IdWorker 
                from SysAutomationHost 
	                inner join SysAutomationFeature 
		                on SysAutomationFeature.IdDomain = SysAutomationHost.IdDomain 
	                inner join SysAutomationScheduler 
		                on SysAutomationScheduler.IdDomain = SysAutomationFeature.IdDomain 
                        and SysAutomationScheduler.IdFeature = SysAutomationFeature.IdFeature 
	                inner join SysAutomationExecution 
		                on SysAutomationExecution.IdDomain = SysAutomationScheduler.IdDomain 
                        and SysAutomationExecution.IdFeature = SysAutomationScheduler.IdFeature 
                        and SysAutomationExecution.NextExecution = SysAutomationScheduler.NextExecution 
                    left join SysAutomationReservation 
	                    on SysAutomationReservation.IdDomain = SysAutomationExecution.IdDomain 
                        and SysAutomationReservation.IdFeature = SysAutomationExecution.IdFeature 
                        and SysAutomationReservation.IdHost = SysAutomationExecution.IdHost 
                where SysAutomationHost.Identifier = :Identifier 
	                and SysAutomationHost.Enabled = '1' 
                    and SysAutomationFeature.Enabled = '1' 
                order by 
                    SysAutomationExecution.NextExecution ";

            #endregion Queries

            try
            {
                foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementDatabaseAlias in LibServiceConfiguration.DynamicXml["Ark.Sys"]["Service"]["SysAutomationService"]["DefaultInstance"]["DatabaseAlias"].Elements)
                {
                    if (dynamicXmlElementDatabaseAlias.Value.Attribute["Enabled"].ToLower() == "true")
                    {
                        #region Initialize database

                        LibDynamicXmlElement dynamicXmlElementDatabaseSettings = LibServiceConfiguration.DynamicXml["Ark.Fwk"]["Database"][dynamicXmlElementDatabaseAlias.Key]["Settings"];

                        String databaseDbms = dynamicXmlElementDatabaseSettings.Attribute["Dbms"];
                        String databaseAssembly = dynamicXmlElementDatabaseSettings.Attribute["Assembly"];
                        String databaseClass = dynamicXmlElementDatabaseSettings.Attribute["Class"];
                        String databaseVersion = dynamicXmlElementDatabaseSettings.Attribute["Version"];
                        String databaseConnectionString = dynamicXmlElementDatabaseSettings["ConnectionString"].Text;
                        String assemblyFolderName = databaseAssembly.Replace(".dll", String.Empty);

                        LazyDatabase internalDatabase = (LazyDatabase)LazyActivator.Local.CreateInstance(Path.Combine(
                            LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[databaseVersion].Lib.NetCoreApp31.Path, databaseAssembly),
                            databaseClass, new Object[] { databaseConnectionString });

                        internalDatabase.OpenConnection();

                        #endregion Initialize database

                        #region Clean invalid executions

                        try
                        {
                            DataTable dataTableExecutionClean = internalDatabase.QueryTable(SQL_EXECUTION_CLEAN, "SysAutomationExecution",
                                new Object[] { System.Environment.MachineName },
                                new String[] { "Identifier" });

                            dataTableExecutionClean.PrimaryKey = new DataColumn[] { 
                                dataTableExecutionClean.Columns["IdDomain"], 
                                dataTableExecutionClean.Columns["IdFeature"], 
                                dataTableExecutionClean.Columns["NextExecution"] };

                            if (dataTableExecutionClean.Rows.Count > 0)
                                internalDatabase.DeleteAll("SysAutomationExecution", dataTableExecutionClean, DataRowState.Unchanged);
                        }
                        catch
                        {
                            /* Nothing to do here yet */
                        }

                        #endregion Clean invalid executions

                        #region Scheduler features

                        DataTable dataTableScheduler = internalDatabase.QueryTable(SQL_SCHEDULER, "SysAutomationScheduler",
                            new Object[] { System.Environment.MachineName, DateTime.Now },
                            new String[] { "Identifier", "Now" });

                        foreach (DataRow dataRowScheduler in dataTableScheduler.Rows)
                        {
                            try { internalDatabase.Insert("SysAutomationExecution", dataRowScheduler, DataRowState.Unchanged); }
                            catch { /* Nothing to do here yet */ }
                        }

                        #endregion Scheduler features

                        #region Execute features

                        DataTable dataTableWorkers = internalDatabase.QueryTable(SQL_WORKERS, "SysAutomationWorker",
                            new Object[] { System.Environment.MachineName },
                            new String[] { "Identifier" });

                        DataTable dataTableExecutions = internalDatabase.QueryTable(SQL_EXECUTIONS, "SysAutomationExecution",
                            new Object[] { System.Environment.MachineName },
                            new String[] { "Identifier" });

                        foreach (DataRow dataRowWorker in dataTableWorkers.Rows)
                        {
                            if (dataTableExecutions.Rows.Count == 0)
                                break;

                            if (SysAutomationWorkerController.Status[LazyConvert.ToString(dataRowWorker["Guid"])] == false)
                            {
                                String sqlFilter = null;
                                DataRow[] dataRowExecutionArray = null;

                                if (String.IsNullOrEmpty(LazyConvert.ToString(dataRowWorker["IdFeature"], null)) == false)
                                {
                                    sqlFilter = "IdDomain = {0} and IdHost = {1} and IdFeature = {2}";
                                    sqlFilter = String.Format(sqlFilter, dataRowWorker["IdDomain"], dataRowWorker["IdHost"], dataRowWorker["IdFeature"]);

                                    dataRowExecutionArray = dataTableExecutions.Select(sqlFilter);

                                    if (dataRowExecutionArray.Length > 0)
                                    {
                                        PrepareAutomationWorker(dataRowWorker, dataRowExecutionArray[0], internalDatabase);
                                        dataTableExecutions.Rows.Remove(dataRowExecutionArray[0]);
                                    }
                                    else
                                    {
                                        if (LazyConvert.ToInt32(dataRowWorker["Exclusive"], 0) == 0)
                                        {
                                            sqlFilter = "IdDomain = {0} and IdHost = {1} and IdWorker is null";
                                            sqlFilter = String.Format(sqlFilter, dataRowWorker["IdDomain"], dataRowWorker["IdHost"]);

                                            dataRowExecutionArray = dataTableExecutions.Select(sqlFilter);

                                            if (dataRowExecutionArray.Length > 0)
                                            {
                                                PrepareAutomationWorker(dataRowWorker, dataRowExecutionArray[0], internalDatabase);
                                                dataTableExecutions.Rows.Remove(dataRowExecutionArray[0]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    sqlFilter = "IdDomain = {0} and IdHost = {1} and IdWorker is null";
                                    sqlFilter = String.Format(sqlFilter, dataRowWorker["IdDomain"], dataRowWorker["IdHost"]);

                                    dataRowExecutionArray = dataTableExecutions.Select(sqlFilter);

                                    if (dataRowExecutionArray.Length > 0)
                                    {
                                        PrepareAutomationWorker(dataRowWorker, dataRowExecutionArray[0], internalDatabase);
                                        dataTableExecutions.Rows.Remove(dataRowExecutionArray[0]);
                                    }
                                }
                            }
                        }

                        #endregion Execute features

                        #region Release database

                        internalDatabase.CloseConnection();

                        #endregion Release database
                    }
                }
            }
            catch
            {
                /* Nothing to do here yet */
            }
        }

        /// <summary>
        /// Before perform service execute
        /// </summary>
        /// <param name="automationDataRequest">The request data</param>
        /// <param name="automationDataResponse">The response data</param>
        private void BeforePerformExecute(SysAutomationDataRequest automationDataRequest, SysAutomationDataResponse automationDataResponse)
        {
        }

        /// <summary>
        /// After perform service execute
        /// </summary>
        /// <param name="automationDataRequest">The request data</param>
        /// <param name="automationDataResponse">The response data</param>
        private void AfterPerformExecute(SysAutomationDataRequest automationDataRequest, SysAutomationDataResponse automationDataResponse)
        {
        }

        /// <summary>
        /// Prepare automation worker
        /// </summary>
        /// <param name="dataRowWorker">The worker datarow</param>
        /// <param name="dataRowExecution">The execution datarow</param>
        /// <param name="databaseType">The database type</param>
        /// <param name="connectionString">The database connection string</param>
        private void PrepareAutomationWorker(DataRow dataRowWorker, DataRow dataRowExecution, LazyDatabase internalDatabase)
        {
            #region Queries

            const string SQL_SCHEDULER_UPDATE = @"
                update SysAutomationScheduler set 
	                LastExecution = NextExecution, 
                    NextExecution = :NextExecution 
                where SysAutomationScheduler.IdDomain = :IdDomain 
	                and SysAutomationScheduler.IdFeature = :IdFeature ";

            #endregion Queries

            try
            {
                SysAutomation automation = new SysAutomation();
                automation.IdDomain = LazyConvert.ToInt16(dataRowWorker["IdDomain"]);
                automation.IdHost = LazyConvert.ToInt16(dataRowWorker["IdHost"]);
                automation.IdWorker = LazyConvert.ToInt16(dataRowWorker["IdWorker"]);
                automation.Guid = LazyConvert.ToString(dataRowWorker["Guid"]);
                automation.Count = LazyConvert.ToInt32(dataRowWorker["Count"]);
                automation.IdFeature = LazyConvert.ToInt16(dataRowExecution["IdFeature"]);
                automation.CodModule = LazyConvert.ToString(dataRowExecution["CodModule"]);
                automation.CodFeature = LazyConvert.ToString(dataRowExecution["CodFeature"]);
                automation.IdUser = LazyConvert.ToInt32(dataRowExecution["IdUser"]);
                automation.Culture = LazyConvert.ToString(dataRowExecution["Culture"]);
                automation.History = LazyConvert.ToChar(dataRowExecution["History"]);
                automation.Request = LazyConvert.ToString(dataRowExecution["Request"]);
                automation.IntervalTime = LazyConvert.ToInt16(dataRowExecution["IntervalTime"]);
                automation.NextExecution = LazyConvert.ToDateTime(dataRowExecution["NextExecution"]);
                automation.LastExecution = LazyConvert.ToDateTime(dataRowExecution["LastExecution"]);

                #region Scheduler next execution

                Double missingExecution = (((DateTime.Now - automation.NextExecution).TotalSeconds) / automation.IntervalTime);
                DateTime dateTimeNextExecution = automation.NextExecution.AddSeconds((missingExecution * automation.IntervalTime) + automation.IntervalTime);

                internalDatabase.QueryExecute(SQL_SCHEDULER_UPDATE,
                    new Object[] { dateTimeNextExecution, automation.IdDomain, automation.IdFeature },
                    new String[] { "NextExecution", "IdDomain", "IdFeature" });

                #endregion Scheduler next execution

                Dictionary<String, Object> threadDataDictionary = new Dictionary<String, Object>();
                threadDataDictionary.Add("Automation", automation);
                threadDataDictionary.Add("DatabaseType", internalDatabase.GetType());
                threadDataDictionary.Add("ConnectionString", internalDatabase.ConnectionString);

                Thread thread = new Thread(new ParameterizedThreadStart(ExecuteAutomationWorker));
                thread.Start(threadDataDictionary);
            }
            catch
            {
                /* Nothing to do here yet */
            }
        }

        /// <summary>
        /// Execute automation worker
        /// </summary>
        /// <param name="data">Automation worker data</param>
        private void ExecuteAutomationWorker(Object data)
        {
            #region Queries

            const string SQL_WORKER_STATUS = @"
                update SysAutomationWorker set 
                    Status = :Status, 
                    Count = :Count 
                where IdDomain = :IdDomain 
                    and IdHost = :IdHost 
                    and IdWorker = :IdWorker ";

            const string SQL_HISTORY = @"
                insert into SysAutomationHistory values (:IdDomain, :IdFeature, :LastExecution, :IdHost, :StartedAt, :FinishedAt, :Status, :Response) ";

            const string SQL_EXECUTION_DELETE = @"
                delete 
                from SysAutomationExecution 
                where IdDomain = :IdDomain 
	                and IdFeature = :IdFeature 
                    and NextExecution = :NextExecution ";

            #endregion Queries

            try
            {
                Dictionary<String, Object> threadDataDictionary = (Dictionary<String, Object>)data;
                SysAutomation automation = (SysAutomation)threadDataDictionary["Automation"];
                LazyDatabase threadDatabase = (LazyDatabase)LazyActivator.Local.CreateInstance(
                    (Type)threadDataDictionary["DatabaseType"], new Object[] { (String)threadDataDictionary["ConnectionString"] });

                #region Before execute feature

                threadDatabase.OpenConnection();

                #region Set worker status to busy on memory

                SysAutomationWorkerController.Status[automation.Guid] = true;

                #endregion Set worker status to busy on memory

                #region Set worker status to busy on database

                try
                {
                    threadDatabase.QueryExecute(SQL_WORKER_STATUS,
                        new Object[] { '1', automation.Count, automation.IdDomain, automation.IdHost, automation.IdWorker },
                        new String[] { "Status", "Count", "IdDomain", "IdHost", "IdWorker" });
                }
                catch
                {
                    /* Nothing to do here yet */
                }

                #endregion Set worker status to busy on database

                #endregion Before execute feature

                #region On execute feature

                FwkEnvironment environment = null;

                String assemblyFolderName = null;
                String classFullName = null;

                IFwkService iService = null;
                FwkDataRequest dataRequest = null;
                FwkDataResponse dataResponse = null;

                DateTime dateTimeStarted = DateTime.Now;
                DateTime dateTimeFinished = DateTime.Now;

                try
                {
                    #region Create environment

                    environment = new FwkEnvironment();
                    environment.Domain = new FwkDomain();
                    environment.Domain.IdDomain = automation.IdDomain;
                    environment.User = new FwkUser();
                    environment.User.IdDomain = automation.IdDomain;
                    environment.User.IdUser = automation.IdUser;
                    environment.UserContext = new FwkUserContext();
                    environment.UserContext["IdDomain"].ValueInt16 = automation.IdDomain;
                    environment.Culture = new LibCulture(automation.Culture);

                    #endregion Create environment

                    #region Create service

                    assemblyFolderName = automation.CodModule + ".Service";
                    classFullName = automation.CodModule + ".Service." + automation.CodFeature.Replace("Server", "Service");

                    iService = (IFwkService)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                        classFullName, new Object[] { environment });

                    if ((iService is FwkServiceProcess) == false)
                        throw new LibException(Properties.SysResourcesService.SysExceptionAutomationInvalidService, Properties.SysResourcesService.SysCaptionInvalidType);

                    #endregion Create service

                    #region Create data

                    assemblyFolderName = automation.CodModule + ".Data";
                    classFullName = automation.CodModule + ".Data." + automation.CodFeature.Replace("Server", "Data") + "Request";

                    Type dataRequestType = (Type)LazyActivator.Local.GetType(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.NetCoreApp31.Path, assemblyFolderName + ".dll"),
                        classFullName);

                    dataRequest = (FwkDataRequest)JsonConvert.DeserializeObject(automation.Request, dataRequestType);

                    #endregion Create data

                    #region Execute service

                    dateTimeStarted = DateTime.Now;

                    dataResponse = ((IFwkServiceProcess)iService).Execute((FwkDataProcessRequest)dataRequest);

                    dateTimeFinished = DateTime.Now;

                    #endregion Execute service

                    #region Write response scope success

                    if (String.IsNullOrEmpty(dataResponse.Scope.StatusCode) == true)
                        dataResponse.Scope.StatusCode = LazyDecorator.GetCustomAttributeFromEnumValue(FwkScopeStatus.Success).Code;

                    if (String.IsNullOrEmpty(dataResponse.Scope.StatusName) == true)
                        dataResponse.Scope.StatusName = LazyDecorator.GetCustomAttributeFromEnumValue(FwkScopeStatus.Success).Name;

                    if (String.IsNullOrEmpty(dataResponse.Scope.StatusCaption) == true)
                        dataResponse.Scope.StatusCaption = LibGlobalization.GetTranslation(Properties.SysResourcesService.SysCaptionSuccess, environment.Culture);

                    if (String.IsNullOrEmpty(dataResponse.Scope.StatusMessage) == true)
                        dataResponse.Scope.StatusMessage = LibGlobalization.GetTranslation(Properties.SysResourcesService.SysMessageSuccess, environment.Culture);

                    #endregion Write response scope success

                    automation.Status = 'S';
                    automation.Response = (String)JsonConvert.SerializeObject(dataResponse, dataResponse.GetType(), null);
                }
                catch (Exception exp)
                {
                    dataResponse = new FwkDataResponse();

                    #region Write response scope error

                    dataResponse.Scope.StatusCode = LazyDecorator.GetCustomAttributeFromEnumValue(FwkScopeStatus.Error).Code;
                    dataResponse.Scope.StatusName = LazyDecorator.GetCustomAttributeFromEnumValue(FwkScopeStatus.Error).Name;
                    dataResponse.Scope.StatusCaption = LibException.GetExceptionCaption(exp.InnerException == null ? exp : exp.InnerException, environment.Culture);
                    dataResponse.Scope.StatusMessage = LibException.GetExceptionMessage(exp.InnerException == null ? exp : exp.InnerException, environment.Culture);

                    #endregion Write response scope error

                    automation.Status = 'E';
                    automation.Response = (String)JsonConvert.SerializeObject(dataResponse, typeof(FwkDataResponse), null);
                }

                #endregion On execute feature

                #region After execute feature

                #region Save execution history

                if (automation.History == '1')
                {
                    try
                    {
                        threadDatabase.QueryExecute(SQL_HISTORY,
                            new Object[] { automation.IdDomain, automation.IdFeature, automation.NextExecution, automation.IdHost, dateTimeStarted, dateTimeFinished, automation.Status, automation.Response },
                            new String[] { "IdDomain", "IdFeature", "LastExecution", "IdHost", "StartedAt", "FinishedAt", "Status", "Response" });
                    }
                    catch
                    {
                        /* Nothing to do here yet */
                    }
                }

                #endregion Save execution history

                #region Delete current NextExecution

                try
                {
                    threadDatabase.QueryExecute(SQL_EXECUTION_DELETE,
                        new Object[] { automation.IdDomain, automation.IdFeature, automation.NextExecution },
                        new String[] { "IdDomain", "IdFeature", "NextExecution" });
                }
                catch
                {
                    /* Nothing to do here yet */
                }

                #endregion Delete current NextExecution

                #region Set worker status to free on database

                try
                {
                    threadDatabase.QueryExecute(SQL_WORKER_STATUS,
                        new Object[] { '0', automation.Count + 1, automation.IdDomain, automation.IdHost, automation.IdWorker },
                        new String[] { "Status", "Count", "IdDomain", "IdHost", "IdWorker" });
                }
                catch
                {
                    /* Nothing to do here yet */
                }

                #endregion Set worker status to free on database

                #region Set worker status to free on memory

                SysAutomationWorkerController.Status[automation.Guid] = false;

                #endregion Set worker status to free on memory

                threadDatabase.CloseConnection();

                #endregion After execute feature
            }
            catch
            {
                /* Nothing to do here yet */
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
