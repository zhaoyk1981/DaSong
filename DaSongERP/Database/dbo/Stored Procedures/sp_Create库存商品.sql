-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[sp_Create库存商品]
	@ID uniqueidentifier
    ,@货号 nvarchar(50)
	,@规格 nvarchar(200)
	,@Name nvarchar(200)
	,@Thumbnails NVARCHAR(500)
	,@Amount int
	,@仓库 nvarchar(50)
	,@库位 nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT EXISTS(SELECT * FROM [dbo].[库存商品] s WHERE s.仓库 = @仓库 AND s.货号 = @货号 AND s.规格 = @规格)
	BEGIN
		INSERT INTO [dbo].[库存商品]
				([ID]
				,[货号]
				,[规格]
				,[Name]
				,[Thumbnails]
				,[Amount]
				,[仓库]
				,[库位])
			VALUES
				(@ID
				,@货号
				,@规格
				,@Name
				,@Thumbnails
				,@Amount
				,@仓库
				,@库位);

	END
	SELECT @@ROWCOUNT [RowCount];
END