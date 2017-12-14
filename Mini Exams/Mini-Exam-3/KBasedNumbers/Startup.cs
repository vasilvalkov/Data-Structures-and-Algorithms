using System;

namespace KBasedNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            
            var pureNums = (k - 1) * (k - 1);
            var defaulterNum = k - 1;

            for (int i = 2; i < n; i++)
            {
                var tmp = pureNums;
                pureNums = pureNums * (k - 1) + defaulterNum * (k - 1);
                defaulterNum = tmp;
            }

            var count = pureNums + defaulterNum;

            Console.WriteLine(count);
        }
    }
}
