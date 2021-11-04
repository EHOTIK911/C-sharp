/*lab 2
 * Novikov Petr IB-11
 * While. Summa posledovatel'nosti
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2_1_ATT_2
{
    internal class Program
    {
        static void tabulation(double A, double B, double dx, double e) // табуляция (установка нужного расстояния между словами в строке по горизонтали)
        {
            // вывод окончательных значений и таблицы
            Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|", "x", "F1(x)", "F2(x)", "F3(x)"));
            for (double x = A; x <= B; x += dx)
            {
                Console.WriteLine($"|{x,10:F5}|{f1(x),10:f5}|{f2(x, e),10:f5}|{f3(x, e),10:f5}|");
            }
        }
        static void Main(string[] args)
        {
            // ввод в строку
            Console.Write("Введите начало и конец отрезка = ");
            string[] inputStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double A = double.Parse(inputStrings[0]);
            // A - начало отрезка
            double B = double.Parse(inputStrings[1]);
            // B - конец отрезка
            Console.Write("Введите количество точек = ");
            int N = int.Parse(Console.ReadLine());
            // N - количество точек
            Console.Write("Введите eps = ");
            double e = double.Parse(Console.ReadLine());
            // e - погрешность (колличество знаков после запятой)
            double dx = (B - A) / (N - 1);
            // расстояние между точками (одинаковое)
            tabulation(A, B, dx, e); // табулирование
            Console.ReadKey();
        }
        static double f1(double x) // 1 функция
        {
            return (Math.Sin(2 * x)) / x;
        }
        static double power(double a, int n) // функция возведения в степень
        {
            // обозначаем условия для переменных a, n
            if (n == 0) return 1;
            if (a == 0) return 0;
            if (n < 0)
            {
                a = 1 / a;
                n = -n;
            }
            // вводим переменные и присваем им значения
            double b = a, p = 1;
            int k = n;
            // через цикл while возвращаем переменную p
            while (k != 0)
            {
                if (k % 2 == 0)
                {
                    b = b * b;
                    k /= 2;
                }
                else
                {
                    p *= b;
                    k--;
                }
            }
            return p;
        }
        static double factor(int n)
        {
            int fact = 1;
            for (int j = 2; j <= n; j++)
            {
                fact = fact * j;
            }
            return fact;
        }
        static double f2(double x, double e) // 2 функция 
        {
            // задаём переменные и присваем им значения
            double sum = 0;
            double predidyshiy, tekyshii;
            int k = 1;
            // формула для текущего члена
            tekyshii = power(2, k) * power(x, k - 1) / factor(k) - power(2, k + 2) * power(x, k + 1) / factor(k + 2);
            sum = sum + tekyshii;
            k += 4;
            // через цикл do проверяем значение 2 функции (проверка)
            do
            {
                predidyshiy = tekyshii;
                tekyshii = power(2, k) * power(x, k - 1) / factor(k) - power(2, k + 2) * power(x, k + 1) / factor(k + 2);
                sum += tekyshii;
                k += 4;
            } while (Math.Abs(tekyshii - predidyshiy) > e); // цикл действует пока разность между текущим и предыдущим будет больше эпсилона 
            return sum;
        }
        static double f(double x, int k)
        {
            return power(-1, k - 1) * power(2, 2 * k - 1) * power(x, 2 * k - 2) / factor(2 * k - 1);
        }
        static double f3(double x, double e) // 3 функция
        {
            // задаём переменные и присваем им значения
            double ai = 2;
            double sum = ai;
            int n = 1;
            while (Math.Abs(ai) > e)
            {
                ai = (-ai * 4 * (x * x)) / (2 * n * (2 * n + 1));
                sum += ai;
                n++;
            }
            return sum; // возвращаем сумму
        }
    }
}

/*
 * TEST 01
0 1
15
0.1
 * TEST 02
-1 0
15
0.1
*/
