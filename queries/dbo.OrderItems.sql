CREATE TABLE [dbo].[OrderItems] (
    [Order_Id] INT NULL,
    [Item_Id]  INT NULL,
    CONSTRAINT [FK_dbo.OrderItems_dbo.Orders_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [FK_dbo.OrderItems_dbo.Items_Item_Id] FOREIGN KEY ([Item_Id]) REFERENCES [dbo].[Items] ([Id])
);

