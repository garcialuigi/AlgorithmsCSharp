using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam2009.QualificationRound.WelcomeToCodeJam
{
    class Program2
    {
        public const string INPUT_PATH = "input.in";
        public const string PHRASE = "welcome to code jam";

        private string[] inputLines;
        private int iLine;

        private Dictionary<char, List<Charactere>> chars;
        private int counter = 0;

        public void Start()
        {
            // read the input
            inputLines = File.ReadAllText(INPUT_PATH).Split('\n');
            iLine = 0;

            StringBuilder outputText = new StringBuilder();

            // tests count
            var N = RequestInput<int>();

            for (int t = 0; t < N; t++)
            {
                String input = RequestInput<string>(); ;
                int[,] array = new int[input.Length + 1, PHRASE.Length + 1];
                array[0, 0] = 1;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < PHRASE.Length; j++)
                    {
                        if (PHRASE[j] == input[i])
                        {
                            array[i + 1, j + 1] = (array[i, j] + array[i + 1, j + 1]) % 10000;
                        }
                        array[i + 1, j] = (array[i, j] + array[i + 1, j]) % 10000;
                    }
                }
                int result = 0;
                for (int i = 0; i <= input.Length; i++)
                {
                    result = (result + array[i, PHRASE.Length]) % 10000;
                }

                outputText.Append("Case #");
                outputText.Append(t + 1);
                outputText.Append(": ");
                outputText.Append(GenerateOutputNumber(result + ""));
                outputText.Append("\n");

            }

            File.WriteAllText("output.in", outputText.ToString());
            Console.WriteLine(outputText.ToString());
            Console.ReadLine();

        }

        public string GenerateOutputNumber(string number)
        {
            var a = 4 - number.Length;
            if (a < 0)
                return number.Substring(number.Length - 4, 4);
            else
            {
                string returne = "";
                for (int i = 0; i < a; i++)
                {
                    returne += "0";
                }
                returne += number;
                return returne;
            }
        }

        public T RequestInput<T>()
        {
            //string input = Console.ReadLine();
            string input = inputLines[iLine++];
            if (typeof(T) == typeof(string))
                return (T)(object)input;
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
}
