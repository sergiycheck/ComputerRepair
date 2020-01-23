namespace mvvmApp.Dal.Abstract.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManuallyManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            CreateTable(
                "dbo.ItemOrders",
                c => new
                    {
                        ItemId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemId, t.OrderId })
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.ItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.OrderId)
                .Index(t => t.ItemId)
                .Index(t => t.OrderId);
            
            DropTable("dbo.OrderItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Item_Id });
            
            DropForeignKey("dbo.ItemOrders", "OrderId", "dbo.Items");
            DropForeignKey("dbo.ItemOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ItemOrders", "ItemId", "dbo.Orders");
            DropForeignKey("dbo.ItemOrders", "ItemId", "dbo.Items");
            DropIndex("dbo.ItemOrders", new[] { "OrderId" });
            DropIndex("dbo.ItemOrders", new[] { "ItemId" });
            DropTable("dbo.ItemOrders");
            CreateIndex("dbo.OrderItems", "Item_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            AddForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
