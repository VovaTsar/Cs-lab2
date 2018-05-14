
using System.Windows.Media;

namespace lab2
{
    class ColoredPoint: Point
    {
        private int x;
        private int y;
        private Color color;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Color Color { get => color; set => color = value; }

        public ColoredPoint(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.Color = color;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ColoredPoint)) return false;
            ColoredPoint tmp = (ColoredPoint)obj;
            if (this.X == tmp.X && this.Y == tmp.Y && this.Color == tmp.Color)
                return true;
            else return false;
        }

        public static bool operator==(ColoredPoint p1,ColoredPoint p2)
        {
            if (p1.Equals(p2)) return true;
            else return false;
        }

        public static bool operator !=(ColoredPoint p1, ColoredPoint p2)
        {
            if (p1.Equals(p2)) return false;
            else return true;
        }

        public override int GetHashCode()
        {
            return (this.X+this.Y)%100 +
                (this.Color.A+this.Color.B+this.Color.G+this.Color.R)%90; 
        }

        public override Point DeepCopy()
        {
            return new ColoredPoint(this.X, this.Y, this.Color);
        }

        public override string ToString()
        {
            string tmp = "ColoredPoint : (" + this.X + ";" + this.Y + 
                ") color = " + this.Color.ToString();
            return tmp;
        }
    }
}
