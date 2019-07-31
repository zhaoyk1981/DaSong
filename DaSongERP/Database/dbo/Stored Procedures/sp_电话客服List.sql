-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_电话客服List]
	@PageIndex INT = NULL
	, @PageSize INT
	, @OrderBy NVARCHAR(50)
	, @OrderByDesc BIT = 1
	, @电话客服ID UNIQUEIDENTIFIER
	, @JD订单号 NVARCHAR(50)
	, @客人地址 NVARCHAR(150)
	, @已导入 BIT
	, @高亮 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(DISTINCT o.Id)
	FROM vw_Orders o
	WHERE ISNULL(o.订单终结, 0) = 0
		AND [自采] = 0
		AND (@电话客服ID IS NULL OR o.[跟进人ID] = @电话客服ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@客人地址 IS NULL OR o.[客人地址] LIKE '%' + @客人地址 + '%' OR o.[客人姓名] LIKE '%' + @客人地址 + '%' OR o.[客人电话] LIKE '%' + @客人地址 + '%')
		AND (@已导入 IS NULL OR o.已导入 = @已导入)
		AND (@高亮 IS NULL OR o.[高亮] = @高亮);

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.*
	FROM vw_Orders o
	WHERE ISNULL(o.订单终结, 0) = 0
		AND [自采] = 0
		AND (@电话客服ID IS NULL OR o.[跟进人ID] = @电话客服ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@客人地址 IS NULL OR o.[客人地址] LIKE '%' + @客人地址 + '%')
		AND (@已导入 IS NULL OR o.已导入 = @已导入)
		AND (@高亮 IS NULL OR o.[高亮] = @高亮)
	ORDER BY o.进货日期 DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END