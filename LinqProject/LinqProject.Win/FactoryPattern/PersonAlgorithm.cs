using LinqProject.Repository.Persons;
using System.Collections.Generic;

namespace LinqProject.Win.FactoryPattern
{
    public class PersonAlgorithm : DataAlgorithm<Person>
    {
        public PersonAlgorithm(IPersonRepository repository)
        {
            Repository = repository;
        }

        public override void ClearDatebase()
        {
            Repository.Clear();
        }

        public override void GenerateData(int count)
        {
            Repository.InitDataWithParameters(count);
        }

        public override List<Person> GetFromDatabase()
        {
            return Repository.GetPersons();
        }
    }
}
