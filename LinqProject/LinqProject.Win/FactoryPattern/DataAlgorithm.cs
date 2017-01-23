using LinqProject.Repository.Persons;
using System.Collections.Generic;

namespace LinqProject.Win.FactoryPattern
{
    public abstract class DataAlgorithm<T> where T : class
    {

        public abstract void ClearDatebase();
        public abstract List<T> GetFromDatabase();
        public abstract void GenerateData(int count);
        public IPersonRepository Repository { get; set; }

        public List<T> Run(int count)
        {
            ClearDatebase();
            GenerateData(count);
            return GetFromDatabase();
        }
    }
}
