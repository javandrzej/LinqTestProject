using LinqProject.Database;
using LinqProject.Utils;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.Repository.Persons
{
    public class PersonDbRepsitory : IPersonRepository
    {
        PersonDb personContext = new PersonDb();
        IGenarator generator = new DataGenerator();
        public void InitData()
        {
            personContext.Persons.AddRange(generator.CreatePersonsWithRandomStrings(100));
            personContext.SaveChanges();
        }

        public void InitDataWithParameters(int count)
        {
            personContext.Persons.AddRange(generator.CreatePersonsWithRandomStrings(count));
            personContext.SaveChanges();
        }

        public void AddPerson(Person p)
        {
            personContext.Persons.Add(p);
        }

        public void Delete(Person p)
        {
            personContext.Persons.Remove(p);
            personContext.SaveChanges();
        }

        public List<Person> GetPersons()
        {
            return personContext.Persons.ToList();
        }

        public void Clear()
        {
            personContext.Persons.RemoveRange(personContext.Persons);
            personContext.SaveChanges();
        }
    }
}
