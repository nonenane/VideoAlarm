SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка ответственных лиц
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetResponsible]		 	
AS
BEGIN
	SET NOCOUNT ON;


select 
	r.id,
	r.id_kadr,
	r.isActive,
	r.DateEdit,
	ISNULL(ltrim(rtrim(k.lastname))+' ','')+ ISNULL(SUBSTRING(ltrim(rtrim(k.firstname)),1,1)+'.','')+ ISNULL(SUBSTRING(ltrim(rtrim(k.secondname)),1,1)+'.','') as nameKadr,
	ltrim(rtrim(d.name)) as nameDeps,
	k.id_departments,
	isnull(l.FIO,'') as FIO
from 
	[CheckVideoReg].[s_Responsible] r
		left join dbo.s_kadr k on k.id = r.id_kadr
		left join dbo.departments d on d.id = k.id_departments
		left join dbo.ListUsers l on l.id = r.id_Editor

END
