using System;

namespace LinqProject
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }

        public Person()
        {

        }

        public Person(Guid id, string firstName, string lastName, int age, string emailAddress, DateTime birthdate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EmailAddress = emailAddress;
            BirthDate = birthdate;
        }
    }
}
