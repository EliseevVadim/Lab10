using System;
using System.Collections.Generic;
using System.Text;

namespace _10._3MD
{
    class Graph
    {
        int[,] graph = null;
        public void GetGraphMatrix(int [,] mas)
        {
            graph = new int[mas.GetLength(0), mas.GetLength(1)];
            for (int i=0; i<mas.GetLength(0); i++)
            {
                for (int j=0; j<mas.GetLength(1); j++)
                {
                    graph[i, j] = mas[i, j];
                }
            }
        }
        public Stack<int> BFS(int start, int end, int verticlecount )
        {
            Queue<int> queue = new Queue<int>();
            int [] vpath = new int[verticlecount];
            int[] checkdv = new int[verticlecount];
            queue.Enqueue(start);
            checkdv[start] = 1;
            while (queue.Count > 0)
            {
                int i = queue.Dequeue();
                for (int j=0; j<verticlecount; j++)
                {
                    if (graph[i, j] == 1 && checkdv[j] == 0)
                    {
                        checkdv[j] = 1;
                        queue.Enqueue(j);
                        vpath[j] = i;
                        if (j == end)
                        {
                            return GetResult(vpath, start, end);
                        }
                    }
                }
            }
            return null;
        }
        public Stack<int> GetResult(int [] mas, int start, int end)
        {
            int pos = end;
            Stack<int> path = new Stack<int>();
            path.Push(pos);
            while (pos != start)
            {
                pos = mas[pos];
                path.Push(pos);
            }
            return path;
        }
        public Stack<int> DFS(int start, int end, int verticlecount)
        {
            Stack<int> stack = new Stack<int>();
            int[] vpath = new int[verticlecount];
            int[] checkdv = new int[verticlecount];
            stack.Push(start);
            checkdv[start] = 1;
            while (stack.Count > 0)
            {
                int i = stack.Pop();
                for (int j = 0; j < verticlecount; j++)
                {
                    if (graph[i, j] == 1 && checkdv[j] == 0)
                    {
                        checkdv[j] = 1;
                        stack.Push(j);
                        vpath[j] = i;
                        if (j == end)
                        {
                            return GetResult(vpath, start, end);
                        }
                    }
                }
            }
            return null;
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
    }
}
