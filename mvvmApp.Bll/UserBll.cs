using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace mvvmApp.Bll
{
    public class UserBll
    {
        Mapper.Mapper Mapper;
        UserRepository<User> repository;
        public UserBll() 
        {
            repository = new UserRepository<User>(ApplicationContext.GetInstance());
            Mapper = new Mapper.Mapper();
        }
        public bool Verify(UserDTO user) 
        {
            return repository.Verify(Mapper.Convert(user));
        }
        public void Register(UserDTO user) 
        {
            repository.Create(Mapper.Convert(user));
        }

    }
}
