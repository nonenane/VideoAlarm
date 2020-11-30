SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка расписаний
-- =============================================
CREATE PROCEDURE [CheckVideoReg].[GetSchedule]		 	
AS
BEGIN
	SET NOCOUNT ON;


select 
	s.id,
	s.TimeRun,
	s.isOn,
	s.DateEdit,
	isnull(l.FIO,'') as FIO
from 
	CheckVideoReg.s_Schedule s
		left join dbo.ListUsers l on l.id = s.id_Editor
END
