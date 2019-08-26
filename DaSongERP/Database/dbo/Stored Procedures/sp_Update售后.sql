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
	,@客人姓名 nvarchar(50)
	,@客人电话 nvarchar(50)
	, @客人地址 NVARCHAR(150)
	, @高亮 BIT
	, @售后完结 BIT
	, @订单修改备注 NVARCHAR(MAX)
	, @淘宝退回单号 NVARCHAR(50)
	, @退款金额 MONEY
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
		, [售后备注] = ISNULL(@售后备注, '')
		, [客人退回单号] = ISNULL(@客人退回单号, '')
		, [淘宝退回单号] = ISNULL(@淘宝退回单号, '')
		,[客人姓名] = CASE WHEN ISNULL(@客人姓名, '') = '' THEN [客人姓名] ELSE @客人姓名 END,
		[客人电话] = CASE WHEN ISNULL(@客人电话, '') = '' THEN [客人电话] ELSE @客人电话 END,
		[客人地址] = CASE WHEN ISNULL(@客人地址, '') = '' THEN [客人地址] ELSE @客人地址 END
		, 退款金额 = @退款金额
		, 高亮 = CASE WHEN [客人地址] <> @客人地址 THEN 1 ELSE @高亮 END
		, [售后完结] = ISNULL(@售后完结, 0)
		, [订单修改备注] = [订单修改备注] + @订单修改备注
	WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END