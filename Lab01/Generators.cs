using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab01
{
    public static class Generators
    {
        public static int[] GenerateRandom(int size, int minVal, int maxVal)
        {
            int[] a = new int[size];
            for (int i = 0; i < size; i++)
            {
                var losowe = new Random();
                a[i] = losowe.Next(minVal, maxVal);
            }
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
            int[] a = GenerateSorted(size, minVal, maxVal);
            int temp;
            var firstRandom = new Random();
            var secondRandom = new Random();
            int first = firstRandom.Next(0, size); 
            int second = secondRandom.Next(0, size);
            var used = new ArrayList();

            for (int i = 0; i < Math.Ceiling(size*0.02); i++) // 0.02 = 4% of values wont be sorted.
            {
                while (used.Contains(first))
                    first = firstRandom.Next(0, size);

                used.Add(first);

                while (used.Contains(second))
                    second = secondRandom.Next(0, size);

                used.Add(second);

                if (a[first] != a[second])
                {
                    temp = a[first];
                    a[first] = a[second];
                    a[second] = temp;
                    Console.WriteLine(a[first]);
                    Console.WriteLine(a[second]);
                }

            }

            //for (int i = 0; i < size; i++)
            //    Console.WriteLine($"A {i} = {a[i]}");
            foreach(int x in a)
                Console.WriteLine(x);

            return a;
        }
    }
}

