using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities
{
    [Serializable]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public override string ToString()
        {
            return "Name = " + Name + " PhoneNumber+ " + PhoneNumber + " Address = " + Address + " Password = " + Password;
        }
    }
}
