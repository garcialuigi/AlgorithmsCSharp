using System;
using System.Collections.Generic;

namespace GoogleCodeJam2015.QualificationRound.StandingOvation
{
    class StandingOvation
    {
        public void Start()
        {
            int T = RequestInput<int>();
            for (int t = 1; t <= T; t++)
            {
                string str = RequestInput<string>();
                string[] strs = str.Split(' ');
                LinkedList<int> list = new LinkedList<int>();
                foreach (char item in strs[1])
                    list.AddLast(item - '0');

                int freeFriends = 0;
                int friends = 0;
                while (list.Count > 0)
                {
                    if (list.First.Value == 0)
                    {
                        list.RemoveFirst();
                        if (freeFriends > 0)
                            freeFriends--;
                        else
                            friends++;
                    }
                    else
                    {
                        freeFriends += list.First.Value - 1;
                        list.RemoveFirst();
                    }
                }
                Print("Case #" + t + ": " + friends + "\n");
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
