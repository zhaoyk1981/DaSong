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
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(0) FROM (
    SELECT o.货号, SUM(o.进货数量) 总销量, COUNT(DISTINCT o.JD订单号) 订单数
	FROM vw_Orders o
	WHERE o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd
		AND o.未发货退款 = 0
		AND o.自采 = 0
	GROUP BY o.货号
	HAVING COUNT(DISTINCT o.JD订单号) > 1) T1;

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.货号, SUM(o.进货数量) 总销量, COUNT(DISTINCT o.JD订单号) 订单数
	FROM vw_Orders o
	WHERE o.进货日期 >= @DateStart
		AND o.进货日期 < @DateEnd
		AND o.未发货退款 = 0
		AND o.自采 = 0
	GROUP BY o.货号
	HAVING COUNT(DISTINCT o.JD订单号) > 1
	ORDER BY SUM(o.进货数量) DESC, COUNT(DISTINCT o.JD订单号) DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];

	SELECT 货号, MIN(Thumbnails) Thumbnails, SUM(现货数量) 现货数量, SUM(在途数量) 在途数量 FROM vw_库存商品
	GROUP BY 货号;
END