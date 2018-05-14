

namespace lab2
{
    class Line: Point
    {
        private int x1,x2;
        private int y1,y2;

        public Line()
        {
            this.x1 = this.x2 = this.y2 = this.y1 = 0;
        }
        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
        
        public int X1 { get => x1; set => x1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int Y2 { get => y2; set => y2 = value; }

        public override bool Equals(object obj)
        {
            if (!(obj is Line)) return false;
            Line tmp = (Line)obj;
            if (this.X1 == tmp.X1 && this.Y1 == tmp.Y1 && this.X2 == tmp.X2 && 
                this.Y2==tmp.Y2)
                return true;
            else return false;
        }

        public static bool operator ==(Line p1, Line p2)
        {
            if (p1.Equals(p2)) return true;
            else return false;
        }

        public static bool operator !=(Line p1, Line p2)
        {
            if (p1.Equals(p2)) return false;
            else return true;
        }

        public override int GetHashCode()
        {
            return (this.X1 + this.Y1 + this.X2 + this.Y2) % 150 + 250 ; 
        }

        public override Point DeepCopy()
        {
            return new Line(this.X1, this.Y1, this.X2, this.Y2);
        }

        public override string ToString()
        {
            string tmp = "Line : A(" + this.X1 + ";" + this.Y1 + "), B(" + 
                this.X2+";"+this.Y2+")";
            return tmp;
        }
    }
}
