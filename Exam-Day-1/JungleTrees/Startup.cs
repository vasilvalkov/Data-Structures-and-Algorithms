using System;
using System.Linq;

namespace JungleTrees
{
    class Tree
    {
        public int Coord { get; set; }
        public int Height { get; set; }
    }

    class Startup
    {
        static void Main()
        {
            int[] inits = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numberOfTrees = inits[0];
            int mj = inits[1];
            int mh = inits[2];
            Tree[] trees = new Tree[numberOfTrees];

            for (int i = 0; i < numberOfTrees; i++)
            {
                var tree = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                trees[i] = new Tree { Coord = tree[0], Height = tree[1] };
            }

            var currentTree = trees[0];
            var next = 1;
            int currentSkokLength = 0;

            while (Math.Abs(currentTree.Coord - trees[next].Coord) <= mj &&
                   Math.Abs(currentTree.Height - trees[next].Height) <= mh)
            {
                currentTree = trees[next];
                ++next;
                ++currentSkokLength;
            }
            
            Console.WriteLine(currentSkokLength != 0 ? currentSkokLength + 1 : -1);
        }
    }
}
