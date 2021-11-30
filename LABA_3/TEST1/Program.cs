using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TEST1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Генерация чаровского массива из алфавита (любого)
            char[] letters = Enumerable.Range('А', 'Я' - 'А' + 1).Select(c => (char)c).ToArray();
            for(int i = 0; i < letters.Length; i++)
            {
                Console.Write(letters[i] + " ");
            }
            Console.ReadKey();

        }
    }
}
