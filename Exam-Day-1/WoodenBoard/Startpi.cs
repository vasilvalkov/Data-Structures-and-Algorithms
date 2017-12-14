using System;

namespace WoodenBoard
{
    class Startup
    {
        static void Main()
        {
            char[] chars = Console.ReadLine().ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                int j = 0;
                for (; j < chars.Length - i; j++)
                {
                    if (chars[i + j] != chars[chars.Length - 1 - j])
                    {
                        break;
                    }
                }

                if (j == chars.Length - i)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
