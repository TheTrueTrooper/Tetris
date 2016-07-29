using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace AngeloSanches_CMPE2300_Lab2
{
    public partial class Form1 : Form
    {
        int GameBlockWidth = 12;
        Stopwatch MyStopWatch = new Stopwatch();
        Queue<Shape> ShapesToGo;
        Shape FallingShape;
        LinkedList<Shape> Floor;
        Dictionary<Shapes, int> Stats = new Dictionary<Shapes, int>();
        List<List<Block>> Rows;

        bool bUp, bDown, bleft, bRight;
        int Lvl, LvlQty, CurrentLeft, Score;
        bool needsNew;

        private void NUD_Scale_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    bleft = false;
                    break;
                case Keys.Right:
                    bRight = false;
                    break;
                case Keys.Up:
                    bUp = false;
                    break;
                case Keys.Down:
                    bDown = false;
                    break;
            }
        }

        private void NUD_Scale_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    bleft = true;
                    break;
                case Keys.Right:
                    bRight = true;
                    break;
                case Keys.Up:
                    bUp = true;
                    break;
                case Keys.Down:
                    bDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    bleft = false;
                    break;
                case Keys.Right:
                    bRight = false;
                    break;
                case Keys.Up:
                    bUp = false;
                    break;
                case Keys.Down:
                    bDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    bleft = true;
                    break;
                case Keys.Right:
                    bRight = true;
                    break;
                case Keys.Up:
                    bUp = true;
                    break;
                case Keys.Down:
                    bDown = true;
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
            MyStopWatch.Start();
            Ticker.Interval = 50;
            Ticker.Enabled = true;
            bUp = false;
            bDown = false;
            bleft = false;
            bRight = false;
            needsNew = false;
        }

        private void Bu_NewGame_Click(object sender, EventArgs e)
        {
            La_Score.Text = "Score : " + 0;
            La_Lvl.Text = "Lvl : 1";
            Block.Display?.Close();
            Block.Display = new GDIDrawer.CDrawer((int)(GameBlockWidth * NUD_Scale.Value), (int)(2 * GameBlockWidth * NUD_Scale.Value), false);
            Block.Display.Scale = (int)NUD_Scale.Value;
            Stats[Shapes.JAngle] = 0;
            Stats[Shapes.LAngle] = 0;
            Stats[Shapes.Line] = 0;
            Stats[Shapes.Square] = 0;
            Stats[Shapes.TBone] = 0;
            Stats[Shapes.SZig] = 0;
            Stats[Shapes.ZZig] = 0;
            listBox1.Items.Clear();
            foreach (KeyValuePair<Shapes, int> P in Stats)
            {
                listBox1.Items.Add(P.ToString());
            }
            needsNew = false;
            Lvl = 1;
            LvlQty = 20;
            Score = 0;
            CurrentLeft = 20;
            Rows = new List<List<Block>>(2 * GameBlockWidth-5);
            for (int i = 0; i < 2 * GameBlockWidth -5 ; i++)
            {
                Rows.Add(new List<Block>(GameBlockWidth));
            }
            Floor = new LinkedList<Shape>();
            ShapesToGo = new Queue<Shape>(20);
            for(int i = 0; i < 20; i ++)
            {
                ShapesToGo.Enqueue(new Shape(new Point(GameBlockWidth/2, 0)));
            }
            FallingShape = null;
            NUD_Scale.Focus();
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            if (Block.Display == null || needsNew)
                return;
            if (MyStopWatch.ElapsedMilliseconds > 200)
            {
                if (ShapesToGo?.Count < 1)
                {
                    Lvl++;
                    La_Lvl.Text = "Lvl : " + Lvl;
                    LvlQty *= 2;
                    CurrentLeft = LvlQty;
                    for (int i = 0; i < LvlQty; i++)
                    {
                        ShapesToGo?.Enqueue(new Shape(new Point(GameBlockWidth / 2, 0)));
                    }
                }
                if (FallingShape == null || !FallingShape.bFalling)
                {
                    if (FallingShape != null && FallingShape.GameOver() && needsNew == false)
                    {
                        needsNew = true;
                        MessageBox.Show("Game over\nShapes to go before lvling: " + CurrentLeft + "\nScore : " + Score);
                        return;
                    }
                    if (FallingShape != null)
                        for (int i = 0; i < Rows.Count; i++)
                        {
                            FallingShape.AddBlocksToRow(Rows[i], 2 * GameBlockWidth - i);
                        }
                    FallingShape = ShapesToGo?.Dequeue();
                    Stats[FallingShape.Type]++;
                    CurrentLeft--;
                    La_ShapesToGo.Text = "Shapes to Go : " + CurrentLeft;
                    La_NextShape.Text = "Next Shape: " + (ShapesToGo.Count > 0 ? ShapesToGo?.Peek().Type.ToString() : "");
                    listBox1.Items.Clear();
                    foreach(KeyValuePair<Shapes, int> P in Stats)
                    {
                        listBox1.Items.Add(P.ToString());
                    }

                    
                }
                FallingShape?.Drop(Floor);
                if (!FallingShape.bFalling)
                    Floor.AddFirst(FallingShape);
                MyStopWatch.Restart();
            }
            Point Temp;
            if (bleft || Block.Display.GetLastMouseLeftClick(out Temp))
                FallingShape?.ShiftLeft(Floor);
            if (bRight || Block.Display.GetLastMouseRightClick(out Temp))
                FallingShape?.ShiftRight(Floor);
            if (bUp)
                FallingShape?.RotateRight(Floor);
            if (bDown)
                FallingShape?.RotateLeft(Floor);

            for (int i = 0; i < Rows.Count; i++)
                    {
                        if (Rows[i].Count >= 12)
                        {
                            Rows[i].ForEach(x => x.Mark = MarkedFor.Remove);
                            Rows.RemoveAt(i);
                            for (int j = i; j < Rows.Count; j++)
                            {
                                Rows[j].ForEach(x => x.Mark = MarkedFor.Slide);
                            }
                        Score += GameBlockWidth;
                        La_Score.Text = "Score : " + Score;
                        }

                    }


            Block.Display.Clear();
            FallingShape?.Show();
            Floor.ToList().ForEach(x => x.Show());
            Block.Display.Render();


             
        }



    }
}
