using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Heaps are also usefull to create efficient priority queues.
 * A priority queue is a data structure for maintaining a set S of elements, each
 * with an associated value called a key. 
 * 
 * A Heap is actually an array, but you work with it picturing a binary tree.
 * 
 * A max-priority queue supports the following
 * operations:
 * 
 * INSERT.S; x/ inserts the element x into the set S, which is equivalent to the operation
 * S D S [ fxg.
 * MAXIMUM.S / returns the element of S with the largest key.
 * EXTRACT-MAX.S / removes and returns the element of S with the largest key.
 * INCREASE-KEY.S; x; k/ increases the value of element x’s key to the new value k,
 * which is assumed to be at least as large as x’s current key value.
 * 
 * Among their other applications, we can use max-priority queues to schedule
 * jobs on a shared computer.
 * 
 * Alternatively, a min-priority queue supports the operations INSERT, MINIMUM,
 * EXTRACT-MIN, and DECREASE-KEY. A min-priority queue can be used in an
 * event-driven simulator
 */

namespace MITbook._6_heaps
{

    class Heap
    {
        private int[] items;
        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public int this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                this.items[index] = value;
            }
        }

        public Heap(int[] array)
        {
            this.length = array.Length;
            // mount the array ignoring the 0 item
            this.items = new int[length + 1];
            Array.Copy(array, 0, this.items, 1, length);

            BuildMaxHeap();
        }

        private void BuildMaxHeap()
        {
            // just int the elements from to middle down to 1
            // cause the rest is leaves
            for (int i = (length) / 2; i >= 1; i--)
            {
                MaxHeapify(i);
            }
        }

        public void MaxHeapify(int cursor)
        {
            int iLeft = IndexLeftChild(cursor);
            int iRigth = IndexRightChild(cursor);
            int largest = 0;

            // discover the largest between the current, the left child and the right child
            if (iLeft <= length && items[iLeft] > items[cursor])
                largest = iLeft;
            else
                largest = cursor;
            if (iRigth <= length && items[iRigth] > items[largest])
                largest = iRigth;
           
            if (largest != cursor)
            {
                int aux = items[cursor];
                items[cursor] = items[largest];
                items[largest] = aux;
                MaxHeapify(largest);
            }
            // else would be the base case(where you exit the recursivety/"pops" everything)
        }

        private int IndexParent(int i)
        {
            return i / 2;
        }
        private int IndexLeftChild(int i)
        {
            return 2 * i;
        }
        private int IndexRightChild(int i)
        {
            return IndexLeftChild(i) + 1;
        }

    }
}
