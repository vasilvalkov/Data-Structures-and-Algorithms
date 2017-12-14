using System;
using System.Linq;

namespace Heights
{
    class Startup
    {
        static void Main()
        {
            double[] vertex1 = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Point pointA = new Point(vertex1[0], vertex1[1]);

            double[] vertex2 = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Point pointB = new Point(vertex2[0], vertex2[1]);

            double[] vertex3 = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Point pointC = new Point(vertex3[0], vertex3[1]);

            double AB = pointA.DistanceTo(pointB);
            double BC = pointB.DistanceTo(pointC);
            double AC = pointA.DistanceTo(pointC);

            double p = (AB + BC + AC) / 2;
            double area = Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));

            double heightAB = (2 * area) / AB;
            double heightBC = (2 * area) / BC;
            double heightAC = (2 * area) / AC;

            Console.WriteLine("{0:0.00}", heightBC);
            Console.WriteLine("{0:0.00}", heightAC);
            Console.WriteLine("{0:0.00}", heightAB);
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
