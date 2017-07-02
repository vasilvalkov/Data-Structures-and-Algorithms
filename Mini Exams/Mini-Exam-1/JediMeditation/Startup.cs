using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation
{
    public class Startup
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            string[] jedysQueue = Console.ReadLine().Split(' ');

            var jedysOrdered = new List<string>();
            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padawans = new Queue<string>();

            foreach (var jedy in jedysQueue)
            {
                var jedyRank = jedy.ToLower()[0];
                var jedyNumber = jedy.Substring(1);
                if (jedyRank == 'p')
                {
                    padawans.Enqueue(jedy);
                }

                if (jedyRank == 'm')
                {
                    masters.Enqueue(jedy);
                }

                if (jedyRank == 'k')
                {
                    knights.Enqueue(jedy);
                }
            }

            jedysOrdered.AddRange(masters);
            jedysOrdered.AddRange(knights);
            jedysOrdered.AddRange(padawans);

            Console.WriteLine(string.Join(" ", jedysOrdered));
        }
    }
}
