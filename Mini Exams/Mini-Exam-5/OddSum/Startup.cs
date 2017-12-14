using System;
using System.Collections.Generic;
using System.Linq;

namespace OddSum
{
    class Startup
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var negativeNumbers = new List<int>();
            var maxSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] >= 0)
                {
                    maxSum += numbers[i];
                }
                else if (numbers[i] < 0)
                {
                    negativeNumbers.Add(numbers[i]);
                }
            }

            negativeNumbers.Sort();

            if (maxSum % 2 == 0)
            {
                var maxNegativeNumber = negativeNumbers[negativeNumbers.Count - 1];
                maxSum -= Math.Abs(maxNegativeNumber);
            }

            Console.WriteLine(maxSum);
        }
    }
}
