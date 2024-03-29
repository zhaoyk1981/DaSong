﻿CREATE TABLE [dbo].[店铺] (
    [ID]     UNIQUEIDENTIFIER NOT NULL,
    [Prefix] NVARCHAR (50)    NOT NULL,
    [Name]   NVARCHAR (50)    NOT NULL,
    [京东仓]    NVARCHAR (50)    CONSTRAINT [DF_店铺_京东仓] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_店铺] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_店铺_Prefix]
    ON [dbo].[店铺]([Prefix] ASC);

