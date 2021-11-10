using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_C
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            List<int> MAS = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList(); MAS.Add(0);
            var result = MAS.OrderByDescending(x => x).Select((x, i) => x + i).Min();
            Console.WriteLine(result);

        }

        
    }
}
