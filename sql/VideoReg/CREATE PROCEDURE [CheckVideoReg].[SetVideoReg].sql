USE [dbase1]
GO
/****** Object:  StoredProcedure [Goods_Card_New].[spg_setSubject]    Script Date: 30.11.2020 15:34:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Запись справочника видео камер
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[SetVideoReg]			 
	@id int,
	@RegName varchar(max),
	@RegIP varchar(max),
	@Place varchar(max),
	@PathLog varchar(max),
	@Comment varchar(max),
	@isActive bit,
	@id_user int,
	@result int = 0,
	@isDel int	
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY 
	IF @isDel = 0
		BEGIN			
			IF EXISTS (select TOP(1) id from [CheckVideoReg].[s_VideoReg] where id <>@id and LTRIM(RTRIM(LOWER(RegName))) = LTRIM(RTRIM(LOWER(@RegName))))
				BEGIN
					SELECT -1 as id,'В справочнике уже присутствует\n видеорегистратор с таким наименованием.\n' as msg;
					return;
				END

			IF EXISTS (select TOP(1) id from [CheckVideoReg].[s_VideoReg] where id <>@id and RegIP=@RegIP)
				BEGIN
					SELECT -1 as id,'В справочнике уже присутствует\n видеорегистратор с таким IP.\n' as msg;
					return;
				END

			IF @id = 0
				BEGIN
					INSERT INTO [CheckVideoReg].[s_VideoReg]
						   ([RegName]
						   ,[RegIP]
						   ,[Place]
						   ,[PathLog]
						   ,[Comment]
						   ,[isActive]
						   ,[id_Editor]
						   ,[DateEdit])
					 VALUES
						   (@RegName,
						   @RegIP,
						   @Place,
						   @PathLog,
						   @Comment,
						   1,
						   @id_user,
						   GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN					
					UPDATE [CheckVideoReg].[s_VideoReg]
					set		[RegName] = @RegName
						   ,[RegIP] = @RegIP
						   ,[Place] = @Place
						   ,[PathLog] = @PathLog
						   ,[Comment] = @Comment
						   ,[isActive] = @isActive
						   ,[id_Editor] = @id_user
						   ,[DateEdit]=GETDATE()
					where id = @id
										
					SELECT @id as id
					return;					
				END
		END
	ELSE
		BEGIN
			IF @result = 0
				BEGIN
					
					IF NOT EXISTS(select TOP(1) id from [CheckVideoReg].[s_VideoReg] where id = @id)
						BEGIN
							select -1 as id
							return;
						END

					
					IF EXISTS(select TOP(1) id from [CheckVideoReg].[s_Camera_vs_Channel] where id_VideoReg = @id)
						BEGIN
							select -2 as id
							return;
						END

					IF EXISTS(select TOP(1) id from [CheckVideoReg].[j_AlarmVideoReg] where id_VideoReg = @id)
						BEGIN
							select -2 as id
							return;
						END

					IF EXISTS(select TOP(1) id from [CheckVideoReg].[j_tAlarmVideoReg]  where  id_VideoReg = @id)
						BEGIN
							select -2 as id
							return;
						END

					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM [CheckVideoReg].[s_VideoReg]  where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id,ERROR_MESSAGE() as msg
	return;
END CATCH
	
END
