using System;
using System.Collections.Generic;
using System.Windows.Media;
namespace lab2
{
    static class ExeptionPrg
    {
        static public void test()
        {
            Picture picture = new Picture(new ColoredLine(0, 0, 1, 1, Color.FromArgb(0, 199, 21, 133)),
                new ColoredPoint(2, 2, Color.FromArgb(0, 199, 21, 133)), new Line(4, 4, 5, 5),
                new PolyLine(new Line(0, 0, 1, 1), new Line(1, 1, 1, 0), new Line(1, 0, 0, 0)));

            ColoredLine coloredLine = (ColoredLine)picture.get(0);
            Console.WriteLine(coloredLine);
            ColoredPoint coloredPoint = (ColoredPoint)picture.get(1);
            Console.WriteLine(coloredPoint);
            Line line = (Line)picture.get(2);
            Console.WriteLine(line);
            PolyLine polyLine = (PolyLine)picture.get(3);
            Picture picture2 = new Picture(coloredPoint, coloredLine, line, polyLine);

            List<Line> tmplist1 = new List<Line>();
            tmplist1.Add(new Line(0, 0, 0, 1));
            tmplist1.Add(new Line(0, 1, 1, 1));
            tmplist1.Add(new Line(1, 1, 1, 0));
            tmplist1.Add(new Line(1, 0, 0, 0));
            PolyLine polyLine1 = new PolyLine(tmplist1);
            Console.WriteLine(polyLine);

            List<Point> tmpList = new List<Point>();
            tmpList.Add(coloredPoint);
            tmpList.Add(coloredLine);
            tmpList.Add(line);
            tmpList.Add(polyLine);
            picture2 = new Picture(tmpList);
            Console.WriteLine(picture2);

            if (picture.Equals(picture2))
				Console.WriteLine("picture1 = picture2");
            if (coloredPoint == (new ColoredPoint(2, 2, Color.FromArgb(0, 199, 21, 133))))
                Console.WriteLine("coloredPoint = (new ColoredPoint(2, 2, Color.FromArgb(0, 199, 21, 133)))");
            ColoredPoint coloredPoint2 = new ColoredPoint(2, 1, Color.FromArgb(0, 199, 21, 133));
            if (!(coloredLine != picture.get(0)))
				Console.WriteLine("coloredLine = picture.get(0)");
            if (!(coloredPoint != picture.get(1)))
				Console.WriteLine("coloredPoint = picture.get(1)");
            if (!(line != picture.get(2)))
				Console.WriteLine("line рiвний =.get(2)");
            if (!(polyLine != picture.get(3)))
				Console.WriteLine("polyLine = picture.get(3)");
            if (!(picture2 != picture))
				Console.WriteLine("picture2 = picture");

            Console.WriteLine("GetHashCode:");
            Console.WriteLine(coloredLine.GetHashCode());
            Console.WriteLine(coloredPoint.GetHashCode());
            Console.WriteLine(line.GetHashCode());
            Console.WriteLine(polyLine.GetHashCode());
            Console.WriteLine(picture2.GetHashCode());

            ColoredPoint mp1 = (ColoredPoint)coloredPoint.DeepCopy();
            ColoredLine mcl = (ColoredLine)coloredLine.DeepCopy();
            Line ml = (Line)line.DeepCopy();
            PolyLine mpol = (PolyLine)polyLine.DeepCopy();
            Picture mp = picture.DeepCopy();

		
            Console.WriteLine("Пiсля створення deepcopies зрiвнюємо з оригiналом ");
            Console.WriteLine(mp1 == coloredPoint);
            Console.WriteLine(mcl == coloredLine);
            Console.WriteLine(ml == line);
            Console.WriteLine(mpol == polyLine);
            Console.WriteLine(mp == picture);

            picture.Deleted += Show_Message;
            picture.Added += Show_Message;
            polyLine.Added += Show_Message;
            polyLine.Deleted += Show_Message;
            polyLine.Changed += Show_Message;
            picture.Changed += Show_Message;
            polyLine.deleteItem(0);

            picture.deleteItem(0);
            picture.addFigure(polyLine);

            polyLine.Lines = new List<Line>();
            picture.Figures = new List<Point>();

            try
            {
                polyLine = new PolyLine(new Line(1, 2, 3, 4), new Line(0, 0, 0, 0));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                polyLine = new PolyLine(new Line(1, 2, 3, 4), new Line(0, 0, 0, 0));
                polyLine.addFigure(new Line(0, 0, 2, 2));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Picture p = new Picture();
                p.deleteItem(10);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                PolyLine p = new PolyLine();

                p.deleteItem(10);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Picture p = new Picture();

                Point t = p.get(10);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }
        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
