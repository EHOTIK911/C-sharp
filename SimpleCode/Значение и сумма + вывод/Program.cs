using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите третье число = ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine($"Сумма чисел: {0} \nПроизведение чисел: {1}", a+b+c, a*b*c);
            Console.ReadKey();


        }
    }
}
