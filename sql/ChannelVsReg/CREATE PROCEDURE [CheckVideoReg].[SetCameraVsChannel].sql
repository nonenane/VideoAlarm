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
-- Description:	Запись справочника канала и видеорегистратора
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[SetCameraVsChannel]			 
	@id int,
	@CamName varchar(max),
	@CamIP varchar(max),
	@RegChannel varchar(max),
	@id_VideoReg int, 
	@PathScan varchar(max),
	@Scan varbinary(max) = null,
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
			IF EXISTS (select TOP(1) id from [CheckVideoReg].[s_Camera_vs_Channel] where id <>@id and LTRIM(RTRIM(LOWER(CamName))) = LTRIM(RTRIM(LOWER(@CamName))) and id_VideoReg = @id_VideoReg)
				BEGIN
					SELECT -1 as id,'В справочнике уже присутствует\n запись для канала\n на выбранном видеорегистраторе.\n' as msg;
					return;
				END
			

			IF @id = 0
				BEGIN
					INSERT INTO [CheckVideoReg].[s_Camera_vs_Channel]
						   ([CamIP]
						   ,[CamName]
						   ,[RegChannel]
						   ,[id_VideoReg]
						   ,[PathScan]
						   ,[Scan]
						   ,[Comment]
						   ,[isActive]
						   ,[id_Editor]
						   ,[DateEdit])
					 VALUES
						   (@CamIP
						   ,@CamName
						   ,@RegChannel
						   ,@id_VideoReg
						   ,@PathScan
						   ,@Scan
						   ,@Comment
						   ,@isActive
						   ,@id_user
						   ,GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END
			ELSE
				BEGIN					
					UPDATE 
							[CheckVideoReg].[s_Camera_vs_Channel]
					set		[CamIP] = @CamIP
						   ,[CamName] = @CamName
						   ,[RegChannel] = @RegChannel
						   ,[id_VideoReg] = @id_VideoReg
						   ,[PathScan] = @PathScan
						   ,[Scan] = @Scan
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
					
					IF NOT EXISTS(select TOP(1) id from [CheckVideoReg].[s_Camera_vs_Channel] where id = @id)
						BEGIN
							select -1 as id
							return;
						END

					
					IF EXISTS(select TOP(1) id from [CheckVideoReg].[j_AlarmVideoReg] where id_Camera_vs_Channel = @id)
						BEGIN
							select -2 as id
							return;
						END
					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM [CheckVideoReg].[s_Camera_vs_Channel]  where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id,ERROR_MESSAGE() as msg
	return;
END CATCH
	
END
