-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[sp_Get库存商品ByID]
	@ID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[vw_库存商品] WHERE ID = @ID;

END