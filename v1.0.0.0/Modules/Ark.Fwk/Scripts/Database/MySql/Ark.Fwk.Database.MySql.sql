use Ark;



-- Create tables section --------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

create table FwkDomain
(
	IdDomain smallint,
    CodDomain varchar(16),
    Name varchar(64),
    constraint Pk_FwkDomain primary key (IdDomain)
);

create table FwkModule
(
	IdDomain smallint,
    CodModule varchar(32),
    Description varchar(64),
    constraint Pk_FwkModule primary key (IdDomain, CodModule)
);

create table FwkFeature
(
	IdDomain smallint,
    CodModule varchar(32),
    CodFeature varchar(64),
    CodModuleBase varchar(32),
    CodFeatureBase varchar(64),
    Description varchar(64),
    constraint Pk_FwkFeature primary key (IdDomain, CodModule, CodFeature)
);

create table FwkFeatureAction
(
	IdDomain smallint,
    CodModule varchar(32),
    CodFeature varchar(64),
    CodAction varchar(16),
    Description varchar(64),
    constraint Pk_FwkFeatureAction primary key (IdDomain, CodModule, CodFeature, CodAction)
);

create table FwkUser
(
	IdDomain smallint,
    IdUser integer,
    Username varchar(32),
    Password varchar(64),
    DisplayName varchar(32),
    constraint Pk_FwkUser primary key (IdDomain, IdUser)
);

create table FwkUserContext
(
	IdDomain smallint,
    IdUser integer,
    Field varchar(32),
    ValueInt16 integer,
    ValueInt32 integer,
    ValueString varchar(64),
    constraint Pk_FwkUserContext primary key (IdDomain, IdUser, Field)
);

create table FwkRole
(
	IdDomain smallint,
    IdRole smallint,
    Name varchar(32),
    constraint Pk_FwkRole primary key (IdDomain, IdRole)
);

create table FwkBranch
(
	IdDomain smallint,
    IdBranch smallint,
    CodBranch varchar(16),
    Name varchar(64),
    constraint Pk_FwkBranch primary key (IdDomain, IdBranch)
);

create table FwkBranchUser
(
	IdDomain smallint,
    IdBranch smallint,
    IdUser integer,
    constraint Pk_FwkBranchUser primary key (IdDomain, IdBranch, IdUser)
);

create table FwkBranchRole
(
	IdDomain smallint,
    IdBranch smallint,
    IdRole smallint,
    constraint Pk_FwkBranchRole primary key (IdDomain, IdBranch, IdRole)
);

create table FwkBranchRoleUser
(
	IdDomain smallint,
    IdBranch smallint,
    IdRole smallint,
    IdUser integer,
    constraint Pk_FwkBranchRoleUser primary key (IdDomain, IdBranch, IdRole, IdUser)
);

create table FwkBranchRoleAction
(
	IdDomain smallint,
    IdBranch smallint,
    IdRole smallint,
    CodModule varchar(32),
    CodFeature varchar(64),
    CodAction varchar(16),
    constraint Pk_FwkBranchRoleAction primary key (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction)
);



-- Add constraints section ------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

alter table FwkDomain 
	add constraint Uk_FwkDomain1 unique key (CodDomain);
    
alter table FwkModule 
	add constraint Fk_FwkModule1 foreign key (IdDomain) references FwkDomain (IdDomain);
    
alter table FwkFeature 
	add constraint Fk_FwkFeature1 foreign key (IdDomain, CodModule) references FwkModule (IdDomain, CodModule), 
    add constraint Fk_FwkFeature2 foreign key (IdDomain, CodModuleBase, CodFeatureBase) references FwkFeature (IdDomain, CodModule, CodFeature);
    
alter table FwkFeatureAction 
	add constraint Fk_FwkFeatureAction1 foreign key (IdDomain, CodModule, CodFeature) references FwkFeature (IdDomain, CodModule, CodFeature);
    
alter table FwkUser 
	add constraint Fk_FwkUser1 foreign key (IdDomain) references FwkDomain (IdDomain),
    add constraint Uk_FwkUser1 unique key (IdDomain, Username);
    
alter table FwkUserContext 
	add constraint Fk_FwkUserContext1 foreign key (IdDomain, IdUser) references FwkUser (IdDomain, IdUser);
    
alter table FwkRole 
	add constraint Fk_FwkRole1 foreign key (IdDomain) references FwkDomain (IdDomain),
    add constraint Uk_FwkRole1 unique key (IdDomain, Name);
    
alter table FwkBranch 
	add constraint Fk_FwkBranch1 foreign key (IdDomain) references FwkDomain (IdDomain),
    add constraint Uk_FwkBranch1 unique key (IdDomain, CodBranch);
    
alter table FwkBranchUser 
	add constraint Fk_FwkBranchUser1 foreign key (IdDomain, IdBranch) references FwkBranch (IdDomain, IdBranch), 
    add constraint Fk_FwkBranchUser2 foreign key (IdDomain, IdUser) references FwkUser (IdDomain, IdUser);
    
alter table FwkBranchRole 
	add constraint Fk_FwkBranchRole1 foreign key (IdDomain, IdBranch) references FwkBranch (IdDomain, IdBranch), 
    add constraint Fk_FwkBranchRole2 foreign key (IdDomain, IdRole) references FwkRole (IdDomain, IdRole);
    
alter table FwkBranchRoleUser 
	add constraint Fk_FwkBranchRoleUser1 foreign key (IdDomain, IdBranch, IdRole) references FwkBranchRole (IdDomain, IdBranch, IdRole), 
    add constraint Fk_FwkBranchRoleUser2 foreign key (IdDomain, IdBranch, IdUser) references FwkBranchUser (IdDomain, IdBranch, IdUser);
    
alter table FwkBranchRoleAction 
	add constraint Fk_FwkBranchRoleAction1 foreign key (IdDomain, IdBranch, IdRole) references FwkBranchRole (IdDomain, IdBranch, IdRole), 
    add constraint Fk_FwkBranchRoleAction2 foreign key (IdDomain, CodModule, CodFeature) references FwkFeature (IdDomain, CodModule, CodFeature);



-- Initial data section ---------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

insert into FwkDomain (IdDomain, CodDomain, Name) values (1, 'DMN', 'Domínio');
insert into FwkUser (IdDomain, IdUser, Username, Password, DisplayName) values (1, 1, 'admin', 'admin', 'Admin');
insert into FwkRole (IdDomain, IdRole, Name) values (1, 1, 'Admin');
insert into FwkBranch (IdDomain, IdBranch, CodBranch, Name) values (1, 1, 'BCH', 'Branch');
insert into FwkBranchUser (IdDomain, IdBranch, IdUser) values (1, 1, 1);
insert into FwkUserContext (IdDomain, IdUser, Field, ValueInt16) values (1, 1, 'IdBranch', 1);
insert into FwkBranchRole (IdDomain, IdBranch, IdRole) values (1, 1, 1);
insert into FwkBranchRoleUser (IdDomain, IdBranch, IdRole, IdUser) values (1, 1, 1, 1);

insert into FwkModule (IdDomain, CodModule, Description) values (1, 'Ark.Fwk', 'Ark Framework');

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Fwk', 'FwkServer', null, null);

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Fwk', 'FwkServerBasic', 'Ark.Fwk', 'FwkServer');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerBasic', 'Init', 'Initialize');

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Fwk', 'FwkServerView', 'Ark.Fwk', 'FwkServerBasic');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerView', 'Format', 'Format the view');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerView', 'ValidateRead', 'Validate read view');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerView', 'Read', 'Read view');

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Ark.Fwk', 'FwkServerBasic');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Format', 'Format the record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'ValidateRead', 'Validate read record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'ValidateInsert', 'Validate insert record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'ValidateIndate', 'Validate indate record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'ValidateUpdate', 'Validate update record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'ValidateUpsert', 'Validate upsert record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'ValidateDelete', 'Validate delete record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Read', 'Read record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Insert', 'Insert record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Indate', 'Indate record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Update', 'Update record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Upsert', 'Upsert record');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fwk', 'FwkServerRecord', 'Delete', 'Delete record');
