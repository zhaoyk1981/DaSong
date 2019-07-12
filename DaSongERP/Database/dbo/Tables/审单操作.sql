CREATE TABLE [dbo].[审单操作] (
    [ID]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    [SN]   INT              NOT NULL,
    CONSTRAINT [PK_审单操作] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_审单操作_Name]
    ON [dbo].[审单操作]([Name] ASC);

