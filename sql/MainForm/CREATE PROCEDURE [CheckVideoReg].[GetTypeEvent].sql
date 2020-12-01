SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка типов тревог
-- =============================================
CREATE PROCEDURE [CheckVideoReg].[GetTypeEvent]		 	
AS
BEGIN
	SET NOCOUNT ON;

select 
	v.TypeEvent
from 
	[CheckVideoReg].[j_AlarmVideoReg] v
GROUP BY v.TypeEvent
END
