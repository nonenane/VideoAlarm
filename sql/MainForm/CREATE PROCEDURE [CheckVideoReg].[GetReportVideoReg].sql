SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка отчётов
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetReportVideoReg]		
	@dateStart date,
	@dateEnd date
AS
BEGIN
	SET NOCOUNT ON;

select 
	a.id,
	a.id_VideoReg,
	a.id_Responsible,
	a.NameFile,
	a.isNoAlarm,	
	a.Comment,
	a.DateCreate,
	a.Delta,
	v.RegName,
	[CheckVideoReg].[GetStrResponsibleName](a.id_Responsible) as nameResponsible,
	s.TimeRun,
	s.id as idShedule
from 
	CheckVideoReg.j_tAlarmVideoReg a
		left join CheckVideoReg.s_VideoReg v on v.id = a.id_VideoReg
		left join CheckVideoReg.s_Schedule  s on s.id = a.id_Shedule --(select TOP(1) ss.id from CheckVideoReg.s_Schedule ss where ss.isOn =1 and  cast(a.DateCreate as time)>= ss.TimeRun order by ss.TimeRun desc)
WHERE
	@dateStart<=cast(a.DateCreate as date) and cast(a.DateCreate as date)<=@dateEnd

END
