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
            bool flag = true;

            string err = default;
            Console.Write("Input file Name: ");
            string path = Console.ReadLine();
            
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                //$"{ex.Message}"._sout(Red);
                //sw.WriteLine((new DateTime()));

                while (flag)
                {
                    try
                    {
                        string[] textArray = File.ReadAllLines(path);
                        Transport[] arr = new Transport[textArray.Length - 1];
                        flag = false;
                        textArray = File.ReadAllLines(path);
                        arr = new Transport[textArray.Length - 1];
                        for (int i = 0; i < textArray.Length - 1; i++)
                        {
                            string[] line = textArray[i + 1].Split(' ');
                            switch (line[0])
                            {
                                case "Truck":
                                    err = line[0];
                                    arr[i] = new Truck(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), double.Parse(line[6]));
                                    break;
                                case "Car":
                                    err = line[0];
                                    arr[i] = (line.Length < 7) ?
                                        new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])) :
                                        new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), int.Parse(line[6]));

                                    break;
                                case "Airplane":
                                    err = line[0];
                                    arr[i] = new Airplane(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]));


                                    break;
                                case "Train":
                                    err = line[0];
                                    arr[i] = new Train(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], int.Parse(line[5]));
                                    break;
                                default:
                                    break;
                            }
                            arr[i].Info();
                        }

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
                    catch (Exception ex)
                    {
                        $"Error:\n{ex.Message}"._sout(Red);
                        sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                        flag = false;

                    }


                }

                Console.ReadKey();

            }
        }
    }
}
