﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Delete售后操作]
	@ID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM dbo.售后操作
	WHERE ID = @ID
		AND NOT EXISTS (SELECT * FROM dbo.订单 WHERE [售后操作ID] = @ID);

	SELECT @@ROWCOUNT [RowCount];
END