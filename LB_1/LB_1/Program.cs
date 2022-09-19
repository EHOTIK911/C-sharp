﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using static System.ConsoleColor;
using static LB_1.ColoredConsole;

namespace LB_1
{

    interface Exeptions
    {
        void test1();
    }
    interface ErTrain
    {
        void test();
    }
    class Errors : Exeptions, ErTrain
    {
        void Exeptions.test1()
        {
            $"     Incorrect Year\n   1900 < Value < 2022\n         ↓↓↓↓"._sout(Red);
        }
        void ErTrain.test()
        {

        }
    }

    #region Classes
    public class Transport
    {
        //  private static string _name;
        //public string Name;
        #region Base
        private int Year;

        // проверить адекватность написания
        private int Weight; // только положительный 
        public string Color;
        //  private int Сarriages;
        public int year {

            get { return Year; }
            set { if (value > 1900 && value < 2022) Year = value; else { $"     Incorrect Year\n   1900 < Value < 2022\n         ↓↓↓↓"._sout(Red); Year = value; } }
        }
        public int weight
        {
            get { return Weight; }
            set
            {
                if (value > 0) Weight = value; else { $"    Incorrect Weight\n       Value > 0\n         ↓↓↓↓"._sout(Red); Weight = value; };
            }
        }
        #endregion
        #region method
        public Transport() { }
        /// <summary>
        /// Transport
        /// </summary>
        /// <param name="year">Year Transport</param>
        /// <param name="weight">Weight Transport</param>
        /// <param name="color">Color Transport</param>
        public Transport(int year, int weight, string color)
        {
            // Name = name;
            this.year = year;
            this.weight = weight;
            Color = color;
        }
        public Transport(string s) : this(2020, 12, "Blue") { }
        #endregion
        #region Override
        //Регионы
        public override string ToString()
        {
            return String.Format
                (
                // $"   {Name}\n" +
                $"      Year: {Year}\n" +
                $"      Weight: {Weight}\n" +
                $"      Color: {Color}\n"
                );
        }
        #endregion

        #region Voids
        public void YearUp()
        {
            Year++;
        }
        public void WeightUp()
        {
            Weight = Weight * Weight;
        }
        #endregion
        //

        // public abstract void Info();
    }

    class Train : Transport
    {

        private int Сarriages;
        
        public Train(int year, int weight, string color, int carriages) : base(year, weight, color)
        {
            this.carriages = carriages;
        }
        public int carriages
        {
            get { return Сarriages; }
            set
            {
                if (value > 0)
                    Сarriages = value;
                else
                { $"    Incorrect Value\n       Value > 0\n         ↓↓↓↓"._sout(Red); Сarriages = value; }
                
            }
        }
        public override string ToString()
        {
            return String.Format
                (
                // $"   {Name}\n" +
                $"      Year: {year}\n" +
                $"      Weight: {weight}\n" +
                $"      Color: {Color}\n" +
                $"      Сarriages: {Сarriages}" 
                );
        }
    }
    
    public class Airplane : Transport
    {
        public double WingLength { get; set; }
        public Airplane(int year, int weight, string color, double wingLength) : base(year, weight, color)
        {
            this.wingLength = wingLength;
        }
        public double wingLength
        {
            get { return WingLength; }
            set
            {
                if (value > 0)
                    WingLength = value;
                else
                { $"    Incorrect Value\n       Value > 0\n         ↓↓↓↓"._sout(Red); WingLength = value; }

            }
        }

        public override string ToString()
        {
            return String.Format
                (
                // $"   {Name}\n" +
                $"      Year: {year}\n" +
                $"      Weight: {weight}\n" +
                $"      Color: {Color}\n" +
                $"      WingLength: {WingLength}" 
                );
        }
    }

    public class Car : Transport
    {
        public double Speed { get; set; }
        public Car(int year, int weight, string color, double speed) : base(year, weight, color)
        {
            this.speed = speed;
        }
        public double speed
        {
            get { return Speed; }
            set
            {
                if (value > 0)
                    Speed = value;
                else
                { $"    Incorrect Value\n       Value > 0\n         ↓↓↓↓"._sout(Red); Speed = value; }

            }
        }

        public override string ToString()
        {
            return String.Format
                (
                // $"   {Name}\n" +
                $"      Year: {year}\n" +
                $"      Weight: {weight}\n" +
                $"      Color: {Color}\n" +
                $"      Speed: {Speed}" 
                );
        }
    }

    public class Truck : Car
    {
        public double BodyLength { get; set; }
        public Truck(int year, int weight, string color, double speed, double bodyLength) : base(year, weight, color, speed)
        {
            this.bodyLength = bodyLength;
        }
        public double bodyLength
        {
            get { return BodyLength; }
            set
            {
                if (value > 0)
                    BodyLength = value;
                else
                { $"    Incorrect Value\n       Value > 0\n         ↓↓↓↓"._sout(Red); BodyLength = value; }

            }
        }

        public override string ToString()
        {
            return String.Format
                (
                // $"   {Name}\n" +
                $"      Year: {year}\n" +
                $"      Weight: {weight}\n" +
                $"      Color: {Color}\n" +
                $"      BodyLength: {BodyLength}" 
                );
        }
    }
    /*
    public class Passenger : Car
    {
        public string PassengerType { get; set; }
        public Passenger(int year, int weight, string color, double speed, string passengerType) : base(year, weight, color, speed)
        {
            PassengerType = passengerType;
        }

        public override string ToString()
        {
            return String.Format
                (
                // $"   {Name}\n" +
                $"      Year: {year}\n" +
                $"      Weight: {weight}\n" +
                $"      Color: {Color}\n" +
                $"      WingLength: {WingLength}" 
                );
        }
    }

    public class PassengerPlane : Airplane
    {
        public int Seats { get; set; }
        public PassengerPlane(int year, int weight, string color, double wingLength, int seats) : base(year, weight, color, wingLength)
        {
            Seats = seats;
        }

        public override void Info()
        {
            Console.WriteLine("Airplane");
            Console.WriteLine($"Year: {Year}\n" +
                              $"Weight: {Weight}\n" +
                              $"Color: {Color}\n" +
                              $"WingLength: {WingLength:0.00}");
            Console.WriteLine($"Seats: {Seats}\n");
        }
    }
    public class CargoPlane : Airplane
    {
        public double Capacity { get; set; }
        public CargoPlane(int year, int weight, string color, double wingLength, double capacity) : base(year, weight, color, wingLength)
        {
            Capacity = capacity;
        }

        public override void Info()
        {
            Console.WriteLine("Airplane");
            Console.WriteLine($"Year: {Year}\n" +
                              $"Weight: {Weight}\n" +
                              $"Color: {Color}\n" +
                              $"WingLength: {WingLength:0.00}");
            Console.WriteLine($"Capacity: {Capacity:0.00}\n");
        }
    }
    */
    

    #endregion
    internal class Program
    {
        
        Errors Error = new Errors();
        //ErTrain Error = new Errors();
        
        public static DateTime cachedTime;
        static void Main(string[] args)
        {

            Errors err = new Errors();
            string path = "data.txt";
            var text = File.ReadAllText(path);
            string[] textArray = File.ReadAllLines(path);
            if (File.Exists(path))
            {
                

                //вывод в консоль количества строк и пути
                Console.WriteLine($"Текстовый файл по пути {path} содержит {textArray.Length} строк:");

                //цикл фор итерирующий по количеству строк
                for (int i = 0; i < textArray.Length; i++)
                {
                    //берём строку по индексу
                    text = textArray[i];

                    //выводим номер строки и строку
                    Console.WriteLine($"{i}) {text}");
                }
            }
            for(int i = 0; i < textArray.Length; i++)
            {

            }
            //var cachedTime = DateTime.Now;
            Random rand = new Random();
            string[] colors = new string[] { "Blue", "Black", "Red", "Green", "Yellow" };
            string[] passengerType = new string[] { "WithBody", "WithoutBody" };

            "   // operator this \\\\"._sout(Cyan);
            Transport TrainAuto = new Transport("Train");

            // $"  {pet}"._sout(Cyan);
            //TrainAuto.year = 9;
            
            $"{TrainAuto.ToString()}"._sout();
            TrainAuto.YearUp();
            TrainAuto.WeightUp();
            "   // operator void \\\\"._sout(Cyan);
            $"{TrainAuto.ToString()}"._sout();
            
            $" // Correct / Incorrect \\\\"._sout(Cyan);

            Transport test = new Transport(2003, 21, "BLue");
            Transport TrainManual = new Transport(2021, -33, "Cyan");
            $"{TrainManual.ToString()}"._sout();
            Transport Trans = new Transport(205, 2, "White");
            $"{Trans.ToString()}"._sout();
            Transport Test_2 = new Train(2003, 21, "BLue", -23);
            $"{Test_2.ToString()}"._sout();
            
                //$"{pet.Weight}"._sout();

                Console.ReadKey();
            void ReadText(string p)
            {
                var text = File.ReadAllText(p);
                string[] textArray = File.ReadAllLines(p);

                //вывод в консоль количества строк и пути
                Console.WriteLine($"Текстовый файл по пути {p} содержит {textArray.Length} строк:");

                //цикл фор итерирующий по количеству строк
                for (int i = 0; i < textArray.Length; i++)
                {
                    //берём строку по индексу
                    text = textArray[i];

                    //выводим номер строки и строку
                    Console.WriteLine($"{i}) {text}");
                }
            }
        }
    }
}
