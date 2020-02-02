using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    [DataContract (IsReference =true)]//took a lot of time to handle http error
    public class ItemDTO
    {
        public ItemDTO() 
        { }
        public ItemDTO(List<OrderDTO> orderDTOs) 
        {
            Orders = orderDTOs;
        }
        public ItemDTO(List<OrderDTO> orderDTOs, List<DetailDTO> detailDTOs)
        {
            Orders = orderDTOs;
            Details = detailDTOs;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public List<OrderDTO> Orders { get; set; }
        [DataMember]
        public List<DetailDTO> Details { get; set; }

    }
}
