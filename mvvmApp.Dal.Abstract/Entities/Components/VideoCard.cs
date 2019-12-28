using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities.Components
{
    public class VideoCard:Element
    {
        public int Memory { get; set; }//8192
        public string MemoryType { get; set; }//gddr6
        public int MemoryBus { get; set; }//256
    }
}
