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
		AND (@拆包人ID IS NULL OR o.[拆包人ID] = @拆包人ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@来快递单号 IS NULL OR o.[来快递单号] LIKE '%' + @来快递单号 + '%')
		AND (@已拆包 IS NULL OR o.[已拆包] = @已拆包)
		AND (@拆包超时 IS NULL OR DATEDIFF(DAY, o.进货日期, GETDATE()) >= @拆包超时);

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.*
	FROM vw_Orders o
	WHERE ISNULL(o.订单终结, 0) = 0
		AND (@拆包人ID IS NULL OR o.[采购人ID] = @拆包人ID)
		AND (@JD订单号 IS NULL OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (@来快递单号 IS NULL OR o.[来快递单号] LIKE '%' + @来快递单号 + '%')
		AND (@已拆包 IS NULL OR o.[已拆包] = @已拆包)
		AND (@拆包超时 IS NULL OR DATEDIFF(DAY, o.进货日期, GETDATE()) >= @拆包超时)
	ORDER BY o.进货日期 DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END