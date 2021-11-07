using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_C
{
    class Program
    {
        static List<int> input()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            return numbers;
        }

        static void Main(string[] args)
        {
            int count1 = 0;
            int count = 0;
            int d = Convert.ToInt32(Console.ReadLine());
            
            List<int> HOME = input();
            for(int i = 0; i < HOME.Count-1; i++)
            {
                if (HOME[i] != HOME[i + 1])
                {
                    count++;
                }
            }
            if(HOME[HOME.Count-1] != HOME[HOME.Count - 2])
            {
                count++;
            }
            Console.WriteLine(count);
            Console.ReadKey();
            
        }
    }
}
