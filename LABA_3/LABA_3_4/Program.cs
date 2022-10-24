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
                List<int> MAS = new List<int> (); // Создаем массив int с количеством элементов LenMin_LenMax
                List<double> MAS_float = new List<double>(); // Создаем массив double с количеством элементов LenMin_LenMax
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
                        //Заплняю список
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {

                            MAS.Add(rnd.Next(Min, Max));
                        }
                        // Удаляю повторяющиеся элементы
                        MAS = MAS.Distinct().ToList();
                        //Проверяю на количество чисел в списке, если оно меньше, то мы заходим в while до тех пор, пока не получим результат
                        while (MAS.Count < LenMin_LenMax)
                        {
                            //Добавляем элемент
                            MAS.Add(rnd.Next(Min, Max));
                            // Проверяем опять список на повторяющиеся элементы и удаляем их
                            MAS = MAS.Distinct().ToList();
                            //Мы заходим в while до тех пор, пока все элементы не будут различны
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

                    // Стилизация вывода
                    if (TypeOut == "row") // Строка
                    {
                        using (StreamWriter sw = File.CreateText(SetName + g + ".txt"))
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
                        using (StreamWriter sw = File.CreateText(SetName + g + ".txt"))
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
                    if (Repeat == "yes")
                    {
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {

                            MAS_float[i] = rnd.NextDouble() * (Max - Min) + Min;
                        }
                    }
                    if (Repeat == "no")
                    {
                        //Заплняю список
                        for (int i = 0; i < LenMin_LenMax; i++)
                        {

                            MAS_float.Add(rnd.NextDouble() * (Max - Min) + Min);
                        }
                        // Удаляю повторяющиеся элементы
                        MAS_float = MAS_float.Distinct().ToList();
                        //Проверяю на количество чисел в списке, если оно меньше, то мы заходим в while до тех пор, пока не получим результат
                        while (MAS_float.Count < LenMin_LenMax)
                        {
                            //Добавляем элемент
                            MAS_float.Add(rnd.NextDouble() * (Max - Min) + Min);
                            // Проверяем опять список на повторяющиеся элементы и удаляем их
                            MAS_float = MAS_float.Distinct().ToList();
                            //Мы заходим в while до тех пор, пока все элементы не будут различны
                        }
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
                    
                    // Стилизация вывода
                    if (TypeOut == "row") // Строка
                    {
                        // Запись в файл
                        using (StreamWriter sw = File.CreateText(SetName + g + ".txt"))
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
                        using (StreamWriter sw = File.CreateText(SetName + g + ".txt"))
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
        private static void SORT_ASC_INT(List<int> MAS)
        {
            for (int i = 0; i < MAS.Count; i++)
            {
                for (int j = 0; j < MAS.Count - 1; j++)
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
        private static void SORT_DESC_INT(List<int> MAS)
        {
            for (int i = 0; i < MAS.Count; i++)
            {
                for (int j = 0; j < MAS.Count - 1; j++)
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

        // Метод для сортировки массива по возрастанию (double)
        private static void SORT_ASC_DOUBLE(List<double> MAS_float)
        {
            for (int i = 0; i < MAS_float.Count; i++)
            {
                for (int j = 0; j < MAS_float.Count - 1; j++)
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
        private static void SORT_DESC_DOUBLE(List<double> MAS_float)
        {
            for (int i = 0; i < MAS_float.Count; i++)
            {
                for (int j = 0; j < MAS_float.Count - 1; j++)
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
