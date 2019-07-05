-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_UpdateUser
	@ID UNIQUEIDENTIFIER
	, @UserName NVARCHAR(50)
	, @Password NVARCHAR(50)
	, @Name NVARCHAR(50)
	, @PermissionID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Users SET
		UserName = @UserName
		, Password = ISNULL(@Password, Password)
		, Name = @Name
		, PermissionID = @PermissionID
	WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END