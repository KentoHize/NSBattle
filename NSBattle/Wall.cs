using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBattle
{

    public class Wall
    {
        public int AreaID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char HorizontalOrVertical { get; set; }
        public int MaterialID { get; set; }
    }
}
