using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TASK_2
{
    class Program
    {
        static int fib(int n)
        {
            return n > 1 ? fib(n - 1) + fib(n - 2) : n;
        }
        static void Main(string[] args)
        {
         int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(fib(n));
        Console.ReadKey();
        }

       
    }
}
