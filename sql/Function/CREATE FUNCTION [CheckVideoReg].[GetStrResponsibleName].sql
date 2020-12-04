/****** Object:  UserDefinedFunction [Calculation].[getSumDayInuer]    Script Date: 04.12.2020 16:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [CheckVideoReg].[GetStrResponsibleName] (@ListIdResponbisle varchar(max)) 
returns NVARCHAR(max) 
as
begin

DECLARE @result NVARCHAR(max) 


select 
	@result = COALESCE(@result +' '+char(13), '') + ISNULL(ltrim(rtrim(k.lastname))+' ','')+ ISNULL(SUBSTRING(ltrim(rtrim(k.firstname)),1,1)+'.','')+ ISNULL(SUBSTRING(ltrim(rtrim(k.secondname)),1,1)+'.','') 
from 
	CheckVideoReg.s_Responsible r	
		left join dbo.s_kadr k on k.id = r.id_kadr
where 
	r.id in (select value from dbo.StringToTable(@ListIdResponbisle,','))

return @result
end;