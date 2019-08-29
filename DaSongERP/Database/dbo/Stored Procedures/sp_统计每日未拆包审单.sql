-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_统计每日未拆包审单
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT CONVERT(CHAR(10), o.进货日期, 20) [Name], COUNT(0) [Count]
	FROM vw_Orders o
	WHERE o.订单终结 = 0 AND o.已拆包 = 0
	GROUP BY CONVERT(CHAR(10), o.进货日期, 20);

END