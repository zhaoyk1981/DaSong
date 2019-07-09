-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_跟进List]
	@PageIndex INT = NULL
	, @PageSize INT
	, @OrderBy NVARCHAR(50)
	, @OrderByDesc BIT = 1
	, @跟进人ID UNIQUEIDENTIFIER
	, @JD订单号 NVARCHAR(50)
	, @拆包超时 INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(DISTINCT o.Id)
	FROM vw_Orders o
	WHERE o.已跟进 = 0
		AND (@跟进人ID IS NULL OR o.[跟进人ID] = @跟进人ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@拆包超时 IS NULL OR DATEDIFF(DAY, o.进货日期, GETDATE()) >= @拆包超时);

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.*
	FROM vw_Orders o
	WHERE o.已跟进 = 0
		AND (@跟进人ID IS NULL OR o.[跟进人ID] = @跟进人ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@拆包超时 IS NULL OR DATEDIFF(DAY, o.进货日期, GETDATE()) >= @拆包超时)
	ORDER BY o.进货日期
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END