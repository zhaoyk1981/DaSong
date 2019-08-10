-- =============================================

-- =============================================
CREATE PROCEDURE dbo.sp_Delete库存商品
	@ID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[库存商品] WHERE ID = @ID;
	SELECT @@ROWCOUNT [RowCount];
END