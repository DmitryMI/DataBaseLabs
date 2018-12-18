CREATE TABLE [dbo].[TypeDictionary] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [EngineType] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([EngineType]<>'')
);

