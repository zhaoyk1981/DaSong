-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update电话客服]
	@ID UNIQUEIDENTIFIER,
	@电话客服ID UNIQUEIDENTIFIER,
	@电话备注 NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		电话客服ID = @电话客服ID,
		电话备注 = @电话备注,
		导入时间 = GETDATE()
	WHERE	ID = @ID
		AND ISNULL(@电话备注, '') <> '';

	SELECT @@ROWCOUNT [RowCount];
END