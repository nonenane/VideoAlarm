SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка сотрудников
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetListKadr]	
	@id_prog int 
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @listDeps varchar(max) = ''

	select @listDeps =value from dbo.prog_config where id_prog = @id_prog and id_value = 'luds'


select 
	k.id,
	ISNULL(ltrim(rtrim(k.lastname))+' ','')+ ISNULL(SUBSTRING(ltrim(rtrim(k.firstname)),1,1)+'.','')+ ISNULL(SUBSTRING(ltrim(rtrim(k.secondname)),1,1)+'.','') as nameKadr,
	ltrim(rtrim(d.name)) as nameDeps,
	k.id_departments	
from 	
	dbo.s_kadr k
		left join dbo.departments d on d.id = k.id_departments	
where 
	k.id_WorkStatus = 4 and k.dateUnemploy is null and k.id_departments in (select cast(value as int) from dbo.StringToTable(@listDeps,','))
order by k.id_departments, k.lastname 
END
