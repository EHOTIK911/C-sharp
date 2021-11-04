/*lab 3
 * Novikov Petr IB-11
 * Obrabotka odnoimennih massivof
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABA_3_1
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\Users\Petr\source\repos\LABA_3\LABA_3\LABA_3_1.txt";
            int[] MAS = input();
            // сортрруем массив пузырьком
            BUBBLE_SORT(MAS);

            int k = 2;
            // смещаем на 2 элемента вправо
            for (int i = 0; i < k; ++i)
            {
                int aLast = MAS[MAS.Length - 1];
                for (int j = MAS.Length - 1; j > 0; j--)
                {
                    MAS[j] = MAS[j - 1];
                }
                MAS[0] = aLast;
            }

            Console.WriteLine("Новый массив: ");
            for (int i = 0; i < MAS.Length; ++i)
                Console.Write(MAS[i] + " ");
            // Вывод в файл
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < MAS.Length; ++i)
                    sw.Write(MAS[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void BUBBLE_SORT(int[] MAS)
        {
            for (int i = 0; i < MAS.Length; i++)
            {
                for (int j = 0; j < MAS.Length - 1; j++)
                {
                    if (MAS[j] > MAS[j + 1])
                    {
                        int z = MAS[j];
                        MAS[j] = MAS[j + 1];
                        MAS[j + 1] = z;
                    }
                }
            }
        }

        private static int[] input()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray<int>();
            return numbers;
        }
    }
}
/* TEST 01
 * 8 7 5 0 7 8 3 2 5 4 6
 * Конечный массив
 * 8 8 0 2 3 4 5 5 6 7 7
 * TEST 02
 * 867 54 57 7 5 564 4 987 475 354
 * Конечный массив
 * 867 987 4 5 7 54 57 354 475 564
 */