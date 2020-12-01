SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	ѕолучение списка канало€ дл€ видеорегистраторов
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetCameraVsChannel]		 	
AS
BEGIN
	SET NOCOUNT ON;

select 
	v.id,
	v.CamName,
	v.CamIP,
	v.Comment,
	v.PathScan,
	v.id_VideoReg,
	v.RegChannel,
	cast(case when v.Scan is not null then 1 else 0 end as bit) as isScan,
	v.isActive,
	v.DateEdit,
	isnull(l.FIO,'') as FIO,
	r.RegName,
	v.RegChannel+'/'+v.CamName as nameRegCamName
from 
	[CheckVideoReg].[s_Camera_vs_Channel] v
		left join CheckVideoReg.s_VideoReg r on r.id = v.id_VideoReg
		left join dbo.ListUsers l on l.id = v.id_Editor
END
