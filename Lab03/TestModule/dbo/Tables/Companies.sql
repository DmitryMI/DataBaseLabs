CREATE TABLE [dbo].[Companies] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName]          NVARCHAR (50) NOT NULL,
    [CompanyAddress]       NVARCHAR (50) NULL,
    [CompanyOwnerPassport] INT           NOT NULL,
    [PhoneNumber]          NVARCHAR (50) NOT NULL,
    [EmploeeCount]         INT           NOT NULL,
    [AnnualTurnover]       FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([CompanyName]<>''),
    CHECK ([CompanyOwnerPassport]>(0)),
    CHECK ([EmploeeCount]>(0)),
    CHECK ([PhoneNumber]<>''),
    CONSTRAINT [FK_Companies_CompanyOwnerPassport] FOREIGN KEY ([CompanyOwnerPassport]) REFERENCES [dbo].[Owners] ([Passport]),
    UNIQUE NONCLUSTERED ([CompanyName] ASC)
);

