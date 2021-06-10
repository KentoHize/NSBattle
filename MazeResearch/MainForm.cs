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
        Pen redPen = new Pen(Brushes.Red);

        Area area;
        Graphics g, g2, g3;
        int multipier = 8, multipierM = 4;
        //List<ItemPrototype> itemPrototypes;
        //List<Object> objects;        

        SortedDictionary<(int x, int y), Block> blocks = new SortedDictionary<(int, int), Block>();
        SortedDictionary<(int x, int y), Block> visibleBlocksA = new SortedDictionary<(int, int), Block>();
        List<(int x, int y)> crossPoints = new List<(int x, int y)>();

        (int x, int y) target;
        List<((int x, int y), (int x, int y))> lines = new List<((int x, int y), (int x, int y))>();

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

        private void btnCalculateConcealment_Click(object sender, EventArgs e)
        {
            target = (Convert.ToInt32(txtCrossX.Text), Convert.ToInt32(txtCrossY.Text));
            lblConcealmentH.Text = blocks.GetConcealment(area, blocks[(T1.X, T1.Y)], blocks[(Convert.ToInt32(txtCrossX.Text), Convert.ToInt32(txtCrossY.Text))], crossPoints, lines).ToString();
            DrawVisible();
        }

        private void btnAllOpen_Click(object sender, EventArgs e)
        {
            visibleBlocksA.Clear();
            foreach (var b in blocks)
                visibleBlocksA.Add(b.Key, b.Value);
            DrawVisible();
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

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            var route = blocks.GetRoute(area, Convert.ToInt32(txtTargetX.Text), Convert.ToInt32(txtTargetY.Text));
            
        }

        private void btnClearVisibleBlocks_Click(object sender, EventArgs e)
        {
            visibleBlocksA.Clear();
            DrawMap();
        }       
   
        private void GetVisibleBlocks()
        {   
            blocks.CheckVisibleBlock(area, visibleBlocksA, blocks[(T1.X, T1.Y)]);
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

            if(crossPoints.Count != 0)
            {
                foreach ((int x, int y) cp in crossPoints)                    
                    g.FillEllipse(Brushes.Red, cp.x * multipier, cp.y * multipier, multipier, multipier);
            }

            if(target != (0, 0))
            {
                g.FillEllipse(Brushes.Red, target.x * multipier + multipier, target.y * multipier + multipier, 8 * multipier, 8 * multipier);
                if((T1.X - target.x < 0 && T1.Y - target.y < 0) ||
                   (T1.X - target.x > 0 && T1.Y - target.y > 0))
                {
                    g.DrawLine(redPen, (T1.X + 10) * multipier, T1.Y * multipier, (target.x + 10) * multipier, target.y * multipier);
                    g.DrawLine(redPen, T1.X * multipier, (T1.Y + 10) * multipier, target.x * multipier, (target.y + 10) * multipier);
                }
            }
                

            if (lines.Count != 0)
            {
                foreach (((int x, int y) a, (int x, int y) b) l in lines)
                    g.DrawLine(redPen, l.a.x * multipier, l.a.y * multipier, l.b.x * multipier, l.b.y * multipier);
            }
        }    
    }
}
