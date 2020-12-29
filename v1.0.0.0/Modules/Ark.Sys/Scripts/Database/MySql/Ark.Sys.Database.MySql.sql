use Ark;



-- Create tables section --------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------



-- Constraints section ----------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------



-- Initial data section ---------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

insert into FwkModule (IdDomain, CodModule, Description) values (1, 'Ark.Sys', 'Ark System');
insert into FwkFeature (IdDomain, CodModule, CodFeature, CodModuleBase, CodFeatureBase) values (1, 'Ark.Sys', 'SysServerBasicLogin', 'Ark.Fwk', 'FwkServerBasic');
insert into FwkBranchRoleAction (IdDomain, IdBranch, IdRole, CodModule, CodFeature, CodAction) values (1, 1, 1, 'Ark.Sys', 'SysServerBasicLogin', 'Init');
