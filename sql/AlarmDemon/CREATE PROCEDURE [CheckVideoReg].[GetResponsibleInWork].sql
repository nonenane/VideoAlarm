SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	��������� ������ ������� �������������
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetResponsibleInWork]		 	
AS
BEGIN
	SET NOCOUNT ON;

--������ �������� �������������
DECLARE @result NVARCHAR(max) 

select 
	@result = COALESCE(@result +',', '') + cast(r.id as nvarchar(500))
from
	CheckVideoReg.s_Responsible r
	--inner join WorkTime.j_InOutTime t on t.id_Kadr = r.id_kadr
	inner join (select id_Kadr, max(TimeIn) as TimeIn from WorkTime.j_InOutTime where TimeOut is null and TimeIn<=GETDATE()
	group by id_Kadr) as t on t.id_Kadr = r.id_kadr
where 
	r.isActive = 1
	--and t.TimeOut is null and t.TimeIn<=GETDATE() and cast(t.TimeIn as date) = cast(GETDATE() as date)
	--and t.TimeIn<=GETDATE()
group by r.id,t.id_Kadr

select @result as listIdResponsible

END
