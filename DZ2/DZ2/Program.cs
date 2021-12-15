using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    delegate string Event(Person person, bool move);

    interface Sig
    {
        void Create(string firstname, string lastname, string lastlastname, string status);
        event Event Stunde;
        event Event Out;
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastLastName { get; set; }
        public string Status { get; set; }


        public Person(string firstname, string lastname, string lastlastname, string status)
        {
            FirstName = firstname;
            LastName = lastname;
            LastLastName = lastlastname;
            Status = status;
        }





    }

    class Lehrer : Person
    {
        public Lehrer(string firstname, string lastname, string lastlastname, string status) : base(firstname, lastname, lastlastname, status) { }
    }

    class Student : Person
    {
        public Student(string firstname, string lastname, string lastlastname, string status) : base(firstname, lastname, lastlastname, status) { }

    }

    class Kadrowik : Person
    {
        public Kadrowik(string firstname, string lastname, string lastlastname, string status) : base(firstname, lastname, lastlastname, status) { }

        public Person Create(string firstname, string lastname, string lastlastname, string status)
        {
            return new Person(firstname, lastname, lastlastname, status)
            {
                FirstName = firstname,
                LastName = lastname,
                LastLastName = lastlastname,
                Status = status
            };
        }

        public string x;

        public string GetInfo(Person person)
        {
            string[] info = { person.FirstName, person.LastName, person.LastLastName, person.Status };

            for (int i = 0; i < info.Length; i++)
            {
                x = x + info[i] + " ";
            }

            if (person.Status != "Преподаватель" && person.Status != "Группа")
            {
                x = x + "Нет такой должности!";
            }

            return x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Lehrer lehrer = new Lehrer("Юрец", "Силёнок", "Викторович", "Преподаватель");
            //Student student = new Student("Даниил", "Давыдов", "Александрович", "3-1П9");
            Kadrowik kadrowik = new Kadrowik("Даниил", "Давыдов", "Александрович", "Кадровик");

            //Console.WriteLine(lehrer.FirstName + " " + lehrer.LastName + " " + lehrer.LastLastName + " " + lehrer.Status);
            //Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.LastLastName + " " + student.Status);

            Person NewStudent = kadrowik.Create("А", "Б", "В", "Преподаватель");
            Person NewLehrer = kadrowik.Create("А", "Б", "В", "Преподаватель");

            Console.WriteLine(kadrowik.GetInfo(NewLehrer));

            Console.ReadKey();

        }
    }
}
