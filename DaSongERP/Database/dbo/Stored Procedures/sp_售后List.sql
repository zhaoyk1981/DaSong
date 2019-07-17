-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_售后List]
	@PageIndex INT = NULL
	, @PageSize INT
	, @OrderBy NVARCHAR(50)
	, @OrderByDesc BIT = 1
	, @售后人员ID UNIQUEIDENTIFIER
	, @JD订单号 NVARCHAR(50)
	, @已售后 BIT
	, @售后完结 BIT
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
		AND (@售后人员ID IS NULL OR o.[售后人员ID] = @售后人员ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@已售后 IS NULL OR o.[已售后] = @已售后)
		AND (@售后完结 IS NULL OR ISNULL(o.[售后完结], 0) = @售后完结);

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.*
	FROM vw_Orders o
	WHERE ISNULL(o.订单终结, 0) = 0
		AND (@售后人员ID IS NULL OR o.[售后人员ID] = @售后人员ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@已售后 IS NULL OR o.[已售后] = @已售后)
		AND (@售后完结 IS NULL OR ISNULL(o.[售后完结], 0) = @售后完结)
	ORDER BY o.进货日期 DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END