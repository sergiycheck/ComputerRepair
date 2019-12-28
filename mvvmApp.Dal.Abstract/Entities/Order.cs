using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace mvvmApp.Dal.Abstract
{   
    [Table(Name = "Orders")]
    [Serializable]
    [DataContract]
    public class Order
    {
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name ="Id")]
        [DataMember]
        public int Id { get; set; }

        
        [Column(Name ="Sum")]
        [DataMember]
        public decimal Sum { get; set; }

        
        [Column(Name = "PhoneNumber")]
        [DataMember]
        public string PhoneNumber { get; set; }

        
        [Column(Name = "Address")]
        [DataMember]
        public string Address { get; set; }

        
        [Column(Name = "Date")]
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public virtual List<Item> OrderedComputers { get; set; }
        public override string ToString()
        {
            return "Sum = " + Sum + " PhoneNumber = " + PhoneNumber + " Address = " + Address + " Date = " + Date;
        }
    }
}