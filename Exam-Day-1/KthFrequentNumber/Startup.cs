using System;
using System.Collections.Generic;
using System.Linq;

namespace KthFrequentNumber
{
    class FreqNumber
    {
        public int Value { get; set; }
        public int Name { get; set; }
    }

    class Startup
    {
        static void Main()
        {
            List<FreqNumber> numbers = new List<FreqNumber>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                string command = input[0].ToUpper();

                if (command == "END" || (command != "ADD" && command != "GET" && command != "REMOVE"))
                {
                    break;
                }

                int currentFreqNumber;

                if (!int.TryParse(input[1], out currentFreqNumber))
                {
                    break;
                }

                switch (command)
                {
                    case "ADD":
                        var existingNumber = numbers.Find(fn => fn.Name == currentFreqNumber);
                        if (existingNumber == null)
                        {
                            var newFreqNumber = new FreqNumber { Name = currentFreqNumber, Value = 1 };
                            numbers.Add(newFreqNumber);
                        }
                        else
                        {
                            existingNumber.Value++;
                        }

                        numbers = numbers.OrderByDescending(fn => fn.Value).ThenBy(fn => fn.Name).ToList();

                        Console.WriteLine("Ok: {0} added", currentFreqNumber);
                        break;
                    case "GET":
                        if (currentFreqNumber <= numbers.Count && currentFreqNumber > 0 && numbers[currentFreqNumber - 1].Value != 0)
                        {
                            Console.WriteLine("Ok: Found {0}", numbers[currentFreqNumber - 1].Name);
                        }
                        else
                        {
                            Console.WriteLine("Error: {0} is invalid K", currentFreqNumber);
                        }

                        break;
                    case "REMOVE":
                        var existingFreqNumber = numbers.Find(fn => fn.Name == currentFreqNumber);
                        if (existingFreqNumber != null && existingFreqNumber.Name != 0)
                        {
                            if (existingFreqNumber.Value > 0)
                            {
                                existingFreqNumber.Value--;
                                Console.WriteLine("Ok: Number {0} removed", currentFreqNumber);
                                numbers = numbers.OrderByDescending(fn => fn.Value).ThenBy(fn => fn.Name).ToList();
                            }
                            else
                            {
                                //numbers.Remove(existingFreqNumber);
                                Console.WriteLine("Error: Number {0} not found", currentFreqNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Number {0} not found", currentFreqNumber);
                        }

                        break;
                    default:
                        Console.WriteLine("Error: {0} is invalid K", currentFreqNumber);
                        break;
                }
            }
        }
    }
}
