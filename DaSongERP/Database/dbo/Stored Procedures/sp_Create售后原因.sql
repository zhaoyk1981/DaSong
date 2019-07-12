-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Create售后原因]
	@ID UNIQUEIDENTIFIER
	, @Name NVARCHAR(50)
	, @SN INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM dbo.售后原因 WHERE [Name] = @Name)
	BEGIN
		SELECT 0 [RowCount];
		RETURN;
	END

	INSERT INTO [dbo].[售后原因]
           ([ID]
           ,[Name]
           ,[SN])
     SELECT
           @ID
           ,@Name
           ,@SN;

	SELECT @@ROWCOUNT [RowCount];
END