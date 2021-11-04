/*lab 3
 * Novikov Petr IB-11
 * Method's prinimauchie i vosvrashauchie massivi v kachestve parametrov. Files.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LABA_3_3
{
    class Program
    {

 
        static void Main(string[] args)
        {
            // Делаем красиво
            Console.Write("log: OPEN FILE");
            System.Threading.Thread.Sleep(600);


            //
            Console.Write("\nlog: READING FILE");
            for (int s = 0; s < 3; s++)
            {
                System.Threading.Thread.Sleep(800);
                Console.Write(".");
            }

            string pathFINAL = @"C:\Users\Petr\source\repos\LABA_3\LABA_3_3\LABA_3_3_FINAL.txt";
            int max = 0, min = 0, max1 = 0, min1 = 0;
            // Открываем файл и записываем в список числа
            string path = @"C:\Users\Petr\source\repos\LABA_3\LABA_3_3\LABA_3_3.txt";
            List<string> NEW_LIST = new List<string>();
            List<string> fileArray = File.ReadLines(path).Where(line => !string.IsNullOrWhiteSpace(line)).SelectMany(line => line.Split(new char[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries)).ToList();
            List<int> intList_X = NEW_LIST.ConvertAll(int.Parse);
            List<int> intList_Y = new List<int>();
            //Находим максимум и минимум из списка
            int MAX_NUMBER = intList_X.Max();
            int MIN_NUMBER = intList_X.Min();
            Console.WriteLine("\nИзначальный массив");
            for (int i = 0; i < intList_X.Count; i++)
            {
                Console.Write(intList_X[i] + " ");

            }
            //Записываем данные из первого списка во второй
            // Дублируем элементы
            for (int r = 0; r < intList_X.Count; r++)
            {
                if ((intList_X[r] % 2.0 != 0) || (intList_X[r] == 0))
                {
                    intList_Y.Add(intList_X[r]);
                }
                else
                {
                    intList_Y.Add(intList_X[r]);
                    intList_Y.Add(intList_X[r]);
                }
            }
            // для массива(списка) с дубликатами находим максимум и минимум
            MAX_MIN_SECOND_MAS(ref max, ref min, intList_Y, MAX_NUMBER, MIN_NUMBER);
            //для изначального массива(списка) находим максимум и минимум
            MAX_MIN_FIRST_MAS(ref max1, ref min1, intList_X, MAX_NUMBER, MIN_NUMBER);
            // Делаем вывод для консоли (Для удобства)
            System.Threading.Thread.Sleep(400);
            Console.WriteLine("\nНовый массив с дубликатами");
            for (int i = 0; i < intList_Y.Count; i++)
            {
                Console.Write(intList_Y[i] + " ");

            }
            int H = min - max;
            int H1 = min1 - max1;
            intList_Y.RemoveRange(max + 1, H - 1); // Удаляем значения с перворго максимального до последнего минимального во втором массиве(списка)
            intList_X.RemoveRange(max1 + 1, H1 - 1); // Удаляем значения с перворго максимального до последнего минимального в первом массиве(списка)
            //Наводим красоту
            System.Threading.Thread.Sleep(400);
            Console.WriteLine("\nНовый массив с дубликатами и удаленными элементами");
            //Выводим элементы массива(списка)
            for (int i = 0; i < intList_Y.Count; i++)
            {
                Console.Write(intList_Y[i] + " ");

            }
            System.Threading.Thread.Sleep(400);
            Console.WriteLine("\nмассив без дубликатами");
            for (int i = 0; i < intList_X.Count; i++)
            {
                Console.Write(intList_X[i] + " ");

            }
            // Перезаписываем в файл данные
            using (StreamWriter sw = File.CreateText(pathFINAL))
            {
                for (int g = 0; g < intList_Y.Count; g++)
                {
                    sw.Write(intList_Y[g] + " ");
                }

            }
            // Делаем красиво
            Console.Write("\nlog: RECORDING FILE");
            for (int s = 0; s < 3; s++)
            {
                System.Threading.Thread.Sleep(800);
                Console.Write(".");
            }
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\nlog: CLOSE FILE");
            Console.ReadKey();
        }
        //Находим максимум и минимум во втором массиве(списке)
        private static void MAX_MIN_SECOND_MAS(ref int max, ref int min, List<int> intList_Y, int MAX_NUMBER, int MIN_NUMBER)
        {
            for (int g = 0; g < intList_Y.Count; g++)
            {
                if (intList_Y[g] == MAX_NUMBER)
                {
                    max = g;
                }
            }
            int l = intList_Y.Count - 1;
            while (l > 0)
            {
                if (intList_Y[l] == MIN_NUMBER)
                {
                    min = l;
                }
                l--;
            }
        }
        // Находим максиум и минимум в первом массиве(списке)
        private static void MAX_MIN_FIRST_MAS(ref int max1, ref int min1, List<int> intList_X, int MAX_NUMBER, int MIN_NUMBER)
        {
            for (int g = 0; g < intList_X.Count; g++)
            {
                if (intList_X[g] == MAX_NUMBER)
                {
                    max1 = g;
                }
            }
            int l2 = intList_X.Count - 1;
            while (l2 > 0)
            {
                if (intList_X[l2] == MIN_NUMBER)
                {
                    min1 = l2;
                }
                l2--;
            }
        }
    }
}

/* ПРИМЕР
 * У нас есть массив:
 * 646 45 342 687 5 3 67  78 234 46 342 2 65 98
 * максимум : 687
 * минимум : 2
 * конечный вывод должен быть:
 * Начальный массив:
 * 646 45 342 687 2 65 98
 * Конечный массив:
 * 646 646 45 342 342 687 2 2 65 98 98
 */

