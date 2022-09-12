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
            Console.WriteLine("Вычисление среднеарифметического числа");
            Console.Write("Введите первое число = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число = ");
            int b = int.Parse(Console.ReadLine());
            double result = (double)(a + b) / 2; // неявное преобразование, чтобы получить дробное число при делении (возможны другие варианты)
            Console.WriteLine($"Среднеарифметическое число: {result}",result);
            Console.ReadKey();
        }
    }
}
