using System;

namespace Squares
{
    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            long result = (long)(Math.Pow(n, m) + Math.Pow(m, n));
            var pow = n * m + 1;
            Console.WriteLine(n * m + 1 + Factorial(n) + Factorial(m));
        }

        static long Factorial(long n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
