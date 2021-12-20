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
        void Create(string lastname, string firstname, string lastlastname);
        event Event Stunden;
        event Event Outt;
    }

    abstract class Jober : Person
    {
        public string Status { get; }

        public Jober(string lastname, string firstname, string lastlastname, string status) : base (lastname, firstname, lastlastname)
        {
            Status = status;
        }
    }

    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string LastLastName { get; }

        public Person(string lastname, string firstname, string lastlastname)
        {
            FirstName = firstname;
            LastName = lastname;
            LastLastName = lastlastname;
        }
        public string x;

        public string GetFIO(Person person)
        {
            string[] info = { person.LastName, person.FirstName, person.LastLastName};

            for (int i = 0; i < info.Length; i++)
            {
                x = x + info[i] + " ";
            }

            return x;
        }
    }

    class Lehrer : Jober
    {
        public Lehrer(string lastname, string firstname, string lastlastname, string status) : base(lastname, firstname, lastlastname, status)
        {
            Stunde = false;
        }

        public event Event Stunden;
        public bool stunde;

        public bool Stunde
        {
            get
            {
                return stunde;
            }

            set
            {
                if (Stunden != null)
                {
                    Stunden(this);
                }

                stunde = value;
            }
        }
    }

    class Student : Person
    {
        public Student(string lastname, string firstname, string lastlastname, string group) : base(lastname, firstname, lastlastname)
        {
            Group = group;
            Out = false;
        }

        public string Group { get; }
        public event Event Outt;
        public bool outt;

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
    }

    class Kadrowik : Jober
    {
        public Kadrowik(string lastname, string firstname, string lastlastname, string status) : base(lastname, firstname, lastlastname, status) { }

        public Lehrer CreateLehrer(string lastname, string firstname, string lastlastname, string status)
        {
            return new Lehrer(lastname, firstname, lastlastname, status) { };
        }

        public Student CreateStudent(string lastname, string firstname, string lastlastname, string group)
        {
            return new Student(lastname, firstname, lastlastname, group) { };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lehrer lehrer = new Lehrer("Силенок", "Юрец", "Викторович", "Преподаватель");
            Student student = new Student("Давыдов", "Даниил", "Александрович", "Группа: 3-1П9");
            Kadrowik kadrowik = new Kadrowik("Смирнова", "Нина", "Михайловна", "Кадровик");            

            Person NewStudent = kadrowik.CreateLehrer("Иванова", "Анна", "Сергеевна", "Ассистент");
            Person NewLehrer = kadrowik.CreateStudent("Петров", "Михаил", "Валерьевич", "Группа: 2-1С9");

            Console.WriteLine(lehrer.GetFIO(lehrer));
            Console.WriteLine(student.GetFIO(NewLehrer));
            Console.WriteLine(kadrowik.GetFIO(kadrowik));
            Console.WriteLine(NewStudent.GetFIO(NewStudent));
            Console.WriteLine(NewLehrer.GetFIO(NewLehrer));
            Console.WriteLine(student.Group);
            Console.WriteLine(lehrer.Status);

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
