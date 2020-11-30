SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Запись расписания
-- =============================================
CREATE PROCEDURE [CheckVideoReg].[SetSchedule]		 	
	@id int,
	@isOn bit,
	@id_user int
AS
BEGIN
	SET NOCOUNT ON;

UPDATE CheckVideoReg.s_Schedule 
SET
	isOn = @isOn,
	DateEdit = GETDATE(),
	id_Editor =@id_user
WHERE
	id = @id

END
