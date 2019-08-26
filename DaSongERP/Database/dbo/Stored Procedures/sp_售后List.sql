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
	, @客人地址 NVARCHAR(150)
	, @已售后 BIT
	, @售后完结 BIT
	, @高亮 BIT
	, @现货 BIT
	, @在途待发 BIT
	, @中转仓 NVARCHAR(50)
	, @淘宝账号 NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(DISTINCT o.Id)
	FROM vw_Orders o
	WHERE [自采] = 0
		AND (@售后人员ID IS NULL OR o.[售后人员ID] = @售后人员ID)
		AND (ISNULL(@JD订单号, '') = '' OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (ISNULL(@客人地址, '') = '' OR o.[客人地址] LIKE '%' + @客人地址 + '%' OR o.[客人姓名] LIKE '%' + @客人地址 + '%' OR o.[客人电话] LIKE '%' + @客人地址 + '%')
		AND (@已售后 IS NULL OR o.[已售后] = @已售后)
		AND (@售后完结 IS NULL OR ISNULL(o.[售后完结], 0) = @售后完结)
		AND (@高亮 IS NULL OR o.[高亮] = @高亮)
		AND (@现货 IS NULL OR o.[现货] = @现货)
		AND (@在途待发 IS NULL OR o.在途待发 = @在途待发)
		AND (ISNULL(@中转仓, '') = '' OR o.[中转仓] = @中转仓)
		AND (ISNULL(@淘宝账号, '') = '' OR o.[淘宝账号] LIKE '%' + @淘宝账号 + '%');

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT o.*
	FROM vw_Orders o
	WHERE [自采] = 0
		AND (@售后人员ID IS NULL OR o.[售后人员ID] = @售后人员ID)
		AND (ISNULL(@JD订单号, '') = '' OR o.[JD订单号] LIKE '%' + @JD订单号 + '%')
		AND (ISNULL(@客人地址, '') = '' OR o.[客人地址] LIKE '%' + @客人地址 + '%' OR o.[客人姓名] LIKE '%' + @客人地址 + '%' OR o.[客人电话] LIKE '%' + @客人地址 + '%')
		AND (@已售后 IS NULL OR o.[已售后] = @已售后)
		AND (@售后完结 IS NULL OR ISNULL(o.[售后完结], 0) = @售后完结)
		AND (@高亮 IS NULL OR o.[高亮] = @高亮)
		AND (@现货 IS NULL OR o.[现货] = @现货)
		AND (@在途待发 IS NULL OR o.在途待发 = @在途待发)
		AND (ISNULL(@中转仓, '') = '' OR o.[中转仓] = @中转仓)
		AND (ISNULL(@淘宝账号, '') = '' OR o.[淘宝账号] LIKE '%' + @淘宝账号 + '%')
	ORDER BY o.进货日期 DESC
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END