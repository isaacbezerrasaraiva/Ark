use Ark; 

delimiter $$ 

drop procedure if exists SpFwkGetFeatureActionNested $$ 
create procedure SpFwkGetFeatureActionNested 
(in inIdDomain smallint, in inCodModule varchar(32), in inCodFeature varchar(64)) 
begin 

	with recursive FwkFeaturePaths as 
	(
		select 
			FwkFeature.IdDomain, 
			FwkFeature.CodModule, 
			FwkFeature.CodFeature, 
			FwkFeature.CodModuleBase, 
			FwkFeature.CodFeatureBase 
		from FwkFeature 
		where FwkFeature.IdDomain = inIdDomain 
			and FwkFeature.CodModule = inCodModule 
			and FwkFeature.CodFeature = inCodFeature 
		
		union all 
		
		select 
			FwkFeature.IdDomain, 
			FwkFeature.CodModule, 
			FwkFeature.CodFeature, 
			FwkFeature.CodModuleBase, 
			FwkFeature.CodFeatureBase 
		from FwkFeature 
			inner join FwkFeaturePaths 
				on FwkFeature.IdDomain = FwkFeaturePaths.IdDomain 
				and FwkFeature.CodModule = FwkFeaturePaths.CodModuleBase 
				and FwkFeature.CodFeature = FwkFeaturePaths.CodFeatureBase 
	) 
	select 
		FwkFeaturePaths.IdDomain, 
		FwkFeaturePaths.CodModule, 
		FwkFeaturePaths.CodFeature, 
		FwkFeatureAction.CodAction, 
		FwkFeatureAction.Description 
	from FwkFeaturePaths 
		inner join FwkFeatureAction 
			on FwkFeaturePaths.IdDomain = FwkFeatureAction.IdDomain 
			and FwkFeaturePaths.CodModule = FwkFeatureAction.CodModule 
			and FwkFeaturePaths.CodFeature = FwkFeatureAction.CodFeature; 

end $$ 



delimiter ; 