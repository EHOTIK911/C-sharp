using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABA_4_2
{
    internal class Program
    {
        private void button1_Click(object sender, EventArgs e)
        {

            
        }
        static void Main(string[] args)
        {
            
            string[] qwertw = new string[33];
            using (StreamReader s2r = new StreamReader("qwerty2.txt"))
            {
                string line;
                line = s2r.ReadLine();
                qwertw = File.ReadAllText("qwerty2.txt").Split(' ');
            }
            //...  CODING  ...\\
            CODING(qwertw);
            //... DECODING ...\\

            DE_CODING(qwertw);
        }

        private static void DE_CODING(string[] qwertw)
        {
            using (StreamReader sr = new StreamReader("coding.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] symbols = File.ReadAllLines("coding.txt");


                    for (int i = 0; i < symbols.Length; i++)
                    {
                        string str = symbols[i];
                        for (int g = 0; g < str.Length; g++)
                        {
                            bool flag = true;
                            int count = 0;
                            for (int g2 = 0; g2 < qwertw.Length; g2++)
                            {
                                if (str[g].ToString() == qwertw[g2])
                                {
                                    count = g2;
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag == false)
                            {
                                if (count - 1 == -1)
                                {
                                    str = str.Remove(g, 1);
                                    str = str.Insert(g, qwertw[31].ToString());
                                    using (StreamWriter file1 = new StreamWriter("decoding.txt"))
                                    {
                                        file1.Write(str);
                                    }
                                }
                                else
                                {
                                    str = str.Remove(g, 1);
                                    str = str.Insert(g, qwertw[count - 1].ToString());
                                    using (StreamWriter file1 = new StreamWriter("decoding.txt"))
                                    {
                                        file1.Write(str);
                                    }
                                }
                            }

                        }

                    }
                }
            }
        }

        private static void CODING(string[] qwertw)
        {
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] symbols = File.ReadAllLines("text.txt");


                    for (int i = 0; i < symbols.Length; i++)
                    {
                        string str = symbols[i];
                        for (int g = 0; g < str.Length; g++)
                        {
                            bool flag = true;
                            int count = 0;
                            for (int g2 = 0; g2 < qwertw.Length; g2++)
                            {
                                if (str[g].ToString() == qwertw[g2])
                                {
                                    count = g2;
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag == false)
                            {
                                if (count + 1 == 32)
                                {
                                    if( str[g].ToString() == qwertw[count].ToUpper())
                                    {
                                        str = str.Remove(g, 1);
                                        str = str.Insert(g, qwertw[0].ToString().ToUpper());
                                        using (StreamWriter file1 = new StreamWriter("coding.txt"))
                                        {
                                            file1.Write(str);
                                        }
                                       
                                    }
                                    else
                                    {
                                        str = str.Remove(g, 1);
                                        str = str.Insert(g, qwertw[0].ToString());
                                        using (StreamWriter file1 = new StreamWriter("coding.txt"))
                                        {
                                            file1.Write(str);
                                        }
                                    }
                                }
                                else
                                {
                                    if (str[g].ToString() == qwertw[count].ToUpper())
                                    {
                                        str = str.Remove(g, 1);
                                        str = str.Insert(g, qwertw[count+1].ToString().ToUpper());
                                        using (StreamWriter file1 = new StreamWriter("coding.txt"))
                                        {
                                            file1.Write(str);
                                        }

                                    }
                                    else
                                    {
                                        str = str.Remove(g, 1);
                                        str = str.Insert(g, qwertw[count + 1].ToString());
                                        using (StreamWriter file1 = new StreamWriter("coding.txt"))
                                        {
                                            file1.Write(str);
                                        }
                                    }
                                }
                            }

                        }

                    }
                }
            }
        }
    }
}
