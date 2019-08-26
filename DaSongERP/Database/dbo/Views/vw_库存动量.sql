CREATE VIEW dbo.vw_库存动量
AS
SELECT        dl.ID, dl.库存商品ID, dl.DateCreated, dl.现货数量, dl.在途数量, dl.OrderID, dl.Remark, dl.UserID, u.Name AS [User.Name], o.JD订单号 AS [Order.JD订单号]
FROM            dbo.库存动量 AS dl INNER JOIN
                         dbo.Users AS u ON dl.UserID = u.ID LEFT OUTER JOIN
                         dbo.订单 AS o ON o.ID = dl.OrderID
GO



GO


