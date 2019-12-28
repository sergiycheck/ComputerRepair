using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using mvvmapp.Models;
using mvvmApp.Dal.Abstract.Client;
using System.Windows;

namespace mvvmapp.ViewModels
{
    class RegisterViewModel:UserModel
    {
        ClientTcpAction client = new ClientTcpAction();
        public bool Register()
        {
            if (Password != null)
            {
                User user = new User()
                {
                    Address = Address,
                    Name = Name,
                    Password = Password,
                    PhoneNumber = PhoneNumber
                };
                //UserRepository<User> repository = new UserRepository<User>(new ApplicationContext("mvvmApp.Dal.Abstract.Entities.ApplicationContext"));

                //repository.Create(user);
                try
                {
                    client.SendData(user);
                }
                catch (Exception ex)
                {

                }
                MessageBox.Show("Успішно зареєстровані");
                //var el = repository.GetAll();
                return true;
            }
            else 
            {
                
                MessageBox.Show("Паролі не співпадають");
                return false;
            }
        }
    }
}
