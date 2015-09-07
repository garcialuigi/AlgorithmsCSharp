using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._2_2_selection_sort
{
    class Class1
    {
        public void Start() {
            int[] array = SelectionSort(new int[] { 3, 6, 5, 7, 1 });
            foreach (int item in array)
                Console.WriteLine(item);
        }

        public int[] SelectionSort(int[] array) {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[iMin]) // if we invert the comparation, we get the desc algorithm
                        iMin = j;
                }

                if(iMin != i){
                    int temp = array[i];
                    array[i] = array[iMin];
                    array[iMin] = temp;
                }
            }
            return array;
        }

    }
}
