/*lab 2
 * Novikov Petr IB-11
 * Obrabotka posledovatel'nosti
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2_3_ATT_2
{
    class Program
    {


        static void Main(string[] args)
        {
            int s = 0;
            int k = 0;
            int n = int.Parse(Console.ReadLine());
            // Создаем массив четверок
            int[] a = new int[4] { 0, 4, 4, 4 };
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int a1 = Convert.ToInt32(input[0]);
                int a2 = Convert.ToInt32(input[1]);
                int a3 = Convert.ToInt32(input[2]);
                // Если первый элемент больше второго
                if (a1 > a2)
                {
                    // И если трети элемент больше второго
                    if (a3 > a2)
                    {
                        s += (a1 + a3);
                    }
                    else
                    {
                        s += (a1 + a2);
                    }
                }
                else
                {
                    if (a1 > a3)
                    {
                        s += (a1 + a2);
                    }
                    else
                    {
                        s += (a3 + a2);
                    }
                }
                // Находим разницу между первым и вторым элементом
                int abs = Math.Abs(a1 - a2);
                // Находи остаток от деления на 4
                k = abs % 4;
                if ((k > 0) && (abs < a[k]))
                {
                    a[k] = abs;
                }
                // Находим разницу между первым и третьим элементом
                abs = Math.Abs(a1 - a3);
                k = abs % 4;
                if ((k > 0) && (abs < a[k]))
                {
                    a[k] = abs;
                }
                // Находим разницу между третьми и вторым элементом
                abs = Math.Abs(a3 - a2);
                k = abs % 4;
                if ((k > 0) && (abs < a[k]))
                {
                    a[k] = abs;
                }
            }
            if ((s % 4 > 0) && (a[(s % 4)] != 4))
            {
                Console.WriteLine(s - a[(s % 4)]);
            }
            else
            {
                Console.WriteLine(0);
            }
            Console.ReadKey();
        }
    }
}

/*
 *  TEST 01
 *  4
    4 8 5
    2 3 6
    1 5 6
    4 2 6
 *  Правильный ответ 
 *  40
 *  
 *  TEST 02
 *  С повторяющимися элементами
 *  2
    4 3 4
    4 4 9
 *  Правильный ответ
 *  20
 *  
 *  TEST 03
 *  С повторяющимися элементами Второй вариант
 *  2
    4 7 4
    4 3 4
 *  Правильный ответ
 *  16
 *  
*/