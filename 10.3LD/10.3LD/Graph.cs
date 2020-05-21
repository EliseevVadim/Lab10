using System;
using System.Collections.Generic;
using System.Text;

namespace _10._3LD
{
    class Graph
    {
        Dictionary<int, List<int>> graph = null;
        public void InitGraphStructure(Dictionary<int, List<int>> dict)
        {
            graph = dict;
        }
        public Stack<int> BFS(int start, int end, int verticlecount)
        {
            Queue<int> queue = new Queue<int>();
            int[] vpath = new int[verticlecount];
            int[] checkdv = new int[verticlecount];
            queue.Enqueue(start);
            checkdv[start] = 1;
            while (queue.Count > 0)
            {
                int i = queue.Dequeue();
                for (int j = 0; j < verticlecount; j++)
                {
                    if (graph[i].Contains(j) && checkdv[j] == 0)
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
        public Stack<int> GetResult(int[] mas, int start, int end)
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
                    if (graph[i].Contains(j) && checkdv[j] == 0)
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
    }
}
