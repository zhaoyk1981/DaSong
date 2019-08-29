-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_统计采购订单]
	@DateStart DATETIME2(7)
	,@DateEnd DATETIME2(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT o.中转仓 [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd)
	GROUP BY o.中转仓;

	SELECT '现货订单' [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE  o.现货 = 1
		AND (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd);

	SELECT '订货订单' [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE  o.现货 = 0 AND o.自采 = 0 AND o.未发货退款 = 0
		AND (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd);

	SELECT '自采订单' [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE  o.自采 = 1
		AND (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd);

	SELECT '在途待发' [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE  o.在途待发 = 1
		AND (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd);

	SELECT '换货待发' [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE  o.换货 = 1
		AND (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd);

	SELECT '未发货退款' [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE  o.未发货退款 = 1
		AND (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd);

	WITH C1 AS(
	SELECT o.采购人ID, COUNT(0) [Count]
	FROM vw_Orders o
	WHERE (o.进货日期 >= @DateStart AND o.进货日期 < @DateEnd)
	GROUP BY o.采购人ID)
	SELECT u.[Name], C1.[Count] FROM C1
	JOIN Users u ON C1.采购人ID = u.ID
	ORDER BY u.[Name];
END