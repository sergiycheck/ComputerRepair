using System.Collections.Generic;

namespace mvvmApp.Dal.Abstract.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Entities.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;//was true
        }

        protected override void Seed(Entities.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Items.Add(new Item { Title = "Macbook", Company = "Apple", Price = 56000, ImagePath = @"E:\filesFromCDisk\important\mvvmapp\Resources\1.jpg", Details = null, Orders = null });
            context.Items.Add(new Item { Title = "Lenovo 330ich", Company = "Lenovo", Price = 60000, ImagePath = @"E:\filesFromCDisk\important\mvvmapp\Resources\2.jpg", Details = null, Orders = null });
            context.Items.Add(new Item { Title = "Acer Nitro 5 ", Company = "Acer", Price = 56000, ImagePath = @"E:\filesFromCDisk\important\mvvmapp\Resources\3.jpg", Details = null, Orders = null });
            context.Items.Add(new Item { Title = "MSI ps42 modern", Company = "Msi", Price = 35000, ImagePath = @"E:\filesFromCDisk\important\mvvmapp\Resources\4.jpg", Details = null, Orders = null });
            context.SaveChanges();
        }
    }
}
