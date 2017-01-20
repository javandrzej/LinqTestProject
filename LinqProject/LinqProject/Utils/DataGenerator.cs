using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.Utils
{
    public class DataGenerator : IGenarator
    {
        public IEnumerable<Person> CreatePersons(int count)
        {
            return Enumerable.Range(1, count).Select(p => new Person(Guid.NewGuid(), "firstname" + p, "lastname" + p, 20 + p, "myemail" + p + p, DateTime.Now.Add(new TimeSpan(p, 0, 0, 0))));
        }
    }
}
