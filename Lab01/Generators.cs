using System;
using System.Collections;

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
            var firstRandomization = new Random();
            var secondRandomization = new Random();
            int first = firstRandomization.Next(0, size);
            int second = secondRandomization.Next(0, size);
            var used = new ArrayList();
            double multiplier = 0.02; // 0.02 = 4% of values wont in order.

            if (size < 10 && multiplier <= 0.02)
                multiplier = multiplier * 10;

            for (int i = 0; i < Math.Ceiling(size * multiplier); i++) 
            {
                while (used.Contains(first))
                    first = firstRandomization.Next(0, size);

                used.Add(first);

                while (used.Contains(second))
                    second = secondRandomization.Next(0, size);

                used.Add(second);

                if (a[first] != a[second])
                {
                    temp = a[first];
                    a[first] = a[second];
                    a[second] = temp;
                }
                
            }


            return a;

        }

        public static int[] GeneratefewUnique(int size, int minVal, int maxVal)
        {
                int[] a = GenerateRandom(size, minVal, maxVal);

                return a;
            
        }
    }
}

