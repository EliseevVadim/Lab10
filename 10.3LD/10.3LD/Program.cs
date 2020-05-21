using System;
using System.Collections.Generic;
namespace _10._3LD
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> ways = new Dictionary<int, List<int>>();
            ways.Add(1, new List<int> { 2, 3 });
            ways.Add(2, new List<int> { 1, 7, 6 });
            ways.Add(3, new List<int> { 1, 6, 8 });
            ways.Add(4, new List<int> { 3, 5 });
            ways.Add(5, new List<int> { 4, 6 });
            ways.Add(6, new List<int> { 2, 3, 5 });
            ways.Add(7, new List<int> { 2, 8 });
            ways.Add(8, new List<int> { 7, 3 });
            Graph graph = new Graph();
            graph.InitGraphStructure(ways);
            Console.WriteLine("Введите начальную вершину: ");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную вершину: ");
            int end = int.Parse(Console.ReadLine());
            Console.Clear();
            Stack<int> BFS = graph.BFS(start, end, 9);
            int c = 0;
            Console.WriteLine("BFS: ");
            try
            {
                while (BFS.Count != 0)
                {
                    if (c == 0)
                    {
                        Console.Write((BFS.Pop()));
                    }
                    else
                    {
                        Console.Write("->" + ( BFS.Pop()));
                    }
                    c++;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Пути нет");
            }
            Console.WriteLine();
            Console.WriteLine("DFS: ");
            Stack<int> DFS = graph.DFS(start, end, 9);
            int n = 0;
            try
            {
                while (DFS.Count != 0)
                {
                    if (n == 0)
                    {
                        Console.Write((DFS.Pop()));
                    }
                    else
                    {
                        Console.Write("->" + (DFS.Pop()));
                    }
                    n++;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Пути нет");
            }
        }
    }
}
