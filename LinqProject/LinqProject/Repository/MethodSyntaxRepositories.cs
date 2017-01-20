using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    public class MethodSyntaxRepositories : IRepository
    {
        public IEnumerable<Person> SortByAge(List<Person> personLists)
        {
            return personLists.OrderBy(p => p.Age);
        }
    }
}
