CREATE TABLE [dbo].[快递] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [SN]          INT           NOT NULL,
    [GroupLetter] NVARCHAR (1)  CONSTRAINT [DF_快递_GroupLetter] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_快递] PRIMARY KEY CLUSTERED ([ID] ASC)
);





