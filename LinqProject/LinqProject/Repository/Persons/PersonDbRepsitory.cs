using LinqProject.Database;
using System.Collections.Generic;
using System.Linq;
namespace LinqProject.Repository.Persons
{
    class PersonDbRepsitory : IPersonRepository
    {
        PersonDb personContext = new PersonDb();

        public void AddPerson(Person p)
        {
            personContext.Persons.Add(p);
        }

        public void Delete(Person p)
        {
            personContext.Persons.Remove(p);
        }

        public List<Person> GetPersons()
        {
            return personContext.Persons.ToList();
        }
    }
}
