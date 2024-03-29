﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_统计拆包审单数量]
	@DateStart DATETIME2(7)
	,@DateEnd DATETIME2(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    WITH CNT AS(
		SELECT u.ID, COUNT(0) [Count]
		FROM 订单 o
		JOIN Users u on o.拆包人ID = u.ID
		WHERE o.拆包时间 >= @DateStart AND o.拆包时间 < @DateEnd
		GROUP BY u.ID
	)
	SELECT u.ID, u.Name, ISNULL(c.[Count], 0) [Count]
	FROM Users u
	LEFT JOIN CNT c ON c.ID = u.ID
	WHERE (u.PermissionID & 16) = 16
		AND ISNULL(c.[Count], 0) > 0
	ORDER BY u.Name;

	WITH CNT AS(
		SELECT p.ID, COUNT(0) [Count]
		FROM 订单 o
		JOIN 审单操作 p on o.审单操作ID = p.ID
		WHERE o.拆包时间 >= @DateStart AND o.拆包时间 < @DateEnd
		GROUP BY p.ID
	)
	SELECT p.ID, p.Name, ISNULL(c.[Count], 0) [Count]
	FROM 审单操作 p
	LEFT JOIN CNT c ON c.ID = p.ID
	ORDER BY p.SN, p.Name;
END