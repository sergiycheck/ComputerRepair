using mvvmApp.Dal;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mvvmApp.Bll.Infrastructure
{

    public class ServiceModuleAdo
    {
        private IRepository<Item> itemsRepo;
        private IRepository<Order> orderRepo;
        public ServiceModuleAdo()
        {

        }
        public IRepository<Item> Items
        {
            get
            {
                if(itemsRepo == null)
                {
                    itemsRepo = new ItemRepositoryADO(); 
                }
                return itemsRepo;
            }
        }
        

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepo == null)
                {
                    orderRepo = new OrderRepositoryADO();
                }
                return orderRepo;
            }
        }
    }
}
