using System;
using System.Diagnostics;
using System.Linq;

namespace Lab01
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int menu = -1;

            do
            {
                Console.WriteLine(" | Wybierz co chcesz zrobić\n\n1| Wybierz test manualnie\n2| Uruchom wszystkie testy\n9| Wyłącz program\n");
                Console.Write(" | Wybierz co chcesz zrobić: ");
                menu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (menu == 1)
                {
                    Console.WriteLine("1| Wybierz test manualnie");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nRozmiary i typy tablic: Small\t(100)\t\tRandom\n" +
                                      "\t\t\tMedium\t(1000)\t\tSorted\n" +
                                      "\t\t\tBig\t(10000)\t\tReversed\n" +
                                      "\t\t\t\t\t\tAlmostSorted\n" +
                                      "\t\t\t\t\t\tFewUnique\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n | Wybierz Rozmiar tablicy: ");
                    string size = Console.ReadLine().ToUpper();
                    Console.Write(" | Wybierz typ tablicy: ");
                    string type = Console.ReadLine().ToUpper();
                    Console.Clear();
                    Test(size, type);
                    Console.Write("\n | Wcisnij dowolny przycisk aby wrócić do Menu: ");
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (menu == 2)
                {
                    Console.WriteLine("2| Uruchom wszystkie testy");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nRozmiary tablic: Small (100) Medium (1000) Big (10000)\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    Test("SMALL", "RANDOM");
                    Test("SMALL", "SORTED");
                    Test("SMALL", "REVERSED");
                    Test("SMALL", "ALMOST_SORTED");
                    Test("SMALL", "FEW_UNIQUE");

                    Test("MEDIUM", "RANDOM");
                    Test("MEDIUM", "SORTED");
                    Test("MEDIUM", "REVERSED");
                    Test("MEDIUM", "ALMOST_SORTED");
                    Test("MEDIUM", "FEW_UNIQUE");

                    Test("BIG", "RANDOM");
                    Test("BIG", "SORTED");
                    Test("BIG", "REVERSED");
                    Test("BIG", "ALMOST_SORTED");
                    Test("BIG", "FEW_UNIQUE");

                    Console.Write("\n | Wcisnij dowolny przycisk aby wrócić do Menu: ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (menu == 9) Console.WriteLine("9| Wyłącz program");
            } while (menu != 9);
        }

        static void Test(string size, string arrayType)
        {
            int[] array;
            switch (size)
            {
                case "SMALL":
                    coloredTitle(size, arrayType);
                    stopwatchSorting(array = type(arrayType, 100, 1000));
                    Console.WriteLine();        
                    break;

                case "MEDIUM":
                    coloredTitle(size, arrayType);
                    stopwatchSorting(array = type(arrayType, 1000, 10000));
                    Console.WriteLine();
                    break;

                case "BIG":
                    coloredTitle(size, arrayType);
                    stopwatchSorting(array = type(arrayType, 10000, 100000));
                    Console.WriteLine();
                    break;
            }
        }
        static int[] type(string type, int size, int variables)
        {
            int[] a;
            switch (type)
            {
                case "RANDOM":
                    a = Generators.GenerateRandom(size, 0, variables);
                    return a;

                case "SORTED":
                    a = Generators.GenerateSorted(size, 0, variables);
                    return a;

                case "REVERSED":
                    a = Generators.GenerateReversed(size, 0, variables);
                    return a;

                case "ALMOST_SORTED":
                    a = Generators.GenerateAlmostSorted(size, 0, variables);
                    return a;

                case "FEW_UNIQUE":
                    a = Generators.GeneratefewUnique(size, 0, size);
                    return a;
            }
            return null;
        }
        static void stopwatchSorting(int[] a)
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
                            if (i == 0) Console.Write(" | Insertion Sort:          ");
                            stopWatch.Start();
                            sortingAlgorithms.insertionSort(a1);
                            stopWatch.Stop();
                            break;

                        case 1:
                            if (i == 0) Console.Write(" | Merge Sort:              ");
                            stopWatch.Start();
                            sortingAlgorithms.mergeSort(a1);
                            stopWatch.Stop();
                            break;

                        case 2:
                            if (i == 0) Console.Write(" | QuickSort Classical:     ");
                            stopWatch.Start();
                            sortingAlgorithms.quickSortClassical(a1);
                            stopWatch.Stop();
                            break;

                        case 3:
                            if (i == 0) Console.Write(" | QuickSort:               ");
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

        public static void coloredTitle(string size, string type)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" | {size} {type}: \n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
