using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MITbook._15_1_cutrod
{
    class CutRodProblem
    {
        Func<int, int, int> Max = (v1, v2) => v1 > v2 ? v1 : v2;

        public void Start()
        {
            int ans = CutRod(new int[] { 0, 2, 5, 7, 8, 8 }, 5);
            Console.WriteLine(ans);
        }

        public int CutRod(int[] prices, int len)
        {
            if (len == 0) return 0;

            int aux = int.MinValue;

            for (int i = 1; i <= len; i++)
            {
                aux = Max(aux, prices[i] + CutRod(prices, len - i));
            }

            return aux;

        }

    }
}
