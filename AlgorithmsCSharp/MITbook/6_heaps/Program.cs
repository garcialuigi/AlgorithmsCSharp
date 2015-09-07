using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._6_heaps
{
    class Program
    {
        public void Start()
        {
            int[] array = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };
            //Heap heap = new Heap(array);
            int[] ret = HeapSort(array);
        }

        public int[] HeapSort(int[] array)
        {
            Heap heap = new Heap(array); // build max heap is called inside constructor
            LinkedList<int> ret = new LinkedList<int>();

            for (int i = heap.Length; i >= 2; i--)
            {
                // this is optional, you can put the element in a return
                // structure. I choosed the linkedlist, where I add the root
                // at the beginning.
                // If I change to AddLast I will get the descOrder
                ret.AddFirst(heap[1]);

                // swap, putting the root(biggest element) at the end, at some place that length-- 
                // will disconsider the element
                int temp = heap[1];
                heap[1] = heap[i];
                heap[i] = temp;
                heap.Length--;

                // now call the max heapify with the new root and disconsidering the previous root
                heap.MaxHeapify(1);
            }

            ret.AddFirst(heap[1]); // add what the loop dont touch 

            return ret.ToArray();
        }
    }
}
