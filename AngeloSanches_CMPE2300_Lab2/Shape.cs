using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace AngeloSanches_CMPE2300_Lab2
{
    enum Shapes
    {
        Square,
        Line,
        LAngle,
        JAngle,
        SZig,
        ZZig,
        TBone
    }

    class Shape
    {
        public Shapes Type { get; private set; }
        public bool bFalling { get; set; }
        public Point Location { get; private set; }
        List<Block> Blocks = new List<Block>();

        public Shape(Point SetLoc)
        {
            Location = SetLoc;
            bFalling = true;
            Color TempColour = RandColor.GetColor();
            Type = (Shapes)Block.Rand.Next(0, 7);
            switch(Type)
            {
                case Shapes.JAngle:
                    Blocks.Add(new Block(this, 0, -1, TempColour));
                    Blocks.Add(new Block(this, 0, 0, TempColour));
                    Blocks.Add(new Block(this, 0, 1, TempColour));
                    Blocks.Add(new Block(this, -1, 1, TempColour));
                    break;
                case Shapes.LAngle:
                    Blocks.Add(new Block(this, 0, -1, TempColour));
                    Blocks.Add(new Block(this, 0, 0, TempColour));
                    Blocks.Add(new Block(this, 0, 1, TempColour));
                    Blocks.Add(new Block(this, 1, 1, TempColour));
                    break;
                case Shapes.Line:
                    Blocks.Add(new Block(this, 0, -1, TempColour));
                    Blocks.Add(new Block(this, 0, 0, TempColour));
                    Blocks.Add(new Block(this, 0, 1, TempColour));
                    Blocks.Add(new Block(this, 0, 2, TempColour));
                    break;
                case Shapes.Square:
                    Blocks.Add(new Block(this, 0, 0, TempColour));
                    Blocks.Add(new Block(this, 0, -1, TempColour));
                    Blocks.Add(new Block(this, -1, -1, TempColour));
                    Blocks.Add(new Block(this, -1, 0, TempColour));
                    break;
                case Shapes.SZig:
                    Blocks.Add(new Block(this, -1, -1, TempColour));
                    Blocks.Add(new Block(this, 0, 0, TempColour));
                    Blocks.Add(new Block(this, 0, -1, TempColour));
                    Blocks.Add(new Block(this, 1, 0, TempColour));
                    break;
                case Shapes.ZZig:
                    Blocks.Add(new Block(this, -1, 0, TempColour));
                    Blocks.Add(new Block(this, 0, 0, TempColour));
                    Blocks.Add(new Block(this, 0, -1, TempColour));
                    Blocks.Add(new Block(this, 1, -1, TempColour));
                    break;
                case Shapes.TBone:
                    Blocks.Add(new Block(this, -1, 0, TempColour));
                    Blocks.Add(new Block(this, 0, 0, TempColour));
                    Blocks.Add(new Block(this, 0, -1, TempColour));
                    Blocks.Add(new Block(this, 1, 0, TempColour));
                    break;
                
            }
        }

        static public bool Falling(Shape In)
        {
            return In.bFalling;
        }

        static public bool NotFalling(Shape In)
        {
            return !In.bFalling;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Shape))
                return false;

            Shape Temp = obj as Shape;
            return Temp.Blocks.Exists(x =>Blocks.Exists(y=>y.Equals(x)));
        }

        public override int GetHashCode()
        {
            return -1;
        }

        public void Show()
        {
            Blocks.ForEach(x => x.Show());
        }

        public void Drop(LinkedList<Shape> Floor)
        {
            if (!bFalling)
                return;
            if (!Blocks.TrueForAll(Block.CanFall))
                bFalling = false;
            Point Temp = Location;
            Location = new Point(Location.X, Location.Y + 1);
            if (Floor.ToList().Exists(x => x.Equals(this)))
            {
                Location = Temp;
                bFalling = false;
            }

        }

        public void ShiftLeft(LinkedList<Shape> Floor)
        {
            Point Temp = Location;
            if (Blocks.TrueForAll(Block.CanShiftLeft))
                Location = new Point(Location.X - 1, Location.Y);
            if (Floor.ToList().Exists(x=>x.Equals(this)))
                Location = Temp;
        }

        public void ShiftRight(LinkedList<Shape> Floor)
        {
            Point Temp = Location;
            if (Blocks.TrueForAll(Block.CanShiftRight))
                Location = new Point(Location.X + 1, Location.Y);
            if (Floor.ToList().Exists(x => x.Equals(this)))
                Location = Temp;
        }

        public void RotateLeft(LinkedList<Shape> Floor)
        {
            if (Blocks.TrueForAll(Block.CanRotateLeft))
                Blocks.ForEach(Block.RotateLeft);
            if (Floor.ToList().Exists(x => x.Equals(this)))
                Blocks.ForEach(Block.RotateRight);
        }

        public void RotateRight(LinkedList<Shape> Floor)
        {
            if(Blocks.TrueForAll(Block.CanRotateRight))
                Blocks.ForEach(Block.RotateRight);
            if (Floor.ToList().Exists(x => x.Equals(this)))
                Blocks.ForEach(Block.RotateLeft);
        }

        public void notifyRemove(Block Rev)
        {
            Blocks.RemoveAll(x => ReferenceEquals(Rev, x));
        }

        public bool GameOver()
        {
            return Blocks.Exists(x => x.GameOver());
        }

        public void AddBlocksToRow(List<Block> Row, int RowNum)
        {
            Blocks.Where(x => x.InRow(RowNum)).ToList().ForEach(x => Row.Add(x));
        }
    }
}
