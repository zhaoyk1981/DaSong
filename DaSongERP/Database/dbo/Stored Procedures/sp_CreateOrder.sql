-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateOrder]
	@ID uniqueidentifier
    ,@进货日期 datetime2(7)
    ,@货号 nvarchar(50)
	,@规格 nvarchar(200)
	,@商品图片 NVARCHAR(500)
    ,@进货数量 int
    ,@店铺 nvarchar(50)
    ,@JD订单号 nvarchar(50)
	,@客人姓名 nvarchar(50)
	,@客人电话 nvarchar(50)
    ,@客人地址 nvarchar(150)
    ,@淘宝账号 nvarchar(50)
	,@淘宝订单号 NVARCHAR(50)
    ,@采购备注 nvarchar(max)
    ,@京东价 money
    ,@成本价 money
	,@采购人ID UNIQUEIDENTIFIER
	,@高亮 BIT
	,@现货 BIT
	,@中转仓 NVARCHAR(50)
	,@换货 BIT
	,@未发货退款 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT EXISTS(SELECT * FROM dbo.订单 o
		WHERE [货号] = @货号
		AND [JD订单号] = @JD订单号
		AND [淘宝订单号] = @淘宝订单号
		AND [采购备注] = @采购备注)
	BEGIN

    INSERT INTO [dbo].[订单]
           ([ID]
           ,[进货日期]
           ,[货号]
		   ,[规格]
		   ,[商品图片]
           ,[进货数量]
           ,[店铺]
           ,[JD订单号]
		   ,[客人姓名]
		   ,[客人电话]
           ,[客人地址]
           ,[淘宝账号]
		   ,[淘宝订单号]
           ,[采购备注]
           ,[京东价]
           ,[成本价]
		   ,[采购人ID]
		   ,[高亮]
		   ,[现货]
		   ,[中转仓]
		   ,[换货]
		   ,[未发货退款])
     SELECT
           @ID
           ,@进货日期
           ,@货号
		   ,ISNULL(@规格, '')
		   ,@商品图片
           ,@进货数量
           ,@店铺
           ,@JD订单号
		   ,@客人姓名
		   ,@客人电话
           ,@客人地址
           ,@淘宝账号
		   ,@淘宝订单号
           ,@采购备注
           ,@京东价
           ,@成本价
		   ,@采购人ID
		   ,@高亮
		   ,@现货
		   ,@中转仓
		   ,@换货
		   ,@未发货退款;

	END

	SELECT @@ROWCOUNT AS [RowCount];
END