using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOME_WORK_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> VALUE = new List<int>();
            int N = int.Parse(Console.ReadLine());
            int SUM_OF_PARTS = 0, COUNTER = 0;
            // ADD ALL VALUES FROM 1 TO N TO THE LIST
            while (N > SUM_OF_PARTS)
            {
                COUNTER++;
                SUM_OF_PARTS =  SUM_OF_PARTS + COUNTER;
                VALUE.Add(COUNTER);
            }
            // WE EXCLUDE THE NUMBER THAT, WHEN ADDED TO ITSELF, PRODUCES N
            if (SUM_OF_PARTS - N != 0)
            {
                int EXTRA_SUMMAND = SUM_OF_PARTS - N;
                VALUE.RemoveAt(VALUE.IndexOf(EXTRA_SUMMAND));
            }

            Console.WriteLine(VALUE.Count);
            for (int i = 0; i < VALUE.Count; i++)
                Console.Write(VALUE[i] + " ");



            Console.ReadKey();
        }
    }
}
