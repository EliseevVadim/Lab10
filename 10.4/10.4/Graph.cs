using System;
using System.Collections.Generic;
using System.Text;

namespace _10._4
{
    class Graph
    {
        int[,] graph = null;
        public void GetGraphMatrix(int[,] mas)
        {
            graph = new int[mas.GetLength(0), mas.GetLength(1)];
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    graph[i, j] = mas[i, j];
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public int DijkstraAlgorithm(int start, int end)
        {
            List<int> distances = new List<int>();
            List<int> q = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                distances.Add(int.MaxValue);
                q.Add(i);
            }
            distances[start] = 0;
            while (q.Count > 0)
            {
                int u = -1, min = int.MaxValue;
                for (int i = 0; i < q.Count; i++)
                {
                    if (distances[q[i]] <= min)
                    {
                        min = distances[q[i]];
                        u = q[i];
                    }
                }
                q.Remove(u);
                for (int i = 0; i < 8; i++)
                {
                    if (graph[u, i] > -1)
                    {
                        if (distances[i] > graph[u, i] + distances[u])
                        {
                            distances[i] = graph[u, i] + distances[u];
                        }
                    }
                }
            }
            return distances[end];
        }
    }
}