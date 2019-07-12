CREATE TABLE [dbo].[售后原因] (
    [ID]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    [SN]   INT              NOT NULL,
    CONSTRAINT [PK_售后原因] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_售后原因_Name]
    ON [dbo].[售后原因]([Name] ASC);

