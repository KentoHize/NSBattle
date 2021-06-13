using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBattle
{
    public class NSBattleSystem
    {
        public string MapName { get; set; }
        public SortedDictionary<(int x, int y), Block> MapBlocks { get; set; }
        public int MapLength { get; set; }
        public int MapWidth { get; set; }
        public List<Team> Teams { get; set; }
        public List<Unit> Units { get; set; }
        

        //TeamRelation



        //public int AreaID { get; set; }
        //public 
    }
}
