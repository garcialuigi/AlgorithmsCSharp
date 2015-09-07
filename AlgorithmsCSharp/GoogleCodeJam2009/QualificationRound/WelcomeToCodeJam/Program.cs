using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam2009.QualificationRound.WelcomeToCodeJam
{
    class Program
    {
        public const string INPUT_PATH = "input.in";
        public const string PHRASE = "welcome to code jam";

        private string[] inputLines;
        private int iLine;

        private Dictionary<char, List<Charactere>> chars;
        private int counter = 0;

        public void Start()
        {
            // create the dictionary
            chars = new Dictionary<char, List<Charactere>>();
            chars.Add('w', new List<Charactere>());
            chars.Add('e', new List<Charactere>());
            chars.Add('l', new List<Charactere>());
            chars.Add('c', new List<Charactere>());
            chars.Add('o', new List<Charactere>());
            chars.Add('m', new List<Charactere>());
            chars.Add('t', new List<Charactere>());
            chars.Add('d', new List<Charactere>());
            chars.Add('j', new List<Charactere>());
            chars.Add('a', new List<Charactere>());
            chars.Add(' ', new List<Charactere>());

            // read the input
            inputLines = File.ReadAllText(INPUT_PATH).Split('\n');
            iLine = 0;

            StringBuilder outputText = new StringBuilder();

            // tests count
            var N = RequestInput<int>();

            for (int i = 0; i < N; i++)
            {
                // clean the dictionary
                foreach (KeyValuePair<char, List<Charactere>> item in chars)
                    item.Value.Clear();

                string inputText = RequestInput<string>();
                counter = 0;

                for (int j = 0; j < inputText.Length; j++)
                    if (PHRASE.Contains(inputText[j]))
                        chars[inputText[j]].Add(new Charactere(symbol: inputText[j], id: j));

                RecCheck(new Charactere('-', -1), -1);

                outputText.Append("Case #");
                outputText.Append(i + 1);
                outputText.Append(": ");
                outputText.Append(GenerateOutputNumber(counter + ""));
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

        public void RecCheck(Charactere charactere, int phraseCursor)
        {
            if (phraseCursor == 18)
            {
                counter++;
                Console.WriteLine("oi{0}", counter);
            }

            List<Charactere> list;
            if (phraseCursor < PHRASE.Length - 1 && PickUpCharacteres(PHRASE[++phraseCursor], charactere.id, out list))
            {
                foreach (Charactere item in list)
                    RecCheck(charactere: item, phraseCursor: phraseCursor);
            }
        }

        public bool PickUpCharacteres(char charactere, int idGreaterThan, out List<Charactere> output)
        {
            output = new List<Charactere>();
            output = chars[charactere].Where(item => item.id > idGreaterThan).ToList();
            return (output.Count == 0 ? false : true);
        }


        public bool PickUpSmallerIndexedCharactere(char charactere, out Charactere output)
        {
            output = new Charactere('-', -1);
            var tempList = chars[charactere].OrderBy(item => item.id).ToList();
            if (tempList.Count > 0)
                output = tempList[0]; // get the first element

            return (output.id == -1 ? false : true);
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

    struct Charactere
    {

        public char symbol;
        public int id;

        public Charactere(char symbol, int id)
        {
            this.symbol = symbol;
            this.id = id;
        }

    }

}
