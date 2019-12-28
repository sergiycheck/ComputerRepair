CREATE TABLE [dbo].[Orders] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Sum]         DECIMAL (18, 2) NOT NULL,
    [PhoneNumber] NVARCHAR (MAX)  NULL,
    [Address]     NVARCHAR (MAX)  NULL,
    [Date]        DATETIME        NOT NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

