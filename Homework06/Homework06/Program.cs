using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06
{
    class Student
    {
        Random rnd = new Random();
        private int tail;
        private bool drunk;
        private int iq;
        private string name = "Oleh";
        private string faculty = "Turism";
        public int Tail
        {
            set
            {
                tail = value;
            }
        }
        public int Iq
        {
            set
            {
                iq = value;
            }
        }
        public bool Drunk
        {
            set
            {
                drunk = value;
            }
        }
        public void pass()
        {
            if(drunk && iq<70 || drunk && tail>3 || iq<70 && tail>3)
            {
                Console.WriteLine("ОТЧИСЛЕН");
            }
            else
            {
                drunk = Convert.ToBoolean(rnd.Next(0, 2));
                iq = ( drunk? iq += 0:iq+=10);
            }
        }
        public void getInfo()
        {
            Console.WriteLine("Name: " + name + ", Faculty: " + faculty + ", Tails: " + tail + ", IQ; " + iq + ", Drunk: " + (drunk? "YES":"NO")) ;
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            Random rnd = new Random();
            student.Tail = rnd.Next(0,12);
            student.Iq = rnd.Next(20, 151);
            student.Drunk = Convert.ToBoolean(rnd.Next(0, 2));
            student.pass();
            student.getInfo();
            Console.ReadKey();
        }
    }
}
