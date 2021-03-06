using System;
using System.Collections.Generic;

namespace NSBattle
{
    //全探索
    //有可知目標→到達目標

    //搜尋到一條最短路徑之後，將其直線移動可入格子都加入清單A中
    //第二條路徑必然有格子不在清單A之內，得清單B
    //第三條路徑必然有格子不在清單A、B，以此類推

    public enum Direction
    {
        None = 0,
        North,
        NorthEast,
        East,
        SouthEast,
        South,        
        SouthWest,
        West,
        NorthWest,
    }

    public static class ExtendMethods
    {
        public static int GetConcealment(this SortedDictionary<(int, int), Block> blocks, Area area, Block blockA, Block blockB, List<(int x, int y)> crossPoints, List<((int x, int y) a, (int x, int y) b)> lines)
        {   
            int lengthX = blockA.X - blockB.X;
            int lengthY = blockA.Y - blockB.Y;
            double lengthZ = Math.Pow((lengthX * lengthX + lengthY * lengthY), 0.5);
            bool isSlash;
            SortedList<int, int> blockLocation = new SortedList<int, int>();

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
            lines.Clear();
            int c1, c2, c3, c4, c5, c6;
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
                    c4 = (int)(100 * (double)(c3 - c2) / (c1 - c2));
                    //c4 = -1 * lengthX * x + 1 * lengthY * y * -1;
                    //c4 * lengthX / lengthY = -1 * lengthX * lengthX /lengthY x + lengthX * y * -1
                    //c4 * lengthX /lengthY - c5 = (-1 * lengthX * lengthX /lengthY - lengthY) * x
                    //x = c4 * lengthX/ lengthY - c5 / (-1 * lengthX * lengthX / lengthY - lengthY); 
                    if ((c3 > c1 && c3 < c2) || (c3 > c2 && c3 < c1))
                    {
                        crossPoints.Add((x, y));
                        if (isSlash)
                        {
                            if (blocks.ContainsKey((x - 10, y - 10)) && blocks[(x - 10, y - 10)].SouthStatus != 0)
                            {   
                                c5 = lengthY * (x - 10) + lengthX * y * -1;
                                c6 = (int)(100 * (double)(c5 - c2) / (c1 - c2));
                                if(!blockLocation.ContainsKey(c6) || blockLocation[c6] < c4)
                                    blockLocation[c6] = c4;
                                //lines.Add((((int)((double)(c5 - c4) / 2 / lengthY), (int)((double)(c5 + c4) * -1 / 2 / lengthX)), (x, y)));
                                lines.Add(((x, y), ((int)(x + (double)10 * lengthY / lengthZ), y - 1)));
                            }
                                
                            if (blocks.ContainsKey((x - 10, y - 10)) && blocks[(x - 10, y - 10)].EastStatus != 0)
                            {   
                                c5 = lengthY * x + lengthX * (y - 10) * -1;
                                c6 = (int)(100 * (double)(c5 - c2) / (c1 - c2));
                                if (!blockLocation.ContainsKey(c4) || blockLocation[c4] < c6)
                                    blockLocation[c4] = c6;
                            }
                            
                            if (blocks.ContainsKey((x, y - 10)) && blocks[(x, y - 10)].SouthStatus != 0)
                            {
                                c5 = lengthY * (x + 10) + lengthX * y * -1;
                                c6 = (int)(100 * (double)(c5 - c2) / (c1 - c2));
                                if (!blockLocation.ContainsKey(c4) || blockLocation[c4] < c6)
                                    blockLocation[c4] = c6;
                            }
                            //    lines.Add(((x, y), (x + 10, y)));
                            if (blocks.ContainsKey((x - 10, y)) && blocks[(x - 10, y)].EastStatus != 0)
                            {
                                c5 = lengthY * x + lengthX * (y + 10) * -1;
                                c6 = (int)(100 * (double)(c5 - c2) / (c1 - c2));
                                if (!blockLocation.ContainsKey(c6) || blockLocation[c6] < c4)
                                    blockLocation[c6] = c4;
                            }
                            //    lines.Add(((x, y), (x, y + 10)));
                            //    (100 * lengthY / lengthZ)
                        }
                        else
                        {

                        }
                    }
                }
            }

            int position = 0;
            int result = 0;
            foreach(KeyValuePair<int, int> kvp in blockLocation)
            {   
                if(kvp.Key < position)
                {
                    result += (kvp.Value > 100 ? 100 : kvp.Value) - position;
                    position = kvp.Value;
                    
                }
                else
                {
                    result += (kvp.Value > 100 ? 100 : kvp.Value) - (kvp.Key < 0 ? 0 : kvp.Key);
                    position = kvp.Value;
                }
                if (position >= 100)
                    break;
            }
            return result;
        }

        //public static List<Block> GoToBlock(this SortedDictionary<(int, int), Block> blocks, Area area, SortedDictionary<(int, int), Block> visibileBlocks, Block self, Block target)
        //{
        //    blocks.CheckVisibleBlock(area, visibileBlocks, self);
        //    if (visibileBlocks.ContainsValue(target))
        //    {

        //    } 
        //    else
        //    {
                
        //    }
        //}

        //public static void Explore(SortedDictionary<(int, int), Block> blocks, Area area, SortedDictionary<(int, int), Block> visibileBlocks, Block self, Block target)
        //{

        //}

        public static List<(int, int)> GetRoute(this SortedDictionary<(int, int), Block> blocks, Area area, int X, int Y)
        {
            //preferDirection
            

            return null;
        }

        public static Direction GetTargetDirection(Block source, Block target)
        {
            if (target.X == source.X)
            {
                if (target.Y > source.Y)
                    return Direction.South;
                else if (target.Y < source.Y)
                    return Direction.North;
                else
                    return Direction.None;
            }
            else if(target.Y == source.Y)
            {
                if (target.X > source.X)
                    return Direction.East;
                else
                    return Direction.West;
            }
            else if(target.X > source.X)
            {
                if (target.Y > source.Y)
                    return Direction.SouthEast;
                else
                    return Direction.NorthEast;
            }
            else
            {
                if (target.Y > source.Y)
                    return Direction.SouthWest;
                else
                    return Direction.NorthWest;
            }
        }

        public static bool BlockNeedExplore(this SortedDictionary<(int, int), Block> blocks, Area area, SortedDictionary<(int, int), Block> visibleBlocks, Block checkBlock)
        {
            Block target;
            if ((blocks.MayGoBlock(area, checkBlock, Direction.North, out target) && !visibleBlocks.ContainsValue(target)) ||
                (blocks.MayGoBlock(area, checkBlock, Direction.West, out target) && !visibleBlocks.ContainsValue(target)) ||
                (blocks.MayGoBlock(area, checkBlock, Direction.South, out target) && !visibleBlocks.ContainsValue(target)) ||
                (blocks.MayGoBlock(area, checkBlock, Direction.East, out target) && !visibleBlocks.ContainsValue(target)))
                return true;
            return false;
        }        

        private static Direction SubDirection(Direction direction, bool getFirst = true)
        {
            switch (direction)
            {
                case Direction.North:
                    if (getFirst)
                        return Direction.West;
                    else
                        return Direction.East;
                case Direction.South:
                    if (getFirst)
                        return Direction.East;
                    else
                        return Direction.West;
                case Direction.East:
                    if (getFirst)
                        return Direction.North;
                    else
                        return Direction.South;
                case Direction.West:
                    if (getFirst)
                        return Direction.South;
                    else
                        return Direction.North;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
        }

        public static void CheckVisibleBlock(this SortedDictionary<(int, int), Block> blocks, Area area, SortedDictionary<(int, int), Block> visibleBlocks, Block checkBlock, Direction mainDirection = Direction.None, Direction subDirection = Direction.None, int preMainTimes = 0, int repeatMainTimes = 0, int repeatMainTimesAtLast = 0)
        {
            Block target;
            if (!visibleBlocks.ContainsKey((checkBlock.X, checkBlock.Y)))
                visibleBlocks.Add((checkBlock.X, checkBlock.Y), checkBlock);

            switch (mainDirection)
            {
                case Direction.None:
                    if (blocks.MayGoBlock(area, checkBlock, Direction.North, out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, Direction.North, Direction.None, 1);
                    if (blocks.MayGoBlock(area, checkBlock, Direction.South, out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, Direction.South, Direction.None, 1);
                    if (blocks.MayGoBlock(area, checkBlock, Direction.West, out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, Direction.West, Direction.None, 1);
                    if (blocks.MayGoBlock(area, checkBlock, Direction.East, out target))
                        blocks.CheckVisibleBlock(area, visibleBlocks, target, Direction.East, Direction.None, 1);
                    break;
                default:
                    if (subDirection == Direction.None)
                    {
                        if (blocks.MayGoBlock(area, checkBlock, mainDirection, out target))
                            blocks.CheckVisibleBlock(area, visibleBlocks, target, mainDirection, Direction.None, preMainTimes + 1);
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

        public static bool MayGoBlock(this SortedDictionary<(int, int), Block> blocks, Area area, Block checkBlock, Direction direction, out Block targetBlock)
        {
            targetBlock = null;
            switch (direction)
            {
                case Direction.North:
                    if (checkBlock.Y != 0 && blocks[(checkBlock.X, checkBlock.Y - 10)].SouthStatus == 0)
                    {
                        targetBlock = blocks[(checkBlock.X, checkBlock.Y - 10)];
                        return true;
                    }
                    break;
                case Direction.East:
                    if (checkBlock.X != area.Width && checkBlock.EastStatus == 0)
                    {
                        targetBlock = blocks[(checkBlock.X + 10, checkBlock.Y)];
                        return true;
                    }
                    break;
                case Direction.South:
                    if (checkBlock.Y != area.Length && checkBlock.SouthStatus == 0)
                    {
                        targetBlock = blocks[(checkBlock.X, checkBlock.Y + 10)];
                        return true;
                    }
                    break;
                case Direction.West:
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
