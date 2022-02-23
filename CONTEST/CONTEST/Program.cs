using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_A
{
    class Program
    {

        static void Main(string[] _1)
        {
            int count = 0;
            int cnt = 4;
            string[] s = File.ReadAllLines("input.txt");
            List<char> check = new List<char>();
            string[] s2 = s[0].Split(' ');
            int n = int.Parse(s2[0]);
            int m = int.Parse(s2[1]);
            string[,] matr = new string[n, m];
            char[] c = s2[2].ToCharArray();
            string inp = "";
            for (int i = 1; i < s.Length; i++)
            {
                inp += s[i];
            }
            for(int i = 0; i < m; i++)
            {
                inp += ".";
            }
            for(int i = 0; i < inp.Length; i++)
            {
                if (inp[i] == c[0])
                {
                    if(i - m > 0)
                    {
                        if ((inp[i - m] != '.') && (!(check.Contains(inp[i - m])) && (inp[i - m] != c[0])))
                        {
                            count++;
                            check.Add(inp[i - m]);
                        }
                    }
                    if(i + m < n * m)
                    {
                        if ((inp[i + m] != '.') && (!(check.Contains(inp[i + m])) && (inp[i + m] != c[0])))
                        {
                            count++;
                            check.Add(inp[i + m]);
                        }
                    }
                    if (i % m != m - 1)
                    {
                        if ((inp[i + 1] != '.') && (!(check.Contains(inp[i + 1])) && (inp[i + 1] != c[0])))
                        {
                            count++;
                            check.Add(inp[i + 1]);
                        }
                    }
                    if (i % m != 0)
                    {
                        if ((inp[i - 1] != '.') && (!(check.Contains(inp[i - 1])) && (inp[i - 1] != c[0])))
                        {
                            count++;
                            check.Add(inp[i - 1]);
                        }
                    }


                }
            }
            StreamWriter RE = new StreamWriter("output.txt");
            RE.WriteLine(count);
            RE.Close();
            
        }
    }
}