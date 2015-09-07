using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._15_dynamic_programming
{
    class KnapSack
    {
        Func<int, int, int> Max = (v1, v2) => v1 > v2 ? v1 : v2;

        public void Start()
        {
            Item[] items = { 
                                new Item(){Value = 5, Weight = 3},
                                new Item(){Value = 3, Weight = 2},
                                new Item(){Value = 4, Weight = 1}
                           };

            int w = 5;
            List<Item> usedItems;
            Console.WriteLine(KnapSackV2(w,items, out usedItems));

        }

        public int KnapSackV1(int capacity, Item[] items, int n) {
            if (n == -1 || capacity == 0)
                return 0;

            // If weight of the nth item is more than Knapsack capacity W, then
            // this item cannot be included in the optimal solution
            if (items[n].Weight > capacity)
                return KnapSackV1(capacity, items, n - 1);

            // Return the maximum of two cases: (1) nth item included (2) not included
            else 
                return Max(
                    items[n].Value + KnapSackV1(capacity - items[n].Weight, items, n - 1),
                    KnapSackV1(capacity, items, n - 1)
                    );
        }

        // optimized, using Dynamic programming
        //https://www.youtube.com/watch?v=EH6h7WA7sDw
        public int KnapSackV2(int capacity, Item[] items, out List<Item> usedItems)
        {
            // shift items to start in index 1
            Item[] nitems = new Item[items.Length + 1];
            nitems[0] = null;
            items.CopyTo(nitems, 1);

            int[,] V = new int[nitems.Length, capacity + 1];
            int[,] keep = new int[nitems.Length, capacity + 1];

            for (int r = 0; r < nitems.Length; r++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    if (r == 0 || c == 0) // zero
                    {
                        V[r, c] = keep[r,c] = 0;
                    }
                    else if (nitems[r].Weight <= c) // has space enough
                    {
                        // Max between(item included + the remain value in the row above, item not included copy the value in the above row)
                        V[r, c] = Max(nitems[r].Value + V[r - 1, c - nitems[r].Weight], V[r - 1, c]);
                        keep[r, c] = V[r - 1, c] > nitems[r].Value + V[r - 1, c - nitems[r].Weight] ? 0 : 1;
                    }
                    else  // has not space enough
                    {
                        V[r, c] = V[r - 1, c]; // copy the value from the above row
                        keep[r, c] = 0;
                    }
                }
            }

            //-----------------------------------------------
            // now lets create the list of itens
            usedItems = new List<Item>(); // initialize the out parameter

            int I = nitems.Length - 1; //item cursor
            int W = capacity;

            while (I > 0)
            {
                // it is 1 and has space enough to pack item
                if (keep[I, W] == 1 && W >= nitems[I].Weight)
                {
                    W -= nitems[I].Weight;
                    usedItems.Add(nitems[I]);
                }
                I--;
            }

            return V[nitems.Length -1, capacity];
        }

    }

    class Item{
        public int Value, Weight;
    }
}
