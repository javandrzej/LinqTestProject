using System.Collections.Generic;

namespace LinqProject.Repository.Persons
{
    public interface IPersonRepository
    {
        void InitData();
        void AddPerson(Person p);
        void Delete(Person p);
        List<Person> GetPersons();
        void Clear();
        void InitDataWithParameters(int count);
    }
}
