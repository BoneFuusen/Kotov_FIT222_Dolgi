using System;
using System.Collections.Generic;

internal class Program
{
    static int V = 6;

    public static bool bfs(int[,] rGraph, int s, int t, int[] parent)
    {
        bool[] visited = new bool[V];
        for (int i = 0; i < V; ++i)
            visited[i] = false;

        Queue<int> q = new Queue<int>();
        q.Enqueue(s);
        visited[s] = true;
        parent[s] = -1;

        while (q.Count != 0)
        {
            int u = q.Dequeue();
            for (int v = 0; v < V; ++v)
            {
                if (visited[v] == false && rGraph[u, v] > 0)
                {
                    q.Enqueue(v);
                    parent[v] = u;
                    visited[v] = true;
                }
            }
        }

        return (visited[t] == true);
    }

    public static int fordFulkerson(int[,] graph, int s, int t)
    {
        int[,] rGraph = new int[V, V];
        for (int u = 0; u < V; u++)
            for (int v = 0; v < V; v++)
                rGraph[u, v] = graph[u, v];

        int[] parent = new int[V];

        int max_flow = 0;

        while (bfs(rGraph, s, t, parent))
        {
            int path_flow = int.MaxValue;
            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                path_flow = Math.Min(path_flow, rGraph[u, v]);
            }

            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                rGraph[u, v] -= path_flow;
                rGraph[v, u] += path_flow;
            }

            max_flow += path_flow;
        }

        return max_flow;
    }

    public static void Main()
    {
        int[,] graph = new int[,] { { 0, 16, 13, 0, 0, 0 },
                                    { 0, 0, 10, 12, 0, 0 },
                                    { 0, 4, 0, 0, 14, 0 },
                                    { 0, 0, 9, 0, 0, 20 },
                                    { 0, 0, 0, 7, 0, 4 },
                                    { 0, 0, 0, 0, 0, 0 } };


        Console.WriteLine("Максимальный поток: " + fordFulkerson(graph, 0, 5));
    }
}
