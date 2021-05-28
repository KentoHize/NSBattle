using System;

namespace NSBattle
{
    public class Block
    {
        public long ID { get; set; }
        public long AreaID { get; set; }
        public byte EastStatus { get; set; }
        public byte SouthStatus { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}