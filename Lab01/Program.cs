using System;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = Generators.GenerateRandom(10, 0, 10);
            sortingAlgoritms.quickSort(a);
        }

    }
}
