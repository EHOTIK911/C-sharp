using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        public string FIO;
        public int course;
        public string group;
        public Student()
        {
            FIO = "test";
            course = 1;
            group = "test.group";
        }
#region test

        
        public Student(string f, int k, string g)
        {
            FIO = f;
            course = k;
            group = g;

        }
        public Student(string FIO) : this(FIO, 1, "PMI") { }
        public void NextCourse() { course++; }
        public override string ToString()
        {
            return String.Format($"{FIO} {course} {group}");
        }
        public override bool Equals(object obj)
        {
            if(obj is Student)
            {
                Student other = (Student) obj;
                return(FIO == other.FIO) && (course == other.course) && (group == other.group);
            }
            return false;
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return true;
        }
        public static bool operator == (Student s1, Student s2)
        {
            return false;
        }
        #endregion
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Student test1 = new Student("Ivan", 1, "IB");
            Student test2 = new Student("Ivan", 2, "IB");
            Console.WriteLine(test1.Equals(test2));

            Console.ReadKey();
        }
    }
}
