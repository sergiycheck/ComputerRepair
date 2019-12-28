using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities.Components;

namespace mvvmApp.Dal.Abstract.Entities
{
    public class Processor:Element
    {
        public string Line { get; set; }//amd ryzen 5

        public string KernelNum { get; set; }//6 cores

    }


}
