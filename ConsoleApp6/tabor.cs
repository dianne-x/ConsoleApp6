using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class tabor
    {
        public int taborkezdesH { get; set; }
        public int taborkezdesN { get; set; }
        public int taborvegeH { get; set; }
        public int taborvegeN { get; set; }

        public string betujelek { get; set; }
        public string tema { get; set; }

        public tabor(string x)
        {
            var asd = x.Split('\t');
            taborkezdesH = Convert.ToInt32(asd[0]);
            taborkezdesN = Convert.ToInt32(asd[1]);
            taborvegeH = Convert.ToInt32(asd[2]);
            taborvegeN = Convert.ToInt32(asd[3]);
            betujelek = asd[4];
            tema = asd[5];
        }
    }
}
