using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace mvvmApp.Dal.Abstract
{
    
    [Serializable]
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public virtual Order Order{ get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string Company { get; set; }
        
        public override  string ToString()
        {
            return "Id = "+Id+" Title = " + Title + " Price = " + Price + " Company = " + Company + System.Environment.NewLine +
                   "" +
                   "ImagePath = " + ImagePath;
        }
    }
}
