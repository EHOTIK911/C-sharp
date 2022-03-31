using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CONTEST_C
{
    internal class Program
    {
        public struct STRUCTUR
        {
            public int NUM;
            public List<int> LIST;
        }
        static void Main(string[] args)
        {
            using (StreamReader _READER = new StreamReader("input.txt"))
            {
                string _STRING = _READER.ReadLine();
                string[] _STRING_MAS = _STRING.Split(' ');
                int _VERT = int.Parse(_STRING_MAS[1]);
                int n = int.Parse(_READER.ReadLine());
                List<STRUCTUR> list = new List<STRUCTUR>();
                for (int i = 0; i < _VERT; i++)
                    _Test_met(list, i);

                using (StreamWriter _WRITE = new StreamWriter("output.txt"))
                {
                    MET(_READER, n, list, _WRITE);

                    
                }

            }





        }

        private static void MET(StreamReader _READER, int n, List<STRUCTUR> list, StreamWriter _WRITE)
        {
            int _MAX_VALIE = 0;
            int _MIN_VALUE = 1000000;
            for (int i = 0; i < n; i++)
            {
                KEKABU(_READER, list, _WRITE, ref _MAX_VALIE, ref _MIN_VALUE);

            }
            _WRITE.Close();
        }

        private static void KEKABU(StreamReader _READER, List<STRUCTUR> list, StreamWriter _WRITE, ref int _MAX_VALIE, ref int _MIN_VALUE)
        {
            int _FIRST = 0;
            int _SEC = 0;
            string[] _STRING_FILE = _READER.ReadLine().Split(' ');
            TRASH(list, _WRITE, ref _MAX_VALIE, ref _MIN_VALUE, ref _FIRST, ref _SEC, _STRING_FILE);
        }

        private static void TRASH(List<STRUCTUR> list, StreamWriter _WRITE, ref int _MAX_VALIE, ref int _MIN_VALUE, ref int _FIRST, ref int _SEC, string[] _STRING_FILE)
        {
            if (_STRING_FILE.Length == 2)
                _FIRST = int.Parse(_STRING_FILE[1]);
            else if (_STRING_FILE.Length == 3)
                FIRST_SEC(out _FIRST, out _SEC, _STRING_FILE);
            MORE_MORE_IF(list, _WRITE, ref _MAX_VALIE, ref _MIN_VALUE, _FIRST, _SEC, _STRING_FILE);
        }

        private static void FIRST_SEC(out int _FIRST, out int _SEC, string[] _STRING_FILE)
        {
            _FIRST = int.Parse(_STRING_FILE[1]);
            _SEC = int.Parse(_STRING_FILE[2]);
        }

        private static void MORE_MORE_IF(List<STRUCTUR> list, StreamWriter _WRITE, ref int _MAX_VALIE, ref int _MIN_VALUE, int _FIRST, int _SEC, string[] _STRING_FILE)
        {
            if (_STRING_FILE[0] == "ADD")
                MORE_IF(list, ref _MAX_VALIE, ref _MIN_VALUE, _FIRST, _SEC);
            if (_STRING_FILE[0] == "LISTSET")
                _FIRSTOS(list, _WRITE, _FIRST);
            if (_STRING_FILE[0] == "LISTSETSOF")
                TEST_43(list, _WRITE, _FIRST);
        }

        private static void MORE_IF(List<STRUCTUR> list, ref int _MAX_VALIE, ref int _MIN_VALUE, int _FIRST, int _SEC)
        {
            list[_SEC - 1].LIST.Add(_FIRST);
            if (_SEC > _MAX_VALIE)
                _MAX_VALIE = _SEC;
            if (_SEC < _MIN_VALUE)
                _MIN_VALUE = _SEC;
        }

        private static void TEST_43(List<STRUCTUR> list, StreamWriter _WRITE, int _FIRST)
        {
            bool flag = true;
            for (int j = 0; j < list.Count; j++)
                flag = _TEST2(list, _WRITE, _FIRST, flag, j);
            if (flag == true)
                _WRITE.Write(-1);
            _WRITE.WriteLine();
        }

        private static bool _TEST2(List<STRUCTUR> list, StreamWriter _WRITE, int _FIRST, bool flag, int j)
        {
            if (list[j].LIST.Count != 0 && list[j].LIST.Contains(_FIRST))
                flag = LOL(list, _WRITE, j);
            return flag;
        }

        private static bool LOL(List<STRUCTUR> list, StreamWriter _WRITE, int j)
        {
            bool flag;
            _WRITE.Write($"{list[j].NUM} ");
            flag = false;
            return flag;
        }

        private static void _FIRSTOS(List<STRUCTUR> list, StreamWriter _WRITE, int _FIRST)
        {
            if (list[list[_FIRST - 1].NUM - 1].LIST.Count == 0)
                _WRITE.Write(-1);
            else
                PTINT(list, _WRITE, _FIRST);

            _WRITE.WriteLine();
        }

        private static void PTINT(List<STRUCTUR> list, StreamWriter _WRITE, int _FIRST)
        {
            IEnumerable<int> _ANS = list[list[_FIRST - 1].NUM - 1].LIST.Distinct();
            list[list[_FIRST - 1].NUM - 1].LIST.Sort();

            foreach (int di in _ANS)
                _WRITE.Write($"{di} ");
        }

        private static void _Test_met(List<STRUCTUR> list, int i)
        {
            STRUCTUR _MAS = new STRUCTUR();
            _MAS.NUM = i + 1;
            _MAS.LIST = new List<int>();
            list.Add(_MAS);
        }
    }
}
