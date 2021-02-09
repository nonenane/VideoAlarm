SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-12-14
-- Description:	Запись данных из файла в БД
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[SetAlarmVideoReg]		 	
	@id_VideoReg int,
	@id_Camera_vs_Channel int = null,
	@TypeEvent varchar(max) = '',
	@id_Responsible varchar(max) = '',
	@DateStartAlarm datetime = null,
	@DateEndAlarm datetime = null,
	@Channel varchar(max) = '',
	@id_Schedule int = null
AS
BEGIN
	SET NOCOUNT ON;



DECLARE @id int
DECLARE @result NVARCHAR(max) 

IF @DateStartAlarm is not null
	BEGIN

		select 
			@result = COALESCE(@result +',', '') + cast(r.id as nvarchar(500))
		from
			CheckVideoReg.s_Responsible r	
			inner join (select id_Kadr, max(TimeIn) as TimeIn from WorkTime.j_InOutTime where TimeOut is null and TimeIn<=@DateStartAlarm
			group by id_Kadr) as t on t.id_Kadr = r.id_kadr
		where 
			r.isActive = 1
		group by r.id,t.id_Kadr
	
		SET @id_Responsible = @result
		
		select 
			@id = id 
		from  
			CheckVideoReg.j_AlarmVideoReg 
		where 
			id_VideoReg = @id_VideoReg 
			and ((@id_Camera_vs_Channel is not null and id_Camera_vs_Channel =  @id_Camera_vs_Channel ) OR (Channel = @Channel))
			and DateStartAlarm is null 
			and DateEndAlarm>@DateStartAlarm 
			and TypeEvent = @TypeEvent
		order  by 
			DateEndAlarm asc

		
		IF @id is not null
			BEGIN

				UPDATE CheckVideoReg.j_AlarmVideoReg
				SET DateStartAlarm = @DateStartAlarm,id_Responsible  = @id_Responsible
				WHERE id = @id

				return
			END
		ELSE
			BEGIN

				IF NOT EXISTS (select TOP(1) id from CheckVideoReg.j_AlarmVideoReg 	where id_VideoReg = @id_VideoReg  and ((@id_Camera_vs_Channel is not null and id_Camera_vs_Channel =  @id_Camera_vs_Channel ) OR (Channel = @Channel)) and DateStartAlarm = @DateStartAlarm and TypeEvent = @TypeEvent)
				BEGIN
					INSERT INTO CheckVideoReg.j_AlarmVideoReg (id_VideoReg,id_Camera_vs_Channel,TypeEvent,id_Responsible,DateStartAlarm,DateEndAlarm,DateCreate,Comment,Channel,id_Shedule)
					VALUES (@id_VideoReg,@id_Camera_vs_Channel,@TypeEvent,@id_Responsible,@DateStartAlarm,@DateEndAlarm,GETDATE(),'',@Channel,@id_Schedule)
				END

				return
			END
	END
ELSE IF @DateEndAlarm is not null
	BEGIN
	
		select 
			@id = id 
		from  
			CheckVideoReg.j_AlarmVideoReg 
		where 
			id_VideoReg = @id_VideoReg 
			and ((@id_Camera_vs_Channel is not null and id_Camera_vs_Channel =  @id_Camera_vs_Channel ) OR (Channel = @Channel))
			and DateEndAlarm is null 
			and DateStartAlarm<@DateEndAlarm
			and TypeEvent = @TypeEvent
		order  by 
			DateStartAlarm desc
		
		IF @id is not null
			BEGIN

				UPDATE CheckVideoReg.j_AlarmVideoReg
				SET DateEndAlarm = @DateEndAlarm
				WHERE id = @id

				return
			END
		ELSE
			BEGIN
				IF NOT EXISTS (select TOP(1) id from CheckVideoReg.j_AlarmVideoReg 	where id_VideoReg = @id_VideoReg  and ((@id_Camera_vs_Channel is not null and id_Camera_vs_Channel =  @id_Camera_vs_Channel ) OR (Channel = @Channel)) and DateEndAlarm = @DateEndAlarm and TypeEvent = @TypeEvent)
				BEGIN

					select 
						@result = COALESCE(@result +',', '') + cast(r.id as nvarchar(500))
					from
						CheckVideoReg.s_Responsible r	
						inner join (select id_Kadr, max(TimeIn) as TimeIn from WorkTime.j_InOutTime where TimeOut is null and TimeIn<=@DateEndAlarm
						group by id_Kadr) as t on t.id_Kadr = r.id_kadr
					where 
						r.isActive = 1
					group by r.id,t.id_Kadr
	
					SET @id_Responsible = @result


					INSERT INTO CheckVideoReg.j_AlarmVideoReg (id_VideoReg,id_Camera_vs_Channel,TypeEvent,id_Responsible,DateStartAlarm,DateEndAlarm,DateCreate,Comment,Channel,id_Shedule)
					VALUES (@id_VideoReg,@id_Camera_vs_Channel,@TypeEvent,@id_Responsible,@DateStartAlarm,@DateEndAlarm,GETDATE(),'',@Channel,@id_Schedule)
				END

				return
			END

	END

END
