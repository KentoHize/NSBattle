using System;

namespace NSBattle
{
    public class Token
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long CharacterID { get; set; }
        public long AreaID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Direction { get; set; }
    }
}