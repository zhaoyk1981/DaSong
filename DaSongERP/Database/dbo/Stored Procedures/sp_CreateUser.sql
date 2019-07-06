-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_CreateUser
	@ID UNIQUEIDENTIFIER
	, @Name NVARCHAR(50)
	, @UserName NVARCHAR(50)
	, @Password NVARCHAR(50)
	, @PermissionID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Users]
           ([ID]
           ,[UserName]
           ,[Password]
           ,[Name]
           ,[PermissionID])
     VALUES
           (@ID
           ,@UserName
           ,@Password
           ,@Name
           ,@PermissionID);

	SELECT @@ROWCOUNT [RowCount];
END