using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class sortingAlgorithms
    {
        public static void printArray(int[] a)  //sortingAlgorithms.printArray(a);
        {
            foreach (double element in a)
            {
                Console.Write(element + "   ");
                Console.WriteLine("\n");
            }

        }
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
        private static int partition(int[] a, int low, int high)
        {

            int i = (low - 1);
            int pivot = a[high];
            int temp;

            for (int j = low; j <= high - 1; j++)
            {
                if (pivot > a[j])
                {
                    i++;
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
            temp = a[i + 1];
            a[i + 1] = a[high];
            a[high] = temp;
            return (i + 1);

        }
        private static void quickSortClassical(int[] a, int low, int high)
        {
            if (low < high)
            {
            int pi = partition(a, low, high);
            quickSortClassical(a, low, pi - 1);
            quickSortClassical(a, pi + 1, high);
            }
        }

        public static void quickSortClassical(int[] a)
        {
            quickSortClassical(a, 0, a.Length - 1);
        }

        public static void quickSort(int[] a)
        {
            Array.Sort(a);
        }

    }
}
