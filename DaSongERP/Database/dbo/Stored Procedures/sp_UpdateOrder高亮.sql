-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_UpdateOrder高亮
	@ID UNIQUEIDENTIFIER
	, @高亮 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE 订单 SET
		高亮 = @高亮
	WHERE ID = @Id;
	SELECT @@ROWCOUNT [RowCount];
END