using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{

    public class House
    {
        public class Furniture
        {
             public string name;
             public int price;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> Furniture = new Dictionary<int, string>();
            FurDefault(Furniture);
            var a = new House.Furniture[7];
            for (int i = 0; i < 7; i++)
            {
                a[i] = new House.Furniture();
            }
            Console.Write("Введите сумму, от которой нужно показать мебель: ");
            var value = int.Parse(Console.ReadLine());
            var s = value <= 5000 ? "Низкая цена" : 5000 < value & value < 10000 ? "Средняя цена" : "Высокая цена";
            Console.WriteLine(s);
            Console.WriteLine();
            var result = Furniture.Where(x => x.Key > value);
            Console.WriteLine("Мебель с значением выше заданного:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.ReadKey();


        }

        private static void FurDefault(Dictionary<int, string> Furniture)
        {
            switch (num)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    break;
            }
            Furniture[6000] = "Стол";
            Furniture[3000] = "Стул";
            Furniture[40000] = "Шкаф";
            Furniture[120000] = "Диван";
            Furniture[70000] = "Кресло";
            Furniture[9000] = "Торшер";
            Furniture[13000] = "Люстра";

        }
    }
}
