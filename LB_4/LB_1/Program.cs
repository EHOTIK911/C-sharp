using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            Console.Title = "dEad.NOT Menu v. 2";
            Console.OutputEncoding = Encoding.UTF8;
            ColoredConsole.Set();
            bool RemoveList = true;
            var textInfo = new CultureInfo("ru-RU").TextInfo;

            bool fl = true;
            int year, weight, horspower, carriages;
            string Color;
            double speed, BodyLenght, WingLenght;
            bool flag = true;
            var ListObj = new TransportList();
            var QObj = new Queue<Transport>();
            string err = default;
            //Console.Write("Input file Name: ");

            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                while (fl)
                {
                    bool flp = true;
                    int PNumber = default;
                    Console.Clear();
                    //$"{ex.Message}"._sout(Red);
                    //sw.WriteLine((new DateTime()));
                    "███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗\n████╗░████║██╔════╝████╗░██║██║░░░██║\n██╔████╔██║█████╗░░██╔██╗██║██║░░░██║\n██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║\n██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝\n╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░ v. 2"._sout(discordGradient1);
                    ""._sout();
                    Console.WriteLine("1. Ввод данных с консоли.");
                    Console.Write("2. Ввод данных из файла.");
                    " (data.txt)"._sout(DarkRed);
                    Console.WriteLine("3. Вывод даных в консоль.");
                    Console.WriteLine("4. Вывод даных в файл.");
                    Console.WriteLine("5. Открытие твоих логов.");
                    Console.WriteLine("6. Отсортировать массив.");
                    Console.WriteLine("7. Удаление элемента из списка");
                    Console.WriteLine("8. Очистить список.");
                    Console.WriteLine("9. Вывод определенных типов данных");
                    Console.WriteLine("10. Меню методов Queue");
                    Console.WriteLine("11. Выход");
                    "404. Количество элементов в листе/очереди"._sout(DarkGray);


                    Console.WriteLine("\nНу что, с чего начнем?");
                    Console.WriteLine("Введи номер пункта:");
                    while (flp)
                    try
                    {
                        PNumber = int.Parse(Console.ReadLine());
                            flp = false;
                    }
                    catch (Exception)
                    {
                            break;
                    }
                    
                    switch (PNumber)
                    {
                        case 1:
                            bool add = true;
                            while (add)
                            {
                                Console.Clear();
                                "\r\n███████╗██╗░░░░░███████╗███╗░░░███╗███████╗███╗░░██╗████████╗  ░█████╗░██████╗░██████╗░\r\n██╔════╝██║░░░░░██╔════╝████╗░████║██╔════╝████╗░██║╚══██╔══╝  ██╔══██╗██╔══██╗██╔══██╗\r\n█████╗░░██║░░░░░█████╗░░██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░  ███████║██║░░██║██║░░██║\r\n██╔══╝░░██║░░░░░██╔══╝░░██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░  ██╔══██║██║░░██║██║░░██║\r\n███████╗███████╗███████╗██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░  ██║░░██║██████╔╝██████╔╝\r\n╚══════╝╚══════╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░  ╚═╝░░╚═╝╚═════╝░╚═════╝░"._sout(discordGradient2);
                                ""._sout();
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
                                            {
                                                ListObj.Add(new Truck("Truck", year, weight, Color, speed, BodyLenght));
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
                                catch (TrainCarrExeption ex)
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
                            P_2(ref flag, ref ListObj, ref err, sw);
                            break;
                        case 3:
                            Console.Clear();
                            "\r\n███████╗██╗░░░░░███████╗███╗░░░███╗███████╗███╗░░██╗████████╗░██████╗  ██╗░░░░░██╗░██████╗████████╗\r\n██╔════╝██║░░░░░██╔════╝████╗░████║██╔════╝████╗░██║╚══██╔══╝██╔════╝  ██║░░░░░██║██╔════╝╚══██╔══╝\r\n█████╗░░██║░░░░░█████╗░░██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░╚█████╗░  ██║░░░░░██║╚█████╗░░░░██║░░░\r\n██╔══╝░░██║░░░░░██╔══╝░░██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░░╚═══██╗  ██║░░░░░██║░╚═══██╗░░░██║░░░\r\n███████╗███████╗███████╗██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░██████╔╝  ███████╗██║██████╔╝░░░██║░░░\r\n╚══════╝╚══════╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚═════╝░  ╚══════╝╚═╝╚═════╝░░░░╚═╝░░░"._sout(discordGradient2);
                            ""._sout();
                            for (int i = 0; i < ListObj.Count; i++)
                            {
                                ListObj[i].Info();
                            }
                            Console.WriteLine($"[ ListObj count: {ListObj.Count} ]");

                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            using (StreamWriter wr = new StreamWriter("ans.txt", true))
                            {
                                foreach (var item in ListObj)
                                {
                                    (item as Transport).InfoFile(wr);
                                }
                            }
                            "\r\n░█████╗░██████╗░██████╗░██╗███╗░░██╗░██████╗░  ████████╗░█████╗░  ███████╗██╗██╗░░░░░███████╗\r\n██╔══██╗██╔══██╗██╔══██╗██║████╗░██║██╔════╝░  ╚══██╔══╝██╔══██╗  ██╔════╝██║██║░░░░░██╔════╝\r\n███████║██║░░██║██║░░██║██║██╔██╗██║██║░░██╗░  ░░░██║░░░██║░░██║  █████╗░░██║██║░░░░░█████╗░░\r\n██╔══██║██║░░██║██║░░██║██║██║╚████║██║░░╚██╗  ░░░██║░░░██║░░██║  ██╔══╝░░██║██║░░░░░██╔══╝░░\r\n██║░░██║██████╔╝██████╔╝██║██║░╚███║╚██████╔╝  ░░░██║░░░╚█████╔╝  ██║░░░░░██║███████╗███████╗\r\n╚═╝░░╚═╝╚═════╝░╚═════╝░╚═╝╚═╝░░╚══╝░╚═════╝░  ░░░╚═╝░░░░╚════╝░  ╚═╝░░░░░╚═╝╚══════╝╚══════╝"._sout(discordGradient2);
                            ""._sout();
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
                            "\r\n░██████╗░█████╗░██████╗░████████╗\r\n██╔════╝██╔══██╗██╔══██╗╚══██╔══╝\r\n╚█████╗░██║░░██║██████╔╝░░░██║░░░\r\n░╚═══██╗██║░░██║██╔══██╗░░░██║░░░\r\n██████╔╝╚█████╔╝██║░░██║░░░██║░░░\r\n╚═════╝░░╚════╝░╚═╝░░╚═╝░░░╚═╝░░░"._sout(discordGradient2);
                            ""._sout();
                            Console.WriteLine("По какому параметру сортируем?");
                            Console.WriteLine("1.Год");
                            Console.WriteLine("2.Вес");
                            Console.WriteLine("3.Цвет");
                            string pNum = Console.ReadLine();
                            foreach (Transport item in ListObj)
                            {
                                item.SortNumber = pNum;
                            }
                            //source: https://stackoverflow.com/questions/16839479/using-lambda-expression-in-place-of-icomparer-argument
                            ListObj.Sort(Comparer<Transport>.Create((firstObj, secondObject) => firstObj.CompareTo(secondObject)));
                            "Список успешно отсортирован!"._sout(Green);
                            Console.ReadKey();
                            break;
                        case 7:
                            while (RemoveList)
                            {
                                bool flRem = true;
                                int numDelElement = default;
                                Console.Clear();
                                int num = 0;
                                Console.Clear();
                                "\r\n██████╗░███████╗██╗░░░░░███████╗████████╗███████╗\r\n██╔══██╗██╔════╝██║░░░░░██╔════╝╚══██╔══╝██╔════╝\r\n██║░░██║█████╗░░██║░░░░░█████╗░░░░░██║░░░█████╗░░\r\n██║░░██║██╔══╝░░██║░░░░░██╔══╝░░░░░██║░░░██╔══╝░░\r\n██████╔╝███████╗███████╗███████╗░░░██║░░░███████╗\r\n╚═════╝░╚══════╝╚══════╝╚══════╝░░░╚═╝░░░╚══════╝"._sout(discordGradient1);
                                ""._sout();
                                Console.WriteLine("Какой элемент будем удалять?");
                                foreach (var item in ListObj)
                                {
                                    num++;
                                    Console.WriteLine(num + ".");
                                    (item as Transport).Info();
                                }
                                Console.WriteLine("Выбери номер элемента, который ты хочешь удалить");
                                numDelElement = int.Parse(Console.ReadLine());
                                
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
                            ListObj.Clear();
                            //QObj.Clear();
                            "Список успешно удален!"._sout(Green);
                            Console.ReadKey();
                            break;
                        case 9:
                            //Console.Clear();
                            //"Какой вид транспорта вы хотите вывести?"._sout();
                            //var name = Console.ReadLine();      //car
                            //name = textInfo.ToTitleCase(textInfo.ToLower(name));
                            //var types = QObj.Where(x => x.type == name);
                            //if (types != null && types.Count() > 0)
                            //    types.ToList().ForEach(x => x.Info());
                            //else
                            //    Console.WriteLine($"Тип {name} не найден");
                            //Console.ReadKey();
                            break;
                        case 10:
                            bool fl10 = true;
                            while (fl10)
                            {
                                bool fl101 = true;
                                int PQ = default;
                                Console.Clear();
                                "\r\n░██████╗░██╗░░░██╗███████╗██╗░░░██╗███████╗\r\n██╔═══██╗██║░░░██║██╔════╝██║░░░██║██╔════╝\r\n██║██╗██║██║░░░██║█████╗░░██║░░░██║█████╗░░\r\n╚██████╔╝██║░░░██║██╔══╝░░██║░░░██║██╔══╝░░\r\n░╚═██╔═╝░╚██████╔╝███████╗╚██████╔╝███████╗\r\n░░░╚═╝░░░░╚═════╝░╚══════╝░╚═════╝░╚══════╝"._sout(rainbowGradient);
                                ""._sout();
                                Console.Write("1. Сортировка ");
                                "COMING SOON"._sout(Red);
                                Console.WriteLine("2. Вывод определенных типов транспорта на экран");
                                Console.WriteLine("3. Добавление элемента в очередь");
                                Console.WriteLine("4. Очистка Queue");
                                Console.WriteLine("5. Удаление и показ первого элемента в очереди");
                                Console.WriteLine("6. Вывод Очереди");
                                Console.WriteLine("7. Выход");
                                Console.Write("\nВведите номер пункта: ");
                                while (fl101)
                                {
                                    try
                                    {
                                        PQ = int.Parse(Console.ReadLine());
                                        fl101 = false;
                                    }
                                    catch (Exception)
                                    {

                                        break;
                                    }
                                }
                               
                                 
                                switch (PQ)
                                {
                                    case 1:
                                        Console.Clear();
                                        "\r\n██████╗░███████╗███╗░░░███╗░█████╗░██╗░░██╗████████╗\r\n██╔══██╗██╔════╝████╗░████║██╔══██╗██║░░██║╚══██╔══╝\r\n██████╔╝█████╗░░██╔████╔██║██║░░██║███████║░░░██║░░░\r\n██╔═══╝░██╔══╝░░██║╚██╔╝██║██║░░██║██╔══██║░░░██║░░░\r\n██║░░░░░███████╗██║░╚═╝░██║╚█████╔╝██║░░██║░░░██║░░░\r\n╚═╝░░░░░╚══════╝╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚═╝░░░╚═╝░░░"._sout(Red);
                                        ""._sout();
                                        "\r\n░█████╗░░█████╗░███╗░░░███╗██╗███╗░░██╗░██████╗░  ░██████╗░█████╗░░█████╗░███╗░░██╗\r\n██╔══██╗██╔══██╗████╗░████║██║████╗░██║██╔════╝░  ██╔════╝██╔══██╗██╔══██╗████╗░██║\r\n██║░░╚═╝██║░░██║██╔████╔██║██║██╔██╗██║██║░░██╗░  ╚█████╗░██║░░██║██║░░██║██╔██╗██║\r\n██║░░██╗██║░░██║██║╚██╔╝██║██║██║╚████║██║░░╚██╗  ░╚═══██╗██║░░██║██║░░██║██║╚████║\r\n╚█████╔╝╚█████╔╝██║░╚═╝░██║██║██║░╚███║╚██████╔╝  ██████╔╝╚█████╔╝╚█████╔╝██║░╚███║\r\n░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝░╚═════╝░  ╚═════╝░░╚════╝░░╚════╝░╚═╝░░╚══╝"._sout(discordGradient1);
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        "Какой вид транспорта вы хотите вывести?"._sout();
                                        var name = Console.ReadLine();      //car
                                        name = textInfo.ToTitleCase(textInfo.ToLower(name));
                                        var types = QObj.Where(x => x.type == name);
                                        if (types != null && types.Count() > 0)
                                            types.ToList().ForEach(x => x.Info());
                                        else
                                            Console.WriteLine($"Тип {name} не найден");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        bool p3 = true;
                                        while (p3)
                                        {
                                            "\r\n░█████╗░██████╗░██████╗░  ░██████╗░██╗░░░██╗███████╗██╗░░░██╗███████╗\r\n██╔══██╗██╔══██╗██╔══██╗  ██╔═══██╗██║░░░██║██╔════╝██║░░░██║██╔════╝\r\n███████║██║░░██║██║░░██║  ██║██╗██║██║░░░██║█████╗░░██║░░░██║█████╗░░\r\n██╔══██║██║░░██║██║░░██║  ╚██████╔╝██║░░░██║██╔══╝░░██║░░░██║██╔══╝░░\r\n██║░░██║██████╔╝██████╔╝  ░╚═██╔═╝░╚██████╔╝███████╗╚██████╔╝███████╗\r\n╚═╝░░╚═╝╚═════╝░╚═════╝░  ░░░╚═╝░░░░╚═════╝░╚══════╝░╚═════╝░╚══════╝"._sout(discordGradient2);
                                            ""._sout();
                                            Console.WriteLine("1. Чтение из файла");
                                            Console.WriteLine("2. Ручкой ввод");
                                            Console.Write("\nВведите номер пункта: ");
                                            int qp3 = int.Parse(Console.ReadLine());
                                            switch (qp3)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    "\r\n░█████╗░██████╗░██████╗░  ░██████╗░██╗░░░██╗███████╗██╗░░░██╗███████╗\r\n██╔══██╗██╔══██╗██╔══██╗  ██╔═══██╗██║░░░██║██╔════╝██║░░░██║██╔════╝\r\n███████║██║░░██║██║░░██║  ██║██╗██║██║░░░██║█████╗░░██║░░░██║█████╗░░\r\n██╔══██║██║░░██║██║░░██║  ╚██████╔╝██║░░░██║██╔══╝░░██║░░░██║██╔══╝░░\r\n██║░░██║██████╔╝██████╔╝  ░╚═██╔═╝░╚██████╔╝███████╗╚██████╔╝███████╗\r\n╚═╝░░╚═╝╚═════╝░╚═════╝░  ░░░╚═╝░░░░╚═════╝░╚══════╝░╚═════╝░╚══════╝"._sout(discordGradient2);
                                                    string path = "data.txt";
                                                    bool flagQ = true;
                                                    while (flagQ)
                                                    {
                                                        try
                                                        {

                                                            string[] textArray = File.ReadAllLines(path);
                                                            flagQ = false;
                                                            textArray = File.ReadAllLines(path);
                                                            for (int i = 0; i < textArray.Length - 1; i++)
                                                            {
                                                                string[] line = textArray[i + 1].Split(' ');
                                                                switch (line[0])
                                                                {
                                                                    case "Truck":
                                                                        err = line[0];
                                                                        QObj.Enqueue(new Truck(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), double.Parse(line[6])));

                                                                        break;
                                                                    case "Car":
                                                                        err = line[0];

                                                                        
                                                                        QObj.Enqueue((line.Length < 7) ?
                                                                            new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])) :
                                                                            new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), int.Parse(line[6])));
                                                                        break;
                                                                    case "Airplane":
                                                                        err = line[0];
                                                                        QObj.Enqueue(new Airplane(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])));

                                                                        break;
                                                                    case "Train":
                                                                        err = line[0];
                                                                        QObj.Enqueue(new Train(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], int.Parse(line[5])));
                                                                        break;
                                                                    default:
                                                                        break;
                                                                }

                                                            }
                                                            "Данные с файла успешно загружены!"._sout(Green);
                                                            p3 = false;

                                                        }
                                                        catch (TrainCarrExeption ex)
                                                        {
                                                            $"Parameter error in {err}:\n{ex.Message} in {ex.type}"._sout(Red);

                                                            //"log file updated..."._sout(Red);
                                                            sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message} in {ex.type}");
                                                            flagQ = false;
                                                            "Нажмите любую клавишу для продолжения"._sout();
                                                            Console.ReadKey();
                                                        }
                                                        catch (UnauthorizedAccessException ex)
                                                        {

                                                            $"Error :\n{ex.Message}"._sout(Red);
                                                            sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                                                            flagQ = false;

                                                        }
                                                        catch (FileNotFoundException ex)
                                                        {
                                                            $"Error:\n{ex.Message}"._sout(Red);
                                                            sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                                                            flagQ = false;

                                                        }
                                                        catch (ArgumentException ex)
                                                        {

                                                            $"Parameter error in {err}:\n{ex.Message}"._sout(Red);
                                                            //"log file updated..."._sout(Red);
                                                            sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message}");
                                                            flagQ = false;


                                                        }
                                                        catch (ArgumentOutOfRangeException ex)
                                                        {
                                                            $"Error:\nНеверное количество аргументов."._sout(Red);
                                                            sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                                                            flagQ = false;
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            $"Error:\n{ex.Message}"._sout(Red);
                                                            sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                                                            flagQ = false;

                                                        }


                                                    }
                                                    Console.WriteLine($"[ {QObj.Count} items add! ]");
                                                    Console.WriteLine("Нажмите любую клавишу для продождения...");
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
                                                    bool addQ = true;
                                                    while (addQ)
                                                    {
                                                        Console.Clear();
                                                        "\r\n░█████╗░██████╗░██████╗░  ░██████╗░██╗░░░██╗███████╗██╗░░░██╗███████╗\r\n██╔══██╗██╔══██╗██╔══██╗  ██╔═══██╗██║░░░██║██╔════╝██║░░░██║██╔════╝\r\n███████║██║░░██║██║░░██║  ██║██╗██║██║░░░██║█████╗░░██║░░░██║█████╗░░\r\n██╔══██║██║░░██║██║░░██║  ╚██████╔╝██║░░░██║██╔══╝░░██║░░░██║██╔══╝░░\r\n██║░░██║██████╔╝██████╔╝  ░╚═██╔═╝░╚██████╔╝███████╗╚██████╔╝███████╗\r\n╚═╝░░╚═╝╚═════╝░╚═════╝░  ░░░╚═╝░░░░╚═════╝░╚══════╝░╚═════╝░╚══════╝"._sout(discordGradient2);
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
                                                                    {
                                                                        QObj.Enqueue(new Truck("Truck", year, weight, Color, speed, BodyLenght));
                                                                    }

                                                                    "ADD!"._sout(Yellow);
                                                                    Thread.Sleep(3000);
                                                                    Console.Clear();
                                                                    Console.WriteLine("Еще что-то добавляем?");
                                                                    "Да/Нет"._sout(Red);
                                                                    s = Console.ReadLine();
                                                                    addQ = (s == "Нет") ? false : true;
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
                                                                        QObj.Enqueue(new Car("Car", year, weight, Color, speed));
                                                                    }
                                                                    else
                                                                    {
                                                                        horspower = int.Parse(Horspower);
                                                                        QObj.Enqueue(new Car("Car", year, weight, Color, speed, horspower));
                                                                    }
                                                                    "ADD!"._sout(Yellow);
                                                                    Thread.Sleep(3000);
                                                                    Console.Clear();
                                                                    Console.WriteLine("Еще что-то добавляем?");
                                                                    "Да/Нет"._sout(Red);
                                                                    s = Console.ReadLine();
                                                                    addQ = (s == "Нет") ? false : true;
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
                                                                    QObj.Enqueue(new Airplane("Airplane", year, weight, Color, WingLenght));
                                                                    "ADD!"._sout(Yellow);
                                                                    Thread.Sleep(3000);
                                                                    Console.Clear();
                                                                    Console.WriteLine("Еще что-то добавляем?");
                                                                    "Да/Нет"._sout(Red);
                                                                    s = Console.ReadLine();
                                                                    addQ = (s == "Нет") ? false : true;
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
                                                                    QObj.Enqueue(new Airplane(s, year, weight, Color, carriages));
                                                                    "ADD!"._sout(Yellow);
                                                                    Thread.Sleep(3000);
                                                                    Console.Clear();
                                                                    Console.WriteLine("Еще что-то добавляем?");
                                                                    "Да/Нет"._sout(Red);
                                                                    s = Console.ReadLine().ToLower();
                                                                    addQ = (s == "нет") ? false : true;
                                                                    Console.Clear();
                                                                    break;
                                                                default:
                                                                    add = false;
                                                                    break;
                                                            }
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
                                                default:
                                                    break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        QObj.Clear();
                                        "Очередь успешно удалена!"._sout(Green);
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        "\r\n░██████╗██╗░░██╗░█████╗░░██╗░░░░░░░██╗  ░█████╗░██████╗░  ██████╗░███████╗██╗░░░░░███████╗████████╗███████╗\r\n██╔════╝██║░░██║██╔══██╗░██║░░██╗░░██║  ██╔══██╗██╔══██╗  ██╔══██╗██╔════╝██║░░░░░██╔════╝╚══██╔══╝██╔════╝\r\n╚█████╗░███████║██║░░██║░╚██╗████╗██╔╝  ██║░░██║██████╔╝  ██║░░██║█████╗░░██║░░░░░█████╗░░░░░██║░░░█████╗░░\r\n░╚═══██╗██╔══██║██║░░██║░░████╔═████║░  ██║░░██║██╔══██╗  ██║░░██║██╔══╝░░██║░░░░░██╔══╝░░░░░██║░░░██╔══╝░░\r\n██████╔╝██║░░██║╚█████╔╝░░╚██╔╝░╚██╔╝░  ╚█████╔╝██║░░██║  ██████╔╝███████╗███████╗███████╗░░░██║░░░███████╗\r\n╚═════╝░╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░╚═╝░░  ░╚════╝░╚═╝░░╚═╝  ╚═════╝░╚══════╝╚══════╝╚══════╝░░░╚═╝░░░╚══════╝"._sout(discordGradient1);
                                        ""._sout();
                                        Console.WriteLine("1. показать и удалить");
                                        Console.WriteLine("2. Показать не удаляя");
                                        string ss = Console.ReadLine();
                                        Console.WriteLine(
                                            (ss == "1") ? QObj.Dequeue() : QObj.Peek()
                                            );
                                        Console.ReadKey();
                                        break;
                                    case 6:
                                        Console.Clear();
                                        "\r\n███████╗██╗░░░░░███████╗███╗░░░███╗███████╗███╗░░██╗████████╗░██████╗  ░██████╗░██╗░░░██╗███████╗██╗░░░██╗███████╗\r\n██╔════╝██║░░░░░██╔════╝████╗░████║██╔════╝████╗░██║╚══██╔══╝██╔════╝  ██╔═══██╗██║░░░██║██╔════╝██║░░░██║██╔════╝\r\n█████╗░░██║░░░░░█████╗░░██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░╚█████╗░  ██║██╗██║██║░░░██║█████╗░░██║░░░██║█████╗░░\r\n██╔══╝░░██║░░░░░██╔══╝░░██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░░╚═══██╗  ╚██████╔╝██║░░░██║██╔══╝░░██║░░░██║██╔══╝░░\r\n███████╗███████╗███████╗██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░██████╔╝  ░╚═██╔═╝░╚██████╔╝███████╗╚██████╔╝███████╗\r\n╚══════╝╚══════╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚═════╝░  ░░░╚═╝░░░░╚═════╝░╚══════╝░╚═════╝░╚══════╝"._sout(discordGradient2);
                                        ""._sout();
                                        foreach (var item in QObj)
                                        {
                                            item.Info();
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 7:
                                        fl10 = false;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case 11:
                            fl = false;
                            break;
                        case 404:
                            Console.Clear();
                            $"Количество Элементов в очереди: {QObj.Count}"._sout();
                            $"Количество Элементов в списке: {ListObj.Count}"._sout();
                            Console.ReadKey();
                            break;
                        default:
                            break;

                    }


                }
                Console.Clear();
                "\n\n\n\n░██████╗███████╗███████╗  ███╗░░██╗███████╗██╗░░██╗████████╗  ████████╗██╗███╗░░░███╗███████╗\n██╔════╝██╔════╝██╔════╝  ████╗░██║██╔════╝╚██╗██╔╝╚══██╔══╝  ╚══██╔══╝██║████╗░████║██╔════╝\n╚█████╗░█████╗░░█████╗░░  ██╔██╗██║█████╗░░░╚███╔╝░░░░██║░░░  ░░░██║░░░██║██╔████╔██║█████╗░░\n░╚═══██╗██╔══╝░░██╔══╝░░  ██║╚████║██╔══╝░░░██╔██╗░░░░██║░░░  ░░░██║░░░██║██║╚██╔╝██║██╔══╝░░\n██████╔╝███████╗███████╗  ██║░╚███║███████╗██╔╝╚██╗░░░██║░░░  ░░░██║░░░██║██║░╚═╝░██║███████╗\n╚═════╝░╚══════╝╚══════╝  ╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░  ░░░╚═╝░░░╚═╝╚═╝░░░░░╚═╝╚══════╝"._sout(discordGradient2);

                Console.ReadKey();
            }
        }



        public static void P_2(ref bool flag, ref TransportList ListObj, ref string err, StreamWriter sw)
        {
            Console.Clear();
            string path = "data.txt";
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
                                ListObj.Add(new Truck(
                                    line[0], 
                                    int.Parse(line[2]), 
                                    int.Parse(line[3]), 
                                    line[4], 
                                    double.Parse(line[5]), 
                                    double.Parse(line[6])
                                    ));

                                break;
                            case "Car":
                                err = line[0];
                                
                                ListObj.Add((line.Length < 7) ?
                                    new Car(
                                        line[0], 
                                        int.Parse(line[2]),
                                        int.Parse(line[3]), 
                                        line[4], 
                                        double.Parse(line[5])
                                        ) :
                                    new Car(
                                        line[0], 
                                        int.Parse(line[2]), 
                                        int.Parse(line[3]), 
                                        line[4], 
                                        double.Parse(line[5]), 
                                        int.Parse(line[6])
                                        ));
                               
                                break;
                            case "Airplane":
                                err = line[0];
                                ListObj.Add(new Airplane(
                                    line[0], 
                                    int.Parse(line[2]),
                                    int.Parse(line[3]),
                                    line[4],
                                    double.Parse(line[5])));

                                break;
                            case "Train":
                                err = line[0];
                                ListObj.Add(new Train(
                                    line[0], 
                                    int.Parse(line[2]), 
                                    int.Parse(line[3]), 
                                    line[4], 
                                    int.Parse(line[5])));
                                break;
                            default:
                                break;
                        }

                    }
                    "\r\n███████╗██╗░░░░░███████╗███╗░░░███╗███████╗███╗░░██╗████████╗░██████╗  ░█████╗░██████╗░██████╗░███████╗██████╗░██╗\r\n██╔════╝██║░░░░░██╔════╝████╗░████║██╔════╝████╗░██║╚══██╔══╝██╔════╝  ██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗██║\r\n█████╗░░██║░░░░░█████╗░░██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░╚█████╗░  ███████║██║░░██║██║░░██║█████╗░░██║░░██║██║\r\n██╔══╝░░██║░░░░░██╔══╝░░██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░░╚═══██╗  ██╔══██║██║░░██║██║░░██║██╔══╝░░██║░░██║╚═╝\r\n███████╗███████╗███████╗██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░██████╔╝  ██║░░██║██████╔╝██████╔╝███████╗██████╔╝██╗\r\n╚══════╝╚══════╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚═════╝░  ╚═╝░░╚═╝╚═════╝░╚═════╝░╚══════╝╚═════╝░╚═╝"._sout(discordGradient1);

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
            Console.WriteLine($"[ items add: {ListObj.Count} ]");

            Console.ReadKey();
        }
    }
}
