CREATE TABLE [dbo].[Products] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [ProductName]     NVARCHAR (50) NOT NULL,
    [EngineType]      INT           NOT NULL,
    [CompanyProducer] NVARCHAR (50) NOT NULL,
    [MolecularMass]   REAL          NOT NULL,
    [PricePerLiter]   REAL          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([CompanyProducer]<>''),
    CHECK ([ProductName]<>''),
    CONSTRAINT [CK_MolecularMass] CHECK ([MolecularMass]>(0)),
    CONSTRAINT [CK_PricePerLiter] CHECK ([PricePerLiter]>(0)),
    CONSTRAINT [FK_Products_CompanyProducer] FOREIGN KEY ([CompanyProducer]) REFERENCES [dbo].[Companies] ([CompanyName]),
    CONSTRAINT [FK_Products_TypeDictionary] FOREIGN KEY ([EngineType]) REFERENCES [dbo].[TypeDictionary] ([Id]),
    UNIQUE NONCLUSTERED ([ProductName] ASC)
);

