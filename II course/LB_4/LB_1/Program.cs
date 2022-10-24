using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using static System.ConsoleColor;
using static LB_1.ColoredConsole;

namespace LB_1
{

    internal class Program
    {

        //ErTrain Error = new Errors();
        public static DateTime cachedTime;
        static void Main(string[] args)
        {
            ColoredConsole.Set();
            bool RemoveList = true;

            bool fl = true;
            int year, weight, horspower, carriages;
            string Color;
            double speed, BodyLenght, WingLenght;
            bool flag = true;
            var ListObj = new List<Transport>();
            string err = default;
            //Console.Write("Input file Name: ");
            
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                while (fl)
                {

                    Console.Clear();
                    //$"{ex.Message}"._sout(Red);
                    //sw.WriteLine((new DateTime()));
                    "███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗\n████╗░████║██╔════╝████╗░██║██║░░░██║\n██╔████╔██║█████╗░░██╔██╗██║██║░░░██║\n██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║\n██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝\n╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░"._sout(rainbowGradient);
                    "Привет! Эта штука второго курса, а мы уже дошли до 4 лабораторной, давай посмотрим, что можно тут сделать"._sout(Red);
                    Console.WriteLine("1. Ввод данных с консоли.");
                    Console.Write("2. Ввод данных из файла.");
                    " (data.txt)"._sout(DarkRed);
                    Console.WriteLine("3. Вывод даных в консоль.");
                    Console.WriteLine("4. Вывод даных в файл.");
                    Console.WriteLine("5. Открытие твоих логов.");
                    Console.WriteLine("6. Отсортировать массив.");
                    Console.WriteLine("7. Удаление элемента из списка");
                    Console.WriteLine("8. Очистить список.");
                    Console.WriteLine("9. Выход");
                    Console.WriteLine("\nНу что, с чего начнем?");
                    Console.WriteLine("Введи номер пункта:");
                    int PNumber = int.Parse(Console.ReadLine());
                    switch (PNumber)
                    {
                        case 1:
                            bool add = true;
                            while (add)
                            {
                                Console.Clear();
                                Console.WriteLine("Какой тип транспорта ты хожешь добавить?");
                                Console.WriteLine("На выбор у тебя есть 4 вида транспорта");
                                Console.WriteLine("1.Truck");
                                Console.WriteLine("2.Car");
                                Console.WriteLine("3.Airplane");
                                Console.WriteLine("4.Train");
                                string s = Console.ReadLine();
                                Console.Clear();
                                try
                                {
                                    switch (s.ToLower())
                                    {
                                        case "1":
                                            Console.WriteLine(s);
                                            Console.Write("Год изготовления: ");
                                            year = int.Parse(Console.ReadLine());
                                            Console.Write("Вес: ");
                                            weight = int.Parse(Console.ReadLine());
                                            Console.Write("Цвет: ");
                                            Color = Console.ReadLine();
                                            Console.Write("Максимальная скорость: ");
                                            speed = double.Parse(Console.ReadLine());
                                            Console.Write("Длинна кузова: ");
                                            BodyLenght = double.Parse(Console.ReadLine());
                                            if (year > 1900 && year < 2023)
                                                ListObj.Add(new Truck("Truck", year, weight, Color, speed, BodyLenght));
                                            "ADD!"._sout(Yellow);
                                            Thread.Sleep(3000);
                                            Console.Clear();
                                            Console.WriteLine("Еще что-то добавляем?");
                                            "Да/Нет"._sout(Red);
                                            s = Console.ReadLine();
                                            add = (s == "Нет") ? false : true;
                                            Console.Clear();
                                            break;
                                        case "2":
                                            Console.WriteLine(s);

                                            "!Если не хочешь писать кол. лошадинных сил, просто ничего не пиши\n"._sout(Red);
                                            Console.Write("Год изготовления: ");
                                            year = int.Parse(Console.ReadLine());
                                            Console.Write("Вес: ");
                                            weight = int.Parse(Console.ReadLine());
                                            Console.Write("Цвет: ");
                                            Color = Console.ReadLine();
                                            Console.Write("Максимальная скорость: ");
                                            speed = double.Parse(Console.ReadLine());
                                            Console.Write("Лошадинные силы: ");
                                            string Horspower = Console.ReadLine();
                                            if (Horspower == "")
                                            {
                                                ListObj.Add(new Car("Car", year, weight, Color, speed));
                                            }
                                            else
                                            {
                                                horspower = int.Parse(Horspower);
                                                ListObj.Add(new Car("Car", year, weight, Color, speed, horspower));
                                            }
                                            "ADD!"._sout(Yellow);
                                            Thread.Sleep(3000);
                                            Console.Clear();
                                            Console.WriteLine("Еще что-то добавляем?");
                                            "Да/Нет"._sout(Red);
                                            s = Console.ReadLine();
                                            add = (s == "Нет") ? false : true;
                                            Console.Clear();
                                            break;
                                        case "3":
                                            Console.WriteLine(s);

                                            Console.Write("Год изготовления: ");
                                            year = int.Parse(Console.ReadLine());
                                            Console.Write("Вес: ");
                                            weight = int.Parse(Console.ReadLine());
                                            Console.Write("Цвет: ");
                                            Color = Console.ReadLine();
                                            Console.Write("Максимальная скорость: ");
                                            WingLenght = double.Parse(Console.ReadLine());
                                            ListObj.Add(new Airplane("Airplane", year, weight, Color, WingLenght));
                                            "ADD!"._sout(Yellow);
                                            Thread.Sleep(3000);
                                            Console.Clear();
                                            Console.WriteLine("Еще что-то добавляем?");
                                            "Да/Нет"._sout(Red);
                                            s = Console.ReadLine();
                                            add = (s == "Нет") ? false : true;
                                            Console.Clear();

                                            break;
                                        case "4":
                                            Console.WriteLine(s);

                                            Console.Write("Год изготовления: ");
                                            year = int.Parse(Console.ReadLine());
                                            Console.Write("Вес: ");
                                            weight = int.Parse(Console.ReadLine());
                                            Console.Write("Цвет: ");
                                            Color = Console.ReadLine();
                                            Console.Write("Максимальная скорость: ");
                                            carriages = int.Parse(Console.ReadLine());
                                            ListObj.Add(new Airplane(s, year, weight, Color, carriages));
                                            "ADD!"._sout(Yellow);
                                            Thread.Sleep(3000);
                                            Console.Clear();
                                            Console.WriteLine("Еще что-то добавляем?");
                                            "Да/Нет"._sout(Red);
                                            s = Console.ReadLine().ToLower();
                                            add = (s == "нет") ? false : true;
                                            Console.Clear();
                                            break;
                                        default:
                                            add = false;
                                            break;
                                    }
                                }
                                catch(TrainCarrExeption ex)
                                {
                                    $"Parameter error in {err}:\n{ex.Message} in {ex.type}"._sout(Red);

                                    //"log file updated..."._sout(Red);
                                    sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message} in {ex.type}");
                                    flag = false;
                                    "Нажмите любую клавишу для продолжения"._sout();
                                    Console.ReadKey();
                                }
                                catch (ArgumentException ex)
                                {

                                    $"Parameter error in {err}:\n{ex.Message} in {ex.type}"._sout(Red);
                                    
                                    //"log file updated..."._sout(Red);
                                    sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message} in {ex.type}");
                                    flag = false;
                                    "Нажмите любую клавишу для продолжения"._sout();
                                    Console.ReadKey();


                                }
                                catch (ArgumentOutOfRangeException ex)
                                {
                                    $"Error:\nНеверное количество аргументов."._sout(Red);
                                    sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                                    flag = false;
                                    "Нажмите любую клавишу для продолжения"._sout();
                                    Console.ReadKey();
                                }
                                catch (Exception ex)
                                {
                                    $"Error:\n{ex.Message}"._sout(Red);
                                    sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                                    flag = false;
                                    "Нажмите любую клавишу для продолжения"._sout();
                                    Console.ReadKey();

                                }

                            }
                            break;
                        case 2:
                            P_2(ref flag, ListObj, ref err, sw);
                            break;
                        case 3:
                            Console.Clear();
                            foreach (var item in ListObj)
                            {
                                item.Info();
                            }
                            Console.ReadKey();

                            break;
                        case 4:
                            using (StreamWriter wr = new StreamWriter("ans.txt", true))
                            {
                                foreach (var item in ListObj)
                                {
                                    item.InfoFile(wr);
                                }
                            }
                            "\n DONE"._sout(Yellow);
                            "Создан или перезаписан файл ans.txt ..."._sout(DarkYellow);
                            Console.ReadKey();
                            break;
                        case 5:
                            Process.Start("log.txt");
                            Console.WriteLine("Нажмите любую клавишу для продождения...");
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("По какому параметру сортируем?");
                            Console.WriteLine("1.Год");
                            Console.WriteLine("2.Вес");
                            Console.WriteLine("3. Цвет");
                            string pNum = Console.ReadLine();
                            foreach(var item in ListObj)
                            {
                                item.SortNumber = pNum;
                            }
                            ListObj.Sort();
                            "Список успешно отсортирован!"._sout(Green);
                            Console.ReadKey();
                            break;
                        case 7:
                            while (RemoveList)
                            {
                                Console.Clear();
                                int num = 0;
                                Console.Clear();
                                Console.WriteLine("Какой элемент будем удалять?");
                                foreach (var item in ListObj)
                                {
                                    num++;
                                    Console.WriteLine(num + ".");
                                    item.Info();
                                }
                                Console.WriteLine("Выбери номер элемента, который ты хочешь удалить");
                                int numDelElement = int.Parse(Console.ReadLine());
                                ListObj.RemoveAt(numDelElement - 1);
                                Console.WriteLine("Удаляем еще?");
                                "Да/Нет"._sout(Red);
                                string ss = Console.ReadLine().ToLower();
                                RemoveList = (ss == "нет") ? false : true;
                            }
                            "Элементы успешно удалены!"._sout(Green);
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.Clear();
                            "Список успешно удален!"._sout(Green);
                            Console.ReadKey();
                            break;
                        case 9:
                            fl = false;
                            break;
                        default:
                            break;

                    }


            }
                Console.Clear();
                "\n\n\n\n░██████╗███████╗███████╗  ███╗░░██╗███████╗██╗░░██╗████████╗  ████████╗██╗███╗░░░███╗███████╗\n██╔════╝██╔════╝██╔════╝  ████╗░██║██╔════╝╚██╗██╔╝╚══██╔══╝  ╚══██╔══╝██║████╗░████║██╔════╝\n╚█████╗░█████╗░░█████╗░░  ██╔██╗██║█████╗░░░╚███╔╝░░░░██║░░░  ░░░██║░░░██║██╔████╔██║█████╗░░\n░╚═══██╗██╔══╝░░██╔══╝░░  ██║╚████║██╔══╝░░░██╔██╗░░░░██║░░░  ░░░██║░░░██║██║╚██╔╝██║██╔══╝░░\n██████╔╝███████╗███████╗  ██║░╚███║███████╗██╔╝╚██╗░░░██║░░░  ░░░██║░░░██║██║░╚═╝░██║███████╗\n╚═════╝░╚══════╝╚══════╝  ╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░  ░░░╚═╝░░░╚═╝╚═╝░░░░░╚═╝╚══════╝"._sout(rainbowGradient);
                
                Console.ReadKey();
            }
        }

        

        private static void P_2(ref bool flag, List<Transport> ListObj, ref string err, StreamWriter sw)
        {
            Console.Clear();
            Console.Write("Введите название файла:");
            string path = Console.ReadLine() + ".txt";
            while (flag)
            {
                try
                {

                    string[] textArray = File.ReadAllLines(path);
                    flag = false;
                    textArray = File.ReadAllLines(path);
                    for (int i = 0; i < textArray.Length - 1; i++)
                    {
                        string[] line = textArray[i + 1].Split(' ');
                        switch (line[0])
                        {
                            case "Truck":
                                err = line[0];
                                ListObj.Add(new Truck(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), double.Parse(line[6])));
                                break;
                            case "Car":
                                err = line[0];
                                ListObj.Add((line.Length < 7) ?
                                    new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])) :
                                    new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), int.Parse(line[6])));

                                break;
                            case "Airplane":
                                err = line[0];
                                ListObj.Add(new Airplane(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])));


                                break;
                            case "Train":
                                err = line[0];
                                ListObj.Add(new Train(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], int.Parse(line[5])));
                                break;
                            default:
                                break;
                        }

                    }
                    "Данные с файла успешно загружены!"._sout(Green);

                }
                catch (TrainCarrExeption ex)
                {
                    $"Parameter error in {err}:\n{ex.Message} in {ex.type}"._sout(Red);

                    //"log file updated..."._sout(Red);
                    sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message} in {ex.type}");
                    flag = false;
                    "Нажмите любую клавишу для продолжения"._sout();
                    Console.ReadKey();
                }
                catch (UnauthorizedAccessException ex)
                {

                    $"Error :\n{ex.Message}"._sout(Red);
                    sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                    flag = false;

                }
                catch (FileNotFoundException ex)
                {
                    $"Error:\n{ex.Message}"._sout(Red);
                    sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                    flag = false;

                }
                catch (ArgumentException ex)
                {

                    $"Parameter error in {err}:\n{ex.Message}"._sout(Red);
                    //"log file updated..."._sout(Red);
                    sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message}");
                    flag = false;


                }
                catch (ArgumentOutOfRangeException ex)
                {
                    $"Error:\nНеверное количество аргументов."._sout(Red);
                    sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                    flag = false;
                }
                catch (Exception ex)
                {
                    $"Error:\n{ex.Message}"._sout(Red);
                    sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                    flag = false;

                }


            }
            Console.WriteLine("Нажмите любую клавишу для продождения...");

            Console.ReadKey();
        }
    }
}
