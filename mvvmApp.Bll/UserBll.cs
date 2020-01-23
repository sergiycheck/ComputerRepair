using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Bll
{
    public class UserBll
    {
        Mapper.Mapper Mapper;
        UserRepository<User> repository;
        public UserBll() 
        {
            repository = new UserRepository<User>
            (
            new ApplicationContext
            ("mvvmApp.Dal.Abstract.Entities.ApplicationContext")
            );
        }

    }
}
