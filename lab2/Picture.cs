using System.Collections.Generic;

namespace lab2
{
    class Picture
    {
        private List<Point> figures = new List<Point>();

        internal List<Point> Figures { get => figures; set {
                if (value.Count == figures.Count)
                    for (int i = 0; i < value.Count; i++)
                    {
                        if (!figures[i].Equals(value[i]))
                            Changed($"Picture змiнений");
                    }
                else Changed($"Picture змiнений");               
                figures = value;
            } }

        public delegate void PictureStateHandler(string message);        
        public event PictureStateHandler Deleted;      
        public event PictureStateHandler Changed;      
        public event PictureStateHandler Added;

        public Picture(params Point[] figures)
        {
            for(int i=0; i < figures.Length; i++)
            {
                this.Figures.Add(figures[i].DeepCopy());
            }
        }

        public Picture(List<Point> figures)
        {
            for (int i = 0; i < figures.Count; i++)
            {               
                this.Figures.Add(figures[i].DeepCopy());
            }
        }

        public Point get(int index)
        {
            if (index < 0 || index > this.Figures.Count)
                throw new System.IndexOutOfRangeException("Iндекс повинен бути в межах [0;" + Figures.Count + "]");
            return Figures[index].DeepCopy();
        }

        public void deleteItem(int index)
        {
            if (index < 0 || index > Figures.Count)
                throw new System.IndexOutOfRangeException("Iндекс повинен бути в межах  [0;" + Figures.Count+"]");           
            Figures.RemoveAt(index);
            if(Deleted!=null)
                Deleted($"Видалили {Figures[index]}");
            
        }

        public void addFigure(Point point)
        {
            if (Added != null)
                Added($"Додали " + point);
            Figures.Add(point);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Picture)) return false;
            Picture tmp = (Picture)obj;
            if (tmp.Figures.Count == this.Figures.Count)
            {
                for (int i = 0; i < tmp.Figures.Count; i++)
                {
                    if (this.Figures.IndexOf(tmp.Figures[i]) == -1)
                        return false;
                }
                return true;
            }
            return false;
        }

        public static bool operator ==(Picture p1, Picture p2)
        {
            if (p1.Equals(p2)) return true;
            else return false;
        }

        public static bool operator !=(Picture p1, Picture p2)
        {
            if (p1.Equals(p2)) return false;
            else return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for(int i=0; i < Figures.Count; i++)
            {
                hash += Figures[i].GetHashCode();
            }
            hash %= 9500;
            hash += 2500;
            return hash;
        }

        public Picture DeepCopy()
        {
            List<Point> tmp = new List<Point>();            
            for (int i = 0; i < this.Figures.Count; i++)
            {              
                tmp.Add(this.Figures[i].DeepCopy());
            }
            return new Picture(tmp);
        }

        public override string ToString()
        {
            string tmp = "Picture:";
            for (int i = 0; i < Figures.Count; i++)
            {
                tmp += "\n"+Figures[i].ToString();
            }
            return tmp;
        }
    }
}
