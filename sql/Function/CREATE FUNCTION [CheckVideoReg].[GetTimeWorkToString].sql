/****** Object:  UserDefinedFunction [Calculation].[getSumDayInuer]    Script Date: 04.12.2020 16:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [CheckVideoReg].[GetTimeWorkToString] (@dateStart datetime,@dateEnd datetime = null) 
returns NVARCHAR(max) 
as
begin

DECLARE @result NVARCHAR(max) 

IF @dateEnd is null 
	BEGIN 
		SET @result = 'По настоящее время' 
	END
ELSE
	BEGIN
		SET @result  = cast(DATEDIFF(hour,@dateStart,@dateEnd) as varchar(10))+' часов '+cast(DATEDIFF(MINUTE,@dateStart,@dateEnd)%60 as varchar(2))+' минут '+cast(DATEDIFF(SECOND,@dateStart,@dateEnd)%60 as varchar(2))+' секунд'
	END

return @result
end;