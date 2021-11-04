using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_FIX_J
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] VALUE = Console.ReadLine().Split(' ');
            int n = int.Parse(VALUE[0]);
            int m = int.Parse(VALUE[1]);
            List<int> BOX = new List<int>();
            List<int> MARKS = new List<int>();
            for(int i = 0; i < m; i++)
            {
                string[] VALUES = Console.ReadLine().Split(' ');
                BOX.Add(int.Parse(VALUES[0]));
                MARKS.Add(int.Parse(VALUES[1]));
            }
            int g = MARKS.IndexOf(MARKS.Max());
            Console.WriteLine(MARKS[g] * BOX[g]);
            Console.ReadKey();
        }
    }
}
