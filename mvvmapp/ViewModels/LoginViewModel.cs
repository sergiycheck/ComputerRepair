using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using mvvmApp.Bll.Intecation.Commands;
using mvvmApp.Bll;
using mvvmApp.Bll.Mapper;
using DTOs;

namespace mvvmapp.ViewModels
{
    public class LoginViewModel:UserModel
    {
        UserBll userBll;
        Mapper Mapper;
        public LoginViewModel() 
        {
            userBll = new UserBll();
            Mapper = new Mapper();
        }
        public bool Verify()
        {
            
            UserDTO user = new UserDTO()
            {
                Address = Address,
                Id = Id,
                Name = Name,
                Password = Password,
                Orders = Mapper.ConvertList(Orders),
                PhoneNumber = PhoneNumber
            };
            return userBll.Verify(user);

        }
    }
}
