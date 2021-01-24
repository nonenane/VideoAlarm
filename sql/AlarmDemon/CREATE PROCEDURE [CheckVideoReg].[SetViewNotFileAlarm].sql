SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-12-14
-- Description:	Автовставка тех кто должен был залить но не смог
-- =============================================
CREATE PROCEDURE [CheckVideoReg].[SetViewNotFileAlarm]		 	

AS
BEGIN
	SET NOCOUNT ON;

	


	DECLARE @id_Shedule int

	select TOP(1) @id_Shedule = id from CheckVideoReg.s_Schedule where cast(GETDATE() as time)>TimeRun and isOn = 1 order by TimeRun desc



	if NOT EXISTS(select * from CheckVideoReg.j_tAlarmVideoReg where 	cast(DateCreate as date)  = cast(getdate() as date) and	id_Shedule = @id_Shedule)
		begin
			--Список активных ответственных
			DECLARE @result NVARCHAR(max) 

			select 
				@result = COALESCE(@result +',', '') + cast(r.id as nvarchar(500))
			from
				CheckVideoReg.s_Responsible r	
				inner join (select id_Kadr, max(TimeIn) as TimeIn from WorkTime.j_InOutTime where TimeOut is null and TimeIn<=GETDATE()
				group by id_Kadr) as t on t.id_Kadr = r.id_kadr
			where 
				r.isActive = 1	
			group by r.id,t.id_Kadr

			if NOT EXISTS (select * from [CheckVideoReg].[j_ViewNotFileAlarm] where cast(DateInsert as date) = cast(getdate() as date) and id_Shedule = @id_Shedule)
				BEGIN
					INSERT INTO [CheckVideoReg].[j_ViewNotFileAlarm] (DateInsert,id_Shedule,IdResponsible) values (GETDATE(),@id_Shedule,@result)
				END
		end

END
