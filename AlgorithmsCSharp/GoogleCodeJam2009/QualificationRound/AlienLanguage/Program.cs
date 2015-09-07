using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam2009.QualificationRound.AlienLanguage
{
    class Program
    {
        public const string INPUT_PATH = "input.in";
        private string[] inputLines;
        private int iLine;

        public void Start()
        {
            inputLines = File.ReadAllText(INPUT_PATH).Split('\n');
            iLine = 0;
            // \/\/ STARTS HERE

            string[] headInput = RequestInput<string>().Split(' ');
            int L = Int32.Parse(headInput[0]);
            int knownsCount = Int32.Parse(headInput[1]);
            int tokensCount = Int32.Parse(headInput[2]);

            List<string> knowns = new List<string>();
            for (int i = 0; i < knownsCount; i++)
            {
                knowns.Add(RequestInput<string>());
            }

            List<Token> tokens = new List<Token>();
            for (int i = 0; i < tokensCount; i++)
            {
                tokens.Add(new Token(chars: RequestInput<string>(), L: L));
            }

            StringBuilder outputText = new StringBuilder();
            int matchsCounter = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                outputText.Append("Case #");
                outputText.Append(i + 1);
                outputText.Append(": ");
                foreach (string item in knowns)
                {
                    if (tokens[i].MatchesWord(item))
                        matchsCounter++;
                }
                outputText.Append(matchsCounter);
                outputText.Append("\n");

                matchsCounter = 0;
            }

            File.WriteAllText("output.in", outputText.ToString());
            Console.WriteLine(outputText.ToString());
            Console.ReadLine();
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

    public class Token
    {

        private List<List<string>> tokenList;

        public Token(string chars, int L)
        {
            // CODE TO GENERATE THE TOKEN LIST
            tokenList = new List<List<string>>();
            for (int i = 0; i < L; i++)
                tokenList.Add(new List<string>());

            bool isOpen = false;
            bool ignoreIncrementOnClose = false;
            int index = 0;
            if (chars[0] == '(')
            {
                chars = chars.Remove(0, 1);
                isOpen = true;
            }
            else
            {
                ignoreIncrementOnClose = true; // to the first element
            }

            foreach (char c in chars)
            {
                if (c == '(')
                {
                    isOpen = true;
                    index++;
                }
                else if (c == ')')
                    isOpen = false;
                else
                {
                    if (isOpen)
                        tokenList[index].Add(c + "");
                    else
                    {
                        if (ignoreIncrementOnClose)
                            ignoreIncrementOnClose = false;
                        else
                            index++;

                        tokenList[index].Add(c + "");
                    }

                }

            }
        }

        public bool MatchesWord(string word)
        {
            if (word.Length != tokenList.Count)
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                if (!tokenList[i].Contains(word[i] + ""))
                {
                    return false;
                }
            }

            return true;
        }

    }

}
