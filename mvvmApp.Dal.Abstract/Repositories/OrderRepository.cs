using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Documents;

//visual studio don't hint this using 

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
            
            var orders = Context.Orders.AsNoTracking().Include(o=>o.OrderedComputers).ToList();
            

            return new List<Order>(orders);

        }

    }
}
