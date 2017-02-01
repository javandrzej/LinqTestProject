using System.Linq;
namespace LinqProject.Utils.ModelWrapper
{
    public static class PersonWrapper
    {

        public static string GetHeadersForPerson()
        {
            var person = new Person();
            var header = typeof(Person).GetProperties().Select(f => f.Name).ToList();
            return header.Aggregate((a, b) => a + "    " + b);

        }
    }
}
