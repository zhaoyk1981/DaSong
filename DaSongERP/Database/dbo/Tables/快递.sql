CREATE TABLE [dbo].[快递] (
    [ID]   INT           NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [SN]   INT           NOT NULL,
    CONSTRAINT [PK_快递] PRIMARY KEY CLUSTERED ([ID] ASC)
);

