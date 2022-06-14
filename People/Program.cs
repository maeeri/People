using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;

namespace People
{
    class Program
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person("Anna", "Smith", "anna.smith@email.com", new DateTime(2002, 03, 27));
            Person secondPerson = new Person("Minna", "Smith", new DateTime(1999, 02, 25));
            Person thirdPerson = new Person("Sarah", "Smith", new DateTime(1985, 12, 05));
            Person fourthPerson = new Person("Jill", "Smith", new DateTime(1994, 06, 30));
            Person fifthPerson = new Person("Mariah", "Smith", new DateTime(1969, 02, 02));

            List<Person> people = new List<Person>();
            people.Add(firstPerson);
            people.Add(secondPerson);
            people.Add(thirdPerson);
            people.Add(fourthPerson);
            people.Add(fifthPerson);

            int counter = 1;
            double sum = 0;
            double averageAge = 0;

            foreach (Person person in people)
            {
                sum += person.Age();
                averageAge = sum / counter;
                counter++;
            }








            IEnumerable<Person> olderThanAverage = (from person in people
                where person.Age() > averageAge
                select person);

            foreach (Person person  in olderThanAverage)
            {
                Console.WriteLine(person.FirstName + " " + person.Age());
            }
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person(string first, string last, string email, DateTime birthday)
        {
            FirstName = first;
            LastName = last;
            Email = email;
            DateOfBirth = birthday;
        }

        public Person(string first, string last, string email)
        {
            FirstName = first;
            LastName = last;
            Email = email;
        }

        public Person(string first, string last, DateTime birthday)
        {
            FirstName = first;
            LastName = last;
            DateOfBirth = birthday;
        }

        public int Age()
        {
            TimeSpan timeFromBirth = new TimeSpan();
            timeFromBirth = DateTime.Today - DateOfBirth;
            int age = timeFromBirth.Days / 365;
            return age;
        }
    }
}


/*Create a reference type called Person.  Populate the Person class with the following properties to store the following information:


First name
Last name
Email address
Date of birth
Add constructors that accept the following parameter lists:


All four parameters
First, Last, Email
First, Last, Date of birth
Add a method that returns the age of the person

Create a program that creates a handful (5) of Person-objects and places them to collection.

Create a way that returns persons in a collection that are older than the average age of the people in the collection.*/