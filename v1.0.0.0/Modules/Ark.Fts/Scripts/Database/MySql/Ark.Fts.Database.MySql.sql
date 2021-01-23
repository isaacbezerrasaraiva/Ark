use Ark;



-- Create tables section --------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

create table FtsIncrementTable
(
	IdTable smallint,
    TableName varchar(32),
    constraint Pk_FtsIncrementTable primary key (IdTable)
);

create table FtsIncrementControllerTable
(
	ControllerTableName varchar(32),
    constraint Pk_FtsIncrementControllerTable primary key (ControllerTableName)
);

create table FtsIncrementByDomain
(
	IdTable smallint,
    IdDomain smallint,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByDomain primary key (IdTable, IdDomain)
);

create table FtsIncrementByDomainMaster
(
	IdTable smallint,
    IdDomain smallint,
    IdMaster integer,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByDomainMaster primary key (IdTable, IdDomain, IdMaster)
);

create table FtsIncrementByBranch
(
	IdTable smallint,
    IdDomain smallint,
    IdBranch smallint,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByBranch primary key (IdTable, IdDomain, IdBranch)
);

create table FtsIncrementByBranchMaster
(
	IdTable smallint,
    IdDomain smallint,
    IdBranch smallint,
    IdMaster integer,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByBranchMaster primary key (IdTable, IdDomain, IdBranch, IdMaster)
);



-- Constraints section ----------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

alter table FtsIncrementTable 
	add constraint Uk_FtsIncrementTable1 unique key (TableName);
    
alter table FtsIncrementByDomain 
	add constraint Fk_FtsIncrementByDomain1 foreign key (IdTable) references FtsIncrementTable (IdTable),
    add constraint Fk_FtsIncrementByDomain2 foreign key (IdDomain) references FwkDomain (IdDomain);
    
alter table FtsIncrementByDomainMaster 
	add constraint Fk_FtsIncrementByDomainMaster1 foreign key (IdTable) references FtsIncrementTable (IdTable),
    add constraint Fk_FtsIncrementByDomainMaster2 foreign key (IdDomain) references FwkDomain (IdDomain);
    
alter table FtsIncrementByBranch 
	add constraint Fk_FtsIncrementByBranch1 foreign key (IdTable) references FtsIncrementTable (IdTable),
    add constraint Fk_FtsIncrementByBranch2 foreign key (IdDomain, IdBranch) references FwkBranch (IdDomain, IdBranch);
    
alter table FtsIncrementByBranchMaster 
	add constraint Fk_FtsIncrementByBranchMaster1 foreign key (IdTable) references FtsIncrementTable (IdTable),
    add constraint Fk_FtsIncrementByBranchMaster2 foreign key (IdDomain, IdBranch) references FwkBranch (IdDomain, IdBranch);



-- Initial data section ---------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

insert into FwkModule (IdDomain, CodModule, Description) values (1, 'Ark.Fts', 'Ark Facilities');

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Fts', 'FtsIncrementServer', 'Ark.Fwk', 'FwkServer');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fts', 'FtsIncrementServer', 'ValidateNext', 'Validate generate next ids');
insert into FwkFeatureAction (IdDomain, CodModule, CodFeature, CodAction, Description) values (1, 'Ark.Fts', 'FtsIncrementServer', 'Next', 'Generate next ids');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Fts', 'FtsIncrementServer', 'ValidateNext');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Fts', 'FtsIncrementServer', 'Next');

insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByDomain');
insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByDomainMaster');
insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByBranch');
insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByBranchMaster');
