CREATE TABLE [dbo].[Owners] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Passport]      INT           NOT NULL,
    [FullName]      NVARCHAR (50) NOT NULL,
    [LivingAddress] NVARCHAR (50) NULL,
    [HasEducation]  NVARCHAR (50) NOT NULL,
    [Sex]           NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([FullName]<>''),
    CHECK ([HasEducation]='True' OR [HasEducation]='False'),
    CHECK ([Passport]<>''),
    CHECK ([Sex]='Male' OR [Sex]='Female'),
    UNIQUE NONCLUSTERED ([Passport] ASC)
);

