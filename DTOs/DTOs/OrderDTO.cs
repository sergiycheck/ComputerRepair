using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace DTOs
{
    [DataContract]
    public class OrderDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public decimal Sum { get; set; }


        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember] 
        public DateTime Date { get; set; }

        [DataMember]
        public List<ItemDTO> OrderedComputers { get; set; }
    }
}
