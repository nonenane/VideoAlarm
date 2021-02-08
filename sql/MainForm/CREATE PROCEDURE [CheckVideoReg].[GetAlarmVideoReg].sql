SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка тревог
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetAlarmVideoReg]		
	@dateStart date,
	@dateEnd date
AS
BEGIN
	SET NOCOUNT ON;

select 
	a.id,
	a.DateCreate,
	a.DateStartAlarm,
	a.DateEndAlarm,
	a.Comment,
	a.TypeEvent,
	a.id_VideoReg,
	a.id_Camera_vs_Channel,
	v.RegName,
	c.RegChannel,
	c.CamName,
	[CheckVideoReg].[GetStrResponsibleName](a.id_Responsible) as nameResponsible,
	[CheckVideoReg].[GetTimeWorkToString](a.DateStartAlarm,a.DateEndAlarm) as DeltaString,
	DATEDIFF(SECOND,a.DateStartAlarm,a.DateEndAlarm) as delta,
	v.id_shop,
	s.cName as nameShop
from 
	CheckVideoReg.j_AlarmVideoReg a
		left join CheckVideoReg.s_VideoReg v on v.id = a.id_VideoReg
		left join dbo.s_Shop s on s.id = v.id_shop
		left join CheckVideoReg.s_Camera_vs_Channel c on c.id = a.id_Camera_vs_Channel
WHERE
	@dateStart<=cast(a.DateCreate as date) and cast(a.DateCreate as date)<=@dateEnd

END
