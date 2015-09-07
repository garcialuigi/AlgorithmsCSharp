using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
A sequence of numbers is called a zig-zag sequence if the differences between successive numbers strictly alternate between positive and negative.
The first difference (if one exists) may be either positive or negative. A sequence with fewer than two elements is trivially a zig-zag sequence.
For example, 1,7,4,9,2,5 is a zig-zag sequence because the differences (6,-3,5,-7,3) are alternately positive and negative. 
In contrast, 1,4,7,2,5 and 1,7,4,5,5 are not zig-zag sequences, the first because its first two differences are positive and the second because 
its last difference is zero.
Given a sequence of integers, sequence, return the length of the longest subsequence of sequence that is a zig-zag sequence. 
A subsequence is obtained by deleting some number of elements (possibly zero) from the original sequence, leaving the remaining elements in 
their original order.
*/

namespace Tcc2013.Semifinal3.ZigZag
{
    class ZigZag
    {
        public Func<int, int, int> Max = (val0, val1) => val0 > val1 ? val0 : val1;

        public void Start()
        {
            Console.WriteLine(longestZigZag(new int[] { 374, 40, 854, 203, 203, 156, 362, 279, 812, 955, 600, 947, 978, 46, 100, 953, 670, 862, 568, 188, 67, 669, 810, 704, 52, 861, 49, 640, 370, 908, 477, 245, 413, 109, 659, 401, 483, 308, 609, 120, 249, 22, 176, 279, 23, 22, 617, 462, 459, 244 }));
            //longestZigZag(new int[] { 17,5,10,11,13,9 });
        }

        public int longestZigZag(int[] sequence)
        {
            int[,] S = new int[sequence.Length, 2];
            for (int i = 0; i < sequence.Length; i++)
            {
                S[i, 0] = S[i, 1] = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (sequence[j] > sequence[i]) // 0 = comes from up
                        S[i, 0] = Max(S[i, 0], S[j, 1] + 1); // max between the current, and the j number oposite sequence plus 1
                    else if (sequence[j] < sequence[i]) // 1 = comes from down
                        S[i, 1] = Max(S[i, 1], S[j, 0] + 1); // max between the current, and the j number oposite sequence plus 1
                    else // they are equal 
                    {
                        S[i, 0] = Max(S[i, 0], 1);
                        S[i, 1] = Max(S[i, 1], 1);
                    }
                }
            }

            //
            return Max(S[sequence.Length - 1, 0], S[sequence.Length - 1, 1]);
        }

    }
}
