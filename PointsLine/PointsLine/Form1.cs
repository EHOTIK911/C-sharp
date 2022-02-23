using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PointsLine
{
    public partial class Form1 : Form
    {
        List<objectslp.Point> allpoints = new List<objectslp.Point>();
        objectslp.Line lRes = new objectslp.Line();
        objectslp.Point point1, point2;
        bool ArePointsLoaded = false;
        bool isSolved = false;
        bool FlagXconst = false;
        bool FlagYconst = false;
        float X2, Y2, X3, Y3, scale;
        float maxY, minY, maxX, minX;

        public Form1()
        {
            InitializeComponent();
            Width = 1000;
            Height = 1000;
        }
        static void QuickSortA(float[] a, float[] b, int iLeft, int iRight)
        {
            int i = iLeft;
            int j = iRight;
            double iMidElement = a[iLeft + (iRight - iLeft) / 2];
            do
            {
                while (a[i] < iMidElement)
                {
                    i++;
                }
                while (a[j] > iMidElement)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(ref a[i], ref a[j]);
                    Swap(ref b[i], ref b[j]);
                    i++;
                    j--;
                }
            } while (i < j);
            if (iLeft < j)
            {
                QuickSortA(a, b, iLeft, j);
            }
            if (iRight > i)
            {
                QuickSortA(a, b, i, iRight);
            }
        }
        static void Swap(ref float A, ref float B)
        {
            float iTemp = A;
            A = B;
            B = iTemp;
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isSolved)
            {
                Graphics g = e.Graphics;
                float XCenter = Width / 2;
                float YCenter = Height / 2;
                scale = Math.Min(Width, Height) / Math.Max(Math.Abs(maxX - minX), Math.Abs(maxY - minY));
                Pen blackPen = new Pen(Color.Black, 2);
                g.DrawLine(blackPen, 0, YCenter, Width, YCenter);
                g.DrawLine(blackPen, XCenter, 0, XCenter, Height);
                foreach (var pt in allpoints)
                {
                    float xCur = XCenter + pt.X * scale;
                    float yCur = YCenter - pt.Y * scale;
                    Brush redBrush = new SolidBrush(Color.Red);
                    g.FillRectangle(redBrush, xCur - 3, yCur - 3, 6, 6);
                }
                Brush greenBrush = new SolidBrush(Color.Green);
                float xScaled2 = XCenter + point1.X * scale;
                float yScaled2 = YCenter - point1.Y * scale;
                float xScaled3 = XCenter + point2.X * scale;
                float yScaled3 = YCenter - point2.Y * scale;

                //Точки через которые проходит прямая отмечены зеленым
                if (allpoints.Count % 2 == 1)
                {
                    foreach (objectslp.Point pt in allpoints)
                    {
                        if (pt.X == point1.X && pt.Y == point1.Y)
                        {
                            Brush purpleBrush = new SolidBrush(Color.Purple);
                            g.FillRectangle(purpleBrush, xScaled2 - 3, yScaled2 - 3, 6, 6);
                            g.FillRectangle(greenBrush, xScaled3 - 3, yScaled3 - 3, 6, 6);
                            break;
                        }
                        if (pt.X == point2.X && pt.Y == point2.Y)
                        {
                            Brush purpleBrush = new SolidBrush(Color.Purple);
                            g.FillRectangle(greenBrush, xScaled2 - 3, yScaled2 - 3, 6, 6);
                            g.FillRectangle(purpleBrush, xScaled3 - 3, yScaled3 - 3, 6, 6);
                            break;
                        }
                    }
                }
                else
                {
                    g.FillRectangle(greenBrush, xScaled2 - 3, yScaled2 - 3, 6, 6);
                    g.FillRectangle(greenBrush, xScaled3 - 3, yScaled3 - 3, 6, 6);
                }
               
                Pen bluePen = new Pen(Color.Blue, 2);

                float x4 = (-maxX * 2);
                float x5 = (maxX * 2);
                float y4 = 0;
                float y5 = 0;
                
                if (Math.Abs(lRes.B) > 0.00000001)
                {
                    y4 = (-lRes.C - lRes.A * x4) / (lRes.B);
                    y5 = (-lRes.C - lRes.A * x5) / (lRes.B);
                }
                else
                {
                    x4 = (-lRes.C / lRes.A);
                    x5 = x4;
                    y4 = -Math.Max(Math.Abs(minX), Math.Abs(maxX)) * 2;
                    y5 = Math.Max(Math.Abs(minX), Math.Abs(maxX)) * 2;
                }
                x4 = XCenter + x4 * scale;
                x5 = XCenter + x5 * scale;
                y4 = YCenter - y4 * scale;
                y5 = YCenter - y5 * scale;
                g.DrawLine(bluePen, x4, y4, x5, y5);
             
                Invalidate();
            }
            else
            {
                MessageBox.Show("Решение не найдено");
            }
        }

        private void точкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sFileName = ofd.FileName;
                allpoints = ReadPointFromFile(sFileName);
                ArePointsLoaded = true;
                MessageBox.Show($"{allpoints.Count} точек загружено из файла");
            }
        }
        private void графикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSolved)
            {
                pictureBox1.Invalidate();
            }
            else
            {
                MessageBox.Show("Решение не найдено");
            }
        }

        private void решениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ArePointsLoaded)
            {
                FlagXconst = false;
                FlagYconst = false;

                int NumbOfPoints = allpoints.Count;
                float[] XCoord = new float[NumbOfPoints];
                float[] YCoord = new float[NumbOfPoints];
                int q = 0;
                minY = int.MaxValue;
                maxY = int.MinValue;
                foreach (objectslp.Point pt in allpoints)
                {
                    XCoord[q] = pt.X;
                    YCoord[q] = pt.Y;
                    if (YCoord[q] < minY)
                    {
                        minY = YCoord[q];
                    }
                    if (YCoord[q] > maxY)
                    {
                        maxY = YCoord[q];
                    }
                    q++;
                }

                //Сортировка X координаты по возрастанию, если Х координата одинаковая, то по возрастанию Y координаты
                QuickSortA(XCoord, YCoord, 0, allpoints.Count - 1);
                int iL = NumbOfPoints;
                int iR = 0;
                for (int i = 1; i < NumbOfPoints; i++)
                {
                    if (XCoord[i] != XCoord[i - 1])
                    {
                        iL = i;
                    }
                    else
                    {
                        iR = i;
                        if (iL < iR)
                        {
                            QuickSortA(YCoord, XCoord, iL, iR);
                        }
                    }
                }
                if (iL == NumbOfPoints)
                {
                    {
                        QuickSortA(YCoord, XCoord, 0, NumbOfPoints - 1);
                    }
                }

                if (minY == maxY)
                {
                    FlagYconst = true;
                    if (NumbOfPoints % 2 == 0)
                    {
                        X2 = (XCoord[NumbOfPoints / 2] + XCoord[NumbOfPoints / 2 - 1]) / 2;
                        X3 = X2;
                        Y2 = (YCoord[0]);
                        Y3 = YCoord[0] + 1;
                    }
                    else
                    {
                        X2 = (XCoord[NumbOfPoints / 2]);
                        X3 = X2;
                        Y2 = (YCoord[0]);
                        Y3 = (YCoord[0] + 1);
                    }
                }
                else
                {
                    if (XCoord[0] == XCoord[NumbOfPoints-1])
                    {
                        FlagXconst = true;
                        if (NumbOfPoints % 2 == 0)
                        {
                            X2 = XCoord[0];
                            X3 = X2 + 1;
                            Y2 = (YCoord[NumbOfPoints / 2] + YCoord[NumbOfPoints / 2 - 1]) / 2;
                            Y3 = Y2;
                        }
                        else
                        {
                            X2 = XCoord[0];
                            X3 = X2 + 1;
                            Y2 = (YCoord[NumbOfPoints / 2]);
                            Y3 = Y2;
                        }
                    }
                    else
                    {
                        //Координаты средней точки (X0;Y0)
                        int iMiddle = NumbOfPoints / 2;
                        float X0 = XCoord[iMiddle];
                        float Y0 = YCoord[iMiddle];

                        //Находим точку (X1;Y1)
                        //X1 - первая отличающаяся координата по X из точек слева от средней, если такой нет, то берем X1 = X0 - 1
                        //Y1 - если X координата точки перед средней равна X0, то Y1 = координате этой точки, иначе Y1 = Y0 - 1
                        float X1 = X0;
                        float Y1 = Y0;
                        for (int i = iMiddle - 1; i >= 0; i--)
                        {
                            if (XCoord[i] != X1)
                            {
                                X1 = XCoord[i];
                                break;
                            }
                        }
                        if (X1 == X0)
                        {
                            X1 = X1 - 1;
                        }

                        //X1_2 - первая X координата точки справа от средней, не равная X0
                        float X1_2 = X0;
                        for (int i = iMiddle + 1; i < NumbOfPoints; i++)
                        {
                            if (XCoord[i] != X1_2)
                            {
                                X1_2 = XCoord[i];
                                break;
                            }
                        }
                        if (X1_2 == X0) //Если такой нет, то X1_2 = X0 + 1
                        {
                            X1_2 = X1_2 + 1;
                        }

                        if (XCoord[iMiddle - 1] == XCoord[iMiddle])
                        {
                            Y1 = YCoord[iMiddle - 1];
                        }
                        else
                        {
                            Y1 = Y0 - 1;
                        }

                        //Параметр Z - минимум из X0 - X1 и X1_2 - X0 
                        float Z = 0;
                        if (X0 - X1 < X1_2 - X0)
                        {
                            Z = X0 - X1;
                        }
                        else
                        {
                            Z = X1_2 - X0;
                        }

                        //Искомая прямая проходит через точки (X2;Y2) (X3;Y3)
                        X2 = X0;
                        if (NumbOfPoints % 2 == 0) //Если общее число точек четно
                        {
                            Y2 = (Y0 + Y1) / 2;
                        }
                        else //нечетное число точек
                        {
                            Y2 = Y0;
                        }
                        X3 = X0 + Z / 2;
                        Y3 = Y0 - maxY + minY;
                        minX = XCoord[0];
                        maxX = XCoord[NumbOfPoints - 1];
                    }
                }
                            
                //координаты для скейлинга
                float XTemp1 = Math.Max(X2, X3);
                float XTemp2 = Math.Min(X2, X3);
                float YTemp1 = Math.Max(Y2, Y3);
                float YTemp2 = Math.Min(Y2, Y3);
                minX = Math.Min(minX, XTemp2) - 5;
                maxX = Math.Min(maxX, XTemp1) + 5;
                minY = Math.Min(minY, YTemp2) - 5;
                maxY = Math.Max(maxY, YTemp1) + 5;

                //искомые объекты
                point1 = new objectslp.Point(X2, Y2);
                point2 = new objectslp.Point(X3, Y3);
                lRes = new objectslp.Line(point1, point2);
                
                MessageBox.Show($"Прямая, являющаяся решением данной задачи проходит через точки ({point1.X}; {point1.Y}) и ({point2.X}; {point2.Y})");
                if (NumbOfPoints % 2 == 1)
                {
                    MessageBox.Show($"Точка лежащая на прямой - ({point1.X}; {point1.Y})");
                }
                if (FlagXconst == true)
                {
                    MessageBox.Show($"Уравнение искомой прямой: y = {Y3}");
                }
                else
                {
                    if (FlagYconst == true)
                    {
                        MessageBox.Show($"Уравнение искомой прямой: x = {X3}");
                    }
                    else
                    {
                        MessageBox.Show($"Уравнение искомой прямой: {lRes.A}x + {lRes.B}y + {lRes.C} = 0");
                    }
                }
                isSolved = true;
            }
            else
            {
                MessageBox.Show("Данные не загружены");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        static List<objectslp.Point> ReadPointFromFile(string sPath)
        {
            List<objectslp.Point> points = new List<objectslp.Point>();
            using (StreamReader sr = new StreamReader(sPath))
            {
                string[] sPts = sr.ReadToEnd().Split('\n');
                string[] coord;
                foreach (string s in sPts)
                {
                    coord = s.Split(' ');
                    points.Add(new objectslp.Point(float.Parse(coord[0]), float.Parse(coord[1])));
                }
                sr.Close();
            }
            return points;
        }
    }    
}