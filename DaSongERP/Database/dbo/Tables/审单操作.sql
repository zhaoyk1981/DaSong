CREATE TABLE [dbo].[审单操作] (
    [ID]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    [SN]   INT              NOT NULL,
    [已完成]  BIT              CONSTRAINT [DF_审单操作_已完成] DEFAULT ((1)) NOT NULL,
    [入库]   BIT              CONSTRAINT [DF_审单操作_入库] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_审单操作] PRIMARY KEY CLUSTERED ([ID] ASC)
);










GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_审单操作_Name]
    ON [dbo].[审单操作]([Name] ASC);

