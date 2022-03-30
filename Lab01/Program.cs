using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab01
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Size("Medium", "Random");
        }

        static void Test(int[] a)
        {
            int[] a1 = new int[a.Length];
            Stopwatch stopWatch = new Stopwatch();
            double[] times = new double[10];

            for (int i = 0; i < 10; i++)
            {
                Array.Copy(a, a1, a.Length);

                stopWatch.Start();
                sortingAlgorithms.insertionSort(a1);
                stopWatch.Stop();

                TimeSpan time = stopWatch.Elapsed;
                times[i] = time.Milliseconds;
                Console.WriteLine(time);
                Console.WriteLine(time.Ticks);
                stopWatch.Reset();

            }
            foreach(double h in times)
                Console.WriteLine(h);
            standardDeviation(times);
        }
        static void standardDeviation(double[] times)
        {
            if (times.Any())
            {
                double average = (times.Average()) / 100;
                double sum = times.Sum(d => Math.Pow(d - average, 2));
                double sD = (Math.Sqrt(sum) / times.Count()) / 1000;
                Console.Write($"Insertion Sort: {Math.Round(average, 5)}s +/- ");
                Console.WriteLine($"{Math.Round(sD, 5)}s");    
            }
        }
        static void Size(string size, string type)
        {
            int[] a;
            switch (size)
            {
                case "Small":
                    Test(a = generate(type, 100, 100));
                    break;

                case "Medium":
                    Test(a = generate(type, 1000, 10000));
                    break;

                case "Big":
                    Test(a = generate(type, 100000, 100000));

                    break;
            }
        }
        static int[] generate(string type, int size, int variables)
        {
            int[] a;
            switch (type)
            {
                case "Random":
                    a = Generators.GenerateRandom(size, 0, variables);
                    return a;

                case "Sorted":
                    a = Generators.GenerateSorted(size, 0, variables);
                    return a;

                case "Reversed":
                    a = Generators.GenerateReversed(size, 0, variables);
                    return a;

                case "AlmostSorted":
                    a = Generators.GenerateAlmostSorted(size, 0, variables);
                    return a;
                    
                case "FewUnique":   
                    a = Generators.GeneratefewUnique(size, 0, size);
                    return a;

            }
            return null;
        }
    }
}
