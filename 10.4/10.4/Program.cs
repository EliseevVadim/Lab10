using System;
using System.Collections.Generic;
namespace _10._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mas = { { -1, 96, 40, -1, -1, -1, -1, -1 }, { 96, -1, -1, -1, -1, 74, 61, -1 }, { 40, -1, -1, 58, -1, 115, -1, 85 }, { -1, -1, 58, -1, 36, -1, -1, -1 }, { -1, -1, -1, 36, -1, 42, -1, -1 }, { -1, 74, 115, -1, 42, -1, -1, -1 }, { -1, 61, -1, -1, -1, -1, -1, 93 }, { -1, -1, 85, -1, -1, -1, 93, -1 } };
            Graph graph = new Graph();
            graph.GetGraphMatrix(mas);
            Console.WriteLine("Введите начальную точку: ");
            int a = int.Parse(Console.ReadLine()) - 1;
            Console.Clear();
            try
            {
                Console.WriteLine("Точки, расстояния в которые из заданной не более 200км: ");
                for (int i = 0; i < 8; i++)
                {
                    if (a != i)
                    {
                        //Использование алгоритма Дейкстры в данном случае целесообразно, так как если найденный минимальный путь меньше либо равен 200 км, то мы получили необходимую точку и смысла в дальнейших проверках нет. Если же полученный путь более 200 км, то любой другой будет также больше 200 км, а значит смысла в дальнейших проверках тоже нет.                       
                        if (graph.DijkstraAlgorithm(a, i) <= 200)
                            Console.WriteLine(i + 1 + "--" + graph.DijkstraAlgorithm(a, i) + "(км)");
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода");
            }
        }
    }
}
