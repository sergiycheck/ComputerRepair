using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class ItemRepository<T>:GenericRepository<T> where T : Item
    {
        public ItemRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
