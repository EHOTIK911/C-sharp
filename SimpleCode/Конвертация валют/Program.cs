using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертация_валют
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dollar = 57.6; double eu = 59.33;
            int value = 0;
            Console.WriteLine("\t Конвертация валют");
            Console.WriteLine("Выберите пункт: ");
            Console.Write("Введи валюту: ");
            value = int.Parse(Console.ReadLine());
            Console.WriteLine("Доллар: ");
            Console.Write(value / dollar);
            Console.WriteLine("\nЕвро: ");
            Console.Write(value / eu);
            Console.ReadKey();
        }
    }
}
