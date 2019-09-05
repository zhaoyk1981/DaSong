-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_销售统计
	@DateStart DATETIME2(7)
	, @DateEnd DATETIME2(7)
	, @运费 MONEY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @总订单数 INT = 0
	, @有效订单数 INT = 0
	, @总销售额 MONEY = 0
	, @有效销售额 MONEY = 0
	, @总毛利 MONEY = 0
	, @有效毛利 MONEY = 0;

	DECLARE @未发货退款 UNIQUEIDENTIFIER = '270D96A8-B765-4EA1-BCE9-1D05801E0612'
		, @退差价 UNIQUEIDENTIFIER = '30B920EE-1D4C-4E20-9900-2AB6166C99A4'
		, @退款拦截 UNIQUEIDENTIFIER = '34389510-5D4E-4528-9F94-576E6A6DA89F'
		, @少件 UNIQUEIDENTIFIER = 'F3A2E746-F6DE-45B4-A30D-6FB442FC2745'
		, @发票 UNIQUEIDENTIFIER = 'E6058389-BACE-4E33-B38F-9159944036C4'
		, @换货 UNIQUEIDENTIFIER = '0F29DA4E-312F-4D3A-B57B-C4B176501214'
		, @退款退货 UNIQUEIDENTIFIER = 'D87B04C5-F8E4-425C-B4EC-D2610803630A'
		, @补发 UNIQUEIDENTIFIER = '8298811D-1F57-4407-ABBE-FB48F64D9EA8';

	SELECT @总订单数 = COUNT(0)
	FROM vw_Orders o
	WHERE o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd;

	SELECT @有效订单数 = COUNT(0)
	FROM vw_Orders o
	WHERE (o.现货 = 1 OR o.自采 = 0)
		AND o.未发货退款 = 0
		AND o.售后操作ID <> @未发货退款
		AND o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd;

	SELECT @总销售额 = SUM(o.进货数量 * 京东价)
	FROM vw_Orders o
	WHERE (o.现货 = 1 OR o.自采 = 0)
		AND o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd;

	SELECT @有效销售额 = SUM(o.进货数量 * o.京东价 - o.退款金额 - dbo.fn_计算运费(o.ID, @运费))
	FROM vw_Orders o
	WHERE (o.现货 = 1 OR o.自采 = 0)
		AND o.未发货退款 = 0
		AND o.售后操作ID <> @未发货退款
		AND o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd;

	SELECT @总毛利 = SUM(o.进货数量 * (o.京东价 - o.成本价))
	FROM vw_Orders o
	WHERE (o.现货 = 1 OR o.自采 = 0)
		AND o.未发货退款 = 0
		AND o.售后操作ID <> @未发货退款
		AND o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd;

	SELECT @有效毛利 = SUM(o.进货数量 * (o.京东价 - o.成本价) - o.退款金额 - dbo.fn_计算运费(o.ID, @运费))
	FROM vw_Orders o
	WHERE (o.现货 = 1 OR o.自采 = 0)
		AND o.未发货退款 = 0
		AND o.售后操作ID <> @未发货退款
		AND o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd;

	SELECT @总订单数 总订单数
		, @有效订单数 有效订单数
		, @总销售额 总销售额
		, @有效销售额 有效销售额
		, @总毛利 总毛利
		, @有效毛利 有效毛利;
END