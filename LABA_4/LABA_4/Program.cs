using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABA_4_1
{
    internal class Program
    {
        public static bool istPalindrom(char[] word)
        {
            int i1 = 0;
            int i2 = word.Length - 1;
            while (i2 > i1)
            {
                if (word[i1] != word[i2])
                {
                    return false;
                }
                ++i1;
                --i2;
            }
            return true;
        }
        //static bool IsPalindromInternal(string str)
        //{
        //    if (str.Length == 1 || string.IsNullOrEmpty(str)) return true;
        //    if (!str[0].Equals(str[str.Length - 1])) return false;
        //    return IsPalindromInternal(str.Substring(1, str.Length - 2));
        //}
        static void Main(string[] args)
        {
            //string[] file_name = File.ReadAllLines("text.txt");
            List<int> Length = new List<int>();

            int max = 0;
            List<string> word = new List<string>();
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    
                    line = line.Replace(",", "");
                    line = line.Replace(".", "");
                    line = line.Replace("-", "");
                    line = line.Replace("+", "");
                    line = line.Replace("=", "");
                    line = line.Replace("/", "");
                    line = line.Replace("*", "");
                    string[] splitLine = line.Split(' ');
                    for(int i = 0; i < splitLine.Length; i++)
                    {
                        char[] nes = splitLine[i].ToCharArray();
                        if (istPalindrom(nes))
                        {
                            if (splitLine[i].Length > max)
                            {
                                word.Add(splitLine[i]);
                                max = splitLine[i].Length;

                            }
                        }
                    }
                }
                
                
            }
            int last_index = word.Count - 1;
            Console.WriteLine(word[last_index]);
            Console.ReadKey();
        }
    }
}