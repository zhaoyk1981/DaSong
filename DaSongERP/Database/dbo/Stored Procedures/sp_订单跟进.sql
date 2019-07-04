-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_订单跟进]
	@ID UNIQUEIDENTIFIER
	, @来快递单号 NVARCHAR(50)
	, @发货时间 DATETIME2(7)
	, @发货备注 NVARCHAR(MAX)
	, @跟进人ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[订单] SET
		来快递单号 = @来快递单号
		, 发货时间 = @发货时间
		, 发货备注 = @发货备注
		, 跟进人ID = @跟进人ID
	WHERE ID = @ID;

	SELECT @@ROWCOUNT AS [RowCount];
END