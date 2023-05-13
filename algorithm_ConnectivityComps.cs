using System;
using System.Collections.Generic;

internal class Program
{
    public static void Main()
    {
        int[,] matrix = new int[,] { { 1, 1, 0, 0, 0, 0 },
                                    { 1, 1, 0, 0, 0, 0 },
                                    { 0, 0, 1, 1, 0, 0 },
                                    { 0, 0, 1, 1, 0, 0 },
                                    { 0, 0, 0, 0, 1, 1 },
                                    { 0, 0, 0, 0, 1, 1 } };

        int count = CountConnectivityComponents(matrix);
        Console.WriteLine("Количество компонент связности: " + count);
    }

    public static int CountConnectivityComponents(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int count = 0;

        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFS(matrix, visited, i);
                count++;
            }
        }

        return count;
    }

    public static void DFS(int[,] matrix, bool[] visited, int vertex)
    {
        visited[vertex] = true;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[vertex, i] == 1 && !visited[i])
            {
                DFS(matrix, visited, i);
            }
        }
    }
}

