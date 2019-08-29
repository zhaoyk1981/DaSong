-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_还原未发货退款订单]
	@ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE 订单 SET
		售后操作ID = null
		,售后原因ID = null
		,售后人员ID = null
		,退款金额 = 0
		,订单终结 = 0
		,售后完结 = 0
		,未发货退款 = 0
	WHERE ID = @ID
		AND 未发货退款 = 1;

	SELECT @@ROWCOUNT [RowCount];
END