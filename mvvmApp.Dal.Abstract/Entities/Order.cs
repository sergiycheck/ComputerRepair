using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace mvvmApp.Dal.Abstract
{   
    [Serializable]
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public virtual List<ItemOrder> ItemOrders { get; set; }
        public override string ToString()
        {
            return "Sum = " + Sum + " PhoneNumber = " + PhoneNumber + " Address = " + Address + " Date = " + Date;
        }
    }
}