CREATE TABLE [dbo].[Items] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (MAX) NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    [Price]     INT            NOT NULL,
    [Company]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([Id] ASC)
);

