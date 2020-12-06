SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка отчётов
-- =============================================
CREATE PROCEDURE [CheckVideoReg].[GetReportVideoReg]		
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
	a.TypeEvent,
	a.Comment,
	a.DateCreate,
	a.Delta,
	v.RegName,
	[CheckVideoReg].[GetStrResponsibleName](a.id_Responsible) as nameResponsible

from 
	CheckVideoReg.j_tAlarmVideoReg a
		left join CheckVideoReg.s_VideoReg v on v.id = a.id_VideoReg
WHERE
	@dateStart<=cast(a.DateCreate as date) and cast(a.DateCreate as date)<=@dateEnd

END
