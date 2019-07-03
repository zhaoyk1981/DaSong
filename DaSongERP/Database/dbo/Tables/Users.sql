CREATE TABLE [dbo].[Users] (
    [ID]       UNIQUEIDENTIFIER NOT NULL,
    [UserName] NVARCHAR (50)    NOT NULL,
    [Password] NVARCHAR (50)    NOT NULL,
    [Name]     NVARCHAR (50)    NOT NULL,
    [RoleID]   INT              NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

