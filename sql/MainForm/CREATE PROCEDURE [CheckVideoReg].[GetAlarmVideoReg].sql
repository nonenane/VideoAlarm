SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	��������� ������ ������
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
	'' as nameResponsible
from 
	CheckVideoReg.j_AlarmVideoReg a
		left join CheckVideoReg.s_VideoReg v on v.id = a.id_VideoReg
		left join CheckVideoReg.s_Camera_vs_Channel c on c.id = a.id_Camera_vs_Channel
WHERE
	@dateStart<=cast(a.DateCreate as date) and cast(a.DateCreate as date)<=@dateEnd

END
