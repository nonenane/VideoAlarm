SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Запись комментария для тревог
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[SetCommentAlarmVideoReg]		 
	@id int,
	@comment varchar(max),
	@typeComment int
AS
BEGIN
	SET NOCOUNT ON;

	IF @typeComment = 1
		BEGIN
			UPDATE
				[CheckVideoReg].[j_AlarmVideoReg]
			SET
				Comment = Comment+ @comment
			WHERE 
				id = @id
		END
	ELSE IF @typeComment = 2
		BEGIN
			UPDATE
				[CheckVideoReg].[j_tAlarmVideoReg]
			SET
				Comment =Comment + @comment
			WHERE 
				id = @id
		END
END
