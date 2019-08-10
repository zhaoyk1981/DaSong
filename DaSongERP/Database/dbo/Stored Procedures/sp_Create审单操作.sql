-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Create审单操作]
	@ID UNIQUEIDENTIFIER
	, @Name NVARCHAR(50)
	, @SN INT
	, @已完成 BIT
	, @入库 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM dbo.审单操作 WHERE [Name] = @Name)
	BEGIN
		SELECT 0 [RowCount];
		RETURN;
	END

	INSERT INTO [dbo].[审单操作]
           ([ID]
           ,[Name]
           ,[SN]
		   ,[已完成]
		   ,[入库])
     SELECT
           @ID
           ,@Name
           ,@SN
		   ,@已完成
		   ,@入库;

	SELECT @@ROWCOUNT [RowCount];
END