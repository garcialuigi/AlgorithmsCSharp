using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._15_dynamic_programming.top_coder_beginner
{
    class Elementary
    {
        Func<int, int, int> Max = (val1, val2) => val1 > val2 ? val1 : val2;

        public void Start()
        {
            Console.WriteLine(LengthLongestIncreasingSequence(new int[] { 5, 3, 4, 8, 6, 7 }));
        }

        public int LengthLongestIncreasingSequence(int[] seq) {
            int[] S = new int[seq.Length];
            for (int i = 0; i < S.Length; i++)
            {
                S[i] = 1;
                for (int j = i-1; j >= 0; j--)
                    if (seq[j] <= seq[i])
                        S[i] = Max(S[i], S[j] + 1);
            }

            return S[seq.Length - 1];
        }

    }
}
