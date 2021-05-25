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
    public partial class MainForm : Form
    {
        public string DataPath =  @"C:\Programs\WinForm\NSBattle\NSBattle\Data\";
        Pen myPen = new Pen(Brushes.Black);
        Graphics g = null;

        Area area;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            JsonSerializerOptions jso = new JsonSerializerOptions();
            //{ WriteIndented = true };
            DefaultJsonConverterFactory djcf = new DefaultJsonConverterFactory();
            jso.Converters.Add(djcf);

            using (FileStream fs = new FileStream(DataPath + @"TestData1\Area.json", FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    List<Area> areas = new List<Area>();
                    string s = sr.ReadToEnd();
                    areas = JsonSerializer.Deserialize<List<Area>>(s, jso);
                    //area = JsonSerializer.Deserialize<List<Area>>(s, jso)[0];
                }
            }
            
            g = pnlCanvas.CreateGraphics();
            myPen.Width = 2;
            g.DrawLine(myPen, new Point(10, 10), new Point(100, 100));
        }
    }
}
