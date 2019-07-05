-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllUsers]
	@Search NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT u.* FROM Users u
	WHERE (@Search IS NULL OR u.Name LIKE '%' + @Search + '%' OR u.UserName LIKE '%' + @Search + '%')
	ORDER BY Name;
END