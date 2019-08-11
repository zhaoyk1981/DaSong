-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[sp_Update库存商品]
	@ID uniqueidentifier
	,@Name nvarchar(200)
	,@Thumbnails NVARCHAR(500)
	,@仓库 nvarchar(50)
	,@库位 nvarchar(50)
	,@UserID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @货号 AS nvarchar(50), @规格 AS nvarchar(200);
	SELECT @货号 = 货号, @规格 = 规格
	FROM 库存商品 WHERE ID = @ID;

	IF NOT EXISTS(SELECT * FROM [dbo].[库存商品] s WHERE s.仓库 = @仓库 AND s.货号 = @货号 AND s.规格 = @规格 AND ID <> @ID)
	BEGIN
		UPDATE [dbo].[库存商品] SET
			[Name] = @Name
			,[Thumbnails] = @Thumbnails
			,[仓库] = @仓库
			,[库位] = @库位
			,[UserID] = @UserID
		WHERE ID = @ID;

	END
	SELECT @@ROWCOUNT [RowCount];
END