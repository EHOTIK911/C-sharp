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
        static void Main(string[] args)
        {

            // строка символов на клавиатуре и следующий за ней символ
            string KeyStr1 = "йцукенгшщзхъйфывапролджэфячсмитьбюяЙЦУКЕНГШЩЗХЪЙФЫВАПРОЛДЖЭФЯЧСМИТЬБЮЯ";
            // файл с текстом
            string path = "text.txt";
            // файл с зашифрованным текстом
            string writePath = "shifr.txt";
            string writePath1 = "DEshifr.txt";
            // очищаем файл
            StreamWriter sw = new StreamWriter(writePath, false);
            sw.Close();
            StreamWriter sw1 = new StreamWriter(writePath1, false);
            sw1.Close();
            
            //CODING
            using (StreamReader sr = new StreamReader(path))
            {
                string orig_line;
                // пока не закончились строки в файле
                while ((orig_line = sr.ReadLine()) != null)
                {
                    // k-тый символ строки текста
                    int k = 0;
                    // временная строка с шифром
                    string newline = "";
                    while (newline.Length != orig_line.Length)
                    {
                        // чекер на кириллицу, кроме ё
                        bool c = true;
                        for (int i = 0; i < KeyStr1.Length; i++)
                        {
                            // если находим символ, записываем следующий за ним (согласно варианту)
                            if (orig_line[k] == KeyStr1[i])
                            {
                                newline += KeyStr1[i + 1];
                                c = false;
                                break;
                            }
                        }
                        // если символ не кириллица, кроме ё, то записываем символ как есть
                        if (c)
                        {
                            newline += orig_line[k];
                        }
                        k++;
                    }
                    // для печати
                    using (sw = new StreamWriter(writePath, true))
                    {
                        sw.WriteLine(newline);
                    }
                }
            }
            //DECODING
            using (StreamReader sr = new StreamReader(path))
            {
                string orig_line;
                // пока не закончились строки в файле
                while ((orig_line = sr.ReadLine()) != null)
                {
                    // k-тый символ строки текста
                    int k = 0;
                    // временная строка с шифром
                    string newline = "";
                    while (newline.Length != orig_line.Length)
                    {
                        // чекер на кириллицу, кроме ё
                        bool c = true;
                        for (int i = KeyStr1.Length-1; i > 0 ; i--)
                        {
                            // если находим символ, записываем следующий за ним (согласно варианту)
                            if (orig_line[k] == KeyStr1[i])
                            {
                                newline += KeyStr1[i];
                                c = false;
                                break;
                            }
                        }
                        // если символ не кириллица, кроме ё, то записываем символ как есть
                        if (c)
                        {
                            newline += orig_line[k];
                        }
                        k++;
                    }
                    // для печати
                    using (sw = new StreamWriter(writePath1, true))
                    {
                        sw.WriteLine(newline);
                    }
                }
            }

        }
    }
}
