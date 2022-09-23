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

    internal class Program
    {
        
        Errors Error = new Errors();
        //ErTrain Error = new Errors();
        
        public static DateTime cachedTime;
        static void Main(string[] args)
        {
            int year, weight;
            string color;
            Errors err = new Errors();
            string path = "data.txt";
            var text = File.ReadAllText(path);
            string[] textArray = File.ReadAllLines(path);
            
            for(int i = 0; i < textArray.Length; i++)
            {
                int s = textArray[i].IndexOf('=');
                textArray[i] = textArray[i].Remove(0, s + 1);
            }
            year = int.Parse(textArray[0]);
            weight = int.Parse(textArray[1]);
            color = textArray[2];

            //var cachedTime = DateTime.Now;
            Random rand = new Random();
            string[] colors = new string[] { "Blue", "Black", "Red", "Green", "Yellow" };
            string[] passengerType = new string[] { "WithBody", "WithoutBody" };

            Console.WriteLine("   // operator this \\\\");
            // "   // operator this \\\\"._sout(Cyan);
            Transport TrainAuto = new Transport(2022);

            // $"  {pet}"._sout(Cyan);
            //TrainAuto.year = 9;
            Console.WriteLine(TrainAuto.ToString());
            //$"{TrainAuto.ToString()}"._sout();
            TrainAuto.YearUp();
            TrainAuto.WeightUp();
            Console.WriteLine("   // operator void \\\\");
            //"   // operator void \\\\"._sout(Cyan);
            Console.WriteLine(TrainAuto.ToString());
            // $"{TrainAuto.ToString()}"._sout();
            Console.WriteLine(" // Correct / Incorrect \\\\");
            //$" // Correct / Incorrect \\\\"._sout(Cyan);
            Transport test = new Transport(2003, 21, "BLue");
            Transport TrainManual = new Transport(2023, -33, "Cyan");
            Console.WriteLine(TrainManual.ToString());
            //$"{TrainManual.ToString()}"._sout();
            Transport Trans = new Transport(205, 2, "White");
            Console.WriteLine(Trans.ToString());
            //$"{Trans.ToString()}"._sout();
            Transport Test_2 = new Train(2003, 21, "BLue", -23);
            Console.WriteLine(Test_2.ToString());
            // $"{Test_2.ToString()}"._sout();
            Console.WriteLine("   Read File");
            //"   Read File"._sout(Cyan);
            Transport file = new Transport(year, weight, color);
            Console.WriteLine(file.ToString());
            //$"{file.ToString()}"._sout(Red);

            //$"{pet.Weight}"._sout();

            Console.ReadKey();
            
        }
    }
}
