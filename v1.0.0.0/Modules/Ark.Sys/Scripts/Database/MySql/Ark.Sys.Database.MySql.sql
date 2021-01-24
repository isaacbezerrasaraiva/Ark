use Ark;



-- Create tables section --------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------



-- Constraints section ----------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------



-- Initial data section ---------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

insert into FwkModule (IdDomain, CodModule, Description) values (1, 'Ark.Sys', 'Ark System');

insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Sys', 'SysRoleServerRecord', 'Ark.Fwk', 'FwkServerRecord');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysRoleServerRecord', 'Init');
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
