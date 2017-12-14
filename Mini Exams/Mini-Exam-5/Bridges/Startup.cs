using System;
using System.Collections.Generic;

public class Bridges
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        int NumberOfNodes = int.Parse(input[0]);
        int numberOfEdges = int.Parse(input[1]);
        List<Edge> edges = new List<Edge>();

        InitializeGraph(edges, numberOfEdges);

        int[] tree = new int[NumberOfNodes + 1];
        var mpd = new List<Edge>();
        int treesCount = 1;

        edges.Sort((x, y) => y.CompareTo(x));

        treesCount = FindMinimumSpanningTree(edges, tree, mpd, treesCount);

        var busWeight = int.Parse(Console.ReadLine());
        PrintMinimumSpanningTree(mpd, busWeight);
    }

    private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
    {
        foreach (var edge in edges)
        {
            if (tree[edge.StartNode] == 0)
            {
                if (tree[edge.EndNode] == 0)
                {
                    tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                    treesCount++;
                }
                else
                {
                    tree[edge.StartNode] = tree[edge.EndNode];
                }

                mpd.Add(edge);
            }
            else
            {
                if (tree[edge.EndNode] == 0)
                {
                    tree[edge.EndNode] = tree[edge.StartNode];
                    mpd.Add(edge);
                }
                else if (tree[edge.EndNode] != tree[edge.StartNode])
                {
                    int oldTreeNumber = tree[edge.EndNode];

                    for (int i = 0; i < tree.Length; i++)
                    {
                        if (tree[i] == oldTreeNumber)
                        {
                            tree[i] = tree[edge.StartNode];
                        }
                    }

                    mpd.Add(edge);
                }
            }
        }

        return treesCount;
    }

    private static void PrintMinimumSpanningTree(IEnumerable<Edge> usedEdges, int busWeight)
    {
        var counter = 0;
        foreach (var edge in usedEdges)
        {
            if (edge.Weight < busWeight)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }

    private static void InitializeGraph(List<Edge> edges, int numberOfEdges)
    {
        for (int i = 0; i < numberOfEdges; i++)
        {
            var input = Console.ReadLine().Split(' ');
            edges.Add(new Edge(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2])));
        }
    }
}

public class Edge : IComparable<Edge>
{
    public Edge(int startNode, int endNode, int weight)
    {
        this.StartNode = startNode;
        this.EndNode = endNode;
        this.Weight = weight;
    }

    public int StartNode { get; set; }

    public int EndNode { get; set; }

    public int Weight { get; set; }

    public int CompareTo(Edge other)
    {
        int weightCompared = this.Weight.CompareTo(other.Weight);
        if (weightCompared == 0)
        {
            var result = this.StartNode.CompareTo(other.StartNode);

        }

        return weightCompared;
    }

    public override string ToString()
    {
        return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
    }
}
