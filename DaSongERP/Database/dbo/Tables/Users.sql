CREATE TABLE [dbo].[Users] (
    [ID]           UNIQUEIDENTIFIER NOT NULL,
    [UserName]     NVARCHAR (50)    NOT NULL,
    [Password]     NVARCHAR (50)    NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [PermissionID] INT              NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_UserName]
    ON [dbo].[Users]([UserName] ASC);

