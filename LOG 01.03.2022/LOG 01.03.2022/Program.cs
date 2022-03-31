using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LOG_01._03._2022
{
    internal class Program
    {
        static int priority(string lexem)
        {
            int pr;
            switch (lexem)
            {
                case "(": pr = 0; break;
                    case ")": case "=": pr = 1; break;
                case "<": case ">": case "<=": case ">=": case "==": case "!=": pr = 6; break;
                case "+": case "-": pr = 7;break;
                    case "*": case "/": case "%": pr = 8;break;
                    case"^"
                    default: pr = -1;break;
            }
        }
        static void Main(string[] args)
        {
            string line;
            using(StreamReader sr = new StreamReader("input.txt"))
            {
                line = sr.ReadToEnd();
            }
            Console.WriteLine();
            string[] lexem = line.Split(new char[] { ' ','\t','\n','\r' }, StringSplitOptions.RemoveEmptyEntries);
            Stack < KeyValuePair < string, int>> stack = new Stack<KeyValuePair<string, int»();
            StringBuilder opz = new StringBuilder();
            foreach(string lexem in lexems){
                int pr = priority(lexem);
                if (pr == -1)
                {
                    opz.Append(lexem + " ");
                }
                else
                {
                    if(pr == 0 || stack.Count == 0|| pr > stack.Peek().Value)
                    {

                    }
                }
}
        }
    }
}
