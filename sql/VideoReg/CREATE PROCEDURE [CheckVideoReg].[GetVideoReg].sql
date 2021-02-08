SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	ѕолучение списка видео регистраторов
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[GetVideoReg]		 	
AS
BEGIN
	SET NOCOUNT ON;

select 
	v.id,
	v.RegName,
	v.RegIP,
	v.Place,
	v.PathLog,
	v.Comment,
	v.isActive,
	v.DateEdit,
	isnull(l.FIO,'') as FIO,
	v.id_shop,
	s.cName as nameShop,
	cast(0 as bit) as isSelect

from 
	[CheckVideoReg].[s_VideoReg] v
		left join dbo.ListUsers l on l.id = v.id_Editor
		left join dbo.s_Shop s on s.id = v.id_shop
END
