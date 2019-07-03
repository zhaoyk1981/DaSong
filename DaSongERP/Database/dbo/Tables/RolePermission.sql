CREATE TABLE [dbo].[RolePermission] (
    [ID]           INT NOT NULL,
    [RoleID]       INT NOT NULL,
    [PermissionID] INT NOT NULL,
    CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([ID] ASC)
);

