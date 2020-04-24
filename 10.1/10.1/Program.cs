using System;
using System.IO;
namespace _10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите вид массива:\n1)Массив мз 100000 элементов, сгенерированный случайным образом\n2)Отсортированный массив из 100000 элементов по возрастанию\n3)Отсортированный массив из 100000 элементов по убыванию\n4)Закончить проверку");
                string answer = Console.ReadLine();
                CC();
                switch (answer)
                {
                    case "1":

                        int[] array = InitCasualArray();
                        Console.WriteLine("Выберите алгоритм сортировки:\n1)Пирамидальная сортировка\n2)Сортировка слиянием\n3)Быстрая сортировка\n4)Выход");
                        string secondanswer = Console.ReadLine();
                        CC();
                        switch (secondanswer)
                        {
                            case "1":
                                TestHeapSort(array, 0, 0);
                                Checker(array);
                                ToFile(array);
                                CR();
                                CC();
                                break;
                            case "2":
                                TestMergeSort(array,0,0);
                                Checker(array);
                                ToFile(array);
                                CR();
                                CC();
                                break;
                            case "3":
                                TestQuickSort(array,0,0);
                                Checker(array);
                                ToFile(array);
                                CR();
                                CC();
                                break;                            
                            case "4":
                                flag = false;
                                break;
                        }
                        break;
                    case "2":
                        int[] arr = InitUpperSortedArray();
                        Console.WriteLine("Выберите алгоритм сортировки:\n1)Пирамидальная сортировка\n2)Сортировка слиянием\n3)Быстрая сортировка\n4)Выход");
                        string secondanswer2 = Console.ReadLine();
                        CC();
                        switch (secondanswer2)
                        {
                            case "1":
                                TestHeapSort(arr, 0, 0);
                                Checker(arr);
                                ToFile(arr);
                                CR();
                                CC();
                                break;
                            case "2":
                                TestMergeSort(arr,0,0);
                                Checker(arr);
                                ToFile(arr);
                                CR();
                                CC();
                                break;
                            case "3":
                                TestQuickSort(arr, 0, 0);
                                Checker(arr);
                                ToFile(arr);
                                CR();
                                CC();
                                break;                            
                            case "4":
                                flag = false;
                                break;
                        }
                        break;
                    case "3":
                        int[] mas = InitLowerSortedArray();
                        Console.WriteLine("Выберите алгоритм сортировки:\n1)Пирамидальная сортировка\n2)Сортировка слиянием\n3)Быстрая сортировка\n4)Выход");
                        string secondanswer3 = Console.ReadLine();
                        CC();
                        switch (secondanswer3)
                        {
                            case "1":
                                TestHeapSort(mas, 0, 0);
                                Checker(mas);
                                ToFile(mas);
                                CR();
                                CC();
                                break;
                            case "2":
                                TestMergeSort(mas,0,0);
                                Checker(mas);
                                ToFile(mas);
                                CR();
                                CC();
                                break;
                            case "3":
                                TestQuickSort(mas, 0,0);
                                Checker(mas);
                                ToFile(mas);
                                CR();
                                CC();
                                break;
                            case "4":
                                flag = false;
                                break;
                        }
                        break;
                    case "4":
                        flag = false;
                        break;
                }
            }
        }
        static int Partition(int [] mas, int leftpos, int rigtpos, ref  int c, ref int s)
        {
            int pivot = mas[rigtpos];
            int i = leftpos-1;
            int j = rigtpos;
            while (i < j)
            {
                while (mas[++i] > pivot) ;
                while (mas[--j] < pivot)
                {
                    c++;
                    if (j == 0)
                    {                       
                        break;
                    }
                }
                c++;
                if (i < j)
                {
                    s++;
                    Swap(ref mas[i], ref mas[j]);
                }
                else
                {
                    break;
                }
            }
            s++;
            Swap(ref mas[i], ref mas[rigtpos]);
            
            return i;
        }
        static void Merge(int [] mas, int leftpos, int midpos, int rightpos, ref int c, ref int s)
        {
            int[] temp = new int[rightpos - leftpos + 1];
            int i = leftpos, j = midpos + 1;
            int k = 0;
            for(k=0; k<temp.Length; k++)
            {
                c++;
                if (i > midpos)
                {
                    s++;
                    temp[k] = mas[j++];
                }
                else if (j > rightpos)
                {
                    s++;
                    temp[k] = mas[i++];
                }
                else
                {
                    c++;
                    s++;
                    temp[k] = (mas[i] > mas[j]) ? mas[i++] : mas[j++];
                }
            }
            k = 0;
            i = leftpos;
            while (k < temp.Length && i <= rightpos)
            {
                c++;
                mas[i++] = temp[k++];
            }            
        }
        static void MergeSort(int [] mas, int leftpos, int rightpos, ref int c, ref int s)
        {
            if (rightpos <= leftpos)
            {
                return;
            }
            int midpos = (leftpos + rightpos) / 2;
            MergeSort(mas, leftpos, midpos, ref c, ref s);
            MergeSort(mas, midpos + 1, rightpos, ref c, ref s);
            Merge(mas, leftpos, midpos, rightpos, ref c, ref s);
        } 
        static void QuickSort (int [] mas, int leftpos, int rightpos, ref int c, ref int s)
        {
            if (rightpos <= leftpos)
            {
                return;
            }
            int p = Partition(mas, leftpos, rightpos, ref c, ref s);
            QuickSort(mas, leftpos, p - 1, ref c, ref s);
            QuickSort(mas, p + 1, rightpos, ref c, ref s);
        }
        static void HeapSort(int [] mas, ref int c, ref int s)
        {
            int leftpos = 0;
            int rightpos = mas.Length-1;
            int N = rightpos - leftpos + 1;
            for (int i=mas.Length-1; i>=0; i--)
            {
                Heapify(mas, i, N, ref c, ref s);
            }
            while (N > 0)
            {
                Swap(ref mas[leftpos], ref mas[N - 1]);
                Heapify(mas, leftpos, --N, ref c, ref s);
            }
        }
        static void Heapify(int [] mas, int i, int N, ref int c, ref int s)
        {
            while (2 * i + 1 < N)
            {
                int k = 2 * i + 1;
                c++;
                if (2 * i + 2 < N && mas[2 * i + 2] <= mas[k])
                {
                    k = 2 * i + 2;
                }
                c++;
                if (mas[i] > mas[k])
                {
                    s++;
                    Swap(ref mas[i], ref mas[k]);
                    i = k;
                }
                else
                {
                    break;
                }
            }
        }
        static void HeapifyUp(int[] mas, int i, int N)
        {
            while (2 * i + 1 < N)
            {
                int k = 2 * i + 1;
                if (2 * i + 2 < N && mas[2 * i + 2] >= mas[k])
                {
                    k = 2 * i + 2;
                }
                if (mas[i] > mas[k])
                {
                    Swap(ref mas[i], ref mas[k]);
                    i = k;
                }
                else
                {
                    break;
                }
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        
        static void CC()
        {
            Console.Clear();
        }
        static void CR()
        {
            Console.ReadKey();
        }
        static void TestHeapSort(int[] array, int counter, int swaps)
        {
            DateTime start = DateTime.Now;
            HeapSort(array, ref counter, ref swaps);
            DateTime end = DateTime.Now;
            TimeSpan result = end.Subtract(start);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Время работы: {result.Minutes}:{result.Seconds}:{result.Milliseconds}");
            Console.WriteLine("Число сравнений: " + counter);
            Console.WriteLine("Число перестановок: " + swaps);
        }
        static int[] InitLowerSortedArray()
        {
            Random random = new Random();
            int[] array = new int[100000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            int leftpos = 0;
            int rightpos = array.Length - 1;
            int N = rightpos - leftpos + 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                HeapifyUp(array, i, N);
            }
            while (N > 0)
            {
                Swap(ref array[leftpos], ref array[N - 1]);
                Heapify(array, leftpos, --N, ref leftpos, ref rightpos);
            }
            return array;
        }
        static int[] InitCasualArray()
        {
            Random random = new Random();
            int[] array = new int[100000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            return array;
        }
        static int[] InitUpperSortedArray()
        {
            Random random = new Random();
            int[] array = new int[100000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            int leftpos = 0;
            int rightpos = array.Length - 1;
            int N = rightpos - leftpos + 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                HeapifyUp(array, i, N);
            }
            while (N > 0)
            {
                Swap(ref array[leftpos], ref array[N - 1]);
                HeapifyUp(array, leftpos, --N);
            }
            return array;
        }        
        static void TestQuickSort(int[] array, int counter, int swaps)
        {
            DateTime start = DateTime.Now;
            QuickSort(array, 0, array.Length - 1, ref  counter, ref swaps );
            DateTime end = DateTime.Now;
            TimeSpan result = end.Subtract(start);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Время работы: {result.Minutes}:{result.Seconds}:{result.Milliseconds}");
            Console.WriteLine("Число сравнений: " + counter);
            Console.WriteLine("Число перестановок: " + swaps);
        }        
        static void TestMergeSort(int[] array, int counter, int swaps)
        {
            DateTime start = DateTime.Now;
            MergeSort(array, 0, array.Length-1, ref counter, ref swaps);
            DateTime end = DateTime.Now;
            TimeSpan result = end.Subtract(start);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Время работы: {result.Minutes}:{result.Seconds}:{result.Milliseconds}");
            Console.WriteLine("Число сравнений: " + counter);
            Console.WriteLine("Число перестановок: " + swaps);
        }                
        static void Checker(int[] arr)
        {
            bool flag = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Массив отсортирован верно");
            }
            else
            {
                Console.WriteLine("Массив отсортирован неверно");
            }
        }
        static void ToFile(int[] mas)
        {
            FileStream file = new FileStream(@"d:\L10\10.1\sorted.dat", FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(file);
            for (int i = 0; i < mas.Length; i++)
            {
                writer.Write(mas[i]);
            }
            writer.Close();
        }               
    }

}



