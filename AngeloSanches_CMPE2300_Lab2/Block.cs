using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace AngeloSanches_CMPE2300_Lab2
{
    enum MarkedFor
    {
        Nothing,
        Remove,
        Slide
    }
    class Block
    {
        static CDrawer _Display = null;
        public static CDrawer Display { get { return _Display; } set { _Display?.Close();  _Display = value; } }
        public static Random Rand { get; private set; }
        Shape Parent;
        int _OffY, _OffX;
        int X { get { return Parent.Location.X + _OffX; } }
        int Y { get { return Parent.Location.Y + _OffY; } }
        Color Colour;
        public MarkedFor Mark
        {
            set
            {
                switch (value)
                {
                    case MarkedFor.Remove:
                        Parent.notifyRemove(this);
                        break;
                    case MarkedFor.Slide:
                        _OffY++;
                        break;
                }
            }
        } 

        static Block()
        {
            Rand = new Random();
        }

        public Block(Shape PArent, int XOFF, int YOFF, Color SetCol)
        {
            _OffY = YOFF;
            _OffX = XOFF;
            Parent = PArent;
            Colour = SetCol;
        }
        
        public void Show()
        {
            Display?.AddRectangle(X, Y, 1, 1, Colour);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Block))
                return false;
            Block _Cto = obj as Block;
            return X == _Cto.X && Y == _Cto.Y;  

        }

        public override int GetHashCode()
        {
            return -1;
        }

        public static void RotateLeft(Block In)
        {
                int Temp = -1 * In._OffX;
                In._OffX = In._OffY;
                In._OffY = Temp;
        }

        public static void RotateRight(Block In)
        {
                int Temp = In._OffY * -1;
                In._OffY = In._OffX;
                In._OffX = Temp;
        }


        public static bool CanShiftLeft(Block In)
        {
            if (In.X - 1 >= 0)
                return true;
            return false;
        }

        public static bool CanShiftRight(Block In)
        {
            if (In.X + 1 < Display.ScaledWidth)
                return true;
            return false;
        }

        public static bool CanFall(Block In)
        {
            if (In.Y + 2 < Display.ScaledHeight)
                return true;
            return false;
        }


        public static bool CanRotateLeft(Block In)
        {
            Block Temp = new Block(In.Parent, In._OffY, In._OffX * -1, Color.Red);
            if (Temp.X >= 0 && Temp.X < Display.ScaledWidth && Temp.Y < Display.ScaledHeight)
                return true;
            return false;
        }

        public static bool CanRotateRight(Block In)
        {
            Block Temp = new Block(In.Parent, In._OffY * -1, In._OffX, Color.Red);
            if (Temp.X >= 0 && Temp.X < Display.ScaledWidth && Temp.Y < Display.ScaledHeight)
                return true;
            return false;
        }

        public bool InRow(int y)
        {
            if (Y == y)
                return true;
            return false;
        }

        public bool GameOver()
        {
            if (Y < 4)
                return true;
            return false;
        }

    }
}
