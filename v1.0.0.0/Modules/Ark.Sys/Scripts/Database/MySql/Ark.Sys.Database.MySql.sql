use Ark;



-- Create tables section --------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

create table SysAutomationFeature
(
	IdDomain smallint,
    IdFeature smallint,
    CodModule varchar(32),
    CodFeature varchar(64),
    IdUser integer,
    Culture char(4),
    Enabled char(1),
    History char(1),
    Request text,
    constraint Pk_SysAutomationFeature primary key (IdDomain, IdFeature)
);

create table SysAutomationHost
(
	IdDomain smallint,
    IdHost smallint,
    Identifier varchar(64),
    Alias varchar(32),
    Enabled char(1),
    constraint Pk_SysAutomationHost primary key (IdDomain, IdHost)
);

create table SysAutomationWorker
(
	IdDomain smallint,
    IdHost smallint,
    IdWorker smallint,
    Guid varchar(32),
    Alias varchar(32),
    Enabled char(1),
    Count integer,
    Workload decimal,
    Status char(1),
    constraint Pk_SysAutomationWorker primary key (IdDomain, IdHost, IdWorker)
);

create table SysAutomationReservation
(
	IdDomain smallint,
    IdHost smallint,
    IdWorker smallint,
    IdFeature smallint,
    Exclusive char(1),
    Enabled char(1),
    constraint Pk_SysAutomationReservation primary key (IdDomain, IdHost, IdWorker)
);

create table SysAutomationScheduler
(
	IdDomain smallint,
    IdFeature smallint,
    IntervalTime smallint,
    LastExecution datetime,
    NextExecution datetime,
    constraint Pk_SysAutomationScheduler primary key (IdDomain, IdFeature)
);
    
create table SysAutomationExecution
(
	IdDomain smallint,
    IdFeature smallint,
    NextExecution datetime,
    IdHost smallint,
    constraint Pk_SysAutomationExecution primary key (IdDomain, IdFeature, NextExecution)
);

create table SysAutomationHistory
(
	IdDomain smallint,
    IdFeature smallint,
    LastExecution datetime,
    IdHost smallint,
    StartedAt datetime,
    FinishedAt datetime,
    Status char(1),
    Response text,
    constraint Pk_SysAutomationHistory primary key (IdDomain, IdFeature, LastExecution)
);



-- Constraints section ----------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

alter table SysAutomationFeature 
	add constraint Fk_SysAutomationFeature1 foreign key (IdDomain, CodModule, CodFeature) references FwkFeature (IdDomain, CodModule, CodFeature),
    add constraint Fk_SysAutomationFeature2 foreign key (IdDomain, IdUser) references FwkUser (IdDomain, IdUser);
    
alter table SysAutomationHost 
	add constraint Fk_SysAutomationHost1 foreign key (IdDomain) references FwkDomain (IdDomain),
    add constraint Uk_SysAutomationHost1 unique key (Identifier);
    
alter table SysAutomationWorker 
	add constraint Fk_SysAutomationWorker1 foreign key (IdDomain, IdHost) references SysAutomationHost (IdDomain, IdHost),
    add constraint Uk_SysAutomationWorker1 unique key (Guid);
    
alter table SysAutomationReservation 
	add constraint Fk_SysAutomationReservation1 foreign key (IdDomain, IdHost, IdWorker) references SysAutomationWorker (IdDomain, IdHost, IdWorker),
    add constraint Fk_SysAutomationReservation2 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature);
    
alter table SysAutomationScheduler 
    add constraint Fk_SysAutomationScheduler1 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature);
    
alter table SysAutomationExecution 
    add constraint Fk_SysAutomationExecution1 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature),
    add constraint Fk_SysAutomationExecution2 foreign key (IdDomain, IdHost) references SysAutomationHost (IdDomain, IdHost);
    
alter table SysAutomationHistory 
    add constraint Fk_SysAutomationHistory1 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature),
    add constraint Fk_SysAutomationHistory2 foreign key (IdDomain, IdHost) references SysAutomationHost (IdDomain, IdHost);



-- Initial data section ---------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

insert into FwkModule (IdDomain, CodModule, Description) values (1, 'Ark.Sys', 'Ark System');

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Sys', 'SysRoleServerView', 'Ark.Fwk', 'FwkServerView');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerView', 'Init');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerView', 'Format');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerView', 'ValidateRead');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerView', 'Read');

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Sys', 'SysRoleServerRecord', 'Ark.Fwk', 'FwkServerRecord');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Init');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Format');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'ValidateRead');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'ValidateInsert');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'ValidateIndate');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'ValidateUpdate');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'ValidateUpsert');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'ValidateDelete');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Read');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Insert');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Indate');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Update');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Upsert');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Delete');

insert into FtsIncrementTable (IdTable, TableName) select ifnull(max(IdTable)+1,1), 'FwkRole' from FtsIncrementTable;
insert into FtsIncrementByDomain (IdTable, IdDomain, IdLastIncrement) select IdTable, 1, 1 from FtsIncrementTable where TableName = 'FwkRole';
