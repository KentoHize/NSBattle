using Aritiafel.Locations.StorageHouse;
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
        public string DataPath = @"C:\Programs\WinForm\NSBattle\NSBattle\Data\";
        Pen defaultPen = new Pen(Brushes.Black);

        Area area;
        int multipier = 8;
        //List<ItemPrototype> itemPrototypes;
        //List<Object> objects;
        List<Wall> walls = new List<Wall>();
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

            using (FileStream fs = new FileStream(DataPath + @"TestData1\Area.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    area = JsonSerializer.Deserialize<List<Area>>(s, jso)[0];
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
            MazeBlocks();
            DrawMap(pnlCanvas.CreateGraphics());
        }

        private void MazeBlocks()
        {
            Wall wall;

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if(j != 0)
                    {
                        wall = new Wall();
                        wall.X = i * 10;
                        wall.Y = j * 10;
                        wall.HorizontalOrVertical = 'h';
                        wall.MaterialID = 0;
                        wall.AreaID = 1;
                        walls.Add(wall);
                    }

                    if(i != 0)
                    {
                        wall = new Wall();
                        wall.X = i * 10;
                        wall.Y = j * 10;
                        wall.HorizontalOrVertical = 'v';
                        wall.MaterialID = 0;
                        wall.AreaID = 1;
                        walls.Add(wall);
                    }
                }
            }
        }

        private void RandomMaze()
        {

        }


        private void DrawMap(Graphics g)
        {
            g.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length * multipier, 0));
            g.DrawLine(defaultPen, new Point(area.Length * multipier, 0), new Point(area.Length * multipier, area.Width * multipier));
            g.DrawLine(defaultPen, new Point(0, area.Width * multipier), new Point(area.Length * multipier, area.Width * multipier));
            g.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width * multipier));
            //g.DrawLine(defaultPen) area.Length
            for(int i = 0; i < walls.Count; i++)
            {
                if (walls[i].HorizontalOrVertical == 'h')
                    g.DrawLine(defaultPen, new Point(walls[i].X * multipier, walls[i].Y * multipier), new Point((walls[i].X + 10) * multipier, walls[i].Y * multipier));
                else
                    g.DrawLine(defaultPen, new Point(walls[i].X * multipier, walls[i].Y * multipier), new Point(walls[i].X * multipier, (walls[i].Y + 10) * multipier));
            }
        }
    }
}
