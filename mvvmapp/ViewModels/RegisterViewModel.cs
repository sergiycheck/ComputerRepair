using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Models;
using mvvmApp.Bll;
using mvvmApp.Bll.Mapper;
using DTOs;

namespace mvvmapp.ViewModels
{
    class RegisterViewModel:UserModel
    {
        UserBll UserBll;
        Mapper Mapper;
        public RegisterViewModel() 
        {
            UserBll = new UserBll();
            Mapper = new Mapper();

        }
        public bool Register()
        {
            if (Password != null)
            {
                UserDTO user = new UserDTO()
                {
                    Address = Address,
                    Name = Name,
                    Password = Password,
                    PhoneNumber = PhoneNumber,
                    Orders = null
                };

                try
                {
                    UserBll.Register(user);
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
