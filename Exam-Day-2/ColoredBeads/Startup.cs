using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace ColoredBeads
{
    class Startup
    {
        static int[] amounts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        static string[] beads = new string[] { "R", "G", "B" };
        //static string[] beads = new string[amounts[0] + amounts[1] + amounts[2]];

        static int n = amounts[0] + amounts[1] + amounts[2];
        static int[] arr = new int[n];
        static bool[] used = new bool[n];
        static OrderedBag<string> list = new OrderedBag<string>();

        static void Main()
        {
            //for (int i = 0; i < amounts[0]; i++)
            //{
            //    beads[i] = "R";
            //}
            //for (int i = amounts[1]; i < amounts[1] + amounts[2]; i++)
            //{
            //    beads[i] = "G";
            //}
            //for (int i = amounts[1] + amounts[2]; i < beads.Length; i++)
            //{
            //    beads[i] = "B";
            //}

            var inputIndex = int.Parse(Console.ReadLine());

            GenerateVariationsNoRepetitions(0);
            Console.WriteLine(list[inputIndex]);
        }

        static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= 3)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        static void PrintVariations()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                builder.Append(beads[arr[i] % 3]);
            }
            list.Add(builder.ToString());
        }
    }
}
