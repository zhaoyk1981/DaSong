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

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (128, N'仓库（只读）')

INSERT [dbo].[Permissions] ([ID], [Name]) VALUES (256, N'仓库（读写）')
END

IF NOT EXISTS (SELECT * FROM dbo.店铺)
BEGIN
INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'368ea6bd-572a-46fd-ab3a-001d0905053e', N'大福福洗护', N'大福福洗护专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'617f9369-97a4-4b1c-a7ee-09967fd498e1', N'lepengcanju', N'乐鹏餐具专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'08e7e1f5-3c38-46db-a545-1a1429f9281f', N'jd_angongzhu1', N'鹏乐个护专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'ba1d6d2c-ca25-4714-babc-331e19613e2a', N'jd_angongzhu2', N'鹏乐洗护专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'30bdb15d-a058-47c9-8bd3-3ca0a2186ee2', N'大福福化妆品', N'大福福化妆品专营店', N'乐鹏仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'fe1905ef-abfc-4e31-8d50-5a19a17da07d', N'福乐乐运动户外', N'福乐乐运动户外专营店', N'')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'4cfe5a3b-b610-47fa-9008-5de59997fd52', N'penglehuli', N'鹏乐清洁用品专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'd4f13edb-d575-43d2-ba65-74afd4d7a8c1', N'乐鹏家装建材', N'乐鹏家装建材专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'646dc37a-4c1e-4856-b000-a17aa9a360fd', N'jd_angongzhu', N'鹏乐美妆专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'0671e234-7082-426d-8a4a-b933f1cd5de5', N'乐鹏礼品专营店', N'乐鹏礼品专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'ffaf708a-1689-4060-becc-cbb53d283fc7', N'dafufu', N'大福福个护专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'3bcb07d1-f3f8-4cd4-9f26-d81d92586394', N'qkd_老店', N'琪可朵旗舰店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'f773caaa-9a8f-44b4-b80c-de62f39bcd9c', N'鹏乐身体护理', N'鹏乐个人护理专营店', N'唯优仓')

INSERT [dbo].[店铺] ([ID], [Prefix], [Name], [京东仓]) VALUES (N'47e08327-9bab-433a-b331-dee39af7aad5', N'dffqingjie', N'大福福清洁用品专营店', N'唯优仓')
END

IF NOT EXISTS (SELECT * FROM dbo.快递)
BEGIN
SET IDENTITY_INSERT [dbo].[快递] ON 

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (1, N'中通', 1, N'Z')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (2, N'邮政', 1, N'Y')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (3, N'顺丰', 1, N'S')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (4, N'韵达', 1, N'Y')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (5, N'圆通', 1, N'Y')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (6, N'申通', 1, N'S')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (7, N'汇通', 1, N'H')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (8, N'国通', 1, N'G')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (9, N'全峰', 1, N'Q')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (10, N'优速', 1, N'Y')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (11, N'天天', 1, N'T')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (12, N'百世汇通', 1, N'B')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (13, N'宅急送', 1, N'Z')

INSERT [dbo].[快递] ([ID], [Name], [SN], [GroupLetter]) VALUES (14, N'德邦', 1, N'D')

SET IDENTITY_INSERT [dbo].[快递] OFF
END

IF NOT EXISTS (SELECT * FROM 审单操作)
BEGIN
INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'707ad2ed-05a2-4661-8783-01ce647353b6', N'货品不对', 4, 0, 0)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'f487a39c-2fe3-4758-8fb5-293409df1737', N'退款--全部入库', 2, 1, 1)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'8d1db75a-b976-47d1-9ba2-3cba8042c369', N'正常发走', 1, 1, 0)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'cac4f053-54bb-4290-a812-687af5e39158', N'破损，等异常需要联系客户', 5, 0, 0)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'15963b1f-e094-4245-891e-7eb3bda69566', N'现货全部到货，入库', 10, 1, 1)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'026ef9b3-dd65-49b1-9658-8e4f791cc917', N'已发货，包裹需要退回', 7, 1, 0)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'14a8e06d-5074-4602-8f4d-ae73cc37bf3e', N'少件', 8, 0, 0)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'ed551e8b-64c3-4c9f-a05d-b52335cf8ae0', N'现货部分到货，入库，还会到货', 11, 0, 1)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'f264a65b-d8ed-4427-90b0-cb4fd8e823a1', N'问题件，还会到货', 9, 0, 0)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'630b59c5-74b0-43e6-87f1-d0a7dedbe4ba', N'发走一部分，一部分入库', 3, 1, 1)

INSERT [dbo].[审单操作] ([ID], [Name], [SN], [已完成], [入库]) VALUES (N'ba32820f-73d6-46f1-9956-ff89fbd4003d', N'已发货，现货入库', 6, 1, 1)
END

IF NOT EXISTS (SELECT * FROM 售后操作)
BEGIN
INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'270d96a8-b765-4ea1-bce9-1d05801e0612', N'未发货退款', 1)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'30b920ee-1d4c-4e20-9900-2ab6166c99a4', N'退差价', 7)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'34389510-5d4e-4528-9f94-576e6a6da89f', N'退款拦截', 2)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'f3a2e746-f6de-45b4-a30d-6fb442fc2745', N'少件', 8)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'e6058389-bace-4e33-b38f-9159944036c4', N'发票', 6)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'0f29da4e-312f-4d3a-b57b-c4b176501214', N'换货', 4)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'd87b04c5-f8e4-425c-b4ec-d2610803630a', N'退款退货', 3)

INSERT [dbo].[售后操作] ([ID], [Name], [SN]) VALUES (N'8298811d-1f57-4407-abbe-fb48f64d9ea8', N'补发', 5)
END

IF NOT EXISTS (SELECT * FROM 售后原因)
BEGIN
INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'b6f21b49-0d9a-4fb7-82f8-09ea00ae4e03', N'质量问题', 6)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'f66870f2-23ea-4614-b273-16ec5db43191', N'尺码、款式等更换', 9)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'e4133458-c62c-4a4a-9c66-35ef9d4321c3', N'发错', 4)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'8d8b0603-1f8e-42ba-8916-3e794e61969e', N'少发', 3)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'1bd610d4-acf5-477f-8a41-45f652c007a7', N'未收到货', 7)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'acfe4ead-764a-4941-8f29-48a381896a65', N'其他', 11)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'e0bb6bd5-519f-43b8-9c4e-9d8effb1be7f', N'无理由退换', 10)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'e7eabdb0-28d2-45f5-9cd1-a9bb73e12594', N'没发货', 2)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'6201d9a1-5db1-448c-909d-c8716789fe63', N'不能等', 1)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'2884b3fb-bca8-4575-b5f1-d10706bf1185', N'给客户优惠', 8)

INSERT [dbo].[售后原因] ([ID], [Name], [SN]) VALUES (N'e34267c4-cbbe-4ebe-ba74-e79d5b3815a3', N'破损', 5)
END

IF NOT EXISTS (SELECT * FROM dbo.中转仓)
BEGIN
INSERT [dbo].[中转仓] ([ID], [Name], [SN]) VALUES (N'fdd447f6-6d70-4223-af92-2b585c27b5f9', N'天津', 1)

INSERT [dbo].[中转仓] ([ID], [Name], [SN]) VALUES (N'c64dc0af-efcc-4bc2-a8cb-c29804c694bf', N'常州', 2)
END

END