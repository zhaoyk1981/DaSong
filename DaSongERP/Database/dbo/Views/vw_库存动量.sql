CREATE VIEW dbo.vw_库存动量
AS
SELECT  dl.ID, dl.库存商品ID, dl.DateCreated, dl.现货数量, dl.在途数量, dl.OrderID, dl.Remark, dl.UserID, u.Name AS [User.Name]
FROM     dbo.库存动量 AS dl INNER JOIN
               dbo.Users AS u ON dl.UserID = u.ID
GO