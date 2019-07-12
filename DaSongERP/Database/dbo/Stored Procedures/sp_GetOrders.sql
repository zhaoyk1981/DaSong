-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetOrders]
	@JD订单号 NVARCHAR(50) = NULL,
	@来快递单号 NVARCHAR(50) = NULL,
	@售后人员ID UNIQUEIDENTIFIER = NULL,
	@售后完结 BIT = NULL,
	@客服ID UNIQUEIDENTIFIER = NULL,
	@已跟进 BIT = NULL,
	@已导入 BIT = NULL,
	@已拆包 BIT = NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM vw_orders
	WHERE (@JD订单号 IS NULL OR JD订单号 LIKE '%' + @JD订单号 + '%')
		AND (@来快递单号 IS NULL OR 来快递单号 LIKE '%' + @来快递单号 + '%')
		AND (@售后人员ID IS NULL OR [售后人员ID] = @售后人员ID)
		AND (@售后完结 IS NULL OR ISNULL([售后完结], 0) = @售后完结)
		AND (@客服ID IS NULL OR [客服ID] = @客服ID)
		AND (@已跟进 IS NULL OR [已跟进] = @已跟进)
		AND (@已导入 IS NULL OR [已导入] = @已导入)
		AND (@已拆包 IS NULL OR [已拆包] = @已拆包)
	ORDER BY 进货日期;

END