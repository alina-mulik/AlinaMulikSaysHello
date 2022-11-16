using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes7._3
{
    public interface IPrint
    {
        public int PaperHeight { get; set; }
        public int PaperWidth { get; set; }

        public void Print();
    }
}
