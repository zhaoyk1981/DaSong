﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_订单跟进]
	@ID UNIQUEIDENTIFIER
	, @来快递 NVARCHAR(150)
	, @来快递单号 NVARCHAR(150)
	, @发货时间 DATETIME2(7)
	, @发货备注 NVARCHAR(MAX)
	, @跟进人ID UNIQUEIDENTIFIER
	, @高亮 BIT
	,@订单终结 BIT
	,@订单终结备注 NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		来快递 = @来快递
		, 来快递单号 = @来快递单号
		, 发货时间 = @发货时间
		, 发货备注 = @发货备注
		, 跟进人ID = @跟进人ID
		, [高亮] = @高亮
		,[订单终结] = @订单终结
		,[订单终结备注] = @订单终结备注
	WHERE ID = @ID;

	SELECT @@ROWCOUNT AS [RowCount];
END