using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities.Components
{
    public class Cooler:Element
    {
        public string Target { get; set; }//for processor
        public string Socet { get; set; }//am2,am3,fm1
    }
}
