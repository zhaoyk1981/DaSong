CREATE VIEW dbo.vw_Orders
AS
SELECT  o.ID, o.进货日期, o.货号, o.规格, o.商品图片, o.进货数量, o.入库数量, o.店铺, o.JD订单号, o.客人姓名, o.客人电话, o.客人地址, o.淘宝账号, o.淘宝订单号, 
               o.采购备注, o.订单修改备注, o.来快递, o.来快递单号, o.发货时间, o.发货备注, o.跟进人ID, o.京东价, o.成本价, o.采购人ID, o.导入时间, o.电话客服ID, 
               o.电话备注, o.审单操作ID, o.拆包人员备注, o.转发单号, o.拆包人ID, o.拆包时间, o.售后操作ID, o.售后原因ID, o.售后备注, o.售后人员ID, o.售后时间, 
               o.客人退回单号, o.售后完结, o.客服ID, o.客服时间, o.高亮, o.现货, o.退款金额, o.中转仓, cg.Name AS [采购人.Name], sd.Name AS [审单操作.Name], 
               sd.入库 AS [审单操作.入库], cb.Name AS [拆包人.Name], sho.Name AS [售后操作.Name], sho.SN AS [售后操作.SN], shr.Name AS [售后原因.Name], 
               shr.SN AS [售后原因.SN], sh.Name AS [售后人员.Name], gj.Name AS [跟进人.Name], kf.Name AS [客服.Name], 
               CAST(CASE WHEN o.[来快递单号] = '' THEN 0 ELSE 1 END AS BIT) AS 已跟进, CAST(CASE WHEN o.[导入时间] IS NULL THEN 0 ELSE 1 END AS BIT) 
               AS 已导入, ISNULL(sd.已完成, 0) AS 已拆包, CAST(CASE WHEN o.售后操作ID IS NULL THEN 0 ELSE 1 END AS BIT) AS 已售后, 
               dhkf.Name AS [电话客服.Name], o.订单终结, o.订单终结备注, o.淘宝退回单号, CAST(CASE WHEN o.JD订单号 = '' THEN 1 ELSE 0 END AS BIT) AS 自采, 
               sp.ID AS 库存商品ID
FROM     dbo.订单 AS o LEFT OUTER JOIN
               dbo.Users AS cg ON cg.ID = o.采购人ID LEFT OUTER JOIN
               dbo.审单操作 AS sd ON sd.ID = o.审单操作ID LEFT OUTER JOIN
               dbo.Users AS cb ON cb.ID = o.拆包人ID LEFT OUTER JOIN
               dbo.售后操作 AS sho ON sho.ID = o.售后操作ID LEFT OUTER JOIN
               dbo.售后原因 AS shr ON shr.ID = o.售后原因ID LEFT OUTER JOIN
               dbo.Users AS sh ON sh.ID = o.售后人员ID LEFT OUTER JOIN
               dbo.Users AS gj ON gj.ID = o.跟进人ID LEFT OUTER JOIN
               dbo.Users AS kf ON kf.ID = o.客服ID LEFT OUTER JOIN
               dbo.Users AS dhkf ON dhkf.ID = o.电话客服ID LEFT OUTER JOIN
               dbo.库存商品 AS sp ON o.中转仓 = sp.仓库 AND o.货号 = sp.货号 AND o.规格 = sp.规格
GO
