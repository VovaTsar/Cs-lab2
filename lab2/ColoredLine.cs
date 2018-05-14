using System.Windows.Media;

namespace lab2
{
    class ColoredLine: Line
    {     
        private Color color;       
        public Color Color { get => color; set => color = value; }

        public ColoredLine(int x1,int y1, int x2, int y2, Color color):base(x1,y1,x2,y2)
        {        
            this.Color = color;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ColoredLine)) return false;
            ColoredLine tmp = (ColoredLine)obj;
            if (this.X1 == tmp.X1 && this.Y1 == tmp.Y1 && this.X2 == tmp.X2 &&
                this.Y2 == tmp.Y2 && this.Color == tmp.Color)
                return true;
            else return false;
        }

        public static bool operator ==(ColoredLine p1, ColoredLine p2)
        {
            if (p1.Equals(p2)) return true;
            else return false;
        }

        public static bool operator !=(ColoredLine p1, ColoredLine p2)
        {
            if (p1.Equals(p2)) return false;
            else return true;
        }

        public override int GetHashCode()
        {
            return (this.X1 + this.Y1 + this.X2 + this.Y2)%90 +
                (this.Color.A + this.Color.B + this.Color.G + this.Color.R)%150+350; 
        }

        public override Point DeepCopy()
        {
            return new ColoredLine(this.X1, this.Y1, this.X2, this.Y2, this.Color);
        }

        public override string ToString()
        {
            string tmp = "ColoredLine : A(" + this.X1 + ";" + this.Y1 + "), B(" +
                this.X2 + ";" + this.Y2 + ") color= " + this.Color.ToString();
            return tmp;
        }
    }
}
