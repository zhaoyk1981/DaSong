-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update电话备注]
	@JD订单号 NVARCHAR(50),
	@电话客服ID UNIQUEIDENTIFIER,
	@电话备注 NVARCHAR(MAX)
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

    UPDATE [dbo].[订单] SET
		电话客服ID = @电话客服ID,
		电话备注 = CASE WHEN ISNULL(@电话备注, '') = '' THEN [电话备注] ELSE @电话备注 END,
		导入时间 = GETDATE()
	WHERE	JD订单号 = @JD订单号;

	SELECT @Count + CASE WHEN @@ROWCOUNT >= 1 THEN 1 ELSE 0 END AS [Result];
END