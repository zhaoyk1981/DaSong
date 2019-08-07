-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_Create中转仓]
	@ID UNIQUEIDENTIFIER
	, @Name NVARCHAR(50)
	, @SN INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM dbo.中转仓 WHERE [Name] = @Name)
	BEGIN
		SELECT 0 [RowCount];
		RETURN;
	END

	INSERT INTO [dbo].[中转仓]
           ([ID]
           ,[Name]
           ,[SN])
     SELECT
           @ID
           ,@Name
           ,@SN;

	SELECT @@ROWCOUNT [RowCount];
END