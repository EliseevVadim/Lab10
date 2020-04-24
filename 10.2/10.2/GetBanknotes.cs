using System;
using System.Collections.Generic;
using System.Text;

namespace _10._2
{
    class GetBanknotes
    {
        public int [] InitBanknoteArray()
        {
            Random random = new Random();
            int[] mas = { 1, 2, 5, 10, 20, 50, 100 };
            int[] banknotes = new int[100];
            for (int i=0; i<banknotes.Length; i++)
            {
                banknotes[i] = mas[random.Next(0, 7)];
            }
            return banknotes;
        }
        public int[] Sort(int [] arr)
        {
            int min = 0, max = 0;
            for (int i=0; i<=arr.Length-1; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                else if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            int bn = max - min + 1;
            int[] mas = new int[bn];
            for(int i=0; i<arr.Length; i++)
            {
                mas[arr[i] - min]++;
            }
            int pos = 0;
            for(int i=min; i<=max; i++)
            {
                for (int j=0; j<mas[i-min]; j++)
                {
                    arr[pos++] = i;
                }
            }
            return arr;
        }
        public void Print(int [] mas)
        {
            foreach(int n in mas)
            {
                Console.WriteLine(n);
            }
        }
    }
}
