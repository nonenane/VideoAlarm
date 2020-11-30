SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка отделов
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetDepartments]		 	
AS
BEGIN
	SET NOCOUNT ON;


select
	cast(d.id as int) as id,
	ltrim(rtrim(d.name)) as cName
from 
	dbo.departments d
WHERE
	ldeyst = 1 --and if_comm = 1
END
