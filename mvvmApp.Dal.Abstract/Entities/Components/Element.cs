using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities.Components
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
