CREATE TABLE [dbo].[库存商品] (
    [ID]          UNIQUEIDENTIFIER NOT NULL,
    [货号]          NVARCHAR (50)    CONSTRAINT [DF_库存商品_货号] DEFAULT ('') NOT NULL,
    [规格]          NVARCHAR (200)   CONSTRAINT [DF_库存商品_规格] DEFAULT ('') NOT NULL,
    [Name]        NVARCHAR (200)   CONSTRAINT [DF_库存商品_Name] DEFAULT ('') NOT NULL,
    [Thumbnails]  NVARCHAR (500)   CONSTRAINT [DF_库存商品_Thumbnails] DEFAULT ('') NOT NULL,
    [仓库]          NVARCHAR (50)    CONSTRAINT [DF_库存商品_仓库] DEFAULT ('') NOT NULL,
    [库位]          NVARCHAR (50)    CONSTRAINT [DF_库存商品_库位] DEFAULT ('') NOT NULL,
    [DateCreated] DATETIME2 (7)    CONSTRAINT [DF_库存商品_DateCreated] DEFAULT (getdate()) NOT NULL,
    [UserID]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_库存商品] PRIMARY KEY CLUSTERED ([ID] ASC)
);



