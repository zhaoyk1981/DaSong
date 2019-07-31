-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update电话客服]
	@ID UNIQUEIDENTIFIER,
	@电话客服ID UNIQUEIDENTIFIER,
	@客人姓名 nvarchar(50),
	@客人电话 nvarchar(50),
	@客人地址 NVARCHAR(150),
	@电话备注 NVARCHAR(MAX),
	@高亮 BIT,
	@订单修改备注 NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		电话客服ID = @电话客服ID,
		[客人姓名] = CASE WHEN ISNULL(@客人姓名, '') = '' THEN [客人姓名] ELSE @客人姓名 END,
		[客人电话] = CASE WHEN ISNULL(@客人电话, '') = '' THEN [客人电话] ELSE @客人电话 END,
		[客人地址] = CASE WHEN ISNULL(@客人地址, '') = '' THEN [客人地址] ELSE @客人地址 END,
		电话备注 = @电话备注,
		高亮 = CASE WHEN [客人地址] <> @客人地址 THEN 1 ELSE @高亮 END,
		导入时间 = GETDATE(),
		[订单修改备注] = [订单修改备注] + @订单修改备注
	WHERE	ID = @ID
		AND ISNULL(@电话备注, '') <> '';

	SELECT @@ROWCOUNT [RowCount];
END