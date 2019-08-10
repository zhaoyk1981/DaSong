-- =============================================

-- =============================================
CREATE PROCEDURE dbo.sp_Save库存动量
	@库存商品ID uniqueidentifier
	,@现货数量 int
	,@在途数量 int
	,@OrderID uniqueidentifier
	,@Remark nvarchar(max)
	,@UserID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	IF EXISTS(SELECT * FROM [dbo].[库存动量] WHERE OrderID = @OrderID AND @OrderID IS NOT NULL)
	BEGIN
		UPDATE [dbo].[库存动量] SET
			库存商品ID = @库存商品ID
			, 现货数量 = ISNULL(@现货数量, 0)
			, 在途数量 = ISNULL(@在途数量, 0)
			, Remark = ISNULL(@Remark, '')
			, UserID = @UserID
		WHERE OrderID = @OrderID;
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[库存动量]
			   ([库存商品ID]
			   ,[DateCreated]
			   ,[现货数量]
			   ,[在途数量]
			   ,[OrderID]
			   ,[Remark]
			   ,[UserID])
		 VALUES
			   (@库存商品ID
			   ,GETDATE()
			   ,ISNULL(@现货数量, 0)
			   ,ISNULL(@在途数量, 0)
			   ,@OrderID
			   ,ISNULL(@Remark, '')
			   ,@UserID);
	END
	SELECT @@ROWCOUNT [RowCount];
END