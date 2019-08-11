-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.sp_UpdateOrder在途待发
	@ID UNIQUEIDENTIFIER
	, @在途待发 BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE 订单 SET
		在途待发 = @在途待发
	WHERE ID = @ID;

	SELECT @@ROWCOUNT [RowCount];
END