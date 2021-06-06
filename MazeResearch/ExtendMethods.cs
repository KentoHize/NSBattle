
using System;
using System.Collections.Generic;

namespace NSBattle
{
    public static class ExtendMethods
    {
        public static bool BlockNeedExplore(this SortedDictionary<(int, int), Block> blocks, Area area, SortedDictionary<(int, int), Block> visibleBlocks, Block checkBlock)
        {
            Block target;
            if ((blocks.MayGoBlock(area, checkBlock, 'n', out target) && !visibleBlocks.ContainsValue(target)) ||
                (blocks.MayGoBlock(area, checkBlock, 'w', out target) && !visibleBlocks.ContainsValue(target)) ||
                (blocks.MayGoBlock(area, checkBlock, 's', out target) && !visibleBlocks.ContainsValue(target)) ||
                (blocks.MayGoBlock(area, checkBlock, 'e', out target) && !visibleBlocks.ContainsValue(target)))
                return true;
            return false;
        }

        public static bool MayGoBlock(this SortedDictionary<(int, int), Block> blocks, Area area, Block checkBlock, char direction, out Block targetBlock)
        {
            targetBlock = null;
            switch (direction)
            {
                case 'n':
                    if (checkBlock.Y != 0 && blocks[(checkBlock.X, checkBlock.Y - 10)].SouthStatus == 0)
                    {
                        targetBlock = blocks[(checkBlock.X, checkBlock.Y - 10)];
                        return true;
                    }
                    break;
                case 'e':
                    if (checkBlock.X != area.Width && checkBlock.EastStatus == 0)
                    {
                        targetBlock = blocks[(checkBlock.X + 10, checkBlock.Y)];
                        return true;
                    }
                    break;
                case 's':
                    if (checkBlock.Y != area.Length && checkBlock.SouthStatus == 0)
                    {
                        targetBlock = blocks[(checkBlock.X, checkBlock.Y + 10)];
                        return true;
                    }
                    break;
                case 'w':
                    if (checkBlock.X != 0 && blocks[(checkBlock.X - 10, checkBlock.Y)].EastStatus == 0)
                    {
                        targetBlock = blocks[(checkBlock.X - 10, checkBlock.Y)];
                        return true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
            return false;
        }
    }
}
