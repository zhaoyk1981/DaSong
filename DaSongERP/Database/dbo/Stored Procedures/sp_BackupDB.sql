-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BackupDB]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    --设置备份数据库的存放目录
	DECLARE @diskPath NVARCHAR(300)
	SET @diskPath='E:\Database_Backup\DaSongERP_'
	+CONVERT(VARCHAR, GETDATE(),112)+'_'
	+REPLACE(CONVERT(VARCHAR, GETDATE(),108),':','')+'.BAK'

	BACKUP DATABASE DaSongERP TO DISK = @diskPath WITH FORMAT;
END