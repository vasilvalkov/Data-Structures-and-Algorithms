using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology
{
    public class Startup
    {
        static void Main()
        {
            var date = Console.ReadLine();

            Console.WriteLine(Calculate(date));
        }

        public static string Calculate(string number)
        {
            if (number.Length == 1)
            {
                return number;
            }

            int a = int.Parse(number[0].ToString());
            int b = int.Parse(number[1].ToString());

            int result = (a + b) * (a ^ b) % 10;
            string substr = number.Substring(2);

            return Calculate(result.ToString() + substr);
        }
        
    }
}
