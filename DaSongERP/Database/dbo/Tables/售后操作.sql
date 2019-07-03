CREATE TABLE [dbo].[售后操作] (
    [ID]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    [SN]   INT              NOT NULL,
    CONSTRAINT [PK_售后操作] PRIMARY KEY CLUSTERED ([ID] ASC)
);

