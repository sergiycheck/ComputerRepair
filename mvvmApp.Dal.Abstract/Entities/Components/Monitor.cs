using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Entities.Components
{
    public class Monitor : Element
    {
        public int Diagonal { get; set; }//27
        public string Resolution { get; set; }//2560*1440
        public string MatrixType { get; set; }//ips
    }
}
