using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBattle
{
    public class Area
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int InX { get; set; }
        public int InY { get; set; }
        public int OutX { get; set; }
        public int OutY { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        public Area() { }
    }
}
