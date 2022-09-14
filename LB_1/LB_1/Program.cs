using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using static System.ConsoleColor;
using static LB_1.ColoredConsole;

namespace LB_1
{


    public class Transport
    {
        private string Name { get; set; }
        private int Year { get; set; }
        private int Weight { get; set; }
        private string Color { get; set; }


        public Transport() { }
        /// <summary>
        /// Transport
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="year">Year</param>
        /// <param name="weight">Weight</param>
        /// <param name="color">Color</param>
        private Transport(string name, int year, int weight, string color)
        {
            Name = name;
            Year = year;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            return String.Format($"   {Name}\n Year: {Year}\n Weight: {Weight}\n Color: {Color}\n");
        }

        public Transport(string s) : this(s, 22, 12, "Blue") { }

       // public abstract void Print();
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
    internal class Program
    {
        public static DateTime cachedTime;
        static void Main(string[] args)
        {
            var cachedTime = DateTime.Now;
            Random rand = new Random();
            string[] colors = new string[] { "Blue", "Black", "Red", "Green", "Yellow" };
            string[] passengerType = new string[] { "WithBody", "WithoutBody" };


            Transport pet = new Transport("Train");
            //$"  {pet.Name}"._sout(Cyan);
            $"{pet.ToString()}"._sout(Red);
            //$"{pet.Weight}"._sout();
            
            Console.ReadKey();
        }
    }
}
