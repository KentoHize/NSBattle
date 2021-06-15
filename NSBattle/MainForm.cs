using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Aritiafel.Locations.StorageHouse;

namespace NSBattle
{
    //主指令
    //副指令

    public partial class MainForm : Form
    {
        public string DataPath =  @"C:\Programs\WinForm\NSBattle\NSBattle\Data\";
        Pen defaultPen = new Pen(Brushes.Black);        

        Area area;
        List<ItemPrototype> itemPrototypes;
        List<Object> objects;
        
        List<Character> characters;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            //g = pnlCanvas.CreateGraphics();
            //defaultPen.Width = 2;
            //g.DrawLine(defaultPen, new Point(10, 10), new Point(100, 100));
        }

        private void btnLoadArea1_Click(object sender, EventArgs e)
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

            using (FileStream fs = new FileStream(DataPath + @"TestData1\ItemPrototype.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    itemPrototypes = JsonSerializer.Deserialize<List<ItemPrototype>>(s, jso);
                }
            }

            using (FileStream fs = new FileStream(DataPath + @"TestData1\Object.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    objects = JsonSerializer.Deserialize<List<Object>>(s, jso);
                }
            }          

            using (FileStream fs = new FileStream(DataPath + @"TestData1\Character.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    characters = JsonSerializer.Deserialize<List<Character>>(s, jso);
                }
            }
            DrawMap(pnlMap.CreateGraphics());
        }

        private void DrawMap(Graphics g)
        {
            g.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length, 0));
            g.DrawLine(defaultPen, new Point(area.Length, 0), new Point(area.Length, area.Width));
            g.DrawLine(defaultPen, new Point(0, area.Width), new Point(area.Length, area.Width));
            g.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width));            
        }
    }
}
