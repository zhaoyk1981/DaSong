-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_统计热销商品]
	@PageIndex INT = NULL
	, @PageSize INT
	, @OrderBy NVARCHAR(50) = NULL
	, @OrderByDesc BIT = 1
	, @DateStart DATETIME2(7)
	,@DateEnd DATETIME2(7)
	, @货号 NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(0) FROM (
    SELECT o.货号, CASE o.规格 WHEN '' THEN o.采购备注 ELSE o.规格 END 规格
	FROM vw_Orders o
	LEFT JOIN vw_库存商品 p ON o.库存商品ID = p.ID
	WHERE o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd
		AND o.未发货退款 = 0
		AND o.自采 = 0
		AND (o.售后操作ID IS NULL
		OR o.售后操作ID <> 'D87B04C5-F8E4-425C-B4EC-D2610803630A')
		AND (ISNULL(@货号, '') = '' OR o.货号 LIKE '%' + @货号 + '%' OR p.Name LIKE '%' + @货号 + '%')
	GROUP BY o.货号, CASE o.规格 WHEN '' THEN o.采购备注 ELSE o.规格 END
	HAVING COUNT(DISTINCT o.JD订单号) > 1) T1;

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.货号, CASE o.规格 WHEN '' THEN o.采购备注 ELSE o.规格 END 规格, MIN(o.商品图片) [Thumbnails], SUM(o.进货数量) 总销量, COUNT(DISTINCT o.JD订单号) 订单数
	FROM vw_Orders o
	LEFT JOIN vw_库存商品 p ON o.库存商品ID = p.ID
	WHERE o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd
		AND o.未发货退款 = 0
		AND o.自采 = 0
		AND (o.售后操作ID IS NULL
		OR o.售后操作ID <> 'D87B04C5-F8E4-425C-B4EC-D2610803630A')
		AND (ISNULL(@货号, '') = '' OR o.货号 LIKE '%' + @货号 + '%' OR p.Name LIKE '%' + @货号 + '%')
	GROUP BY o.货号, CASE o.规格 WHEN '' THEN o.采购备注 ELSE o.规格 END
	HAVING COUNT(DISTINCT o.JD订单号) > 1
	ORDER BY SUM(o.进货数量) DESC, COUNT(DISTINCT o.JD订单号) DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
	
	SELECT 货号, 规格, MIN(Thumbnails) Thumbnails, SUM(现货数量) 现货数量, SUM(在途数量) 在途数量 FROM vw_库存商品
	WHERE (ISNULL(@货号, '') = '' OR 货号 LIKE '%' + @货号 + '%' OR Name LIKE '%' + @货号 + '%')
	GROUP BY 货号, 规格;

	SELECT o.货号, CASE o.规格 WHEN '' THEN o.采购备注 ELSE o.规格 END 规格, SUM(o.进货数量) 总销量, COUNT(DISTINCT o.JD订单号) 订单数
	FROM vw_Orders o
	LEFT JOIN vw_库存商品 p ON o.库存商品ID = p.ID
	WHERE o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd
		AND o.未发货退款 = 0
		AND o.自采 = 0
		AND o.售后操作ID = 'D87B04C5-F8E4-425C-B4EC-D2610803630A'
		AND (ISNULL(@货号, '') = '' OR o.货号 LIKE '%' + @货号 + '%' OR p.Name LIKE '%' + @货号 + '%')
	GROUP BY o.货号, CASE o.规格 WHEN '' THEN o.采购备注 ELSE o.规格 END
END