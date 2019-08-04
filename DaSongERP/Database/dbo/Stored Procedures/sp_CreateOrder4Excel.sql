-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateOrder4Excel]
	@进货日期 datetime2(7)
    ,@货号 nvarchar(50)
    ,@进货数量 int
    ,@店铺 nvarchar(50)
    ,@JD订单号 nvarchar(50)
	,@淘宝订单号 NVARCHAR(50)
	,@淘宝账号 NVARCHAR(50)
    ,@采购备注 nvarchar(max)
	,@来快递 NVARCHAR(150)
	,@来快递单号 NVARCHAR(150)
    ,@京东价 money
    ,@成本价 money
	,@采购人ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT EXISTS(SELECT * FROM dbo.订单 o
		WHERE [货号] = ISNULL(@货号, '')
		AND [JD订单号] = ISNULL(@JD订单号, '')
		AND [淘宝订单号] = ISNULL(@淘宝订单号, '')
		AND [采购备注] = ISNULL(@采购备注, ''))
	BEGIN

    INSERT INTO [dbo].[订单]
           ([ID]
           ,[进货日期]
           ,[货号]
           ,[进货数量]
           ,[店铺]
           ,[JD订单号]
		   ,[淘宝订单号]
           ,[采购备注]
		   ,[淘宝账号]
		   ,[来快递]
		   ,[来快递单号]
           ,[京东价]
           ,[成本价]
		   ,[采购人ID])
     SELECT
           NEWID()
           ,@进货日期
           ,ISNULL(@货号, '')
           ,@进货数量
           ,ISNULL(@店铺, '')
           ,ISNULL(@JD订单号, '')
		   ,ISNULL(@淘宝订单号, '')
           ,ISNULL(@采购备注, '')
		   ,ISNULL(@淘宝账号, '')
		   ,ISNULL(@来快递, '')
		   ,ISNULL(@来快递单号, '')
           ,@京东价
           ,@成本价
		   ,@采购人ID;

	END

	SELECT @@ROWCOUNT AS [RowCount];
END