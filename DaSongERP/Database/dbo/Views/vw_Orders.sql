﻿CREATE VIEW dbo.vw_Orders
AS
SELECT    o.ID, o.进货日期, o.货号, o.商品图片, o.进货数量, o.店铺ID, o.JD订单号, o.客人地址, o.淘宝账号ID, o.淘宝订单号, o.采购备注, o.订单修改备注, o.来快递单号, o.发货时间, o.发货备注, 
               o.跟进人ID, o.京东价, o.成本价, o.采购人ID, o.导入时间, o.电话客服ID, o.电话备注, o.审单操作ID, o.拆包人员备注, o.转发单号, o.拆包人ID, o.拆包时间, o.售后操作ID, o.售后原因ID, 
               o.售后备注, o.售后人员ID, o.售后时间, o.客人退回单号, o.是否淘宝退回, o.售后完结, s.Name AS [店铺.Name], cg.Name AS [采购人.Name], tb.Name AS [淘宝账号.Name], 
               sd.Name AS [审单操作.Name], cb.Name AS [拆包人.Name], sho.Name AS [售后操作.Name], sho.SN AS [售后操作.SN], shr.Name AS [售后原因.Name], shr.SN AS [售后原因.SN], 
               sh.Name AS [售后人员.Name], gj.Name AS [跟进人.Name]
FROM       dbo.订单 AS o LEFT OUTER JOIN
               dbo.店铺 AS s ON s.ID = o.店铺ID LEFT OUTER JOIN
               dbo.Users AS cg ON cg.ID = o.采购人ID LEFT OUTER JOIN
               dbo.淘宝账号 AS tb ON tb.ID = o.淘宝账号ID LEFT OUTER JOIN
               dbo.审单操作 AS sd ON sd.ID = o.审单操作ID LEFT OUTER JOIN
               dbo.Users AS cb ON cb.ID = o.拆包人ID LEFT OUTER JOIN
               dbo.售后操作 AS sho ON sho.ID = o.售后操作ID LEFT OUTER JOIN
               dbo.售后原因 AS shr ON shr.ID = o.售后原因ID LEFT OUTER JOIN
               dbo.Users AS sh ON sh.ID = o.售后人员ID LEFT OUTER JOIN
               dbo.Users AS gj ON gj.ID = o.跟进人ID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Orders';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' End
         Begin Table = "shr"
            Begin Extent = 
               Top = 9
               Left = 1788
               Bottom = 175
               Right = 1971
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sh"
            Begin Extent = 
               Top = 9
               Left = 2028
               Bottom = 201
               Right = 2222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "gj"
            Begin Extent = 
               Top = 9
               Left = 2279
               Bottom = 201
               Right = 2473
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Orders';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "o"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 201
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 30
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 9
               Left = 326
               Bottom = 175
               Right = 509
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cg"
            Begin Extent = 
               Top = 9
               Left = 566
               Bottom = 201
               Right = 760
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb"
            Begin Extent = 
               Top = 9
               Left = 817
               Bottom = 175
               Right = 1000
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sd"
            Begin Extent = 
               Top = 9
               Left = 1057
               Bottom = 175
               Right = 1240
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cb"
            Begin Extent = 
               Top = 9
               Left = 1297
               Bottom = 201
               Right = 1491
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sho"
            Begin Extent = 
               Top = 9
               Left = 1548
               Bottom = 175
               Right = 1731
            End
            DisplayFlags = 280
            TopColumn = 0
        ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Orders';


