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
        //List<ItemPrototype> itemPrototypes;
        //List<Object> objects;
        //List<Wall> walls;
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
            DrawMap(pnlCanvas.CreateGraphics());
        }

        private void DrawMap(Graphics g)
        {
            g.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length, 0));
            g.DrawLine(defaultPen, new Point(area.Length, 0), new Point(area.Length, area.Width));
            g.DrawLine(defaultPen, new Point(0, area.Width), new Point(area.Length, area.Width));
            g.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width));
            //g.DrawLine(defaultPen) area.Length
        }
    }
}
