using System;
using System.Collections.Generic;

namespace Lab01
{
    public class Generator
    {
        public static int[] GenerateRandom(int size, int minVal, int maxVal)
        {
            int[] a = new int[size];
            for (int i = 0; i < size; i++)
            {
                var losowe = new Random();
                a[i] = losowe.Next(minVal, maxVal);
                Console.WriteLine($"GR {i}: {a[i]}");
            }
            Console.WriteLine("");
            return a;
        }

        public static int[] GenerateSorted(int size, int minVal, int maxVal)
        {
            int[] a = GenerateRandom(size, minVal, maxVal);
            Array.Sort(a);
            return a;
        }

        public static int[] GenerateReversed(int size, int minVal, int maxVal)
        {
            int[] a = GenerateSorted(size, minVal, maxVal);
            Array.Reverse(a);
            return a;
        }

        public static int[] GenerateAlmostSorted(int size, int minVal, int maxVal)
        {
            int[] a = GenerateRandom(size, minVal, maxVal);
            int[] b = new int[size];
            int temp;
            bool done = false;
            int licznik = 0;

            do
            {
                for (int i = 0; i < a.Length; i++)
                {

                    if (i != size - 1 && a[i] > a[i + 1])
                    {
                        temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        licznik = 0;
                    }

                    if (i != size - 1 && a[i] <= a[i + 1])
                        licznik++;

                    if (licznik % size == 0)
                        done = true;
                }
            } while (done == false);

            for (int i = 0; i < size; i++)
                Console.WriteLine($"A {i} = {a[i]}");

            return a;
        }
    }
}

