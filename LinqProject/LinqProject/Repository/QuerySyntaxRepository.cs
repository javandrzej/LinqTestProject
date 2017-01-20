using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    public class QuerySyntaxRepository : IRepository
    {
        public IEnumerable<Person> SortByAge(List<Person> personLists)
        {
            return
            from p in personLists
            orderby p.Age
            select p;
        }
    }
}
