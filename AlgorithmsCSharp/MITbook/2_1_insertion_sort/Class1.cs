using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._2_1_insertion_sort
{
    class Class1
    {
        public void Start()
        {
            //int[] array = InsertionSort(new int[] { 3, 6, 5, 7, 1 });
            int[] array = InsertionSort(new int[] { 3, 6, 5, 7, 1 }, true);
            foreach (int item in array)
                Console.WriteLine(item);

            Console.WriteLine(LinearSearch(new int[] { 9, 5, 4 }, 5));
        }

        public int[] InsertionSort(int[] input, bool desc = false)
        {
            Func<int, int, bool> LoopComparer = null;
            if (desc)
                LoopComparer = (x, y) => x < y;
            else
                LoopComparer = (x, y) => x > y;

            for (int i = 1; i < input.Length; i++)
            {
                int key = input[i];
                int j = i - 1;
                while (j >= 0 && LoopComparer(input[j], key))
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j + 1] = key;
            }
            return input;
        }

        public int? LinearSearch(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    return i;
            }

            return null;
        }

    }
}
