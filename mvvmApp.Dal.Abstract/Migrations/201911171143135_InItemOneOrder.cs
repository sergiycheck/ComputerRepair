﻿namespace mvvmApp.Dal.Abstract.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InItemOneOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(),
                        Price = c.Int(nullable: false),
                        Company = c.String(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Items", new[] { "Order_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Items");
        }
    }
}
