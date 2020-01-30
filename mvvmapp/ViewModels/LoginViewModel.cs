using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using mvvmApp.Bll.Intecation.Commands;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;


namespace mvvmapp.ViewModels
{
    public class LoginViewModel:UserModel
    {

        public bool Verify()
        {
            User model = new User()
            {
                Password = Password,
                PhoneNumber = PhoneNumber
            };
            UserRepository<User> repository = new UserRepository<User>(new ApplicationContext("mvvmApp.Dal.Abstract.Entities.ApplicationContext"));
            return repository.Verify(model);

        }
    }
}
