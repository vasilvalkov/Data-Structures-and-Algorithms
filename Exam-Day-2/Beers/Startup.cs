using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Beers
{
    class Coord
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int beersCount = int.Parse(input[2]);
            
            var map = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    map[row, col] = ' ';
                }
            }

            for (int i = 0; i < beersCount; i++)
            {
                var beer = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                map[beer[1], beer[0]] = '@';
            }

            //var map = new string[]
            //{
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "                    ",
            //    "         @ @        ",
            //    "   @            @   ",
            //    "        @           ",
            //    "           @        ",
            //    "    @  @   @        ",
            //    "      @             ",
            //    "              @     ",
            //    "     @     @        ",
            //    "                   @",
            //    "                    "
            //};

            //var n = map.Length;
            //var m = map[0].Length;

            var n = rows;
            var m = cols;

            var memo = new BigInteger[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    memo[i, j] = -1;
                }
            }
            //var result = Dfs(map, memo, 0, 0);
            //Console.WriteLine(result);


            //Console.WriteLine(DP(map, n, m));
            Console.WriteLine(DPMemoryOptimized(map, n, m));
        }

        static BigInteger DPMemoryOptimized(char[,] map, int n, int m)
        {
            var dp = new BigInteger[2, m];
            dp[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    var fromUp = i > 0 ? dp[(i - 1) % 2, j] : 0;
                    var fromLeft = j > 0 ? dp[i % 2, j - 1] : 0;

                    dp[i % 2, j] = map[i,j] == ' '
                        ? fromUp + fromLeft
                        : 0;
                }
            }

            return dp[(n - 1) % 2, m - 1];
        }

        static BigInteger DP(string[] map, int n, int m)
        {
            var dp = new BigInteger[n, m];
            dp[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    var fromUp = i > 0 ? dp[i - 1, j] : 0;
                    var fromLeft = j > 0 ? dp[i, j - 1] : 0;

                    dp[i, j] = map[i][j] == ' '
                        ? fromUp + fromLeft
                        : 0;
                }
            }

            return dp[n - 1, m - 1];
        }

        static BigInteger Dfs(string[] map, BigInteger[,] memo, int row, int col)
        {
            if (row >= map.Length || col >= map[row].Length)
            {
                return 0;
            }

            if (row == map.Length - 1
                && col == map[row].Length - 1)
            {
                //Console.WriteLine("Found a way");
                return 1;
            }

            if (map[row][col] != ' ')
            {
                return 0;
            }

            if (memo[row, col] < 0)
            {
                var down = Dfs(map, memo, row + 1, col);
                var right = Dfs(map, memo, row, col + 1);
                memo[row, col] = down + right;
            }

            return memo[row, col];
        }
    }
}
