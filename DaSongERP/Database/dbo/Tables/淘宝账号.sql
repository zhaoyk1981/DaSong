CREATE TABLE [dbo].[淘宝账号] (
    [ID]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    [SN]   INT              NOT NULL,
    CONSTRAINT [PK_淘宝账号] PRIMARY KEY CLUSTERED ([ID] ASC)
);

