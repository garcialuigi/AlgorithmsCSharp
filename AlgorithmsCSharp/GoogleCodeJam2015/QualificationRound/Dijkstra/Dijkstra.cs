using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam2015.QualificationRound.Dijkstra
{
    class Dijkstra
    {
        public string[,] _ijk = new string[4, 4]{
            {"+1","+i","+j","+k"},
            {"+i","-1","+k","-j"},
            {"+j","-k","-1","+i"},
            {"+k","+j","-i","-1"}
        };

        public void Start()
        {
            int T = RequestInput<int>();
            for (int t = 1; t <= T; t++)
            {
                string[] strs = RequestInput<string>().Split(' ');
                string seq = RequestInput<string>();
                Print("Case #" + t + ": " + Verificate(Int32.Parse(strs[0]), Int32.Parse(strs[1]), seq) + "\n");
            }
        }

        public string Verificate(int L, int X, string subExpression)
        {
            if (subExpression == "ijk")
            {
                return "YES";
            }
            /*if(L * X > 100 && X > 4){
                X = X % 4;
                if (X == 0)
                    X = 4;
                X += 4;
            }*/


            string expression = "";
            for (int i = 0; i < X; i++)
                expression += subExpression;

            string solution = MultiplyExpression(expression);

            if (solution == "-1")
            {
                bool canGenerateI = false;
                bool canGenerateJ = false;
                bool canGenerateK = false;

                int v = 0;
                if (expression.Contains("i"))
                    v++;
                if (expression.Contains("j"))
                    v++;
                if (expression.Contains("k"))
                    v++;

                if (v >= 2)
                    return "YES";
            }

            return "NO";

        }

        public string MultiplyExpression(string expression)
        {
            string currSolution = "+" + expression[0];
            if (expression.Length > 1)
            {
                currSolution = Multiply("+" + expression[0], "+" + expression[1]);
                for (int i = 2; i < expression.Length; i++)
                {
                    currSolution = Multiply(currSolution, "+" + expression[i]);
                }
            }
            return currSolution;
        }

        public string Multiply(string arg0, string arg1)
        {
            bool invert = false;
            if (arg0[0] != arg1[0])
                invert = true;
            string result = _ijk[ParseToTableIndex(arg0[1]), ParseToTableIndex(arg1[1])];
            if (invert)
            {
                if (result[0] == '-')
                    result = result.Replace('-', '+');
                else
                    result = result.Replace('+', '-');
            }
            return result;
        }

        public int ParseToTableIndex(char str)
        {
            switch (str)
            {
                case '1':
                    return 0;
                case 'i':
                    return 1;
                case 'j':
                    return 2;
                case 'k':
                    return 3;
            }
            return -1;
        }

        public void Print(string value)
        {
            Console.WriteLine(value);
        }

        public T RequestInput<T>()
        {
            string input = "";

            input = Console.ReadLine();

            if (typeof(T) == typeof(string))
                return (T)(object)input;
            return (T)Convert.ChangeType(input, typeof(T));
        }

    }
}
