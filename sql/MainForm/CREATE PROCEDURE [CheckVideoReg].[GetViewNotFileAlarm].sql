SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-12-14
-- Description:	Автовставка тех кто должен был залить но не смог
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetViewNotFileAlarm]		 	
	@dateStart date,
	@dateEnd date
AS
BEGIN
	SET NOCOUNT ON;

	select 
		DateInsert,
		id_Shedule,
		IdResponsible,
		[CheckVideoReg].[GetStrResponsibleName](IdResponsible) as nameResponsible
	from 
		[CheckVideoReg].[j_ViewNotFileAlarm]
	where
		@dateStart<= cast(DateInsert as date) and cast(DateInsert as date)<=@dateEnd

END
