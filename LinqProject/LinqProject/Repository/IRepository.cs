using System.Collections.Generic;

namespace LinqProject
{
    public interface IRepository
    {
        IEnumerable<Person> SortByAge(List<Person> personLists);
    }
}
