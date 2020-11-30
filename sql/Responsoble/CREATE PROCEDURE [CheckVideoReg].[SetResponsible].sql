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
-- Description:	«апись справочника ответственного
-- =============================================
ALTER PROCEDURE [CheckVideoReg].[SetResponsible]			 
	@id int,
	@id_kadr int,
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
			IF EXISTS (select TOP(1) id from [CheckVideoReg].[s_Responsible] where id <>@id and id_kadr = @id_kadr)
				BEGIN
					SELECT -1 as id,'¬ справочнике уже присутствует\n такой сотрудник.\n' as msg;
					return;
				END						

			IF @id = 0
				BEGIN
					INSERT INTO [CheckVideoReg].[s_Responsible]
						   ([id_kadr]
						   ,[isActive]						   
						   ,[id_Editor]
						   ,[DateEdit])
					 VALUES
						   (@id_kadr,
						   1,
						   @id_user,
						   GETDATE())

					SELECT  cast(SCOPE_IDENTITY() as int) as id
					return;
				END	
			ELSE
				BEGIN
					UPDATE [CheckVideoReg].[s_Responsible]
					set		id_kadr = @id_kadr
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
					
					IF NOT EXISTS(select TOP(1) id from [CheckVideoReg].[s_Responsible] where id = @id)
						BEGIN
							select -1 as id
							return;
						END

					IF EXISTS(select TOP(1) id from [CheckVideoReg].[j_tAlarmVideoReg]  where  id_Responsible = @id)
						BEGIN
							select -2 as id
							return;
						END

					
					select 0 as id
					return;
				END
			ELSE
				BEGIN
					DELETE FROM [CheckVideoReg].[s_Responsible]  where id = @id
					RETURN
				END
		END
END TRY 
BEGIN CATCH 
	SELECT -9999 as id,ERROR_MESSAGE() as msg
	return;
END CATCH
	
END
