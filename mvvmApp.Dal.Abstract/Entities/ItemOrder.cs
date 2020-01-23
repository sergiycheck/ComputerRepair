using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities
{
    public class ItemOrder
    {  
        
        public virtual Item Item { get; set; }
        
        public virtual Order Order { get; set; }
        
        public int? ItemId { get; set; }
        public int? OrderId { get; set; }
    }
}
