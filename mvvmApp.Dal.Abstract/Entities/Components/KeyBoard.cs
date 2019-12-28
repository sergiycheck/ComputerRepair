using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities.Components
{
    public class KeyBoard:Element
    {
        public string Type { get; set; }//membran
        public string Connection { get; set; }//wired
    }
}
