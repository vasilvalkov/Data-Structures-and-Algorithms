using System;
using System.Linq;

namespace Flies
{
    class Point2D
    {
        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return string.Format("{0:F4} {1:F4}", this.X, this.Y);
        }
    }

    class Circle
    {
        public Point2D Centre { get; set; }

        public double Radius { get; set; }

        public Circle(Point2D p1, Point2D p2, Point2D p3)
        {
            double t = p2.X * p2.X + p2.Y * p2.Y;
            double bc = (p1.X * p1.X + p1.Y * p1.Y - t) / 2.0;
            double cd = (t - p3.X * p3.X - p3.Y * p3.Y) / 2.0;
            double det = (p1.X - p2.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p2.Y);

            if (Math.Abs(det) > 1.0e-6)
            {
                det = 1 / det;
                double x = (bc * (p2.Y - p3.Y) - cd * (p1.Y - p2.Y)) * det;
                double y = ((p1.X - p2.X) * cd - (p2.X - p3.X) * bc) * det;
                double r = Math.Sqrt((x - p1.X) * (x - p1.X) + (y - p1.Y) * (y - p1.Y));

                this.Centre = new Point2D(x, y);
                this.Radius = r;
            }
        }
    }

    class Startup
    {
        static void Main()
        {
            var fly1Coords = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Point2D fly1 = new Point2D(fly1Coords[0], fly1Coords[1]);

            var fly2Coords = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Point2D fly2 = new Point2D(fly2Coords[0], fly2Coords[1]);

            var fly3Coords = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Point2D fly3 = new Point2D(fly3Coords[0], fly3Coords[1]);

            var circle = new Circle(fly1, fly2, fly3);

            Console.WriteLine(circle.Centre);
        }
    }
}
