-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update店铺]
	@ID UNIQUEIDENTIFIER
	, @Name NVARCHAR(50)
	, @Prefix NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM dbo.店铺 WHERE [Prefix] = @Prefix AND [ID] <> @ID)
	BEGIN
		SELECT 0 [RowCount];
		RETURN;
	END

	UPDATE [dbo].[店铺] SET
           [Name] = @Name
           ,[Prefix] = @Prefix
    WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END