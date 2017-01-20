using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    public class MethodSyntaxRepository : IRepository
    {
        public IEnumerable<Person> SortByAge(List<Person> personLists)
        {
            return personLists.OrderBy(p => p.Age);
        }

        public IEnumerable<Person> TakeYoungPerson(List<Person> personLists, int minEge, int maxAge)
        {
            return personLists.Where(a => a.Age >= minEge && a.Age <= maxAge);
        }
    }
}
