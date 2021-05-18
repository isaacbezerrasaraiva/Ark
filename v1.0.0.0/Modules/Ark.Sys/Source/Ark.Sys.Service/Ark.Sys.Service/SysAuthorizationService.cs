// SysAuthorizationService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

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
    public class SysAuthorizationService : FwkService, ISysAuthorizationService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationService(FwkEnvironment environment)
            : base(environment)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <returns>The authorization response data</returns>
        public SysAuthorizationDataResponse Authorize(SysAuthorizationDataRequest authorizationDataRequest)
        {
            this.Operation = "Authorize";

            SysAuthorizationDataResponse authorizationDataResponse = new SysAuthorizationDataResponse();

            PerformAuthorize(authorizationDataRequest, authorizationDataResponse);

            return authorizationDataResponse;
        }

        /// <summary>
        /// Perform service authorization
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <param name="authorizationDataResponse">The authorization response data</param>
        protected void PerformAuthorize(SysAuthorizationDataRequest authorizationDataRequest, SysAuthorizationDataResponse authorizationDataResponse)
        {
            #region BeforeAuthorize

            if (this.IPlugins != null)
            {
                foreach (ISysAuthorizationPlugin iAuthorizationPlugin in this.IPlugins)
                    iAuthorizationPlugin.AuthorizePluginBeforeEventHandler?.Invoke(this, new FwkPluginBeforeEventArgs(authorizationDataRequest, authorizationDataResponse));
            }

            #endregion BeforeAuthorize

            OnAuthorize(authorizationDataRequest, authorizationDataResponse);

            #region AfterAuthorize

            if (this.IPlugins != null)
            {
                foreach (ISysAuthorizationPlugin iAuthorizationPlugin in this.IPlugins)
                    iAuthorizationPlugin.AuthorizePluginAfterEventHandler?.Invoke(this, new FwkPluginAfterEventArgs(authorizationDataRequest, authorizationDataResponse));
            }

            #endregion AfterAuthorize
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <param name="authorizationDataResponse">The authorization response data</param>
        protected virtual void OnAuthorize(SysAuthorizationDataRequest authorizationDataRequest, SysAuthorizationDataResponse authorizationDataResponse)
        {
            #region Authorization Query

            String sqlAuthorization = @"
                select 1 
                from FwkBranchRoleUser 
	                inner join FwkBranchRoleAction 
		                on FwkBranchRoleUser.IdDomain = FwkBranchRoleAction.IdDomain 
                        and FwkBranchRoleUser.IdBranch = FwkBranchRoleAction.IdBranch 
                        and FwkBranchRoleUser.IdRole = FwkBranchRoleAction.IdRole 
	                inner join FwkUserContext 
		                on FwkBranchRoleUser.IdDomain = FwkUserContext.IdDomain 
                        and FwkBranchRoleUser.IdBranch = FwkUserContext.ValueInt16 
                        and FwkBranchRoleUser.IdUser = FwkUserContext.IdUser 
                where FwkBranchRoleUser.IdDomain = :IdDomain 
	                and FwkUserContext.Field = 'IdBranch' 
                    and FwkBranchRoleUser.IdUser = :IdUser 
                    and FwkBranchRoleAction.CodModule = :CodModule 
                    and FwkBranchRoleAction.CodFeature = :CodFeature 
                    and FwkBranchRoleAction.CodAction = :CodAction ";

            #endregion Authorization Query

            this.Database.OpenConnection();

            authorizationDataResponse.Content.Authorized =
                this.Database.QueryFind(sqlAuthorization, new Object[] {
                    authorizationDataRequest.Content.IdDomain,
                    authorizationDataRequest.Content.IdUser,
                    authorizationDataRequest.Content.CodModule,
                    authorizationDataRequest.Content.CodFeature,
                    authorizationDataRequest.Content.CodAction });

            this.Database.CloseConnection();
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
