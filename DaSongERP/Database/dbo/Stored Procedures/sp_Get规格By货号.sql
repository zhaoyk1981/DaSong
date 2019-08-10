-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_Get规格By货号
	@货号 NVARCHAR(50)
	, @仓库 NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM vw_库存商品 sp
	WHERE sp.货号 = @货号
		AND sp.仓库 = @仓库;
END