using System;
using System.Diagnostics;
using System.Linq;

namespace Lab01
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test("Small", "Random");
            Test("Small", "Sorted");
            Test("Small", "Reversed");
            Test("Small", "AlmostSorted");
            Test("Small", "FewUnique");

            Test("Medium", "Random");
            Test("Medium", "Sorted");
            Test("Medium", "Reversed");
            Test("Medium", "AlmostSorted");
            Test("Medium", "FewUnique");            
            
            Test("Big", "Random");
            Test("Big", "Sorted");
            Test("Big", "Reversed");
            Test("Big", "AlmostSorted");
            Test("Big", "FewUnique");
        }

        static void testFn(int[] a)
        {
            int[] a1 = new int[a.Length];
            Stopwatch stopWatch = new Stopwatch();
            double[] table = new double[10];

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Array.Copy(a, a1, a.Length);

                    switch (j)
                    { 
                        case 0:
                            if (i == 0) Console.Write("Insertion Sort:          ");
                            stopWatch.Start();
                            sortingAlgorithms.insertionSort(a1);
                            stopWatch.Stop();
                            break;

                        case 1:
                            if (i == 0) Console.Write("Merge Sort:              ");
                            stopWatch.Start();
                            sortingAlgorithms.mergeSort(a1);
                            stopWatch.Stop();
                            break;

                        case 2:
                            if (i == 0) Console.Write("QuickSort Classical:     ");
                            stopWatch.Start();
                            sortingAlgorithms.quickSortClassical(a1);
                            stopWatch.Stop();
                            break;

                        case 3:
                            if (i == 0) Console.Write("QuickSort:               ");
                            stopWatch.Start();
                            sortingAlgorithms.quickSort(a1);
                            stopWatch.Stop();
                            break;
                    }

                    TimeSpan time = stopWatch.Elapsed;
                    table[i] = time.TotalMilliseconds;
                    stopWatch.Reset();
                }
                Calc(table);
            }
        }


        static void Calc(double[] times)
        {
            if (times.Any())
            {
                double average = (times.Average()) / 1000;
                double sum = times.Sum(d => Math.Pow(d - average, 2));
                double calc = ((Math.Sqrt(sum) / times.Count()) / 1000);

                string sD = calc.ToString("F" + 6);
                string avg = average.ToString("F" + 6);
                Console.Write($"{avg}s +/- ");
                Console.WriteLine($"{sD}s");
                
            }
        }
        static void Test(string size, string type)
        {
            int[] a;
            switch (size)
            {
                case "Small":
                    printColored(size, type);
                    testFn(a = generate(type, 100, 1000));
                    Console.WriteLine();        
                    break;

                case "Medium":
                    printColored(size, type);
                    testFn(a = generate(type, 1000, 10000));
                    Console.WriteLine();
                    break;

                case "Big":
                    printColored(size, type);
                    testFn(a = generate(type, 10000, 100000));
                    Console.WriteLine();
                    break;
            }
        }

        public static void printColored(string size, string type)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{size} {type}: \n");
            Console.ForegroundColor = ConsoleColor.White;
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
