using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaSato
{
    public class NSBattleFrame
    {
        public SortedDictionary<(int x, int y), Block> MapBlocks { get; set; }
        public List<Team> Teams { get; set; }
        public List<Unit> Units { get; set; }

    }
}
