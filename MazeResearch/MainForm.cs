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

namespace MazeResearch
{
    public partial class MainForm : Form
    {
        public string DataPath = @"C:\Programs\WinForm\NSBattle\MazeResearch\Data\";
        Pen defaultPen = new Pen(Brushes.Black);
        
        Area area;
        Graphics g;
        int multipier = 8;
        //List<ItemPrototype> itemPrototypes;
        //List<Object> objects;        

        List<Block> blocks = new List<Block>();
        List<DirectionStatus> dStatus = new List<DirectionStatus>();
        
        //List<Character> characters;
        public MainForm()
        {
            InitializeComponent();
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

            //using (FileStream fs = new FileStream(DataPath + @"TestData1\Wall.json", FileMode.Open))
            //{
            //    using (StreamReader sr = new StreamReader(fs))
            //    {
            //        string s = sr.ReadToEnd();
            //        walls = JsonSerializer.Deserialize<List<Wall>>(s, jso);
            //    }
            //}
            RandomMaze();
            if(g == null)
                g = pnlCanvas.CreateGraphics();
            DrawMap();
        }

   

        private void RandomMaze()
        {
            ChaosBox cb = new ChaosBox();
            blocks.Clear();
            Block block;
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    block = new Block();
                    block.AreaID = 1;
                    block.ID = i * 10 + j;
                    block.X = i * 10;
                    block.Y = j * 10;
                    block.EastStatus = cb.DrawOutByte(0, 1);
                    block.SouthStatus = cb.DrawOutByte(0, 1);

                    if (i == 9)
                        block.EastStatus = 1;                    
                    if (j == 9)
                        block.SouthStatus = 1;
                    blocks.Add(block);
                }
            }

            using (FileStream fs = new FileStream(DataPath + @"Block.json", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    JsonSerializerOptions jso = new JsonSerializerOptions();
                    DefaultJsonConverterFactory djcf = new DefaultJsonConverterFactory();
                    jso.Converters.Add(djcf);
                    sw.Write(JsonSerializer.Serialize(blocks, jso));
                }
            }
        }


        private void DrawMap()
        {
            g.Clear(BackColor);
            //pnlCanvas.Refresh();
            g.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length * multipier, 0));
            //g.DrawLine(defaultPen, new Point(area.Length * multipier, 0), new Point(area.Length * multipier, area.Width * multipier));
            //g.DrawLine(defaultPen, new Point(0, area.Width * multipier), new Point(area.Length * multipier, area.Width * multipier));
            g.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width * multipier));
            //g.DrawLine(defaultPen) area.Length
            for(int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].EastStatus != 0)
                    g.DrawLine(defaultPen, new Point((blocks[i].X + 10) * multipier, blocks[i].Y * multipier), new Point((blocks[i].X + 10) * multipier, (blocks[i].Y + 10) * multipier));
                if(blocks[i].SouthStatus != 0)
                    g.DrawLine(defaultPen, new Point((blocks[i].X) * multipier, (blocks[i].Y + 10) * multipier), new Point((blocks[i].X + 10) * multipier, (blocks[i].Y + 10) * multipier));
            }
            //defaultPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        private void btnStartSearch_Click(object sender, EventArgs e)
        {

        }

        //private void DrawMiniMap
    }
}
