SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-12-14
-- Description:	Запись данных по парсеному файлу в БД
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[SetTAlarmVideoReg]		 	
	@id_VideoReg int,	
	@NameFile varchar(max) = '',
	@Delta int,
	@id_Responsible varchar(max) = '',
	@isNoAlarm bit  = 0,
	@DateCreate datetime = null
AS
BEGIN
	SET NOCOUNT ON;

	if @DateCreate is null SET @DateCreate = GETDATE();

	IF NOT EXISTS(select top(1) id from CheckVideoReg.j_tAlarmVideoReg where id_VideoReg = @id_VideoReg and NameFile = @NameFile)
		BEGIN
			INSERT INTO CheckVideoReg.j_tAlarmVideoReg (id_VideoReg,DateCreate,NameFile,id_Responsible,Delta,isNoAlarm,Comment)
			VALUES (@id_VideoReg,@DateCreate,@NameFile,@id_Responsible,@Delta,@isNoAlarm ,'')
		END

END
