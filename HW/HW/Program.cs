using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOME_WORK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> LIST_FIRST = new List<int>();
            List<int> LIST_SECOND = new List<int>();
            int N = int.Parse(Console.ReadLine());
            // FILL_THE_ARRAY & WE_DISTRIBUTE_FOR_CONVENIENCE_IN_2_DIFFERENT_SHEETS_(THE_2ND_COLUMN_AND_THE_SECOND_[STARTING_POINTS_OF_THE_SEGMENT_AND_END_POINTS])
            for (int i = 0; i < N; i++)
            {
                int[] COORD = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(g => int.Parse(g)).ToArray(); 
                LIST_FIRST.Add(COORD[0]);
                LIST_SECOND.Add(COORD[1]);
            }

            bool flag = true;
            while (flag == true)
            {
                flag = false;
                for (int i = 0; i < N - 1; i++)
                {
                    if (LIST_FIRST[i] > LIST_FIRST[i + 1])
                    {
                        LIST_FIRST[i + 1] = LIST_FIRST[i];
                        flag = true;
                    }
                }
            }

            int FIRST, SECOND; // TIME_VARIABLES
            int ANS_VALUE = 0; // ANSWER

            List<int> ANSWER = new List<int>();
            while (LIST_FIRST.Count > 1)
            {
                //CHECK_IF_THE_POINT_BELONGS_TO_THE_NEXT_SEGMENT
                if (LIST_SECOND[0] < LIST_FIRST[1])
                {
                    ANSWER.Add(LIST_FIRST[0]);
                    ANS_VALUE++;
                    LIST_FIRST.RemoveAt(0);
                    LIST_SECOND.RemoveAt(0);
                }
                else // CHECK_THE_OTHER_OPTIONS
                {
                    if (LIST_FIRST[0] < LIST_FIRST[1])
                        FIRST = LIST_FIRST[1];
                    else
                        FIRST = LIST_FIRST[0];
                    if (LIST_SECOND[0] > LIST_SECOND[1])
                        SECOND = LIST_SECOND[1];
                    else
                        SECOND = LIST_SECOND[0];


                    for(int i = 0; i < 2; i++)
                    {
                        LIST_FIRST.RemoveAt(0);
                        LIST_SECOND.RemoveAt(0);
                    }
                    
                    LIST_FIRST.Insert(0, FIRST);
                    LIST_SECOND.Insert(0, SECOND);
                }
            }
            ANSWER.Add(LIST_FIRST[0]);
            ANS_VALUE++;

            Console.WriteLine(ANS_VALUE);

            for (int i = 0; i < ANSWER.Count; i++)
                Console.WriteLine(ANSWER[i]);



            Console.ReadKey();
        }
    }
}
