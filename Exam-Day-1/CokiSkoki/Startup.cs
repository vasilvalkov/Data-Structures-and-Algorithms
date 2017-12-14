using System;
using System.Linq;

namespace CokiSkoki
{
    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] heights = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] skokLengths = new int[heights.Length];
            int maxSkokLength = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                int currentSkokLength = 0;
                int currentPosition = i;

                for (int j = i; j < heights.Length; j++)
                {
                    if (heights[j] <= heights[currentPosition])
                    {
                        continue;
                    }

                    if (heights[j] > heights[currentPosition])
                    {
                        currentPosition = j;
                        ++currentSkokLength;
                    }

                    skokLengths[i] = currentSkokLength;
                    if (maxSkokLength < currentSkokLength)
                    {
                        maxSkokLength = currentSkokLength;
                    }
                }
            }

            Console.WriteLine(maxSkokLength);
            Console.WriteLine(string.Join(" ", skokLengths));
        }
    }
}
