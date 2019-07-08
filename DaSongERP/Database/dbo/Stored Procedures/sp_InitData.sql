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

IF NOT EXISTS (SELECT * FROM 店铺)
BEGIN
INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'8560009b-c4ca-49cb-8a03-04db240eb2f3', N'乐鹏灯饰照明专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'08bcf65c-650a-47f1-a11c-1123b64bc87a', N'CHIC DOLL/琪可朵旗舰店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'765bbcde-9699-4a55-8604-1a612f2f1a2b', N'大福福清洁用品专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'7ef2242d-22dd-4fde-aade-23cca0df77da', N'乐鹏礼品专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'31f07fbd-70fc-466e-a3b1-23d8576b5782', N'宇天下家居拼购店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'eb91bc0f-e2a3-44da-bf94-2ad31553036c', N'太阳景家装建材拼购店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'a8383e46-3ad3-474b-b6e6-4aafb501e782', N'福乐乐家具专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'9d2feeec-0931-43dd-875e-58f40d8e61ba', N'鹏乐个人护理专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'514286b7-e7ff-4764-a1ac-5d03690262bc', N'鹏乐女装专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'c504209b-f4e2-40a9-9ffd-63ad2fe3f3a6', N'鹏乐美妆专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'62238e10-5a02-472a-922d-63b9008d2436', N'大福福个护专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'63ebf03b-a074-44b7-9d80-6882fd955b45', N'怡壹澜陆服饰拼购店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'731519b5-71e7-4a23-b829-6a33f86f614b', N'福乐乐家具专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'9021f4bf-4884-4d02-bbcf-6ebc3be9794c', N'鹏乐洗护专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'8a6fc1bf-0491-4dfa-a3de-7208fa0ed6ee', N'鹏乐个护专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'd6067b35-bfc6-446d-ab50-7b3a8b5c5362', N'御龙象家装建材拼购店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'4b9ff5ea-7430-45cd-9c15-8986d5ed2cf7', N'鹏乐清洁用品专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'7d467fc0-4a54-4c01-8bfb-99f172fa1274', N'秀华天家装建材拼购店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'263f788c-6d3b-4cf3-b938-a43c07fe1334', N'乐鹏餐具专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'cd2f8857-fda6-4c2f-9fdf-a6e53704ed05', N'乐鹏家装建材专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'cc69c3ad-17cf-478a-b523-af79ce6f950e', N'乐鹏服饰专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'86d2d2a7-1a7f-4e86-9cd5-b15fb0c413b5', N'泰聚金家装建材拼购店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'afbb6232-96ff-4dfc-a7cb-b49b567dfdf4', N'大福福洗护专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'0928f58c-5c2c-41a6-be2a-c5a6fa5f620f', N'靳继家装建材拼购店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'5f42618d-6c26-414e-875f-e4b71a69b74a', N'大福福化妆品专营店', 0)

INSERT [dbo].[店铺] ([ID], [Name], [SN]) VALUES (N'febadf75-3bbe-4e43-82a4-fc0bde8acbe4', N'福乐乐运动户外专营店', 0)
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

IF NOT EXISTS (SELECT * FROM 淘宝账号)
BEGIN
INSERT [dbo].[淘宝账号] ([ID], [Name], [SN]) VALUES (N'2ef31db4-9315-4847-9569-6456ae911c78', N'淘宝账号2', 2)

INSERT [dbo].[淘宝账号] ([ID], [Name], [SN]) VALUES (N'b814979f-8a0d-4349-8cfb-a92db480097d', N'淘宝账号1', 1)

INSERT [dbo].[淘宝账号] ([ID], [Name], [SN]) VALUES (N'4c135e0f-e563-45df-a818-d6592992e353', N'淘宝账号3', 3)
END

END