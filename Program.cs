using System;
using System.Collections.Generic;

namespace SchoolTracker
{
    enum School
    {
        Hogwarts,
        Howards,
        MIT

    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {

            ///Console.WriteLine("Hello World!");
            ///
            PayRoll payRoll = new PayRoll();
            payRoll.PayAll();

            var adding = true;
            while (adding)
            {
                try
                {
                    var newStudent = new Student();
                    newStudent.Name = Util.Console.Ask("Student Name: ");
                    newStudent.Grade = Util.Console.AskInt("Student Grade: ");
                    newStudent.School = (School) Util.Console.AskInt("School Name (type corresponding number): \n 0:Hogwards \n 1:Howards \n 2:MIT \n");
                    newStudent.Birthday = Util.Console.Ask("Student Birthday: ");
                    newStudent.Address = Util.Console.Ask("Student Address: ");
                    newStudent.Phone = Util.Console.AskInt("Student Phone Number: ");

                    students.Add(newStudent);
                    Student.Count++;
                    Console.WriteLine("Student Count {0}", Student.Count);

                    Console.WriteLine("Add another? y/n");
                    if (Console.ReadLine() != "y")
                        adding = false;
                }
                catch (FormatException msg)
                {
                    Console.WriteLine(msg.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error adding student. Please try again");
                }
                
              
            }

            foreach (var student in students)
            {
                Console.WriteLine("Name: {0}, Grade: {1}", student.Name, student.Grade);
            }

            Export();
        }

        static void Import()
        {
            var importStudent = new Student("Jenny", 86, "birthday", "address", 1);
            Console.WriteLine(importStudent.Name);
        }

        static void Export()
        {
            foreach (var student in students)
            {
                switch (student.School)
                {
                    case School.Hogwarts:
                        Console.WriteLine("Exporting to Hogwards");
                        break;
                    case School.Howards:
                        Console.WriteLine("Exporting to Howards");
                        break;
                    case School.MIT:
                        Console.WriteLine("Exporting to MIT");
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Member
    {
        public string Name; 
        public string Address;
        protected int _phone;

        public int Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }

    class Student : Member
    {
        public static int Count = 0;

        public int Grade;
        public string Birthday;
        public School School;

        public Student()
        {

        }
        public Student(string name, int grade, string birthday, string address, int phone)
        {
            Name = name;
            Grade = grade;
            Birthday = birthday;
            Address = address;
            Phone = phone;
        }

    }

    
}
