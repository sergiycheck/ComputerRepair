using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities
{
    [Serializable]
   
    public class Detail : BaseEntity
    {
        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        
        public string ImagePath { get; set; }
       
        public int Price { get; set; }
        
        public string Company { get; set; }

        public override string ToString()
        {
            return "Id = " + Id + " Title = " + Title + " Price = " + Price + " Company = " + Company + System.Environment.NewLine +
                   "" +
                   "ImagePath = " + ImagePath + Company + System.Environment.NewLine +"" +
                   "Item id  = "+ItemId+" Status = "+Status.ToString();
        }
    }
}
