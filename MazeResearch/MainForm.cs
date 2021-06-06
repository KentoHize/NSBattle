using Aritiafel.Locations.StorageHouse;
using Aritiafel.Artifacts;
using NSBattle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

//SafeSearch
//DirectSearch

namespace MazeResearch
{
    public partial class MainForm : Form
    {
        public string DataPath = @"C:\Programs\WinForm\NSBattle\MazeResearch\Data\";
        Pen defaultPen = new Pen(Brushes.Black);
        Pen whitePen = new Pen(Brushes.White);

        Area area;
        Graphics g, g2, g3;
        int multipier = 8, multipierM = 4;
        //List<ItemPrototype> itemPrototypes;
        //List<Object> objects;        

        SortedDictionary<(int x, int y), Block> blocks = new SortedDictionary<(int, int), Block>();
        SortedDictionary<(int x, int y), Block> visibleBlocksA = new SortedDictionary<(int, int), Block>();
        List<Entry> entries;
        Character C1, C2;
        Token T1, T2;

        List<DirectionStatus> dStatus = new List<DirectionStatus>();
        public MainForm()
        {
            InitializeComponent();
            picT1.Width = multipier * 9;
            picT1.Height = multipier * 9;
            picT1.Left = multipier;
            picT1.Top = multipier;
            g = pnlCanvas.CreateGraphics();
            g2 = picT1.CreateGraphics();
            g3 = pnlMiniCanvas.CreateGraphics();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            JsonSerializerOptions jso = new JsonSerializerOptions();
            DefaultJsonConverterFactory djcf = new DefaultJsonConverterFactory();
            jso.Converters.Add(djcf);

            using (FileStream fs = new FileStream(DataPath + @"Area.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    area = JsonSerializer.Deserialize<List<Area>>(s, jso)[0];
                }
            }

            using (FileStream fs = new FileStream(DataPath + @"DirectionStatus.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    dStatus = JsonSerializer.Deserialize<List<DirectionStatus>>(s, jso);
                }
            }

            using (FileStream fs = new FileStream(DataPath + @"Entry.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    entries = JsonSerializer.Deserialize<List<Entry>>(s, jso);
                }
            }
            RandomMaze();
            DrawMap();
        }

        private void RandomMaze()
        {
            ChaosBox cb = new ChaosBox();
            blocks.Clear();
            Block block;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    block = new Block();
                    block.AreaID = 1;
                    block.ID = i * 10 + j;
                    block.X = i * 10;
                    block.Y = j * 10;
                    block.EastStatus = cb.DrawOutByte(0, 1);
                    block.SouthStatus = cb.DrawOutByte(0, 1);
                    block.Status = BlockStatus.Empty;
                    if (i == 9)
                        block.EastStatus = 1;
                    if (j == 9)
                        block.SouthStatus = 1;
                    blocks.Add((block.X, block.Y), block);
                }
            }

            using (FileStream fs = new FileStream(DataPath + @"Block.json", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    JsonSerializerOptions jso = new JsonSerializerOptions();
                    DefaultJsonConverterFactory djcf = new DefaultJsonConverterFactory();
                    jso.Converters.Add(djcf);
                    sw.Write(JsonSerializer.Serialize(blocks.Values, jso));
                }
            }
        }


        private void DrawMap()
        {
            g3.Clear(BackColor);
            foreach (Block block in blocks.Values)
                if (block.Status == BlockStatus.Empty)
                    g3.FillRectangle(Brushes.White, block.X * multipierM, block.Y * multipierM, 10 * multipierM, 10 * multipierM);

            foreach (Block block in blocks.Values)
            {
                if (block.EastStatus != 0)
                    g3.DrawLine(defaultPen, new Point((block.X + 10) * multipierM, block.Y * multipierM), new Point((block.X + 10) * multipierM, (block.Y + 10) * multipierM));
                if (block.SouthStatus != 0)
                    g3.DrawLine(defaultPen, new Point((block.X) * multipierM, (block.Y + 10) * multipierM), new Point((block.X + 10) * multipierM, (block.Y + 10) * multipierM));
            }
            g3.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length * multipierM, 0));
            g3.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width * multipierM));

            if(T1 != null)
            {
                
                //picT1.Left = T1.X * multipier + multipier;
                //picT1.Top = T1.Y * multipier + multipier;                
                g3.DrawEllipse(defaultPen, new Rectangle(T1.X * multipierM + multipierM, T1.Y * multipierM + multipierM, 8 * multipierM, 8 * multipierM));
                //g3.DrawLine(defaultPen, new Point(4 * multipier, 4 * multipier),
                //    new Point((int)(Math.Cos(T1.Direction * Math.PI / 180) * 4 * multipier + 4 * multipier), (int)(Math.Sin(T1.Direction * Math.PI / 180) * 4 * multipier + 4 * multipier)));
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            T1.X += 10;
            DrawToken();
            DrawMap();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            T1.Y += 10;
            DrawToken();
            DrawMap();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            T1.X -= 10;
            DrawToken();
            DrawMap();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            T1.Y -= 10;
            DrawToken();
            DrawMap();
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            T1.Direction += 45;
            DrawToken();
            DrawMap();
        }

        private void DrawToken()
        {
            picT1.Left = T1.X * multipier + multipier;
            picT1.Top = T1.Y * multipier + multipier;
            g2.Clear(Color.White);
            g2.DrawEllipse(defaultPen, new Rectangle(0, 0, 8 * multipier, 8 * multipier));
            g2.DrawLine(defaultPen, new Point(4 * multipier, 4 * multipier),
                new Point((int)(Math.Cos(T1.Direction * Math.PI / 180) * 4 * multipier + 4 * multipier), (int)(Math.Sin(T1.Direction * Math.PI / 180) * 4 * multipier + 4 * multipier)));
        }

        private void btnCrossTest_Click(object sender, EventArgs e)
        {
            GetVisibleBlocks();
        }

        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            C1 = new Character();
            C1.ID = 1;
            T1 = new Token();
            T1.CharacterID = 1;
            T1.Name = "Enemy";
            Entry entry = entries.Find(m => m.IsEntry);
            T1.X = 50;
            T1.Y = 50;
            T1.Direction = 0;

            if (g2 == null)
                g2 = pnlCanvas.CreateGraphics();
            DrawToken();
            DrawMap();            
        }

        private char SubDirection(char direction, bool getFirst = true)
        {
            switch(direction)
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

        private void btnClearVisibleBlocks_Click(object sender, EventArgs e)
        {
            visibleBlocksA.Clear();
            DrawMap();
        }

        private void CheckVisibleBlock(Block checkBlock, char mainDirection = ' ', char subDirection = ' ', int preMainTimes = 0, int repeatMainTimes = 0, int repeatMainTimesAtLast = 0)
        {
            Block target;
            if(!visibleBlocksA.ContainsKey((checkBlock.X, checkBlock.Y)))
                visibleBlocksA.Add((checkBlock.X, checkBlock.Y), checkBlock);            
            switch (mainDirection)
            {
                case ' ':
                    if (blocks.MayGoBlock(area, checkBlock, 'n', out target))
                        CheckVisibleBlock(target, 'n', ' ', 1);
                    if (blocks.MayGoBlock(area, checkBlock, 's', out target))
                        CheckVisibleBlock(target, 's', ' ', 1);
                    if (blocks.MayGoBlock(area, checkBlock, 'w', out target))
                        CheckVisibleBlock(target, 'w', ' ', 1);
                    if (blocks.MayGoBlock(area, checkBlock, 'e', out target))
                        CheckVisibleBlock(target, 'e', ' ', 1);
                    break;
                default:
                    if(subDirection == ' ')
                    {
                        if (blocks.MayGoBlock(area, checkBlock, mainDirection, out target))
                            CheckVisibleBlock(target, mainDirection, ' ', preMainTimes + 1);
                        if (blocks.MayGoBlock(area, checkBlock, SubDirection(mainDirection), out target))
                            CheckVisibleBlock(target, mainDirection, SubDirection(mainDirection), preMainTimes);
                        if (blocks.MayGoBlock(area, checkBlock, SubDirection(mainDirection, false), out target))
                            CheckVisibleBlock(target, mainDirection, SubDirection(mainDirection, false), preMainTimes);
                    }
                    else
                    {
                        if(repeatMainTimesAtLast == 0)
                        {
                            if (blocks.MayGoBlock(area, checkBlock, mainDirection, out target))
                                CheckVisibleBlock(target, mainDirection, subDirection, preMainTimes, repeatMainTimes + 1);                            
                            if (repeatMainTimes >= preMainTimes)
                            {   
                                if (blocks.MayGoBlock(area, checkBlock, subDirection, out target))
                                    CheckVisibleBlock(target, mainDirection, subDirection, preMainTimes, 0, repeatMainTimes);
                            }   
                        }
                        else
                        {
                            if (repeatMainTimes < repeatMainTimesAtLast)
                            {
                                if (blocks.MayGoBlock(area, checkBlock, mainDirection, out target))
                                    CheckVisibleBlock(target, mainDirection, subDirection, preMainTimes, repeatMainTimes + 1, repeatMainTimesAtLast);
                            }
                            else
                            {
                                if (blocks.MayGoBlock(area, checkBlock, subDirection, out target))
                                    CheckVisibleBlock(target, mainDirection, subDirection, preMainTimes, repeatMainTimes, repeatMainTimesAtLast);
                            }                           
                        }
                    }
                    break;              
            }
        }

        private void GetVisibleBlocks()
        {   
            CheckVisibleBlock(blocks[(T1.X, T1.Y)]);
            DrawVisible();
        }

        private void DrawVisible()
        {
            g.Clear(BackColor);
            foreach (Block block in visibleBlocksA.Values)
                if (block.Status == BlockStatus.Empty)
                    g.FillRectangle(Brushes.White, block.X * multipier, block.Y * multipier, 10 * multipier, 10 * multipier);

            foreach (Block block in visibleBlocksA.Values)
            {
                if (block.X == 0 || blocks[(block.X - 10, block.Y)].EastStatus != 0)
                    g.DrawLine(defaultPen, new Point(block.X * multipier, block.Y * multipier), new Point(block.X * multipier, (block.Y + 10) * multipier));
                if (block.Y == 0 || blocks[(block.X, block.Y - 10)].SouthStatus != 0)
                    g.DrawLine(defaultPen, new Point(block.X * multipier, block.Y * multipier), new Point((block.X + 10) * multipier, block.Y * multipier));
                if (block.EastStatus != 0)
                    g.DrawLine(defaultPen, new Point((block.X + 10) * multipier, block.Y * multipier), new Point((block.X + 10) * multipier, (block.Y + 10) * multipier));
                if (block.SouthStatus != 0)
                    g.DrawLine(defaultPen, new Point((block.X) * multipier, (block.Y + 10) * multipier), new Point((block.X + 10) * multipier, (block.Y + 10) * multipier));
                
            }
            g.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length * multipier, 0));
            g.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width * multipier));
        }

        private void getVisibleBlocks()
        {

        }

        private int getConsealmentAndVisibleBlocks()
        {
            return 21;
        }
    }
}
