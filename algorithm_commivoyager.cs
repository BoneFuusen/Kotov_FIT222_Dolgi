using System;

public class TSP
{
    private int[,] distances;
    private int numberOfCities;

    public TSP(int[,] distances, int numberOfCities)
    {
        this.distances = distances;
        this.numberOfCities = numberOfCities;
    }

    public int Compute()
    {
        int[] cities = new int[numberOfCities - 1];
        for (int i = 0; i < cities.Length; i++)
        {
            cities[i] = i + 1;
        }

        return permute(cities, 0, numberOfCities - 2);
    }

    private int permute(int[] cities, int start, int end)
    {
        if (start == end)
        {
            return cost(cities);
        }
        else
        {
            int min = int.MaxValue;
            for (int i = start; i <= end; i++)
            {
                swap(cities, start, i);
                int temp = permute(cities, start + 1, end);
                min = Math.Min(min, temp);
                swap(cities, start, i);
            }
            return min;
        }
    }

    private int cost(int[] cities)
    {
        int totalCost = distances[0, cities[0]];
        for (int i = 0; i < cities.Length - 1; i++)
        {
            totalCost += distances[cities[i], cities[i + 1]];
        }
        totalCost += distances[cities[cities.Length - 1], 0];
        return totalCost;
    }

    private void swap(int[] cities, int i, int j)
    {
        int temp = cities[i];
        cities[i] = cities[j];
        cities[j] = temp;
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        int[,] distances = new int[,]{
        {0, 10, 15, 20},
        {10, 0, 35, 25},
        {15, 35, 0, 30},
        {20, 25, 30, 0}
    };
        int numberOfCities = 4;

        TSP tsp = new TSP(distances, numberOfCities);
        int shortestPath = tsp.Compute();
        Console.WriteLine("Длина кратчайшего пути: " + shortestPath);
    }
}
