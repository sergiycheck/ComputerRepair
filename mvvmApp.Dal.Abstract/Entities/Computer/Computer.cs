using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities.Components;

namespace mvvmApp.Dal.Abstract.Entities.Computer
{
    public class Computer:Element
    {
        public Cooler Cooler { get; set; }

        public KeyBoard KeyBoard { get; set; }

        public MemoryDisc MemoryDisc { get; set; }

        public MemoryModule MemoryModule { get; set; }

        public Monitor Monitor { get; set; }

        public MotherBoard MotherBoard { get; set; }

        public PowerBlock PowerBlock { get; set; }

        public Processor Processor { get; set; }

        public VideoCard VideoCard { get; set; }
    }
}
