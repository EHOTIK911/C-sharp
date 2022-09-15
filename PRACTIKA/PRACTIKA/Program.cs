using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examole
{
    public class student
    {
        public string FIO;
        private int kurs;
        public string group;
        #region Constructors

        public int Kurs
        {
            get
            {
                return kurs;
            }
            set
            {
                if(value > 0 && value < 7)
                {
                    kurs = value;
                    
                }
                else
                    Console.WriteLine($"Для студента {FIO} была попытка установить курс {value}");
            }
        }
        public student()
        {

        }
        /// <summary>
        /// запись информации о новом студенте 
        /// </summary>
        /// <param name="f">фио</param>
        /// <param name="k">курс</param>
        /// <param name="g">группа</param>
        public student(string f, int k, string g)
        {
            FIO = f;
            kurs = k;
            group = g;
        }
        public student(string fio) : this(fio, 7, "PMI-1")
        {

        }
        public void NextCourse() { this.kurs++; }
        public override string ToString()
        {
            return String.Format($"{FIO} , {kurs} , {group}");
        }
        public override bool Equals(object obj)
        {
            if (obj is student)
            {
                student other = (student)obj;
                return (FIO == other.FIO) && (kurs == other.kurs) && (group == other.group);


            }

            return false;
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            student ivanov = new student();
            ivanov.FIO = "ivanov ivan";
            Console.WriteLine(ivanov.FIO);
            Console.WriteLine(ivanov.ToString());

            student Petrov = new student("Petr Petrov", 1, "fedot");
            student etrov = new student("Petr Petrov", 0, "fedot");
            Console.WriteLine(etrov.FIO);
            Console.WriteLine(etrov.Kurs);
            Console.WriteLine(etrov.group);
            Console.WriteLine(etrov);
            student sidorov = new student("sidor sidorovich ");
            sidorov.NextCourse();
            sidorov.Kurs = 7;
            Console.WriteLine(sidorov.Kurs);
            Console.WriteLine(sidorov);
            student d = new student("test", 7, "111");

            Console.ReadKey();
        }
    }
}
