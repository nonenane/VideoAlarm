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
	cast(a.DateCreate as date) as Date,
	a.RegName,
	a.TimeRun,
	a.Delta,
	a.DateCreate,
	a.Comment,
	a.nameResponsible,
	a.isNoAlarm,
	a.idShedule as id_Shedule,
	a.id_Responsible,
	a.FIO
from(
select 
	a.id,
	a.id_VideoReg,
	a.id_Responsible,
	--a.NameFile,
	a.isNoAlarm,	
	a.Comment,
	a.DateCreate,
	a.Delta,
	v.RegName,
	[CheckVideoReg].[GetStrResponsibleName](a.id_Responsible) as nameResponsible,
	s.TimeRun,
	s.id as idShedule,
	isnull(l.FIO,'') as FIO
from 
	CheckVideoReg.j_tAlarmVideoReg a
		left join CheckVideoReg.s_VideoReg v on v.id = a.id_VideoReg
		left join CheckVideoReg.s_Schedule  s on s.id = a.id_Shedule 
		left join dbo.ListUsers l on l.id = idCreater
WHERE
	@dateStart<=cast(a.DateCreate as date) and cast(a.DateCreate as date)<=@dateEnd and a.id_Shedule is not null

union all

select 
	null as id,
	v.id as id_VideoReg,
	a.IdResponsible as  id_Responsible,
	--'' as NameFile,
	cast(0 as bit) as isNoAlarm,
	'' as Comment,
	a.DateInsert as DateCreate,
	0 as Delta,
	v.RegName,
	[CheckVideoReg].[GetStrResponsibleName](a.IdResponsible) as nameResponsible,	
	s.TimeRun,
	s.id as idShedule,
	'' as FIO
from 
	CheckVideoReg.j_ViewNotFileAlarm a
		 inner join CheckVideoReg.j_ViewNotFileAlarmVsReg vr on vr.id_ViewNotFileAlarm = a.id
		 join CheckVideoReg.s_VideoReg v on v.id  = vr.id_VideoReg
		 left join CheckVideoReg.s_Schedule  s on s.id = a.id_Shedule 
WHERE
	@dateStart<=cast(a.DateInsert as date) and cast(a.DateInsert as date)<=@dateEnd and a.id_Shedule is not null ) as a

	/*
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
	@dateStart<=cast(a.DateCreate as date) and cast(a.DateCreate as date)<=@dateEnd and a.id_Shedule is not null
*/


END
