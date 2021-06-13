using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBattle
{
    public class Unit
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long CharacterID { get; set; }
        public int TeamID { get; set; }        
        public int X { get; set; }
        public int Y { get; set; }
        public int Direction { get; set; }
    }
}
