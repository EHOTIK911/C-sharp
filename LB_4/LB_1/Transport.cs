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
    //class Names : IComparable
    //{
    //    public string Name { get; set; }
    //    public int CompareTo(object o)
    //    {
    //        Transport t = o as Transport;
    //        if (t != null)
    //        {
    //            return Name.CompareTo(t.type);
    //        }
    //        else
    //            throw new Exception("Невозможно отсортировать");
    //    }
    //}
    class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException() { }

        public UnauthorizedAccessException(string message) : base(message) { }
    }
    class FileNotFoundException : Exception
    {
        public FileNotFoundException() { }
        public FileNotFoundException(string message) : base(message) { }
    }
    class TrainCarrExeption : Exception
    {
        public string type;
        public TrainCarrExeption() { }
        public TrainCarrExeption(string message, string type) : base(message)
        {
            this.type = type;
        }
    }
    class ArgumentException : Exception
    {
        public string type;
        public ArgumentException() { }

        public ArgumentException(string message) : base(message) { }
        public ArgumentException(string message, string type) : base(message) 
        {
        
        this.type = type;
        }

    }

    #region Classes
    public abstract class Transport : IComparable<Transport>
    {
        #region Base
        public string type;
        private int _year;
        public string SortNumber;
        List<TransportElements> transports = new List<TransportElements>();
        public int CompareTo(Transport t)
        {
            if (SortNumber == "1")
            {
                return _year.CompareTo(t._year);
            }
            else if (SortNumber == "2")
            {
                return weight.CompareTo(t.weight);
            }
            else if (SortNumber == "3")
            {
                return Color.CompareTo(t.Color);
            }
            else
            {
                return type.CompareTo(t.type);
            }
        }
        
        
        public int year
        {

            get { return _year; }
            set { 
                if (value > 1900 && value < 2022) _year = value; 
                else { throw new ArgumentException("Enter the correct release date",type); _year = value; } }
        }

        private int _weight;
        public int weight
        {
            get { return _weight; }
            set
            {
                if (value > 0) _weight = value; 
                else { throw new ArgumentException("Enter the correct weight"); _weight = value; };
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
        public Transport(string type, int year, int weight, string color)
        {
            this.type = type;
            this.year = year;
            this.weight = weight;
            Color = color;
        }
        /// <summary>
        /// Transport
        /// </summary>
        /// <param name="s">Year</param>
        public Transport(int s) : this("test", s, 12, "Blue") { }
        #endregion
        #region Override
        public override string ToString()
        {
            return String.Format
                (
                $"      {type}\n" +
                $"      Year: {_year}\n" +
                $"      Weight: {_weight}\n" +
                $"      Color: {Color}\n"
                );
        }

        #endregion

        #region Voids

        public virtual void CarrAddError()
        {        }
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

        public virtual void speak()
        {
            " i'm Transport"._sout(Cyan);
        }
        public abstract void Info();
        public abstract void InfoFile(StreamWriter sw);
    }


    class Train : Transport
    {

        private int Сarriages;

        public Train(string type, int year, int weight, string color, int carriages) : base(type, year, weight, color)
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
                { throw new ArgumentException("Enter the correct number of Сarriages"); Сarriages = value; }

            }
        }
        public override void CarrAddError()
        {
            carriages += 100;
            throw new TrainCarrExeption("Максимальное число вагонов - 100", type);
        }
        public override void speak()
        {
            "I'm Train"._sout(Cyan);

        }
        public override string ToString()
        {
            return base.ToString() + $"      Сarriages: {Сarriages}\n";
        }
        public override void Info()

        {
            
            this.speak();
            Console.WriteLine($"{type}");
            Console.WriteLine($"Year: {year}\n" +
                              $"Weight: {weight}\n" +
                              $"Color: {Color}");
            Console.WriteLine($"Сarriages: {Сarriages}\n");
        }
        public override void InfoFile(StreamWriter sw)

        {

            sw.WriteLine($"{type}");
            sw.WriteLine($"Year: {year}\n" +
                              $"Weight: {weight}\n" +
                              $"Color: {Color}");
            sw.WriteLine($"Сarriages: {Сarriages}\n");
        }
    }

    class Airplane : Transport
    {
        public double WingLength { get; set; }
        public Airplane(string type, int year, int weight, string color, double wingLength) : base(type, year, weight, color)
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
                { throw new ArgumentException("Enter the correct length of the wings"); WingLength = value; }

            }
        }
        public override void speak()
        {
            "I'm Airplane"._sout(Cyan);
        }
        public override string ToString()
        {
            return base.ToString() + $"      WingLength: {WingLength}\n";
        }
        public override void Info()
        {
            Console.WriteLine($"{type}");
            Console.WriteLine($"Year: {year}\n" +
                              $"Weight: {weight}\n" +
                              $"Color: {Color}");
            Console.WriteLine($"WingLength: {WingLength}\n");
        }
        public override void InfoFile(StreamWriter sw)
        {
            sw.WriteLine($"{type}");
            sw.WriteLine($"Year: {year}\n" +
                              $"Weight: {weight}\n" +
                              $"Color: {Color}");
            sw.WriteLine($"WingLength: {WingLength}\n");
        }


        /*
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
        public class Passenger : Car
    {
        public string PassengerType { get; set; }
        public Passenger(int year, int weight, string color, double speed, string passengerType) : base(year, weight, color, speed)
        {
            PassengerType = passengerType;
        }
        public override void speak()
        {
            Console.WriteLine("I'm Passenger");
        }
        public override void Info()
        {
            this.speak();
            Console.WriteLine("Passenger");
            Console.WriteLine($"Year: {year}\n" +
                              $"Weight: {weight}\n" +
                              $"Color: {Color}");
            Console.WriteLine($"PassengerType: {PassengerType}\n");
        }
    }
        */

    }
    public class Car : Transport
    {
        public double Speed { get; set; }
        public int HorsePower { get; set; }
        public Car(string type, int year, int weight, string color, double speed, int horspower) : base(type, year, weight, color)
        {
            this.horspower = horspower;
            this.speed = speed;
        }
        public Car(string type, int year, int weight, string color, double speed) : base(type, year, weight, color)
        {
            this.speed = speed;
        }
        public int horspower
        {
            get { return HorsePower; }
            set
            {
                if (value > 0)
                    HorsePower = value;
                else
                { throw new ArgumentException("Enter the correct number of horsepower"); HorsePower = value; }

            }
        }
        public double speed
        {
            get { return Speed; }
            set
            {
                if (value > 0)
                    Speed = value;
                else
                { throw new ArgumentException("Enter the correct speed"); Speed = value; }

            }
        }
        public override void speak()
        {
            "I'm Car"._sout(Cyan);
        }
        public override string ToString()
        {
            return base.ToString() + $"      Speed: {Speed}\n      HorsePower: {horspower}\n";
        }
        public override void Info()
        {
            if (HorsePower != 0)
            {
                speak();
                Console.WriteLine($"{type}");
                Console.WriteLine($"Year: {year}\n" +
                                  $"Weight: {weight}\n" +
                                  $"Color: {Color}");
                Console.WriteLine($"Speed: {Speed}");
                Console.WriteLine($"HorsePower: {horspower}\n");
            }
            else
            {
                speak();
                Console.WriteLine($"{type}");
                Console.WriteLine($"Year: {year}\n" +
                                  $"Weight: {weight}\n" +
                                  $"Color: {Color}");
                Console.WriteLine($"Speed: {Speed}\n");
            }

        }
        public override void InfoFile(StreamWriter sw)
        {
            if (HorsePower != 0)
            {
                sw.WriteLine($"{type}");
                sw.WriteLine($"Year: {year}\n" +
                                  $"Weight: {weight}\n" +
                                  $"Color: {Color}");
                sw.WriteLine($"Speed: {Speed}");
                sw.WriteLine($"HorsePower: {horspower}\n");
            }
            else
            {
                sw.WriteLine($"{type}");
                sw.WriteLine($"Year: {year}\n" +
                                  $"Weight: {weight}\n" +
                                  $"Color: {Color}");
                sw.WriteLine($"Speed: {Speed}\n");
            }

        }
    }

    public class Truck : Car
    {
        public double BodyLength { get; set; }
        public Truck(string type, int year, int weight, string color, double speed, double bodyLength) : base(type, year, weight, color, speed)
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
                { throw new ArgumentException("Enter the correct body length"); BodyLength = value; }

            }
        }
        public override void speak()
        {
            "I'm Truck"._sout(Cyan);
        }
        public override string ToString()
        {
            return base.ToString() + $"      bodyLength: {bodyLength}\n";
        }
        public override void Info()
        {
            this.speak();
            this.ToString();
            Console.WriteLine($"{type}");
            Console.WriteLine($"Year: {year}\n" +
                              $"Weight: {weight}\n" +
                              $"Color: {Color}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"bodyLength: {bodyLength}\n");
        }
        public override void InfoFile(StreamWriter sw)
        {

            sw.WriteLine($"{type}");
            sw.WriteLine($"Year: {year}\n" +
                              $"Weight: {weight}\n" +
                              $"Color: {Color}");
            sw.WriteLine($"Speed: {Speed}");
            sw.WriteLine($"bodyLength: {bodyLength}\n");
        }
    }

}
#endregion