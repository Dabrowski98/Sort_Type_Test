using System;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            sortingAlgoritms.mergeSort(Generators.GenerateRandom(10, 0, 10));
        }

    }
}
