using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Entities.Computer;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class UserRepository<T> : GenericRepository<T> where T : User
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }

        public bool Verify(User user)
        {
            var all = Context.Users;

            var VerifiedUser =
                Context.Users.FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber && u.Password == user.Password);
            
            if (VerifiedUser != null)
                return true;
            return false;
        }
    }
}
