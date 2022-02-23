using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABA_6
{
    internal class Program
    {
        public static int[,] Rotate(int[,] m)
        {
            var result = new int[m.GetLength(1), m.GetLength(0)];

            for (int i = 0; i < m.GetLength(1); i++)
                for (int j = 0; j < m.GetLength(0); j++)
                    result[i, j] = m[m.GetLength(0) - j - 1, i];

            return result;
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int[,] t = new int[0,0];
            int e = 0;
            bool Flag = true;
            bool flag1 = true;
            Console.WriteLine("MENU");
            Console.WriteLine("1. Ввод матрицы с клавиатуры");
            Console.WriteLine("2. ввод матрицы из файла");
            Console.WriteLine("3. вычисление характеристики");
            Console.WriteLine("4. преобразование матрицы (Поворот на 180 градусов)");
            Console.WriteLine("5. печать матрицы");
            Console.WriteLine("6. выход");
            Console.Write("Введите пункт меню: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if(n == 6)
            {
                Flag = false;
            }
            while(n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6)
            {
                Console.WriteLine("Такого пункта нет :(");
                Console.Write("Введите пункт меню: ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            while(Flag)
            {
                if (n == 1)
                {
                    Console.Write("Введите размер матрицы: ");
                    int s = Convert.ToInt32(Console.ReadLine());
                    e = s;
                    int[,] a = new int[s, s];
                    for (int i = 0; i < s; i++)
                    {
                        string[] ss = Console.ReadLine().Split(' ');
                        for (int g = 0; g < ss.Length; g++)
                        {
                            a[i, g] = int.Parse(ss[g]);
                        }
                    }
                    t = (int[,])a.Clone();
                    Console.Write("Введите пункт меню: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    flag1 = false;
                }
                if (n == 2)
                {
                    //using (StreamReader re = new StreamReader());
                    string[] ss = File.ReadAllLines("input.txt");
                    int s = int.Parse(ss[0]);
                    e = s;
                    int[,] a = new int[s, s];
                    for (int i = 1; i < ss.Length; i++)
                    {
                        string[] sss = ss[i].Split(' ');
                        for (int g = 0; g < s; g++)
                        {
                            a[i - 1, g] = int.Parse(sss[g]);
                        }
                    }
                    t = (int[,])a.Clone();
                    Console.Write("Матрица загружена.");
                    Console.Write("\nВведите пункт меню: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    flag1 = false;
                }
                if (n == 3)
                {
                    if (flag1)
                    {
                        Console.WriteLine("Матрица не введена");
                    }
                    
                    int count = 0;
                    for (int i = 0; i < e; i++)
                    {
                        for(int g = 0; g < e; g++)
                        {
                            if(i % 2 == 0)
                            {
                                if (t[i, g] > 0)
                                {
                                    count++;
                                }
                            }
                            
                        }
                        if(count > 3)
                        {
                            list.Add(1);
                            break;
                        }
                        count = 0;

                    }
                    if (list.Contains(1))
                    {
                        Console.WriteLine("Матрица неверна");
                    }
                    else
                        Console.WriteLine("Матрица верна");
                    Console.Write("Введите пункт меню: ");
                    n = Convert.ToInt32(Console.ReadLine());

                }
                if (n == 4)
                {
                    if (flag1)
                    {
                        Console.WriteLine("Матрица не введена");
                    }
                    t = Rotate(t);
                    t = Rotate(t);
                    Console.Write("Введите пункт меню: ");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                if (n == 5)
                {
                    if (flag1)
                    {
                        Console.WriteLine("Матрица не введена");
                    }
                    PRINT_CONSOLE(t, e);
                    Console.Write("Введите пункт меню: ");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                if (n == 6)
                {
                    Flag = false;
                }
            }
            Console.Write("Exit");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);

        }

        private static void PRINT_CONSOLE(int[,] a, int s)
        {
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
