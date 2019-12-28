using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class OrderRepository<T> : GenericRepository<T> where T : Order
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
