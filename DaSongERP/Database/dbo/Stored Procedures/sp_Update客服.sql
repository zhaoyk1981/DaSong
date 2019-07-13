-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update客服]
	@ID UNIQUEIDENTIFIER
	, @客人地址 NVARCHAR(150)
	, @订单修改备注 NVARCHAR(MAX)
	, @客服ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		[客人地址] = @客人地址
		, [客服ID] = @客服ID
		, [高亮] = CASE WHEN [客人地址] <> @客人地址 THEN 1 ELSE [高亮] END
		, [客服时间] = GETDATE()
		, [订单修改备注] = [订单修改备注] + @订单修改备注
	WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END