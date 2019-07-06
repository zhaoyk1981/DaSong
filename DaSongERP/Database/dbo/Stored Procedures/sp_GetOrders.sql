-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetOrders]
	@JD订单号 NVARCHAR(50),
	@来快递单号 NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM vw_orders
	WHERE (@JD订单号 IS NULL OR JD订单号 = @JD订单号)
		AND (@来快递单号 IS NULL OR 来快递单号 = @来快递单号)
	ORDER BY 进货日期 DESC;

END