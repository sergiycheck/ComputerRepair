
using mvvmApp.Dal;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Bll.Infrastructure
{
    public class ServiceModule
    {
        private ApplicationContext db;
        private OrderRepositoryEF orderRepo;
        private ItemRepositoryEF itemRepo;
        public ServiceModule(string connectionString)
        {
            db = new ApplicationContext(connectionString);            
        }
        public IRepository<Item> Items
        {
            get
            {
                if (itemRepo == null)
                {
                    itemRepo = new ItemRepositoryEF(db);
                    
                }
                return itemRepo;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepo == null)
                {
                    orderRepo = new OrderRepositoryEF(db);
                }
                return orderRepo;
            }
            
        }

    }
}
