-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateOrder]
	@ID uniqueidentifier
    ,@货号 nvarchar(50)
	,@商品图片 NVARCHAR(500)
    ,@进货数量 int
    ,@店铺 nvarchar(50)
    ,@JD订单号 nvarchar(50)
    ,@客人地址 nvarchar(150)
    ,@淘宝账号 nvarchar(50)
	,@淘宝订单号 NVARCHAR(50)
    ,@采购备注 nvarchar(max)
    ,@京东价 money
    ,@成本价 money
	,@订单修改备注 nvarchar(max)
	,@采购人ID UNIQUEIDENTIFIER
	,@高亮 BIT
	,@订单终结 BIT
	,@订单终结备注 NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
           [货号] = @货号
		   ,[商品图片] = @商品图片
           ,[进货数量] = @进货数量
           ,[店铺] = @店铺
           ,[JD订单号] = @JD订单号
           ,[客人地址] = @客人地址
           ,[淘宝账号] = @淘宝账号
		   ,[淘宝订单号] = @淘宝订单号
           ,[采购备注] = @采购备注
           ,[京东价] = @京东价
           ,[成本价] = @成本价
		   ,[采购人ID] = @采购人ID
		   ,[高亮] = @高亮
		   ,[订单终结] = @订单终结
		   ,[订单终结备注] = @订单终结备注
		WHERE ID = @ID;

	SELECT @@ROWCOUNT AS [RowCount];
END