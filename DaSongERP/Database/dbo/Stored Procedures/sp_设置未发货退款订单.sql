-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_设置未发货退款订单
	@ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE 订单 SET
		售后操作ID = '270D96A8-B765-4EA1-BCE9-1D05801E0612'
		,售后原因ID = '6201D9A1-5DB1-448C-909D-C8716789FE63'
		,退款金额 = 京东价 * 进货数量
		,售后人员ID = 采购人ID
		,订单终结 = 1
		,售后完结 = 1
		,未发货退款 = 1
	WHERE ID = @ID
		AND 未发货退款 = 0;

	SELECT @@ROWCOUNT [RowCount];
END