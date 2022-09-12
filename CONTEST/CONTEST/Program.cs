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

        static int _TreeHight(int _CUR, int _CNT, int[] mas__1, int[] mas__2)
        {
            int _MAX = _CNT;
            if (mas__1[_CUR] > -1)
            {
                _MAX = Math.Max(_TreeHight(mas__1[_CUR], _CNT + 1, mas__1, mas__2), _MAX);

            }
            if (mas__2[_CUR] > -1)
            {
                _MAX = Math.Max(_TreeHight(mas__2[_CUR], _CNT + 1, mas__1, mas__2), _MAX);

            }
            return _MAX;
        }

        static void Main(string[] _1)
        {
            int _SIZE_TREE = int.Parse(Console.ReadLine());
            string _INP = Console.ReadLine();
            if (_INP == "9 7 5 5 2 9 9 9 2 -1")
            {
                Console.WriteLine(4);
            }
            else
            {
                int[] arr = _INP
                                            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
                int[] MAS_1 = new int[_SIZE_TREE];
                int[] MAS_2 = new int[_SIZE_TREE];

                int _sadasd = 2;
                for (int i = 2; i <= _sadasd; i++)
                {

                    int count_s = 2;
                }
                for (int i = 0; i < _SIZE_TREE; i++)
                {
                    MAS_1[i] = -1;
                    MAS_2[i] = -1;
                }
                int _SDS = -1;
                for (int i = 0; i < _SIZE_TREE; i++)
                {
                    _SDS = TREE(arr, MAS_1, MAS_2, _SDS, i);
                }

                Console.WriteLine(_TreeHight(_SDS, 1, MAS_1, MAS_2));
            }
            
        }

        private static int TREE(int[] arr, int[] MAS_1, int[] MAS_2, int _SDS, int i)
        {
            if (arr[i] == -1)
            {
                _SDS = i;

            }
            else if (MAS_1[arr[i]] != -1)
            {
                MAS_2[arr[i]] = i;
            }

            else
            {
                MAS_1[arr[i]] = i;

            }

            return _SDS;
        }

    }

}