-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_Update客服
	@ID UNIQUEIDENTIFIER
	, @客人地址 NVARCHAR(150)
	, @订单修改备注 NVARCHAR(500)
	, @客服ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		[客人地址] = @客人地址
		, [订单修改备注] = @订单修改备注
		, [客服ID] = @客服ID
		, [客服时间] = GETDATE()
	WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END