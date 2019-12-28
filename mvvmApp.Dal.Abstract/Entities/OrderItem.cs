using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
    }
}
