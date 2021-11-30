/*lab 3
 * Novikov Petr IB-11
 * Obrabotka posledovatel'nosti
 * https://i.imgur.com/JMznE2f.png
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABA_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Petr\source\repos\LABA_3\LABA_3_2\LABA_3_2.txt";
            int count = 0; // Создаем счетчик
            int K = Convert.ToInt32(Console.ReadLine());
            List<int> MAS_2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList(); // создаем массив
            for (int g = 0; g < MAS_2.Count - 1; g++)
            {
                if (MAS_2[g] != MAS_2[g + 1])
                {
                    count++;
                }
            }
            for(int g = 0; g < MAS_2.Count; g++)
            {
                if(g == K)
                {
                    MAS_2.Add(0);
                    for (int j = MAS_2.Count - 1; j > g + 1; j--)
                    {
                        MAS_2[j] = MAS_2[j - 1];
                    }
                    MAS_2[g + 1] = MAS_2[g];
                    g++;
                }
            }
            if(count > K)
            {
                PrintInConsole_WtiteToFile(path, MAS_2);
            }
            else
            {
                PrintInConsole_WtiteToFile(path, MAS_2);
            }
            
            Console.ReadKey();
        }

        private static void PrintInConsole_WtiteToFile(string path, List<int> MAS_2)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int g = 0; g < MAS_2.Count; g++)
                {
                    sw.Write(MAS_2[g] + " ");
                }
            }
            for (int g = 0; g < MAS_2.Count; g++)
            {
                Console.Write(MAS_2[g] + " ");
            }
        }
    }
}
/*
 * TEST 01
 * Серий больше чем К
 * К = 3
 * Массив:
 * 3 2 4 5 4 8 7 5 4 3 3
 * ВЫВОД
 * 3 2 4 5 5 4 8 7 5 4 3 3
 * 
 * 
 * TEST 02
 * Серий меньше чем К
 * К = 20
 * 7 5 8 6 4 4 5 6 8 6 0
 * ВЫВОД
 * 7 5 8 6 4 4 5 6 8 6 0
*/

