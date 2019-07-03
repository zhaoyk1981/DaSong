CREATE TABLE [dbo].[库存] (
    [ID]   UNIQUEIDENTIFIER NOT NULL,
    [货号]   NVARCHAR (50)    NOT NULL,
    [库存数量] INT              NOT NULL,
    [在途数量] INT              NOT NULL,
    CONSTRAINT [PK_库存] PRIMARY KEY CLUSTERED ([ID] ASC)
);

