SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	ѕолучение списка рабочих ответственных
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetResponsibleInWork]		 	
AS
BEGIN
	SET NOCOUNT ON;

--—писок активных ответственных
DECLARE @result NVARCHAR(max) 

select 
	@result = COALESCE(@result +',', '') + cast(r.id as nvarchar(500))
from
	CheckVideoReg.s_Responsible r
	inner join WorkTime.j_InOutTime t on t.id_Kadr = r.id_kadr
where 
	r.isActive = 1
	and t.TimeOut is null and t.TimeIn<=GETDATE()
group by r.id,t.id_Kadr

select @result as listIdResponsible

END
