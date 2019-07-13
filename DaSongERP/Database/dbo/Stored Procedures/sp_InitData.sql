-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InitData]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


IF NOT EXISTS (SELECT * FROM [Permissions])
BEGIN
INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (1, N'管理员')

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (2, N'采购')

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (4, N'订单跟进')

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (8, N'电话客服')

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (16, N'拆包审单')

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (32, N'售后')

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (64, N'客服')
END

IF NOT EXISTS (SELECT * FROM 审单操作)
BEGIN
INSERT [dbo].[审单操作] ([ID], [Name], [SN]) VALUES (N'707ad2ed-05a2-4661-8783-01ce647353b6', N'货品不对', 4)

INSERT [dbo].[审单操作] ([ID], [Name], [SN]) VALUES (N'f487a39c-2fe3-4758-8fb5-293409df1737', N'退款--全部入库', 2)

INSERT [dbo].[审单操作] ([ID], [Name], [SN]) VALUES (N'8d1db75a-b976-47d1-9ba2-3cba8042c369', N'正常发走', 1)

INSERT [dbo].[审单操作] ([ID], [Name], [SN]) VALUES (N'cac4f053-54bb-4290-a812-687af5e39158', N'破损，等异常需要联系客户', 5)

INSERT [dbo].[审单操作] ([ID], [Name], [SN]) VALUES (N'630b59c5-74b0-43e6-87f1-d0a7dedbe4ba', N'发走一部分，一部分入库', 3)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'270d96a8-b765-4ea1-bce9-1d05801e0612', N'查单可以等', 1)
END

IF NOT EXISTS (SELECT * FROM 售后操作)
BEGIN
INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'30b920ee-1d4c-4e20-9900-2ab6166c99a4', N'发货拦截', 7)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'34389510-5d4e-4528-9f94-576e6a6da89f', N'直接退款（没发货）', 2)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'e6058389-bace-4e33-b38f-9159944036c4', N'补发票', 6)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'0f29da4e-312f-4d3a-b57b-c4b176501214', N'换货，退回', 4)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'd87b04c5-f8e4-425c-b4ec-d2610803630a', N'收到退货再退款', 3)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'8298811d-1f57-4407-abbe-fb48f64d9ea8', N'补发货', 5)
END

IF NOT EXISTS (SELECT * FROM 售后原因)
BEGIN
INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'b6f21b49-0d9a-4fb7-82f8-09ea00ae4e03', N'破损', 6)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'e4133458-c62c-4a4a-9c66-35ef9d4321c3', N'多发一份', 4)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'8d8b0603-1f8e-42ba-8916-3e794e61969e', N'发少了', 3)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'1bd610d4-acf5-477f-8a41-45f652c007a7', N'无理由退换', 7)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'e7eabdb0-28d2-45f5-9cd1-a9bb73e12594', N'没发', 2)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'6201d9a1-5db1-448c-909d-c8716789fe63', N'不能等', 1)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'e34267c4-cbbe-4ebe-ba74-e79d5b3815a3', N'发错货', 5)
END

IF NOT EXISTS (SELECT * FROM 快递)
BEGIN
SET IDENTITY_INSERT [dbo].[快递] ON 

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (1, N'中通', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (2, N'邮政', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (3, N'顺丰', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (4, N'韵达', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (5, N'圆通', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (6, N'申通', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (7, N'汇通', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (8, N'国通', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (9, N'全峰', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (10, N'优速', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (11, N'天天', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (12, N'百世汇通', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (13, N'宅急送', 0)

INSERT [dbo].[快递] ([ID], [Name], [SN]) VALUES (14, N'德邦', 0)

SET IDENTITY_INSERT [dbo].[快递] OFF
END

END