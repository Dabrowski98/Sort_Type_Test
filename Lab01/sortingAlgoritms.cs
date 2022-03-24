using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class sortingAlgoritms
    {

        public static void insertionSort(int[] a)
        {

            for (int i = 1; i < a.Length; i++)
            {
                int actual = a[i];
                int b = i - 1;
                
                while (b >= 0 && actual < a[b])
                {
                    a[b + 1] = a[b];
                    b--;
                }
                a[b + 1] = actual;
            }
        }

        public static void mergeSort(int[] a)
        {
            int arrayLength = a.Length;
            if (a.Length <= 1) return;

            int middle = arrayLength / 2;
            int[] left = new int[middle];
            int[] right = new int[arrayLength - middle];
            int i = 0;
            int j = 0;

            for (i = 0; i < arrayLength; i++)
            {

            if (i < middle)
                left[i] = a[i];

            else
                {
                right[j] = a[i];
                j++;
                }
            }
            mergeSort(left);
            mergeSort(right);
            merge(left, right, a);
        }

        private static void merge(int[] left, int[] right, int[] a)
        {
            int leftSize = a.Length / 2;
            int rightSize = a.Length - leftSize;
            int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize)
            {
                if (left[l] < right[r])
                {
                    a[i] = left[l];
                    i++;
                    l++;
                }
                else
                {
                    a[i] = right[r];
                    i++;
                    r++;
                }
            }
            while (l < leftSize)
            {
                a[i] = left[l];
                i++;
                l++;
            }

            while (r < rightSize)
            {
                a[i] = right[r];
                i++;
                r++;
            }
            


        }

        public static void quickSort(int[] a)
        {
            int arrayLength = a.Length;
            int pivot = a[arrayLength - 1];
            int j = 0;
            int temp = 0;

            for (int i = -1; i < arrayLength - 1;)
            {
                 Console.Write($"i = {i} a j = {j}");
                

                if (a[j] > pivot && j != arrayLength - 1)
                {
                    j++;
                    Console.WriteLine();
                    foreach (int liczba in a)
                        Console.Write(liczba + "    ");

                }

                else if (a[j] <= pivot && j != arrayLength - 1)
                {
                    i++;
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    j++;
                    Console.WriteLine();
                    foreach (int liczba in a)
                        Console.Write(liczba + "    ");
                }

                else if (j == arrayLength - 1 && a[j] <= pivot)
                    break;

            }
        }
    }
}
