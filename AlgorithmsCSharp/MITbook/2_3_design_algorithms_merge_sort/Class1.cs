using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._2_3_design_algorithms_merge_sort
{
    class Class1
    {
        public void Start()
        {
            //int[] array = SelectionSort(new int[] { 3, 6, 5, 7, 1 });
            //foreach (int item in array)
            //    Console.WriteLine(item);
            int[] a = new int[] { 3, 6, 5, 7, 1, 2, 9, 8 ,4};
            MergeSort(a, 0, 8);
            //Merge(new int[] { 3, 6, 5, 7, 1, 2, 9, 8 }, 0, 3, 7);
            foreach (int item in a)
                Console.WriteLine(item);
        }

        public void MergeSort(int[] array, int start, int end)
        {
            // to understand what is going on, check: https://www.youtube.com/watch?v=TzeBrDU-JaY
            if(start < end){
                int middle = (start + end) / 2;
                MergeSort(array, start, middle);
                MergeSort(array, middle + 1, end);
                Merge(array, start, middle, end);
            }
            // the else is the exit point
        }

        public void Merge(int[] array, int start, int middle, int end) {
            int[] left = new int[middle - start + 2];
            int[] right = new int[end - middle + 1];
            Array.Copy(array, start, left, 0, middle - start + 1);
            Array.Copy(array, middle + 1, right, 0, end - middle);
            left[left.Length - 1] = int.MaxValue;
            right[right.Length - 1] = int.MaxValue;
            int i = 0, j = 0;
            for (int k = start; k <= end; k++)
            {
                if (left[i] <= right[j])
                    array[k] = left[i++];
                else
                    array[k] = right[j++];
            }
        }

    }
}
