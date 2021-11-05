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
            //string[] qwerty = File.ReadAllLines("qwerty.txt");
            char[] qwertw = new char[26];
            using (StreamReader s2r = new StreamReader("qwerty2eng.txt"))
            {
                string line;
                line = s2r.ReadLine();
                qwertw = line.ToCharArray();
            }
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    char[] symbols = line.ToCharArray();
                    string str = string.Empty;
                    using (StreamReader reader = File.OpenText("text.txt"))
                    {
                        str = reader.ReadToEnd();
                    }
                    for (int i = 0; i < symbols.Length; i++)
                    {

                        
                        for (int j = 0; j < qwertw.Length; j++)
                        {
                            if (symbols[i] == qwertw[j])
                            {
                                if (j + 1 < 32)
                                {
                                    str = str.Replace(symbols[i], qwertw[j + 1]);
                                    using (StreamWriter file1 = new StreamWriter("test.txt"))
                                    {
                                        file1.Write(str);
                                    }

                                }
                                else if (j + 1 == 32)
                                {
                                    str = str.Replace(symbols[i], qwertw[0]);
                                    using (StreamWriter file1 = new StreamWriter("test.txt"))
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
