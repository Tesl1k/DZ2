using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    delegate void Event(Person person);

    interface INeed
    {
        void Create(string lastname, string firstname, string lastlastname, string status);
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

        public bool stunde;
        public bool outt;

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
                if (Outt != null)
                {
                    Outt(this);
                }

                outt = value;
            }
        }


        public Person(string lastname, string firstname, string lastlastname, string status)
        {
            FirstName = firstname;
            LastName = lastname;
            LastLastName = lastlastname;
            Status = status;
        }     
        
        public string x;

        public string GetInfo(Person person)
        {
            string[] info = { person.LastName, person.FirstName, person.LastLastName, person.Status };

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
        public Lehrer(string lastname, string firstname, string lastlastname, string status) : base(lastname, firstname, lastlastname, status) { Stunde = false; }        
    }

    class Student : Person
    {
        public Student(string lastname, string firstname, string lastlastname, string status) : base(lastname, firstname, lastlastname, status) { Out = false; }        
    }

    class Kadrowik : Person
    {
        public Kadrowik(string lastname, string firstname, string lastlastname, string status) : base(lastname, firstname, lastlastname, status) { }

        public Person Create(string lastname, string firstname, string lastlastname, string status)
        {
            return new Person(lastname, firstname, lastlastname, status)
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
            Lehrer lehrer = new Lehrer("Силенок", "Юрец", "Викторович", "Преподаватель");
            Student student = new Student("Давыдов", "Даниил", "Александрович", "Группа: 3-1П9");
            Kadrowik kadrowik = new Kadrowik("Смирнова", "Нина", "Михайловна", "Кадровик");            

            Person NewStudent = kadrowik.Create("Иванова", "Анна", "Сергеевна", "Ассистент");
            Person NewLehrer = kadrowik.Create("Петров", "Михаил", "Валерьевич", "Группа: 2-1С9");

            Console.WriteLine(lehrer.GetInfo(lehrer));
            Console.WriteLine(student.GetInfo(NewLehrer));
            Console.WriteLine(kadrowik.GetInfo(kadrowik));
            Console.WriteLine(NewStudent.GetInfo(NewStudent));
            Console.WriteLine(NewLehrer.GetInfo(NewLehrer));                    

            lehrer.Stunden += Event1;
            student.Outt += Event2;

            lehrer.Stunde = true;
            student.Out = true;

            Console.ReadKey();

        }

        public static void Event1(Person person)
        {
            Console.WriteLine("Провёл лекцию");
        }

        public static void Event2(Person person)
        {
            Console.WriteLine("Отчислился");
        }
    }
}
