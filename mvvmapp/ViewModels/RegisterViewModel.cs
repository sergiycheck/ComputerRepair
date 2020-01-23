using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using mvvmapp.Models;

using System.Windows;

namespace mvvmapp.ViewModels
{
    class RegisterViewModel:UserModel
    {
        
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

                try
                {
                    
                }
                catch (Exception ex)
                {

                }
                MessageBox.Show("Успішно зареєстровані");
                
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
