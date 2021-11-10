using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CONTEST_D
{

    class Program
    {

        static void Main(string[] args)
        {
            int s = Convert.ToInt32(Console.ReadLine());
            int[] MAS = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
            var result = MAS.OrderByDescending(x => x).Select((x, i) => x + i + 1).Max() + 1;
            Console.WriteLine(result);

        }
    }
}

