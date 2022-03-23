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
                int aktualna = a[i];
                int b = i - 1;
                
                while (b >= 0 && aktualna < a[b])
                {
                    a[b + 1] = a[b];
                    b--;
                }
                a[b + 1] = aktualna;
            }
        }

        public static void mergeSort(int[] a)
        {
            int arrayLength = a.Length;
            if (a.Length <= 1) return;

            int middle = arrayLength / 2;
            int[] left = new int[middle];
            int[] right = new int[arrayLength - middle];

            for (int i = 0; i < left.Length; i++)
            {

            if (i < middle)
                left[i] = a[i];

            else
                right[i] = a[i + left.Length];

            }
        }

        private static void merge(int[] left, int[] right, int[] array)
        {

        }
    }
}
