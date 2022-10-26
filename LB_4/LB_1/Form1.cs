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
using Microsoft.Win32;
using static System.ConsoleColor;
using static LB_1.ColoredConsole;
using System.Windows.Forms;

namespace LB_1
{

    public partial class Form1 : Form
    {
        public TransportList ListObj = new TransportList();

        public Form1()
        {
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

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ListObj.Count; i++)
            {
                ListObj[i].Info();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListObj.Clear();

        }

        private void импортФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                bool flag = true;
                
                var QObj = new Queue<Transport>();
                string err = default;
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
                                    ListObj.Add(new Truck(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), double.Parse(line[6])));
                                    QObj.Enqueue(new Truck(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), double.Parse(line[6])));

                                    break;
                                case "Car":
                                    err = line[0];
                                    ListObj.Add((line.Length < 7) ?
                                        new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])) :
                                        new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), int.Parse(line[6])));
                                    QObj.Enqueue((line.Length < 7) ?
                                        new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])) :
                                        new Car(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5]), int.Parse(line[6])));
                                    break;
                                case "Airplane":
                                    err = line[0];
                                    ListObj.Add(new Airplane(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])));
                                    QObj.Enqueue(new Airplane(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], double.Parse(line[5])));

                                    break;
                                case "Train":
                                    err = line[0];
                                    ListObj.Add(new Train(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], int.Parse(line[5])));
                                    QObj.Enqueue(new Train(line[0], int.Parse(line[2]), int.Parse(line[3]), line[4], int.Parse(line[5])));
                                    break;
                                default:
                                    break;
                            }

                        }

                    }
                    catch (TrainCarrExeption ex)
                    {

                        sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message} in {ex.type}");
                        flag = false;
                        MessageBox.Show($"Parameter error in {err}:\n{ex.Message} in {ex.type}");
                    }
                    catch (UnauthorizedAccessException ex)
                    {

                        MessageBox.Show($"Error :\n{ex.Message}");
                        sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                        flag = false;

                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show($"Error:\n{ex.Message}");
                        sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                        flag = false;

                    }
                    catch (ArgumentException ex)
                    {

                        MessageBox.Show($"Parameter error in {err}:\n{ex.Message}");
                        sw.WriteLine(DateTime.Now + $": Parameter error in {err}: {ex.Message}");
                        flag = false;


                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBox.Show($"Error:\nНеверное количество аргументов.");
                        sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                        flag = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error:\n{ex.Message}");
                        sw.WriteLine(DateTime.Now + $": Error: {ex.Message}");
                        flag = false;

                    }


                }
            }
            
        }
    }
}
