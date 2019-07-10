-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_电话客服List
	@PageIndex INT = NULL
	, @PageSize INT
	, @OrderBy NVARCHAR(50)
	, @OrderByDesc BIT = 1
	, @电话客服ID UNIQUEIDENTIFIER
	, @JD订单号 NVARCHAR(50)
	, @客人地址 NVARCHAR(150)
	, @已导入 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(DISTINCT o.Id)
	FROM vw_Orders o
	WHERE (@电话客服ID IS NULL OR o.[跟进人ID] = @电话客服ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@客人地址 IS NULL OR o.[客人地址] LIKE '%' + @JD订单号 + '%')
		AND (@已导入 IS NULL OR o.已跟进 = @已导入);

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.*
	FROM vw_Orders o
	WHERE (@电话客服ID IS NULL OR o.[跟进人ID] = @电话客服ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@客人地址 IS NULL OR o.[客人地址] LIKE '%' + @JD订单号 + '%')
		AND (@已导入 IS NULL OR o.已跟进 = @已导入)
	ORDER BY o.进货日期 DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END