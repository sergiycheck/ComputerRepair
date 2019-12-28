using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities.Components;

namespace mvvmApp.Dal.Abstract.Entities
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<VideoCard> VideoCards { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<PowerBlock> PowerBlocks { get; set; }
        public DbSet<MotherBoard> MotherBoards { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<MemoryModule> MemoryModules { get; set; }
        public DbSet<MemoryDisc> MemoryDiscs { get; set; }
        public DbSet<KeyBoard> KeyBoards { get; set; }
        public DbSet<Cooler> Coolers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Computer.Computer> Computers { get; set; }
        

        public ApplicationContext()
        {

        }
        public ApplicationContext(string connectionString) : base(connectionString)
        {
           
        }
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new ItemDbInitializer());
            
        }
    }
    public class ItemDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            db.Items.Add(new Item { Title = "Macbook", Company = "Apple", Price = 56000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\1.jpg" });
            db.Items.Add(new Item { Title = "Lenovo 330ich", Company = "Lenovo", Price = 60000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\2.jpg" });
            db.Items.Add(new Item { Title = "Acer Nitro 5 ", Company = "Acer", Price = 56000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\3.jpg" });
            db.Items.Add(new Item { Title = "MSI ps42 modern", Company = "Msi", Price = 35000, ImagePath = @"D:\filesFromCDisk\important\mvvmapp\Resources\4.jpg" });
            db.SaveChanges();
        }
    }
}
