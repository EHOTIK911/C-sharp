using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_E
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
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> numbers = input();
            double k = Convert.ToInt32(Console.ReadLine());
            double result = 0;
            int sum;
            bool flag = true;
            while (flag)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] = numbers[i] - 1;
                }
                sum = numbers.Sum();
                result = sum / k;
                if(numbers.Sum() <= 1)
                {
                    flag = false;
                }
            }
            if(result <= 0.5)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(Math.Round(result));
            }
            Console.ReadKey();

        }
    }
}
