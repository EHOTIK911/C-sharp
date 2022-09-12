using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CONTEST_B
{
    class Program
    {
        public struct _CNT
        {
            public string SN;
            public double SC;
        }
        static void Main(string[] _1)
        {
            using (StreamReader az = new StreamReader("schools.in"))
            {
                _CNT NUMS = new _CNT();
                List<_CNT> _L1 = new List<_CNT>(); List<string> _L2 = new List<string>();
                int _COUT = int.Parse(az.ReadLine());
                string _ANS = null;
                for (int i = 0; i < _COUT; i++)
                    _ANS = @base(az, ref NUMS, _L1, _L2);

                using (StreamWriter aq = new StreamWriter("schools.out"))
                {
                    aq.WriteLine(_L1.Count); for (int i = 0; i < _L1.Count; i++) aq.WriteLine(_L1[i].SN);

                }
            }
        }

        private static string @base(StreamReader sr, ref _CNT NUMS, List<_CNT> _L1, List<string> _L2)
        {
            string _ANS = ""; string _INP = sr.ReadLine();
            for (int j = 0; j < _INP.Length; j++)
            {
                if (_INP[j] >= '0' && _INP[j] <= '9') _ANS = _ANS + _INP[j];
            }
            string DS = _ANS;
            if (!_L2.Contains(DS))
            {
                _L2.Add(DS); NUMS.SN = DS; NUMS.SC = 1; _L1.Add(NUMS);
            }
            else test(NUMS, _L1, DS);
            return _ANS;
        }

        private static void test(_CNT NUMS, List<_CNT> _L1, string DS)
        {
            for (int s = 0; s < _L1.Count; s++)
            {
                if (_L1[s].SN == DS)
                {
                    NUMS.SN = DS; NUMS.SC = _L1[s].SC + 1; _L1.RemoveAt(s); _L1.Insert(s, NUMS);
                    if (_L1[s].SC == 6) _L1.RemoveAt(s); break;
                }
            }
        }
    }
}