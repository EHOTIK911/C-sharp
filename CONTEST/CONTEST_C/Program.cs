using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_C
{
    class Program
    {
        static int Counter(int[] off, int POS_OFF, int[] LINE, int POS_LINE)
        {
            int count = 0;
            if (POS_OFF == off.Length)
            {

                return 1;
            }

            LINE[POS_LINE] = off[POS_OFF];
            count += Counter(off, POS_OFF + 1, LINE, POS_LINE + 1);
            if (
                off[POS_OFF] != 0 && 
                POS_OFF < off.Length - 1 &&
                 off[POS_OFF] * 10 + off[POS_OFF + 1] <= 33
                )
            {
                LINE[POS_LINE] = off[POS_OFF] * 10 + off[POS_OFF + 1];
                count += Counter(off, POS_OFF + 2, LINE, POS_LINE + 1);
            }
            return count;
        }

        static void Main(string[] _1)
        {


            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int MS = int.Parse(sr.ReadLine());

                string[] _MASSIV = sr.ReadLine().Split(' ');
                List<int> _LIST = new List<int>();
                for (int i = 0; i < _MASSIV.Length; i++) _LIST.Add(int.Parse(_MASSIV[i]));
                int _CH;
                int _COUNT = int.Parse(sr.ReadLine());
                for (int i = 0; i < _COUNT; i++)
                {
                    _CH = TEST1(sr, MS, _LIST);
                    Console.WriteLine(_CH);
                }
                for (int i1 = 0; i1 < _LIST.Count; i1++)
                {
                    int i = _LIST[i1];
                    Console.Write(i + " ");
                }

            }

        }

        private static int TEST1(StreamReader sr, int MS, List<int> _LIST)
        {
            int _CH;
            string[] MAS_STR = sr.ReadLine().Split(' ');
            _CH = int.Parse(MAS_STR[0]); _LIST[int.Parse(MAS_STR[0]) - 1] = _LIST[int.Parse(MAS_STR[0]) - 1] - int.Parse(MAS_STR[1]);
            for (int j = 0; j < MS - 2; j++)
            {

                if ((j + 1) * 2 - 1 < MS && (j + 1) * 2 < MS)
                    _CH = BASE(_LIST, _CH, j);
                if ((j + 1) * 2 - 1 < MS && (j + 1) * 2 >= MS)
                    _CH = BASE1(_LIST, _CH, j);
            }

            return _CH;
        }

        private static int BASE1(List<int> _LIST, int _CH, int j)
        {
            if (_LIST[j] < _LIST[(j + 1) * 2 - 1])
            {
                int A = _LIST[j];
                _LIST[j] = _LIST[(j + 1) * 2 - 1]; _LIST[(j + 1) * 2 - 1] = A; _CH = ((j + 1) * 2 - 1 + 1);

            }

            return _CH;
        }

        private static int BASE(List<int> _LIST, int _CH, int j)
        {
            if (_LIST[j] < _LIST[(j + 1) * 2 - 1] || _LIST[j] < _LIST[(j + 1) * 2])
            {
                int A = _LIST[j];
                _LIST[j] = Math.Max(_LIST[(j + 1) * 2], _LIST[(j + 1) * 2 - 1]);
                if (_LIST[(j + 1) * 2] >= _LIST[(j + 1) * 2 - 1])
                {
                    _LIST[(j + 1) * 2] = A; _CH = (j + 1) * 2 + 1;
                }
                else
                {
                    _LIST[(j + 1) * 2 - 1] = A; _CH = (j + 1) * 2 - 1 + 1;

                }

            }

            return _CH;
        }

    }
}
