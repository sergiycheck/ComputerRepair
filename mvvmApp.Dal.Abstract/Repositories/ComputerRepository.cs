using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Entities.Computer;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class ComputerRepository<T>:GenericRepository<T> where T:Computer
    {
        public ComputerRepository(ApplicationContext context):base(context)
        {

        }
    }
}
