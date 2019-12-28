using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities.Components
{
    public class MemoryDisc:Element
    {
        public string MemoryType { get; set; }//hdd sdd
        public int Volume { get; set; }//256gb
    }
}
