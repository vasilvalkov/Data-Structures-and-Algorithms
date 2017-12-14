using System;
using System.Linq;

namespace Repeat
{
    public class Startup
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var failLink = new int[sequence.Length + 1];
            failLink[0] = -1;
            failLink[1] = 0;

            int j;
            for (var i = 1; i < sequence.Length; i++)
            {
                j = failLink[i];
                while (j >= 0 && sequence[i] != sequence[j])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            j = 0;
            for (var i = 1; ; i++)
            {
                if (i == sequence.Length)
                {
                    i = 0;
                }

                while (j >= 0 && sequence[i] != sequence[j])
                {
                    j = failLink[j];
                }

                j++;

                if (j != sequence.Length) continue;
                j = i + 1;
                break;
            }

            Console.WriteLine(string.Join(" ", sequence.Take(j)));
        }
    }
}
