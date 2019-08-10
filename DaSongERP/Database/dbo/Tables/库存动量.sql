CREATE TABLE [dbo].[库存动量] (
    [ID]          INT              IDENTITY (1, 1) NOT NULL,
    [库存商品ID]      UNIQUEIDENTIFIER NOT NULL,
    [DateCreated] DATETIME2 (7)    CONSTRAINT [DF_库存动量_DateCreated] DEFAULT (getdate()) NOT NULL,
    [现货数量]        INT              CONSTRAINT [DF_库存动量_现货数] DEFAULT ((0)) NOT NULL,
    [在途数量]        INT              CONSTRAINT [DF_库存动量_在途数] DEFAULT ((0)) NOT NULL,
    [OrderID]     UNIQUEIDENTIFIER NULL,
    [Remark]      NVARCHAR (MAX)   CONSTRAINT [DF_库存动量_Remark] DEFAULT ('') NOT NULL,
    [UserID]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_库存动量] PRIMARY KEY CLUSTERED ([ID] ASC)
);

