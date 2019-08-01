-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update拆包4Excel]
	@JD订单号 NVARCHAR(50)
	, @来快递单号 NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Count INT = 0;

	SELECT 
		@Count = CASE 
					WHEN COUNT(0) > 0 THEN 1
					ELSE 0 END
	FROM 订单
	WHERE JD订单号 = @JD订单号;

    UPDATE 订单 SET
		来快递单号 = @来快递单号
	WHERE JD订单号 = @JD订单号;

	SELECT @Count + CASE WHEN @@ROWCOUNT >= 1 THEN 1 ELSE 0 END AS [Result];
END