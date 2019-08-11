CREATE VIEW dbo.vw_库存商品
AS
SELECT  sp.ID, sp.货号, sp.规格, sp.Name, sp.Thumbnails, sp.仓库, sp.库位, ISNULL(kctj.现货数量, 0) AS 现货数量, ISNULL(kctj.在途数量, 0) AS 在途数量, 
               ISNULL(kctj.现货数量, 0) + ISNULL(kctj.在途数量, 0) AS 虚拟数量, sp.DateCreated, sp.UserID, u.Name AS [User.Name]
FROM     dbo.库存商品 AS sp LEFT OUTER JOIN
                   (SELECT  库存商品ID, SUM(现货数量) AS 现货数量, SUM(在途数量) AS 在途数量
                   FROM     dbo.库存动量 AS dl
                   GROUP BY 库存商品ID) AS kctj ON sp.ID = kctj.库存商品ID LEFT OUTER JOIN
               dbo.Users AS u ON u.ID = sp.UserID
GO