SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение изображения для канала для видеорегистраторов
-- =============================================
CREATE PROCEDURE [CheckVideoReg].[GetImageCameraVsChannel]	
	@id_CameraVsChannel int
AS
BEGIN
	SET NOCOUNT ON;

select 
	v.Scan
from 
	[CheckVideoReg].[s_Camera_vs_Channel] v
where
	v.id = @id_CameraVsChannel
END
