-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update售后操作]
	@ID UNIQUEIDENTIFIER
	, @Name NVARCHAR(50)
	, @SN INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM dbo.售后操作 WHERE [Name] = @Name AND [ID] <> @ID)
	BEGIN
		SELECT 0 [RowCount];
		RETURN;
	END

	UPDATE [dbo].[售后操作] SET
           [Name] = @Name
           ,[SN] = @SN
    WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END