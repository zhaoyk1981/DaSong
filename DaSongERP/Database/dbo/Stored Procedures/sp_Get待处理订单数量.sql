﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get待处理订单数量]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @未跟进 INT = 0
		, @未导入 INT = 0
		, @未拆包 INT = 0
		, @未完结售后 INT = 0;

	SELECT @未跟进 = COUNT(0) FROM dbo.vw_Orders WHERE 已跟进 = 0 AND ISNULL(订单终结, 0) = 0 AND [现货] = 0;
	SELECT @未导入 = COUNT(0) FROM vw_Orders WHERE 已导入 = 0 AND ISNULL(订单终结, 0) = 0 AND [自采] = 0 AND [现货] = 0;
	SELECT @未拆包 = COUNT(0) FROM vw_Orders WHERE 已拆包 = 0 AND ISNULL(订单终结, 0) = 0 AND [现货] = 0;
	SELECT @未完结售后 = COUNT(0) FROM vw_Orders WHERE 售后操作ID IS NOT NULL AND ISNULL(售后完结, 0) = 0 AND ISNULL(订单终结, 0) = 0;

	SELECT @未跟进 [未跟进]
		, @未导入 [未导入]
		, @未拆包 [未拆包]
		, @未完结售后 [未完结售后];
END