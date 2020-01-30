using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mvvmApp.Dal.Abstract.Entities
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Detail> Details { get; set; }
        
        public DbSet<User> Users { get; set; }


        

        public ApplicationContext()
        {

        }
        public ApplicationContext(string connectionString) : base(connectionString)
        {
           
        }
        static ApplicationContext()
        {
            //Database.SetInitializer<ApplicationContext>(new ItemDbInitializer());
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

        }
    }
    public class ItemDbInitializer :DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            db.Items.Add(new Item { Title = "Macbook", Company = "Apple", Price = 56000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\1.jpg", Details = null, Orders = null });
            db.Items.Add(new Item { Title = "Lenovo 330ich", Company = "Lenovo", Price = 60000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\2.jpg", Details = null, Orders = null });
            db.Items.Add(new Item { Title = "Acer Nitro 5 ", Company = "Acer", Price = 56000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\3.jpg", Details = null, Orders = null });
            db.Items.Add(new Item { Title = "MSI ps42 modern", Company = "Msi", Price = 35000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\4.jpg", Details = null, Orders = null });
            db.SaveChanges();
        }
    }
}
