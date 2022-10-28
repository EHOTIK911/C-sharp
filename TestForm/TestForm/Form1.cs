using LB_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArgumentException = LB_1.ArgumentException;
using FileNotFoundException = LB_1.FileNotFoundException;
using UnauthorizedAccessException = LB_1.UnauthorizedAccessException;

namespace TestForm
{

    public partial class Form1 : Form
    {
        public TransportList ListObj = new TransportList();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void импортToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            label1.Text = str;
            for (int i = 0; i < ListObj.Count; i++)
            {
                str += $"{ListObj[i].type}\n{ListObj[i].type}\n{ListObj[i].year}\n{ListObj[i].weight}\n{ListObj[i].Color}\n\n";


            }
            textBox1.AppendText(str);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            label1.Text = str;
            for (int i = 0; i < ListObj.Count; i++)
            {
                str += $"{ListObj[i].type}\n{ListObj[i].type}\n{ListObj[i].year}\n{ListObj[i].weight}\n{ListObj[i].Color}\n\n";
                

            }
            label1.Text = str;
            for(int i = 0; i < 1; i++)
                textBox1.Text = str;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
