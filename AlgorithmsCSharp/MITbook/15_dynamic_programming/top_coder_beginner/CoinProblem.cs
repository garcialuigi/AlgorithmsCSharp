using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._15_dynamic_programming.top_coder_beginner
{
    class CoinProblem
    {
        Func<int, int, int> Min = (val1, val2) => val1 < val2 ? val1 : val2;

        public void Start()
        {
            Console.WriteLine(MinNumberOfCoins(new int []{1,3,5}, 11));      
        }

        public int MinNumberOfCoins(int[] coins, int totalSum) {
            int[] mins = new int[totalSum + 1]; // including space to the 0 value
            mins[0] = 0; // the zero part of the table
            for (int i = 1; i <= totalSum; i++)
            {
                mins[i] = int.MaxValue;// infinity - greater than anything
                for (int j = 0; j < coins.Length; j++)
                    if(coins[j] <= i) // if the coin fits 
                        mins[i] = Min(mins[i], mins[i - coins[j]] + 1); // get the min between the current value and the new value(remainder num of coins + 1{the coin to be added})
            }

            return mins[totalSum];
        }
    }
}
