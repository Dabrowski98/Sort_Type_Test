using System;
using System.Diagnostics;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("Big", "Reversed");
        }

        static void Tests(int[] a)
        {
            int[] a1 = new int[a.Length];
            Stopwatch stopWatch = new Stopwatch();

            for (int i = 0; i < 10; i++)
            {
                Array.Copy(a, a1, a.Length);
                stopWatch.Start();
                sortingAlgoritms.insertionSort(a);
                stopWatch.Stop();
                Console.WriteLine(stopWatch.Elapsed);
            }
        }

        static void Test(string size, string type)
        {
            int[] a;
            switch (size)
            {
                case "Small":
                    Tests(a = generateSmall(type));
                    break;

                case "Medium":
                    Tests(a = generateMedium(type));
                    break;

                case "Big":
                    Tests(a = generateBig(type));
                    break;
            }
        }
        static int[] generateSmall(string type)
        {
            int[] a;
            switch (type)
            {
                case "Random":
                    a = Generators.GenerateRandom(10, 0, 100);
                    return a;

                case "Sorted":
                    a = Generators.GenerateSorted(10, 0, 100);
                    return a;

                case "Reversed":
                    a = Generators.GenerateReversed(10, 0, 100);
                    return a;

                case "AlmostSorted":
                    a = Generators.GenerateAlmostSorted(10, 0, 100);
                    return a;
                    
                case "FewUnique":   
                    a = Generators.GeneratefewUnique(10, 0, 10);
                    return a;

            }
            return null;
        }

        static int[] generateMedium(string type)
        {
            int[] a;
            switch (type)
            {
                case "Random":
                    a = Generators.GenerateRandom(1000, 0, 10000);
                    return a;

                case "Sorted":
                    a = Generators.GenerateSorted(1000, 0, 10000);
                    return a;

                case "Reversed":
                    a = Generators.GenerateReversed(1000, 0, 10000);
                    return a;

                case "AlmostSorted":
                    a = Generators.GenerateAlmostSorted(1000, 0, 10000);
                    return a;

                case "FewUnique":
                    a = Generators.GeneratefewUnique(1000, 0, 1000);
                    return a;
            }
            return null;
        }
        static int[] generateBig(string type)
        {
            int[] a;
            switch (type)
            {
                case "Random":
                    a = Generators.GenerateRandom(100000, 0, 1000000);
                    return a;

                case "Sorted":
                    a = Generators.GenerateSorted(100000, 0, 1000000);
                    return a;

                case "Reversed":
                    a = Generators.GenerateReversed(100000, 0, 1000000);
                    return a;

                case "AlmostSorted":
                    a = Generators.GenerateAlmostSorted(100000, 0, 1000000);
                    return a;

                case "FewUnique":
                    a = Generators.GeneratefewUnique(100000, 0, 100000);
                    return a;
            }
            return null;
        }
    }
}
