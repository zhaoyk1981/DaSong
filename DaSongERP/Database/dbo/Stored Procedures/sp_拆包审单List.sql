-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_拆包审单List]
	@PageIndex INT = NULL
	, @PageSize INT
	, @OrderBy NVARCHAR(50)
	, @OrderByDesc BIT = 1
	, @拆包人ID UNIQUEIDENTIFIER
	, @JD订单号 NVARCHAR(50)
	, @来快递单号 NVARCHAR(50)
	, @已拆包 BIT
	, @拆包超时 INT
	, @货号 NVARCHAR(50)
	, @自采 BIT
	, @高亮 BIT
	, @订单终结 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(DISTINCT o.Id)
	FROM vw_Orders o
	WHERE o.现货 = 0
		AND (@拆包人ID IS NULL OR o.[拆包人ID] = @拆包人ID)
		AND (ISNULL(@JD订单号, '') = '' OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@来快递单号 IS NULL OR o.[来快递单号] LIKE '%' + @来快递单号 + '%')
		AND (@已拆包 IS NULL OR o.[已拆包] = @已拆包)
		AND (@订单终结 IS NULL OR o.[订单终结] = @订单终结)
		AND (@拆包超时 IS NULL OR DATEDIFF(DAY, o.进货日期, GETDATE()) >= @拆包超时)
		AND (ISNULL(@货号, '') = '' OR o.[货号] LIKE '%' + @货号 + '%')
		AND (@自采 IS NULL OR o.[自采] = @自采)
		AND (@高亮 IS NULL OR o.[高亮] = @高亮);

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.*
	FROM vw_Orders o
	WHERE o.现货 = 0
		AND (@拆包人ID IS NULL OR o.[采购人ID] = @拆包人ID)
		AND (ISNULL(@JD订单号, '') = '' OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@来快递单号 IS NULL OR o.[来快递单号] LIKE '%' + @来快递单号 + '%')
		AND (@已拆包 IS NULL OR o.[已拆包] = @已拆包)
		AND (@订单终结 IS NULL OR o.[订单终结] = @订单终结)
		AND (@拆包超时 IS NULL OR DATEDIFF(DAY, o.进货日期, GETDATE()) >= @拆包超时)
		AND (ISNULL(@货号, '') = '' OR o.[货号] LIKE '%' + @货号 + '%')
		AND (@自采 IS NULL OR o.[自采] = @自采)
		AND (@高亮 IS NULL OR o.[高亮] = @高亮)
	ORDER BY o.进货日期 DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END