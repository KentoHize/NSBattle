using System;
using System.Collections.Generic;

namespace NSBattle
{
    //全探索
    //有可知目標→到達目標

    //搜尋到一條最短路徑之後，將其直線移動可入格子都加入清單A中
    //第二條路徑必然有格子不在清單A之內，得清單B
    //第三條路徑必然有格子不在清單A、B，以此類推

    public static class ExtendMethods
    {        
        public static int GetConcealment(this SortedDictionary<(int, int), Block> blocks, Area area, Block blockA, Block blockB, List<(int, int)> crossPoints)
        {
            //blocks
            int lengthX = blockA.X - blockB.X;
            int lengthY = blockA.Y - blockB.Y;
            double lengthZ = Math.Pow((lengthX * lengthX + lengthY * lengthY), 0.5);
            

            //lenngthY * x + lengthX * y 
            //eq = x + (lengthX / lengthY) y = A
            //eq = x + (lengthX / lengthY) y = B
            crossPoints.Clear();
            int c1, c2, c3;
            if((lengthX < 0 && lengthY >= 0) || (lengthX >= 0 && lengthY < 0))
            {
                c1 = lengthY * (blockA.X + 10) + lengthX * blockB.Y;
                c2 = lengthY * blockA.X + lengthX * (blockB.Y + 10);

                
            }
            else
            {
                c1 = lengthY * blockA.X + lengthX * blockB.Y;
                c2 = lengthY * (blockA.X + 10) + lengthX * (blockB.Y + 10);

                foreach(Block b in blocks.Values)
                {
                    c3 = b.X * lengthY + b.Y * lengthX;
                    if (c3 > c1 && c3 < c2)
                        crossPoints.Add((b.X, b.Y));
                }   
            }
            return (int)(100 * (double)lengthY / lengthZ);
        }

        public static List<(int, int)> GetRoute(this SortedDictionary<(int, int), Block> blocks, Area area, int X, int Y)
        {
            return null;
        }

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

        private static char SubDirection(char direction, bool getFirst = true)
        {
            switch (direction)
            {
                case 'n':
                    if (getFirst)
                        return 'w';
                    else
                        return 'e';
                case 's':
                    if (getFirst)
                        return 'e';
                    else
                        return 'w';
                case 'e':
                    if (getFirst)
                        return 'n';
                    else
                        return 's';
                case 'w':
                    if (getFirst)
                        return 's';
                    else
                        return 'n';
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
        }

        public static void CheckVisibleBlock(this SortedDictionary<(int, int), Block> blocks, Area area, SortedDictionary<(int, int), Block> visibleBlocks, Block checkBlock, char mainDirection = ' ', char subDirection = ' ', int preMainTimes = 0, int repeatMainTimes = 0, int repeatMainTimesAtLast = 0)
        {
            Block target;
            if (!visibleBlocks.ContainsKey((checkBlock.X, checkBlock.Y)))
                visibleBlocks.Add((checkBlock.X, checkBlock.Y), checkBlock);

            switch (mainDirection)
            {
                case ' ':
                    if (blocks.MayGoBlock(area, checkBlock, 'n', out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, 'n', ' ', 1);
                    if (blocks.MayGoBlock(area, checkBlock, 's', out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, 's', ' ', 1);
                    if (blocks.MayGoBlock(area, checkBlock, 'w', out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, 'w', ' ', 1);
                    if (blocks.MayGoBlock(area, checkBlock, 'e', out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, 'e', ' ', 1);
                    break;
                default:
                    if (subDirection == ' ')
                    {
                        if (blocks.MayGoBlock(area, checkBlock, mainDirection, out target))
                            blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, ' ', preMainTimes + 1);
                        if (blocks.MayGoBlock(area, checkBlock, SubDirection(mainDirection), out target))
                            blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, SubDirection(mainDirection), preMainTimes);
                        if (blocks.MayGoBlock(area, checkBlock, SubDirection(mainDirection, false), out target))
                            blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, SubDirection(mainDirection, false), preMainTimes);
                    }
                    else
                    {
                        if (repeatMainTimesAtLast == 0)
                        {
                            if (blocks.MayGoBlock(area, checkBlock, mainDirection, out target))
                                blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, subDirection, preMainTimes, repeatMainTimes + 1);
                            if (repeatMainTimes >= preMainTimes)
                            {
                                if (blocks.MayGoBlock(area, checkBlock, subDirection, out target))
                                    blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, subDirection, preMainTimes, 0, repeatMainTimes);
                            }
                        }
                        else
                        {
                            if (repeatMainTimes < repeatMainTimesAtLast)
                            {
                                if (blocks.MayGoBlock(area, checkBlock, mainDirection, out target))
                                    blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, subDirection, preMainTimes, repeatMainTimes + 1, repeatMainTimesAtLast);
                            }
                            else
                            {
                                if (blocks.MayGoBlock(area, checkBlock, subDirection, out target))
                                    blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, subDirection, preMainTimes, repeatMainTimes, repeatMainTimesAtLast);
                            }
                        }
                    }
                    break;
            }
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
