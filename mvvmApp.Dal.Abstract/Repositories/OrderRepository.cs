using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;//visual studio don't hint this using 

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class OrderRepository<T> : GenericRepository<T> where T : Order
    {
        ApplicationContext db;
        public OrderRepository(ApplicationContext context) : base(context)
        {
            db = context;
        }

        public List<Order> GetOrdersWithComputers()
        {
           return Context.Orders.Include(io=>io.ItemOrders).ToList();

        }

    }
}
