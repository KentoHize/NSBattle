using System;

namespace Data
{
    public class Entry
    {
        public long ID { get; set; }
        public long AreaID { get; set; }
        public long OutAreaID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public bool IsEntry { get; set; }
    }
}