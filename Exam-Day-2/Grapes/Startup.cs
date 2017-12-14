using System;
using System.Numerics;

namespace Grapes
{
    class Startup
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var result = Factorial(2 * number) / (Factorial(number + 1) * Factorial(number));

            Console.WriteLine(result);
        }

        static BigInteger Factorial(BigInteger n)
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
