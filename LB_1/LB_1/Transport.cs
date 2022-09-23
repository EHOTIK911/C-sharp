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
        #region Base
        private int _year;
        public int year
        {

            get { return _year; }
            set { if (value > 1900 && value < 2022) _year = value; else { $"     Incorrect Year\n   1900 < Value < 2022\n         ↓↓↓↓"._sout(Red); _year = value; } }
        }

        private int _weight;
        public int weight
        {
            get { return _weight; }
            set
            {
                if (value > 0) _weight = value; else { $"    Incorrect Weight\n       Value > 0\n         ↓↓↓↓"._sout(Red); _weight = value; };
            }
        }
        public string Color;
        
        
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
        /// <summary>
        /// Transport
        /// </summary>
        /// <param name="s">Year</param>
        public Transport(int s) : this(s, 12, "Blue") { }
        #endregion
        #region Override
        //Регионы
        public override string ToString()
        {
            return String.Format
                (
                $"      Year: {_year}\n" +
                $"      Weight: {_weight}\n" +
                $"      Color: {Color}\n"
                );
        }
        #endregion

        #region Voids
        public void YearUp()
        {
            _year++;
        }
        public void WeightUp()
        {
            _weight = _weight + 25;
        }
        public override bool Equals(object obj)
        {
            if (obj is Transport)
            {
                Transport other = (Transport)obj;
                return (_year == other._year) && (_weight == other._weight) && (Color == other.Color);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Transport s1, Transport s2)
        {

            return s1.Equals(s2);
        }
        public static bool operator !=(Transport s1, Transport s2)
        {

            return !(s1.Equals(s2));
        }
        #endregion

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
                { $"    Incorrect Сarriages\n       Value > 0\n         ↓↓↓↓"._sout(Red); Сarriages = value; }

            }
        }
        public override string ToString()
        {
            return base.ToString() + $"      Сarriages: {Сarriages}";
                //(
                //// $"   {Name}\n" +
                //$"      Year: {year}\n" +
                //$"      Weight: {weight}\n" +
                //$"      Color: {Color}\n" +
                //);
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
            return base.ToString() + 
                $"      WingLength: {WingLength}";

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
            return base.ToString() + 
                $"      Speed: {Speed}";
            
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
            return base.ToString() + 
                $"      BodyLength: {BodyLength}";
            
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
}
