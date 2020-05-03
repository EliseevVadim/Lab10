using System;
using System.Collections.Generic;
namespace _10._3MD
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = { { 0, 1, 1, 0, 0, 0, 0, 0 },
                             { 1, 0, 0, 0, 0, 1, 1, 0 },
                             { 1, 0, 0, 1, 0, 1, 0, 1 },
                             { 0, 0, 1, 0, 1, 0, 0, 0 },
                             { 0, 0, 0, 1, 0, 1, 0, 0 },
                             { 0, 1, 1, 0, 1, 0, 0, 0 },
                             { 0, 1, 0, 0, 0, 0, 0, 1 },
                             { 0, 0, 1, 0, 0, 0, 1, 0 } };            
            Graph g = new Graph();
            g.GetGraphMatrix(array);
            Console.WriteLine("Введите начальную позицию");
            int start = int.Parse(Console.ReadLine()) - 1;
            Console.Clear();
            Console.WriteLine("Введите конечную позицию");
            int end = int.Parse(Console.ReadLine()) - 1;
            Console.Clear();
            Stack<int> BFSpath = g.BFS(start, end, 8);
            Console.WriteLine("BFS:");
            int c = 0;
            try
            {
                while (BFSpath.Count != 0)
                {
                    if (c == 0)
                    {
                        Console.Write((1 + BFSpath.Pop()));
                    }
                    else
                    {
                        Console.Write("->" + (1 + BFSpath.Pop()));
                    }
                    c++;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Пути нет");
            }
            Console.WriteLine("\nDFS:");
            Stack<int> DFSpath = g.DFS(start, end, 8);
            int N = 0;
            try
            {
                while (DFSpath.Count != 0)
                {
                    if (N == 0)
                    {
                        Console.Write((1 + DFSpath.Pop()));
                    }
                    else
                    {
                        Console.Write("->" + (1 + DFSpath.Pop()));
                    }
                    N++;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Пути нет");
            }
        }
    }
}
