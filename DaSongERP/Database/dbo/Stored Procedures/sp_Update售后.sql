-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update售后]
	@ID UNIQUEIDENTIFIER
	, @售后操作ID UNIQUEIDENTIFIER
	, @售后原因ID UNIQUEIDENTIFIER
	, @售后备注 NVARCHAR(MAX)
	, @售后人员ID UNIQUEIDENTIFIER
	, @客人退回单号 NVARCHAR(50)
	, @客人地址 NVARCHAR(150)
	, @高亮 BIT
	, @售后完结 BIT
	, @订单修改备注 NVARCHAR(MAX)
	, @淘宝退回单号 NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		[售后操作ID] = @售后操作ID
		, [售后原因ID] = @售后原因ID
		, [售后人员ID] = @售后人员ID
		, [售后时间] = GETDATE()
		, [售后备注] = @售后备注
		, [客人退回单号] = @客人退回单号
		, [淘宝退回单号] = @淘宝退回单号
		, [客人地址] = @客人地址
		, 高亮 = CASE WHEN [客人地址] <> @客人地址 THEN 1 ELSE @高亮 END
		, [售后完结] = @售后完结
		, [订单修改备注] = [订单修改备注] + @订单修改备注
	WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END