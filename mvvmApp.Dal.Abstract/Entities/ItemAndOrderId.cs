using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities
{
    public class ItemAndOrderId
    {
        public Item item { get; set; }
        public int OrderId { get; set; }
    }
}
