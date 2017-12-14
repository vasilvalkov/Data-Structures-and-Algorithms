using System;
using System.Linq;

namespace Beach
{
    public class Startup
    {
        public static void Main()
        {
            double[] steveProps = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] ellenProps = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            double sx = steveProps[0];
            double sy = steveProps[1];
            double v1 = steveProps[2];

            double ex = ellenProps[0];
            double ey = ellenProps[1];
            double v2 = ellenProps[2];

            double midY = (sy + ey) / 2;
            Point steve = new Point(sx, sy);
            Point steveZeroLine = new Point(0, midY);
            Point ellen = new Point(ex, ey);
            Point ellenZeroLine = new Point(0, midY);

            //

            // big triangle
            Point pointC = new Point(sx, ey);
            double sideA = steve.DistanceToSquared(pointC);
            double sideB = ellen.DistanceToSquared(pointC);
            double sideC = sideA + sideB;
            double cosA = (sideB + sideC - sideA) / 2 * sideB * sideC;
            double cosB = (sideC + sideA - sideB) / 2 * sideC * sideA;

            double angleA = Math.Pow(Math.Cos(cosA * Math.PI / 180), -1);
            double angleB = Math.Pow(Math.Cos(cosB * Math.PI / 180), -1);
            double angleC = Math.Cos(90 * Math.PI / 180);

            double 

            Console.WriteLine("{0:F2}", Math.Sqrt(sideC / (v1 + v2)));


            //
            double steveDistanceToWater = steve.DistanceTo(steveZeroLine);
            double ellenDistanceToWater = ellen.DistanceTo(ellenZeroLine);

            double minTime = Math.Abs(steveDistanceToWater) / v1 + Math.Abs(ellenDistanceToWater) / v2;

           // Console.WriteLine("{0:F2}",minTime);
        }

        public class Point
        {
            private const double Epsilon = 1e-12;

            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double DistanceToSquared(Point other)
            {
                var dx = this.X - other.X;
                var dy = this.Y - other.Y;
                return dx * dx + dy * dy;
            }

            public double DistanceTo(Point other)
            {
                return Math.Sqrt(this.DistanceToSquared(other));
            }
            
            public static int XComparer(Point a, Point b)
            {
                var dx = a.X - b.X;
                if (dx < -Epsilon)
                {
                    return -1;
                }
                if (dx > Epsilon)
                {
                    return 1;
                }
                return 0;
            }
        }
    }
}
