using System;
using System.Collections.Generic;

namespace Reconstruction
{
    public class Program
    {
        public class Edge : IComparable<Edge>
        {
            public int VertexA { get; private set; }
            public int VertexB { get; private set; }
            public int Cost { get; private set; }

            public Edge(int townA, int townB, int cost)
            {
                this.VertexA = townA;
                this.VertexB = townB;
                this.Cost = cost;
            }

            public int CompareTo(Edge edge)
            {
                return Cost - edge.Cost;
            }
        }

        static int GetValue(char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
            {
                return ch - 'A';
            }
            return ch - 'a' + 26;
        }

        static int FindMinimalCost(List<string> paths, List<string> pathsToBuild, List<string> pathsToDestroy)
        {
            int massiveCost = 0;
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < paths.Count; ++i)
            {
                for (int j = i + 1; j < paths.Count; ++j)
                {
                    if (paths[i][j] == '0')
                    {
                        edges.Add(new Edge(i, j, GetValue(pathsToBuild[i][j])));
                    }
                    else
                    {
                        int val = GetValue(pathsToDestroy[i][j]);
                        edges.Add(new Edge(i, j, -val));
                        massiveCost += val;
                    }
                }
            }

            edges.Sort();

            int[] color = new int[paths.Count];
            for (int i = 0; i < paths.Count; ++i)
            {
                color[i] = i;
            }

            int mstCost = 0;

            for (int i = 0; i < edges.Count; ++i)
            {
                Edge edge = edges[i];

                if (color[edge.VertexA] != color[edge.VertexB])
                {
                    mstCost += edge.Cost;

                    int oldColor = color[edge.VertexB];
                    for (int j = 0; j < paths.Count; ++j)
                    {
                        if (color[j] == oldColor)
                        {
                            color[j] = color[edge.VertexA];
                        }
                    }
                }
            }

            return massiveCost + mstCost;
        }

        static void Main()
        {
            int townsCount = int.Parse(Console.ReadLine());
            List<string> paths = new List<string>();
            List<string> pathsToBuild = new List<string>();
            List<string> pathsToDestroy = new List<string>();

            for (int i = 0; i < townsCount; i++)
            {
                paths.Add(Console.ReadLine());
            }

            for (int i = 0; i < townsCount; i++)
            {
                pathsToBuild.Add(Console.ReadLine());
            }

            for (int i = 0; i < townsCount; i++)
            {
                pathsToDestroy.Add(Console.ReadLine());
            }

            Console.WriteLine(FindMinimalCost(paths, pathsToBuild, pathsToDestroy));
        }
    }
}
