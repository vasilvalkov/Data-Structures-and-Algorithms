using System;
using System.Collections.Generic;
using System.Linq;

namespace Swapping
{
    class Startup
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<int> steveNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(i + 1);
            }

            foreach (var x in steveNumbers)
            {
                var reorderedNumbers = new List<int>();
                int xIndex = numbers.IndexOf(x);

                var after = numbers.GetRange(xIndex + 1, (numbers.Count - xIndex) - 1);
                reorderedNumbers.AddRange(after);

                reorderedNumbers.Add(numbers[xIndex]);

                var before = numbers.GetRange(0, xIndex);
                reorderedNumbers.AddRange(before);
                
                numbers = reorderedNumbers;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
