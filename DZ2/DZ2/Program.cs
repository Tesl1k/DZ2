using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    delegate void Event(Person person);

    interface Need
    {
        void Create(string firstname, string lastname, string lastlastname, string status);
        event Event Stunden;
        event Event Outt;
    }

    class Person
    {
        public event Event Stunden;
        public event Event Outt;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastLastName { get; set; }
        public string Status { get; set; }

        bool stunde;
        bool outt;

        public bool Stunde
        {
            get
            {
                return stunde;
            }

            set
            {
                if(Stunden != null)
                {
                    Stunden(this);
                }

                stunde = value;
            }
        }

        public bool Out
        {
            get
            {
                return outt;
            }

            set
            {
                if (Stunden != null)
                {
                    Outt(this);
                }

                outt = value;
            }
        }


        public Person(string firstname, string lastname, string lastlastname, string status)
        {
            FirstName = firstname;
            LastName = lastname;
            LastLastName = lastlastname;
            Status = status;
        }

        public string x;

        public string GetInfo(Person person)
        {
            string[] info = { person.FirstName, person.LastName, person.LastLastName, person.Status };

            for (int i = 0; i < info.Length; i++)
            {
                x = x + info[i] + " ";
            }

            if (person.Status != "Преподаватель" && person.Status != "Кадровик" && person.Status.Contains("Группа") == false && person.Status != "Ассистент" && person.Status != "Старший преподаватель")
            {
                x = x + "Нет такой должности!";
            }

            return x;
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

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lehrer lehrer = new Lehrer("Юрец", "СилЕнок", "Викторович", "Преподаватель");
            Student student = new Student("Даниил", "Давыдов", "Александрович", "3-1П9");
            Kadrowik kadrowik = new Kadrowik("Даниил", "Давыдов", "Александрович", "Кадровик");            

            Person NewStudent = kadrowik.Create("А", "Б", "В", "Преподаватель");
            Person NewLehrer = kadrowik.Create("А", "Б", "В", "Преподаватель");

            Console.WriteLine(kadrowik.GetInfo(NewLehrer));

            lehrer.Stunde = true;
            student.Out = true;

            lehrer.Stunden += Event1;
            student.Outt += Event2;

            Console.ReadKey();

        }

        public static void Event1(Person person)
        {
            Console.WriteLine("Лекция проведена");
        }

        public static void Event2(Person person)
        {
            Console.WriteLine("Отчислился");
        }
    }
}
