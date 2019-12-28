using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities.Components
{
    public class MotherBoard:Element
    {
        public string Socket { get; set; }//am4

        public string CompatProcessors { get; set; }//processor for am4
    }
}
