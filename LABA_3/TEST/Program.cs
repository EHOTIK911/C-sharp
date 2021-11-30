/*lab 2
 * Novikov Petr IB-11
 * Obrabotka posledovatel'nosti
 * TEST
 * 
 * https://i.imgur.com/k523uuj.png
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
            Console.WriteLine("Введите количество троек");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Вводите тройки");

            int[] ost = new int[4];

            string[] troik = Console.ReadLine().Split(' ');

            int aa = int.Parse(troik[0]),
            bb = int.Parse(troik[1]),
            cc = int.Parse(troik[2]);

            int ssumm = aa + bb;
            int ssumm2 = aa + cc;
            int ssumm3 = bb + cc;
            if (ost[ssumm % 4] < ssumm)
            {
                ost[ssumm % 4] = ssumm;
            }
            if (ost[ssumm2 % 4] < ssumm2)
            {
                ost[ssumm2 % 4] = ssumm2;
            }
            if (ost[ssumm3 % 4] < ssumm3)
            {
                ost[ssumm3 % 4] = ssumm3;
            }

            for (int i = 1; i < n; i++)
            {
                string[] troiki = Console.ReadLine().Split(' ');
                int a = int.Parse(troiki[0]),
                b = int.Parse(troiki[1]),
                c = int.Parse(troiki[2]);

                int[] ostat2 = new int[4];
                for (int j = 0; j < ostat2.Length; j++)
                {
                    if (ost[j] == 0)
                    {
                        continue;
                    }
                    int summ = ost[j] + a + b;
                    int summ2 = ost[j] + a + c;
                    int summ3 = ost[j] + b + c;
                    if (ostat2[summ % 4] < summ)
                    {
                        ostat2[summ % 4] = summ;
                    }
                    if (ostat2[summ2 % 4] < summ2)
                    {
                        ostat2[summ2 % 4] = summ2;
                    }
                    if (ostat2[summ3 % 4] < summ3)
                    {
                        ostat2[summ3 % 4] = summ3;
                    }


                }
                for (int k = 0; k < 4; k++)
                {
                    ost[k] = ostat2[k];
                }


            }

            Console.WriteLine(ost[0]);
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