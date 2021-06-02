﻿using Aritiafel.Locations.StorageHouse;
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
            g3 = pnlPersonal.CreateGraphics();
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


            //using (FileStream fs = new FileStream(DataPath + @"TestData1\Wall.json", FileMode.Open))
            //{
            //    using (StreamReader sr = new StreamReader(fs))
            //    {
            //        string s = sr.ReadToEnd();
            //        walls = JsonSerializer.Deserialize<List<Wall>>(s, jso);
            //    }
            //}
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
            g.Clear(BackColor);
            foreach(Block block in blocks.Values)
                if (block.Status == BlockStatus.Empty)
                    g.FillRectangle(Brushes.White, block.X * multipier, block.Y * multipier, 10 * multipier, 10 * multipier);

            foreach (Block block in blocks.Values)
            {               
                if (block.EastStatus != 0)
                    g.DrawLine(defaultPen, new Point((block.X + 10) * multipier, block.Y * multipier), new Point((block.X + 10) * multipier, (block.Y + 10) * multipier));
                if (block.SouthStatus != 0)
                    g.DrawLine(defaultPen, new Point((block.X) * multipier, (block.Y + 10) * multipier), new Point((block.X + 10) * multipier, (block.Y + 10) * multipier));
            }
            g.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length * multipier, 0));
            g.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width * multipier));
            //defaultPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {   
            T1.X += 10;
            DrawToken();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {   
            T1.Y += 10;
            DrawToken();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {   
            T1.X -= 10;
            DrawToken();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {   
            T1.Y -= 10;
            DrawToken();
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            T1.Direction += 45;
            DrawToken();
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
            GetCrossingBlocks(Convert.ToInt32(txtCrossX.Text) * 10, Convert.ToInt32(txtCrossY.Text) * 10);
            //DrawItemEventArgs 
        }

        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            C1 = new Character();
            C1.ID = 1;
            T1 = new Token();
            T1.CharacterID = 1;
            T1.Name = "Enemy";
            Entry entry = entries.Find(m => m.IsEntry);
            T1.X = entry.X;
            T1.Y = entry.Y;
            T1.Direction = 0;

            if (g2 == null)
                g2 = pnlCanvas.CreateGraphics();
            DrawToken();
            
            //getVisibleBlocks();
        }

        private void GetCrossingBlocks(int x, int y)
        {
            visibleBlocksA.Clear();
            double w = x - T1.X + 5;
            double h = y - T1.Y + 5;
            lblh.Text = w.ToString();
            lblw.Text = h.ToString();
            //h = 0
            //斜率即w/h
            foreach (Block b in blocks.Values)
            {
                if (x >= T1.X && (b.X > x || b.X < T1.X))
                    continue;
                if (x < T1.X && (b.X >= T1.X || b.X <= x))
                    continue;
                if (y >= T1.Y && (b.Y > y || b.Y < T1.Y))
                    continue;
                if (y < T1.Y && (b.Y >= T1.Y || b.Y <= y))
                    continue;

                //visibleBlocksA.Add((b.X, b.Y), b);                
                //continue;

                if (h == 0)
                {
                    if (b.Y - T1.Y != 0)
                        continue;
                    else
                        visibleBlocksA.Add((b.X, b.Y), b);
                }                
                else
                {
                    //最外點和最內點與斜率w/h沒有相交則忽略
                    if (b.Y + 10 - T1.Y + 5 == 0)
                        continue;

                    if (b.Y - T1.Y + 5 == 0 || b.Y + 10 - T1.Y + 5 == 0)
                    {
                        if ((double)(b.X - T1.X - 5) / (b.Y + 10 - T1.Y - 5) <= w / h)
                            visibleBlocksA.Add((b.X, b.Y), b);
                    }
                    else
                    {
                        if ((double)(b.X + 10 - T1.X - 5) / (b.Y - T1.Y - 5) >= w / h && (double)(b.X - T1.X - 5) / (b.Y + 10 - T1.Y - 5) <= w / h)
                            visibleBlocksA.Add((b.X, b.Y), b);
                        //else if ((double)(b.X + 10 - T1.X - 5) / (b.Y - T1.Y - 5) < w / h && (double)(b.X - T1.X - 5) / (b.Y + 10 - T1.Y - 5) > w / h)
                        //    visibleBlocksA.Add((b.X, b.Y), b);
                    }
                    //else if ((double)(b.X - T1.X + 5) / (b.Y + 10 - T1.Y + 5) < w / h && (double)(b.X + 10 - T1.X + 5) / (b.Y - T1.Y + 5) > w / h)
                    //    visibleBlocksA.Add((b.X, b.Y), b);
                }
            }
            DrawVisible();
        }

        private void DrawVisible()
        {
            g3.Clear(BackColor);
            foreach (Block block in visibleBlocksA.Values)
                if (block.Status == BlockStatus.Empty)
                    g3.FillRectangle(Brushes.White, block.X * multipierM, block.Y * multipierM, 10 * multipierM, 10 * multipierM);

            foreach (Block block in visibleBlocksA.Values)
            {
                if (block.EastStatus != 0)
                    g3.DrawLine(defaultPen, new Point((block.X + 10) * multipierM, block.Y * multipierM), new Point((block.X + 10) * multipierM, (block.Y + 10) * multipierM));
                if (block.SouthStatus != 0)
                    g3.DrawLine(defaultPen, new Point((block.X) * multipierM, (block.Y + 10) * multipierM), new Point((block.X + 10) * multipierM, (block.Y + 10) * multipierM));
            }
            g3.DrawLine(defaultPen, new Point(0, 0), new Point(area.Length * multipierM, 0));
            g3.DrawLine(defaultPen, new Point(0, 0), new Point(0, area.Width * multipierM));
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
