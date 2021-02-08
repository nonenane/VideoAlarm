SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-30
-- Description:	Получение списка Магазинов
-- =============================================
CREATE PROCEDURE [CheckVideoReg].[GetShopName]		 	
AS
BEGIN
	SET NOCOUNT ON;

select 
	id,
	cName,
	isActive
from 
	dbo.s_Shop
END
