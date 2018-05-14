using System;
using System.Collections.Generic;

namespace lab2
{
    class PolyLine : Line
    {
        private List<Line> lines = new List<Line>();
        
        internal List<Line> Lines { get {return lines; } set
            {
                if(value.Count == lines.Count)
                    for(int i=0; i < value.Count; i++)
                    {
                        if(!lines[i].Equals(value[i]))                            
                            Changed($"Polyline змiнений");                        
                    }
                else Changed($"Polyline змiнений");
                lines = value;       
            }
        }

        public delegate void PolyLineStateHandler(string message);
        public event PolyLineStateHandler Deleted;
        public event PolyLineStateHandler Changed;
        public event PolyLineStateHandler Added;

        public PolyLine(params Line[] lines)
        {
            for(int i=0; i < lines.Length; i++)
            {
				if (lines[i].X2 != lines[(i + 1) % lines.Length].X1
					|| lines[i].Y2 != lines[(i + 1) % lines.Length].Y1)
					throw new ArgumentException("Лiнiї повиннi бути з'єднанi. X2, Y2 з першої лiнiї = з X1, Y1 з другої лiнiї");
            }

            for(int i=0; i< lines.Length; i++)
            {
                this.Lines.Add((Line)lines[i].DeepCopy());
            }
        }

        public PolyLine(List<Line> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
				if (lines[i].X2 != lines[(i + 1) % lines.Count].X1
					|| lines[i].Y2 != lines[(i + 1) % lines.Count].Y1)
					throw new ArgumentException("Лiнiї повиннi бути з'єднанi. X2, Y2 з першої лiнiї = з X1, Y1 з другої лiнiї");
            }
            for (int i = 0; i < lines.Count; i++) 
                this.Lines.Add((Line)lines[i].DeepCopy());            
        }             

        public void deleteItem(int index)
        {
            if (index < 0 || index > lines.Count)
                throw new System.IndexOutOfRangeException("Iндекс повинен бути в межах [0;" + lines.Count + "]");
            Lines.RemoveAt(index);
            if (Deleted != null)
                Deleted($"Видалили {Lines[index]}");         
        }

        public void addFigure(Line line)
        {
            if (lines.Count < 0) lines.Add(line);
			if (line.X1 != lines[(this.lines.Count) - 1].X2 || line.Y1 != this.lines[(lines.Count) - 1].Y2)
				throw new ArgumentException("Лiнiї повиннi бути з'єднанi.X2, Y2 з першої = рівнi з X1, Y1 з другої лiнiї");
            if (Added != null)
                Added($"Додали " + line);
            lines.Add(line);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PolyLine)) return false;
            PolyLine tmp = (PolyLine)obj;
            if(tmp.Lines.Count==this.Lines.Count)
            {                
                for(int i=0; i < tmp.Lines.Count; i++)
                {
                    if (this.Lines.IndexOf(tmp.Lines[i])==-1)                  
                        return false;
                }
                return true;
            }
            return false;
        }

        public static bool operator ==(PolyLine p1, PolyLine p2)
        {
            if (p1.Equals(p2)) return true;
            else return false;
        }

        public static bool operator !=(PolyLine p1, PolyLine p2)
        {
            if (p1.Equals(p2)) return false;
            else return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for(int i=0; i < Lines.Count; i++)
            {
                hash += Lines[i].GetHashCode();
            }
            hash %= 900;
            hash += 600; 
            return hash;
        }

        public override Point DeepCopy()
        {
            List<Line> tmp = new List<Line>();
            for(int i=0; i < this.Lines.Count; i++)
                tmp.Add((Line)Lines[i].DeepCopy());
            return new PolyLine(tmp);
        }

        public override string ToString()
        {
            string tmp = "PolyLine:\n";
            for (int i = 0; i < Lines.Count; i++)
            {
                tmp += Lines[i].ToString()+"\n";
            }
            return tmp;
        }
    }
}
