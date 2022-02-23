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
        static void Main(string[] args)
        {
            Console.Write("Введите длинну квадрата: ");
            int Len_coub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите радиус круга: ");
            int Len_Cirkle = Convert.ToInt32(Console.ReadLine());

            if(Math.Pow(2, Len_coub) > ((Math.Pow(2, 2*Len_Cirkle) / 4) * Math.PI))
            {
                Console.WriteLine("Площадть квабрата больше");

            }
            else
            {
                Console.WriteLine("Площадь круга больше");
            }
            Console.ReadKey();
        }

       
    }
}
