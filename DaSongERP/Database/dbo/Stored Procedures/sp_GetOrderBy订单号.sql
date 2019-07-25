-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetOrderBy订单号]
	@JD订单号 NVARCHAR(50),
	@淘宝订单号 NVARCHAR(50),
	@货号 NVARCHAR(50),
	@采购备注 NVARCHAR(MAX),
	@ID UNIQUEIDENTIFIER = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM vw_orders
	WHERE JD订单号 = @JD订单号
		AND [淘宝订单号] = @淘宝订单号
		AND [货号] = @货号
		AND [采购备注] = @采购备注
		AND (@ID IS NULL OR ID <> @ID);

END