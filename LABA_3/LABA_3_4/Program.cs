/*lab 3
 * Novikov Petr IB-11
 * Datchik slychainix chisel
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABA_3_4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string path = @"C:\Users\Petr\source\repos\LABA_3\LABA_3_4\LABA_3_4.txt";
            Random rnd = new Random(); // Создаем рандом
            // Вводим необходимые параметры
            Console.Write("SetName = ");
            string SetName = Console.ReadLine();
            Console.Write("N = ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type = ");
            string Type = Console.ReadLine();
            Console.Write("Min = ");
            int Min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Max = ");
            int Max = Convert.ToInt32(Console.ReadLine());
            Console.Write("LenMin = ");
            int LenMin = Convert.ToInt32(Console.ReadLine());
            Console.Write("LenMax = ");
            int LenMax = Convert.ToInt32(Console.ReadLine());
            Console.Write("Repeat = ");
            string Repeat = Console.ReadLine();
            Console.Write("Sort = ");
            string Sort = Console.ReadLine();
            Console.Write("TypeOut = ");
            string TypeOut = Console.ReadLine();
            //Array.ForEach(Enumerable.Range(1, N).Select(x => @"C:\Users\Petr\source\repos\LABA_3\LABA_3_4\" + "LABA_3_4 "+x.ToString() + ".txt").ToArray(), fileName =>
            //{
            //    File.Create(fileName);
            //});
            for (int g = 0; g < N; g++)
            {
                // Выводим имя теста + проверка на правильность написания (01, 02, 03, ... 09, 10, ...)
                if (g < 10)
                {
                    Console.WriteLine("\n" + SetName + "0" + g);
                }
                else
                    Console.WriteLine("\n" + SetName + g);
                int LenMin_LenMax = rnd.Next(LenMin, LenMax); // Генерируем случайно число чисел в массиве
                int[] MAS = new int[LenMin_LenMax]; // Создаем массив int с количеством элементов LenMin_LenMax
                double[] MAS_float = new double[LenMin_LenMax]; // Создаем массив double с количеством элементов LenMin_LenMax
                Console.WriteLine(LenMin_LenMax);
                if (Type == "int")
                {
                    // Заполняем массив int случайными числами
                    if(Repeat == "yes")
                    {
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {

                            MAS[i] = rnd.Next(Min, Max);
                        }
                    }
                    if(Repeat == "no")
                    {
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {
                            for(int j = 0; j < i; j++)
                            {

                                if(MAS[i] != MAS[j])
                                {
                                    MAS[i] = rnd.Next(Min, Max);
                                }
                            }
                        }
                    }
                    
                    // Сортируем массив, при необходимости
                    if (Sort == "asc") // По убыванию
                    {
                        SORT_ASC_INT(MAS);
                    }
                    if (Sort == "desc") // По возрастанию
                    {
                        SORT_DESC_INT(MAS);
                    }
                    // Повторяющиеся элементы при необходимости ( В случае "yes" , случайные числа итак модгут повторяться)
                    //if (Repeat == "no")
                    //{
                    //    REPEAT_NO_INT(rnd, Min, Max, LenMin_LenMax, MAS);
                    //}
                    // Стилизация вывода
                    if (TypeOut == "row") // Строка
                    {
                        using (StreamWriter sw = File.CreateText(@"C:\Users\Petr\source\repos\LABA_3\LABA_3_4\" + SetName + g + ".txt"))
                        {
                            if (g < 10)
                            {
                                sw.WriteLine("\n" + SetName + "0" + g);
                            }
                            else
                                sw.WriteLine("\n" + SetName + g);
                            sw.WriteLine(LenMin_LenMax);
                            for (int i = 0; i < LenMin_LenMax; i++)
                            {
                                sw.Write(MAS[i] + " ");
                            }
                        }
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {
                            Console.Write(MAS[i] + " ");
                        }

                    }
                    if (TypeOut == "col") // Колонка
                    {
                        // Запись в файл
                        using (StreamWriter sw = File.CreateText(@"C:\Users\Petr\source\repos\LABA_3\LABA_3_4\" + SetName + g + ".txt"))
                        {
                            if (g < 10)
                            {
                                sw.WriteLine("\n" + SetName + "0" + g);
                            }
                            else
                                sw.WriteLine("\n" + SetName + g);
                            sw.WriteLine(LenMin_LenMax);
                            for (int i = 0; i < LenMin_LenMax; i++)
                            {
                                sw.WriteLine(MAS[i] + " ");
                            }
                        }
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {
                            Console.WriteLine(MAS[i] + " ");
                        }

                    }



                }


// ---------------------------------------------------------------------------------------------


                // Случай с double
                if (Type == "double") 
                {
                    // Заполняем массив double случайными числами
                    for (int i = 0; i < LenMin_LenMax; i++)
                    {
                        MAS_float[i] = rnd.NextDouble() * (Max - Min) + Min+1;
                    }
                    // Сортируем массив, при необходимости
                    if (Sort == "asc") // По Убыванию
                    {
                        SORT_ASC_DOUBLE(MAS_float);
                    }
                    if (Sort == "desc") // По возрастанию
                    {
                        SORT_DESC_DOUBLE(MAS_float);
                    }
                    // Повторяющиеся элементы при необходимости ( В случае "yes" , случайные числа итак модгут повторяться)
                    if (Repeat == "no")
                    {
                        REPEAT_NO_DOUBLE(rnd, Min, Max, LenMin_LenMax, MAS_float);
                    }
                    // Стилизация вывода
                    if (TypeOut == "row") // Строка
                    {
                        // Запись в файл
                        using (StreamWriter sw = File.CreateText(@"C:\Users\Petr\source\repos\LABA_3\LABA_3_4\" + SetName + g + ".txt"))
                        {
                            if (g < 10)
                            {
                                sw.WriteLine("\n" + SetName + "0" + g);
                            }
                            else
                                sw.WriteLine("\n" + SetName + g);
                            sw.WriteLine(LenMin_LenMax);
                            for (int i = 0; i < LenMin_LenMax; i++)
                            {
                                sw.Write(MAS_float[i] + " ");
                            }
                        }

                        
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {
                            Console.Write(MAS_float[i] + " ");
                        }
                    }
                    if (TypeOut == "col") // Колонка
                    {
                        // Запись в файл
                        using (StreamWriter sw = File.CreateText(@"C:\Users\Petr\source\repos\LABA_3\LABA_3_4\" + SetName + g + ".txt"))
                        {
                            if (g < 10)
                            {
                                sw.WriteLine("\n" + SetName + "0" + g);
                            }
                            else
                                sw.WriteLine("\n" + SetName + g);
                            sw.WriteLine(LenMin_LenMax);
                            for (int i = 0; i < LenMin_LenMax; i++)
                            {
                                sw.WriteLine(MAS_float[i]);
                            }
                        }
                        
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {
                            Console.WriteLine(MAS_float[i]);
                        }
                    }
                }

            }
            Console.ReadKey();
        }
        // Метод для сортировки массива по возрастанию (int)
        private static void SORT_ASC_INT(int[] MAS)
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
        // Метод для сортировки массива по убыванию (int)
        private static void SORT_DESC_INT(int[] MAS)
        {
            for (int i = 0; i < MAS.Length; i++)
            {
                for (int j = 0; j < MAS.Length - 1; j++)
                {
                    if (MAS[j] < MAS[j + 1])
                    {
                        int z = MAS[j];
                        MAS[j] = MAS[j + 1];
                        MAS[j + 1] = z;
                    }
                }
            }
        }
        // Проверка на повторяющиеся элементы (int)
        private static void REPEAT_NO_INT(Random rnd, int Min, int Max, int LenMin_LenMax, int[] MAS)
        {
            var result = MAS.Distinct().ToArray();
            for (int l = 0; l < LenMin_LenMax; l++)
            {
                for (int f = 0; f < LenMin_LenMax; f++)
                {
                    if (MAS[l] == MAS[f])
                    {
                        MAS[l] = rnd.Next(Min, Max);
                        
                    }
                }
            }
        }
        // Проверка на повторяющиеся элементы (double)
        private static void REPEAT_NO_DOUBLE(Random rnd, int Min, int Max, int LenMin_LenMax, double[] MAS_float)
        {
            for (int l = 0; l < LenMin_LenMax; l++)
            {
                for (int f = 0; f < LenMin_LenMax; f++)
                {
                    if (MAS_float[l] == MAS_float[f])
                    {
                        MAS_float[l] = rnd.NextDouble() * (Max - Min) + Min;
                        
                    }
                }
            }
        }
        // Метод для сортировки массива по возрастанию (double)
        private static void SORT_ASC_DOUBLE(double[] MAS_float)
        {
            for (int i = 0; i < MAS_float.Length; i++)
            {
                for (int j = 0; j < MAS_float.Length - 1; j++)
                {
                    if (MAS_float[j] > MAS_float[j + 1])
                    {
                        double z = MAS_float[j];
                        MAS_float[j] = MAS_float[j + 1];
                        MAS_float[j + 1] = z;
                    }
                }
            }
        }
        // Метод для сортировки массива по убыванию (double)
        private static void SORT_DESC_DOUBLE(double[] MAS_float)
        {
            for (int i = 0; i < MAS_float.Length; i++)
            {
                for (int j = 0; j < MAS_float.Length - 1; j++)
                {
                    if (MAS_float[j] < MAS_float[j + 1])
                    {
                        double z = MAS_float[j];
                        MAS_float[j] = MAS_float[j + 1];
                        MAS_float[j + 1] = z;
                    }
                }
            }
        }
    }
}
