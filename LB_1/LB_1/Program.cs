using System;
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

            get { return Year;}
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
            Weight = Weight*Weight;
        }
        #endregion
        //
        
       // public abstract void Info();
    }
    /*
    class Train : Transport
    {
        public int Сarriages { get; set; }
        public Train(int year, int weight, string color, int carriages) : base(year, weight, color)
        {
            Сarriages = carriages;
        }
        public static void Info()
        {
            "   Train"._sout(Cyan);
            $" Year: {Year}\n Weight: {Weight}\n Color: {Color}\n Carriages: {Сarriages}"._sout(Red);
            //Console.WriteLine("Train");
            //Console.WriteLine($"Year: {Year}\n" +
            //                  $"Weight: {Weight}\n" +
            //                  $"Color: {Color}");
            //Console.WriteLine($"Сarriages: {Сarriages}\n");
        }
    }
    
    public class Airplane : Transport
    {
        public double WingLength { get; set; }
        public Airplane(int year, int weight, string color, double wingLength) : base(year, weight, color)
        {
            WingLength = wingLength;
        }

        public override void Info()
        {
            Console.WriteLine("Airplane");
            Console.WriteLine($"Year: {Year}\n" +
                              $"Weight: {Weight}\n" +
                              $"Color: {Color}");
            Console.WriteLine($"WingLength: {WingLength:0.00}\n");
        }
    }

    public class Car : Transport
    {
        public double Speed { get; set; }
        public Car(int year, int weight, string color, double speed) : base(year, weight, color)
        {
            Speed = speed;
        }

        public override void Info()
        {
            Console.WriteLine("Car");
            Console.WriteLine($"Year: {Year}\n" +
                              $"Weight: {Weight}\n" +
                              $"Color: {Color}");
            Console.WriteLine($"Speed: {Speed:0.00}\n");
        }
    }

    public class Truck : Car
    {
        public double BodyLength { get; set; }
        public Truck(int year, int weight, string color, double speed, double bodyLength) : base(year, weight, color, speed)
        {
            BodyLength = bodyLength;
        }

        public override void Info()
        {
            Console.WriteLine("Truck");
            Console.WriteLine($"Year: {Year}\n" +
                              $"Weight: {Weight}\n" +
                              $"Color: {Color}\n" +
                              $"Speed: {Speed:0.00}");
            Console.WriteLine($"BodyLength: {BodyLength:0.00}\n");
        }
    }

    public class Passenger : Car
    {
        public string PassengerType { get; set; }
        public Passenger(int year, int weight, string color, double speed, string passengerType) : base(year, weight, color, speed)
        {
            PassengerType = passengerType;
        }

        public override void Info()
        {
            Console.WriteLine("Truck");
            Console.WriteLine($"Year: {Year}\n" +
                              $"Weight: {Weight}\n" +
                              $"Color: {Color}\n" +
                              $"Speed: {Speed:0.00}");
            Console.WriteLine($"PassengerType: {PassengerType}\n");
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
        public static DateTime cachedTime;
        static void Main(string[] args)
        {
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
                //$"{pet.Weight}"._sout();

                Console.ReadKey();
        }
    }
}
