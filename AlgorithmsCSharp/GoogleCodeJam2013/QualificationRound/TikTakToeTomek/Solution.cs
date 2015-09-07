using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam2013.QualificationRound.TikTakToeTomek
{

    class Solution
    {
        public const string INPUT_PATH = "input.in";
        private string[] inputLines;
        private int iLine;

        public void Start()
        {
            inputLines = File.ReadAllText(INPUT_PATH).Split('\n');
            iLine = 0;
            // \/\/ STARTS HERE
            int T = RequestInput<int>();
            int tests = 0;
            StringBuilder outputText = new StringBuilder();
            while (tests < T)
            {
                bool somebodyWon = false;
                bool thereIsDots = false;
                char winnerChar = '.';
                string[] nonsfSeqs = new string[6];

                for (int i = 0; i < 4; i++)
                {
                    string line = RequestInput<string>();
                    if (!somebodyWon)
                    {
                        if (!thereIsDots && line.Contains('.'))
                            thereIsDots = true;

                        if (CheckSequence(line, out winnerChar))
                        {
                            somebodyWon = true;
                        }
                        nonsfSeqs[0] += line[0];
                        nonsfSeqs[1] += line[1];
                        nonsfSeqs[2] += line[2];
                        nonsfSeqs[3] += line[3];
                        nonsfSeqs[4] += line[i]; // diagonal \
                        nonsfSeqs[5] += line[3 - i]; // diagonal /
                    }
                }

                // jump the blank line
                RequestInput<string>();

                if (!somebodyWon)
                {
                    foreach (string item in nonsfSeqs)
                    {
                        if (CheckSequence(item, out winnerChar))
                        {
                            somebodyWon = true;
                            break;
                        }
                    }
                }

                outputText.Append("Case #");
                outputText.Append(tests + 1);
                outputText.Append(": ");
                if (somebodyWon)
                    outputText.Append(winnerChar + " won");
                else if (thereIsDots)
                    outputText.Append("Game has not completed");
                else
                    outputText.Append("Draw");
                outputText.Append("\n");

                tests++;

            }

            File.WriteAllText("output.in", outputText.ToString());
            Console.WriteLine(outputText.ToString());
        }

        public bool CheckSequence(string seq, out char winnerChar)
        {
            winnerChar = '.';
            char c = seq[0];
            if (c == 'T')
                c = seq[1];
            if (c == '.')
                return false;
            if ((!seq.Contains('.')) && (c == 'X' && !seq.Contains('O') || c == 'O' && !seq.Contains('X')))
            {
                winnerChar = c;
                return true;
            }
            else
            {
                return false;
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