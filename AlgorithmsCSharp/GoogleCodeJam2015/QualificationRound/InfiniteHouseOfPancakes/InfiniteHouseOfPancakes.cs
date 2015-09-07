using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam2015.QualificationRound.InfiniteHouseOfPancakes
{
    class InfiniteHouseOfPancakes
    {
        public void Start()
        {
            int T = RequestInput<int>();
            for (int t = 1; t <= T; t++)
            {
                RequestInput<string>();
                string[] aux = RequestInput<string>().Split(' ');
                List<int> array = new List<int>();
                foreach (string item in aux)
                    array.Add(Int32.Parse(item));

                array = new List<int>() { 5, 6, 9, 6, 9, 6 };

                int specialMinutes = 0;
                int regularMinutes = 0;
                while (!array.TrueForAll(x => x == 0))
                {
                    int remainValue, specialUsed, newSlices = 0;
                    int bestDivision = BestDivision(array.Max(), array.Count(x => x == array.Max()), out remainValue, out newSlices, out specialUsed);
                    if (remainValue + specialUsed < array.Max())
                    {
                        int prevmax = array.Max();
                        for (int i = 0; i < array.Count(x => x == prevmax); i++)
                        {
                            if (bestDivision == 2)
                            {
                                array.Add(newSlices);
                                array.Add(remainValue);
                                specialMinutes++;
                            }
                            else
                            {
                                array.Add(newSlices);
                                array.Add(newSlices);
                                array.Add(remainValue);
                                specialMinutes += 2;
                            }
                        }
                        array.RemoveAll(x => x == prevmax);
                    }
                    else
                    {
                        regularMinutes++;
                        for (int i = 0; i < array.Count; i++)
                            if (array[i] > 0)
                                array[i]--;
                    }
                }

                Print("Case #" + t + ": " + (specialMinutes + regularMinutes) + "\n");

            }
        }

        public int BestDivision(int value, int count, out int remainValue, out int newSlices, out int specialUsed)
        {
            if ((value - (value / 2)) + count < value - (value / 3) - (value / 3) + (2 * count))
            {
                remainValue = (value - (value / 2));
                newSlices = value / 2;
                specialUsed = count;
                return 2;
            }
            else
            {
                remainValue = value - (value / 3) - (value / 3);
                newSlices = value / 3;
                specialUsed = 2 * count;
                return 3;
            }
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
