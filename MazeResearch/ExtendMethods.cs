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
        public static int GetConcealment(this SortedDictionary<(int, int), Block> blocks, Area area, Block blockA, Block blockB, List<(int x, int y)> crossPoints, List<((int x, int y) a, (int x, int y) b)> lines)
        {   
            int lengthX = blockA.X - blockB.X;
            int lengthY = blockA.Y - blockB.Y;
            double lengthZ = Math.Pow((lengthX * lengthX + lengthY * lengthY), 0.5);
            bool isSlash;

            //lenngthY * x + lengthX * y 
            //eq = x + (lengthX / lengthY) y = A
            //eq = x + (lengthX / lengthY) y = B
            int smallX, bigX;
            int smallY, bigY;
            if (blockA.X > blockB.X)
            {
                smallX = blockB.X;
                bigX = blockA.X + 10;
            }
            else
            {
                smallX = blockA.X;
                bigX = blockB.X + 10;
            }

            if (blockA.Y > blockB.Y)
            {
                smallY = blockB.Y;
                bigY = blockA.Y + 10;
            }
            else
            {
                smallY = blockA.Y;
                bigY = blockB.Y + 10;
            }


            crossPoints.Clear();
            int c1, c2, c3;
            if((lengthX < 0 && lengthY >= 0) || (lengthX >= 0 && lengthY < 0))
            {                
                c1 = lengthY * blockA.X + lengthX * blockA.Y * -1;
                c2 = lengthY * (blockA.X + 10) + lengthX * (blockA.Y * -1 - 10);
                isSlash = false;
            }
            else
            {
                c1 = lengthY * (blockA.X + 10) + lengthX * blockA.Y * -1;
                c2 = lengthY * blockA.X + lengthX * (blockA.Y * -1 - 10);
                isSlash = true;
            }

            
            
            for(int x = smallX; x <= bigX; x += 10)
            {
                for (int y = smallY; y <= bigY; y += 10)
                {
                    if(isSlash)
                    {
                        if ((x == smallX && y == smallY) ||
                            (x == bigX && y == bigY))
                            continue;
                    }
                    else
                    {
                        if ((x == smallX && y == bigY) ||
                            (x == bigX && y == smallY))
                            continue;
                    }

                    c3 = lengthY * x + lengthX * y * -1;
                    if ((c3 > c1 && c3 < c2) || (c3 > c2 && c3 < c1))
                        crossPoints.Add((x, y));

                    if(isSlash)
                    {   
                        if (blocks.ContainsKey((x, y)) && blocks[(x,y)].SouthStatus != 0)
                            lines.Add(((x, y), (x + 3, y - 3)));
                        //    (100 * lengthY / lengthZ)
                    }
                    else
                    {

                    }
                }
            }

            //for(int i = 0; i < crossPoints.Count; i++)
            //{
            //    //if(blocks.ContainsKey(crossPoints[i]) && blocks[crossPoints[i]].SouthStatus != 0)                    

            //         //100 *(lengthY * crossPoints[i].x + lengthX * crossPoints[i].y * - 1) / (c2 - c1);
            //}


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
