-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_GetOrderByJD订单号
	@JD订单号 NVARCHAR(50),
	@ID UNIQUEIDENTIFIER = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM vw_orders
	WHERE JD订单号 = @JD订单号
		AND (@ID IS NULL OR ID <> @ID);

END