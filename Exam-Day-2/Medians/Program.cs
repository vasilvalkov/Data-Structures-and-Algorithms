using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace Medians
{
    class Program
    {
        static void Main()
        {
            OrderedBag<int> bag = new OrderedBag<int>();

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToArray();

                if (command[0].ToUpper() == "EXIT")
                {
                    break;
                }

                if (command[0].ToUpper() == "ADD")
                {
                    int number = int.Parse(command[1]);
                    bag.Add(number);
                }

                if (command[0].ToUpper() == "FIND")
                {
                    Console.WriteLine(GetMedian(bag));
                }
            }
        }

        private static double GetMedian(OrderedBag<int> bag)
        {
            if (bag.Count % 2 == 1)
            {
                return bag[bag.Count / 2];
            }
            else if (bag.Count == 2)
            {
                return (double)(bag[1] + bag[0]) / 2;
            }
            else
            {
                return (double)(bag[(bag.Count - 1) / 2] + bag[((bag.Count - 1) / 2) + 1]) / 2;
            }
        }
    }
}

