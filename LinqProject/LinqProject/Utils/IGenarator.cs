using System.Collections.Generic;

namespace LinqProject.Utils
{
    public interface IGenarator
    {
        IEnumerable<Person> CreatePersons(int count);
    }
}
