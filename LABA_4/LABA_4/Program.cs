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
        static bool IsPalindromInternal(string str)
        {
            if (str.Length == 1 || string.IsNullOrEmpty(str)) return true;
            if (!str[0].Equals(str[str.Length - 1])) return false;
            return IsPalindromInternal(str.Substring(1, str.Length - 2));
        }
        static void Main(string[] args)
        {
            string path = "text.txt";
            string[] file_name = File.ReadAllLines("text.txt");
            List<int> Length = new List<int>();
            List<string> word = new List<string>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
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
                    line = line.Replace(" ", "\n");
                    if (IsPalindromInternal(line))
                    {
                        Length.Add(line.Length);
                        word.Add(line);
                    }
                    
                }
                int d = Length.Max();
                int r =Length.IndexOf(d);
                Console.WriteLine(word[r]);
            }
            Console.ReadKey();
        }
    }
}
