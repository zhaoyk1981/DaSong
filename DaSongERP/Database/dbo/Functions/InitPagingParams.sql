-- =============================================
-- Author:		赵永昆
-- Create date: 2018-02-20
-- Description:	计算分页参数
-- =============================================
CREATE FUNCTION [dbo].[InitPagingParams]
(	
	@PageSize INT,
	@PageIndex INT,
	@PageIndexByID INT = NULL,
	@RecordsCount INT
)
RETURNS TABLE 
AS
RETURN 
(
	WITH PageSize AS(
		-- 每页记录数非法值修正，默认20
		SELECT 'PageSize' [Name], CASE WHEN ISNULL(@PageSize, 0) <= 0 THEN 20 ELSE @PageSize END [Value]
	)
	, PagesCount AS(
		-- 计算总页数
		SELECT 'PagesCount' [Name], CEILING(CAST(@RecordsCount AS MONEY) / ps.[Value]) [Value]
		FROM PageSize ps
	)
	, PageIndexById AS (
		-- 焦点页优先
		SELECT ISNULL(@PageIndexByID, ISNULL(@PageIndex, 0)) [Value]
	)
	, PageIndex AS(
		SELECT 'PageIndex' [Name], CASE
			WHEN pc.Value = 0 THEN 0 --空结果
			WHEN ISNULL(pbi.[Value], 0) < 0 THEN pc.Value + ISNULL(pbi.[Value], 0) --倒数页
			WHEN ISNULL(pbi.[Value], 0) >= pc.Value THEN pc.Value - 1 --正溢出
			ELSE ISNULL(pbi.[Value], 0) END PageIndex --正常情况
		FROM PagesCount pc
		JOIN PageIndexById pbi ON 1 = 1
	)
	, Result AS(
		SELECT * FROM PageSize
		UNION ALL
		SELECT * FROM PagesCount
		UNION ALL
		SELECT * FROM PageIndex
	)
	
	-- 纵表转横表
	SELECT 
		CAST(PageSize AS INT) PageSize
		, CAST(PagesCount AS INT) PagesCount
		, CAST(PageIndex AS INT) PageIndex
	FROM Result
	PIVOT
	(MAX([Value]) FOR [Name] IN(
		PageSize
		, PagesCount
		, PageIndex)
	)TBL
)