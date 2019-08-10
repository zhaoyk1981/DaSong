-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_库存商品List]
	@PageIndex INT = NULL
	, @PageSize INT
	, @OrderBy NVARCHAR(50)
	, @OrderByDesc BIT = 1
	, @仓库 NVARCHAR(50)
	, @货号 NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @RecordsCount AS INT -- 总记录数
		, @PagesCount AS INT; -- 总页数

	SELECT @RecordsCount = COUNT(DISTINCT kc.Id)
	FROM dbo.vw_库存商品 kc
	WHERE (ISNULL(@仓库, '') = '' OR kc.仓库 = @仓库)
		AND (ISNULL(@货号, '') = '' OR kc.货号 LIKE '%' + @货号 + '%')

	SELECT @PagesCount = PagesCount, @PageSize = PageSize, @PageIndex = PageIndex
	FROM [dbo].[InitPagingParams](@PageSize, @PageIndex, NULL, @RecordsCount);

	SELECT kc.*
	FROM dbo.vw_库存商品 kc
	WHERE (ISNULL(@仓库, '') = '' OR kc.仓库 = @仓库)
		AND (ISNULL(@货号, '') = '' OR kc.货号 LIKE '%' + @货号 + '%')
	ORDER BY kc.仓库, kc.Name
	OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;

	SELECT @PageIndex [PageIndex], @RecordsCount [RecordsCount], @PagesCount [PagesCount], @PageSize [PageSize];
END