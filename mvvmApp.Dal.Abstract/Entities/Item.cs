using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using mvvmApp.Dal.Abstract.Entities;

namespace mvvmApp.Dal.Abstract
{
    
    [Serializable]
    
    public class Item:BaseEntity
    {
        public string Title { get; set; }
        
        public string ImagePath { get; set; }
        
        public int Price { get; set; }
       
        public string Company { get; set; }


        public virtual List<Order> Orders { get; set; }

        public virtual List<Detail> Details { get; set; }

        public override  string ToString()
        {
            return "Id = "+Id+" Title = " + Title + " Price = " + Price + " Company = " + Company + System.Environment.NewLine +
                   "" +
                   "ImagePath = " + ImagePath;
        }
    }
}
