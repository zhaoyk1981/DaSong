CREATE TABLE [dbo].[订单] (
    [ID]     UNIQUEIDENTIFIER NOT NULL,
    [进货日期]   DATETIME2 (7)    NULL,
    [货号]     NVARCHAR (50)    CONSTRAINT [DF_订单_货号] DEFAULT ('') NOT NULL,
    [商品图片]   NVARCHAR (500)   CONSTRAINT [DF_订单_商品图片] DEFAULT ('') NOT NULL,
    [进货数量]   INT              NULL,
    [店铺ID]   UNIQUEIDENTIFIER NULL,
    [JD订单号]  NVARCHAR (50)    CONSTRAINT [DF_订单_京东订单号] DEFAULT ('') NOT NULL,
    [客人地址]   NVARCHAR (150)   CONSTRAINT [DF_订单_客人地址] DEFAULT ('') NOT NULL,
    [淘宝账号ID] UNIQUEIDENTIFIER NOT NULL,
    [淘宝订单号]  NVARCHAR (50)    CONSTRAINT [DF_订单_淘宝订单号] DEFAULT ('') NULL,
    [采购备注]   NVARCHAR (MAX)   CONSTRAINT [DF_订单_采购备注] DEFAULT ('') NOT NULL,
    [订单修改备注] NVARCHAR (MAX)   CONSTRAINT [DF_订单_订单修改备注] DEFAULT ('') NOT NULL,
    [来快递单号]  NVARCHAR (50)    CONSTRAINT [DF_订单_来快递单号] DEFAULT ('') NOT NULL,
    [发货时间]   DATETIME2 (7)    NULL,
    [发货备注]   NVARCHAR (MAX)   CONSTRAINT [DF_订单_发货备注] DEFAULT ('') NOT NULL,
    [跟进人ID]  UNIQUEIDENTIFIER NULL,
    [京东价]    MONEY            NULL,
    [成本价]    MONEY            NULL,
    [采购人ID]  UNIQUEIDENTIFIER NULL,
    [导入时间]   DATETIME2 (7)    NULL,
    [电话客服ID] UNIQUEIDENTIFIER NULL,
    [电话备注]   NVARCHAR (MAX)   CONSTRAINT [DF_订单_电话客服备注] DEFAULT ('') NOT NULL,
    [审单操作ID] UNIQUEIDENTIFIER NULL,
    [拆包人员备注] NVARCHAR (MAX)   CONSTRAINT [DF_订单_拆包人员备注] DEFAULT ('') NOT NULL,
    [转发单号]   NVARCHAR (100)   CONSTRAINT [DF_订单_转发单号] DEFAULT ('') NOT NULL,
    [拆包人ID]  UNIQUEIDENTIFIER NULL,
    [拆包时间]   DATETIME2 (7)    NULL,
    [售后操作ID] UNIQUEIDENTIFIER NULL,
    [售后原因ID] UNIQUEIDENTIFIER NULL,
    [售后备注]   NVARCHAR (MAX)   CONSTRAINT [DF_订单_售后备注] DEFAULT ('') NOT NULL,
    [售后人员ID] UNIQUEIDENTIFIER NULL,
    [售后时间]   DATETIME2 (7)    NULL,
    [客人退回单号] NVARCHAR (100)   CONSTRAINT [DF_订单_客人退回单号] DEFAULT ('') NOT NULL,
    [是否淘宝退回] BIT              NULL,
    [售后完结]   BIT              NULL,
    [客服ID]   UNIQUEIDENTIFIER NULL,
    [客服时间]   DATETIME2 (7)    NULL,
    CONSTRAINT [PK_订单] PRIMARY KEY CLUSTERED ([ID] ASC)
);








GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_订单_JD订单号]
    ON [dbo].[订单]([JD订单号] ASC);

