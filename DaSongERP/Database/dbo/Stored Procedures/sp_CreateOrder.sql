-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateOrder]
	@ID uniqueidentifier
    ,@进货日期 datetime2(7)
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
	,@采购人ID UNIQUEIDENTIFIER
	,@高亮 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[订单]
           ([ID]
           ,[进货日期]
           ,[货号]
		   ,[商品图片]
           ,[进货数量]
           ,[店铺]
           ,[JD订单号]
           ,[客人地址]
           ,[淘宝账号]
		   ,[淘宝订单号]
           ,[采购备注]
           ,[京东价]
           ,[成本价]
		   ,[采购人ID]
		   ,[高亮])
     SELECT
           @ID
           ,@进货日期
           ,@货号
		   ,@商品图片
           ,@进货数量
           ,@店铺
           ,@JD订单号
           ,@客人地址
           ,@淘宝账号
		   ,@淘宝订单号
           ,@采购备注
           ,@京东价
           ,@成本价
		   ,@采购人ID
		   ,@高亮;
	SELECT @@ROWCOUNT AS [RowCount];
END