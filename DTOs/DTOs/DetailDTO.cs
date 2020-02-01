﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    [DataContract]
    public class DetailDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? ItemId { get; set; }
        [DataMember]
        public ItemDTO Item { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string Company { get; set; }
    }
}
