-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update拆包4Excel]
	@JD订单号 NVARCHAR(50)
	, @转发单号 NVARCHAR(50)
	, @拆包人ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @审单操作ID UNIQUEIDENTIFIER = NULL;
	SELECT @审单操作ID = ID FROM dbo.审单操作 WHERE [Name] = '正常发走';

	DECLARE @Count INT = 0;

	SELECT 
		@Count = CASE 
					WHEN COUNT(0) > 0 THEN 1
					ELSE 0 END
	FROM 订单
	WHERE JD订单号 = @JD订单号;

    UPDATE 订单 SET
		转发单号 = @转发单号
		, [审单操作ID] = @审单操作ID
		, [拆包人ID] = @拆包人ID
		, [拆包时间] = GETDATE()
		, [在途待发] = 0
	WHERE JD订单号 = @JD订单号 AND [转发单号] = '';

	SELECT @Count + CASE WHEN @@ROWCOUNT >= 1 THEN 1 ELSE 0 END AS [Result];
END