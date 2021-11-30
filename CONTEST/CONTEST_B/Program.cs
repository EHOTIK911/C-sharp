
using System.IO;


namespace CONTEST_B
{
    class Program
    {
        static void Main(string[] args)
        {

            int O = 0;string[] MASSIV = File.ReadAllLines("input.txt");int MAXIMUM = MASSIV[1].Length;
            StreamWriter RE = new StreamWriter("output.txt");
            NULL_STRING(MASSIV, MAXIMUM);O = CASE_BASE_PROGRAM(O, MASSIV, MAXIMUM, RE);
            RE.Close();
        }

        private static int CASE_BASE_PROGRAM(int O, string[] MASSIV, int MAXIMUM, StreamWriter RE)
        {
            if (MASSIV.Length - 1 > 1)
            {
                while (O < MAXIMUM)
                    O = WHILE_METHOD(O, MASSIV, RE);
            }
            else
            {
                string STRING = MASSIV[1];
                for (int i = 0; i < MASSIV[1].Length; i++)
                    PRINT_1(RE, STRING, i);
            }

            return O;
        }

        private static void PRINT_1(StreamWriter RE, string STRING, int i)
        {
            if (STRING[i] == '?')
                RE.Write("a" + "");
            else
                RE.Write(STRING[i] + "");
        }

        private static int WHILE_METHOD(int O, string[] MASSIV, StreamWriter RE)
        {
            bool FLAG_1 = true, FLAG_2 = true;
            char SIGN_1 = MASSIV[1][O];
            for (int i = 2; i < MASSIV.Length; i++)
                BASE_CODE(O, MASSIV, ref FLAG_1, ref FLAG_2, ref SIGN_1, i);
            if (FLAG_2 == true && SIGN_1 != '?')
                RE.Write(SIGN_1.ToString());
            if (FLAG_2 == false)
                RE.Write("?");
            if (SIGN_1 == '?' && FLAG_2 == true)
                RE.Write("a");
            O++;
            return O;
        }

        private static void BASE_CODE(int O, string[] MASSIV, ref bool FLAG_1, ref bool FLAG_2, ref char SIGN_1, int i)
        {
            char SIGN_2 = MASSIV[i][O];
            if ((SIGN_2.ToString() == "?" && FLAG_1 == true && SIGN_2 != SIGN_1) || (SIGN_1.ToString() == "?" && FLAG_1 == true && SIGN_2 != SIGN_1))
            {
                FLAG_1 = false;
                if (SIGN_1.ToString() == "?")
                    SIGN_1 = SIGN_2;
            }

            if (SIGN_2 != SIGN_1 && SIGN_2.ToString() != "?" && SIGN_1.ToString() != "?" && FLAG_2 == true && SIGN_2 != SIGN_1)
            {
                FLAG_2 = false;
                SIGN_1 = '?';
            }
        }

        private static void NULL_STRING(string[] MASSIV, int MAXIMUM)
        {
            for (int H = 1; H < MASSIV.Length; H++)
                FORM_MASSIV(MASSIV, MAXIMUM, H);
        }

        private static void FORM_MASSIV(string[] MASSIV, int MAXIMUM, int H)
        {
            while (MASSIV[H].Length < MAXIMUM)
                MASSIV[H] += "?";
        }
    }
}