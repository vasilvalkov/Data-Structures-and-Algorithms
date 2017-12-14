using System;
using System.Linq;

namespace Beach
{
    public class Solution
    {
        public static void Main()
        {
            int[] steve = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] ellen = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double time = double.MaxValue;

            if (steve[2] == ellen[2] || steve[0] == ellen[0])
            {
                double distance = Math.Sqrt(Math.Pow(steve[0] - ellen[0], 2) + Math.Pow(steve[1] - ellen[1], 2));
                time = distance / steve[2];
            }
            else
            {
                if (steve[0] > ellen[0])
                {
                    double temp_time = 0;
                    for (double x = ellen[0]; x <= steve[0]; x += 0.01)
                    {
                        temp_time = 0;
                        double distance1 = Math.Sqrt(Math.Pow(steve[0] - x, 2) + Math.Pow(steve[1], 2));
                        temp_time += distance1 / steve[2];
                        double distance2 = Math.Sqrt(Math.Pow(x - ellen[0], 2) + Math.Pow(ellen[1], 2));
                        temp_time += distance2 / ellen[2];
                        time = Math.Min(temp_time, time);
                    }
                }
                else
                {
                    double temp_time = 0;
                    for (double x = steve[0]; x <= ellen[0]; x += 0.01)
                    {
                        temp_time = 0;
                        double distance1 = Math.Sqrt(Math.Pow(steve[0] - x, 2) + Math.Pow(steve[1], 2));
                        temp_time += distance1 / steve[2];
                        double distance2 = Math.Sqrt(Math.Pow(x - ellen[0], 2) + Math.Pow(ellen[1], 2));
                        temp_time += distance2 / ellen[2];
                        time = Math.Min(temp_time, time);
                    }
                }
            }

            Console.WriteLine(String.Format("{0:0.00}", time));
        }
    }
}
