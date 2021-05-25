using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSBattle
{
    public partial class MainForm : Form
    {
        public string DataPath =  @"C:\Programs\WinForm\NSBattle\NSBattle\Data\";
        Pen myPen = new Pen(Brushes.Black);
        Graphics g = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            g = pnlCanvas.CreateGraphics();
            myPen.Width = 2;
            g.DrawLine(myPen, new Point(10, 10), new Point(100, 100));
        }
    }
}
