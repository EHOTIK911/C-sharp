using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TEST1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<int> MAS = new List<int>();
            int LenMin_LenMax = rnd.Next(4, 4);
            for (int i = 0; i < LenMin_LenMax; i++)
            {

                MAS.Add(rnd.Next(3, 7));
            }
            // Удаляю повторяющиеся элементы
            MAS = MAS.Distinct().ToList();
            //Проверяю на количество чисел в списке, если оно меньше, то мы заходим в while до тех пор, пока не получим результат
            while (MAS.Count < LenMin_LenMax)
            {
                //Добавляем элемент
                MAS.Add(rnd.Next(3, 7));
                // Проверяем опять список на повторяющиеся элементы и удаляем их
                MAS = MAS.Distinct().ToList();
                //Мы заходим в while до тех пор, пока все элементы не будут различны
            }
            for (int i = 0; i < MAS.Count; i++)
                Console.Write(MAS[i]+ " ");
            Console.ReadKey();

        }
    }
}
