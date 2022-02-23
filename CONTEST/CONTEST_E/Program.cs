using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_E
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] s = File.ReadAllLines("input.txt");
            List<string> check = new List<string>();
            string[] s2 = s[0].Split(' ');
            int n = int.Parse(s2[0]);
            int m = int.Parse(s2[1]);
            for (int i = 0; i < s.Length; i++)
            {
                string gd = "";
                List<char> ss = s[i].ToCharArray().ToList();
                if(ss[0] == '+')
                {
                    check.Add(s[i]);
                    continue;
                }
                if(ss[0] == '|')
                {
                    for(int g = 1; g < ss.Count - 1; g++)
                    {
                        ss[g] = '.';
                    }
                }
                for(int l = 0; l < ss.Count; l++)
                {
                    gd += ss[l];
                }
                check.Add(gd);

            }
            check.RemoveAt(0);
            StreamWriter RE = new StreamWriter("output.txt");
            for(int i = 0; i < check.Count; i++)
            {
                RE.WriteLine(check[i]);
            }
            RE.Close();
            
        }
    }
}
