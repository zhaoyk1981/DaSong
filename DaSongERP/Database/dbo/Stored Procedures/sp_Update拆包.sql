﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update拆包]
	@ID UNIQUEIDENTIFIER
	, @审单操作ID UNIQUEIDENTIFIER
	, @拆包人员备注 NVARCHAR(MAX)
	, @转发单号 NVARCHAR(50)
	, @入库数量 INT
	, @拆包人ID UNIQUEIDENTIFIER
	, @订单终结 BIT
	,@订单终结备注 NVARCHAR(MAX)
	, @高亮 BIT
	, @订单修改备注 NVARCHAR(MAX)
	, @在途待发 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		[审单操作ID] = @审单操作ID
		, [入库数量] = ISNULL(入库数量, 0) + ISNULL(@入库数量, 0)
		, [拆包人ID] = @拆包人ID
		, [拆包人员备注] = @拆包人员备注
		, [转发单号] = @转发单号
		, [订单终结] = @订单终结
		,[订单终结备注] = @订单终结备注
		, [拆包时间] = GETDATE()
		, [高亮] = @高亮
		, [订单修改备注] = [订单修改备注] + ISNULL(@订单修改备注, '')
		, [在途待发] = CASE WHEN @在途待发 = 0 THEN 0 ELSE [在途待发] END
	WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END