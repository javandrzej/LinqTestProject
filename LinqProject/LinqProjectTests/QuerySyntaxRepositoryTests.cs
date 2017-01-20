using LinqProject;
using LinqProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LinqProjectTests
{
    [TestClass]
    public class QuerySyntaxRepositoryTests
    {

        [TestMethod]
        public void ShouldReturnTheYoungestPerson()
        {
            //given
            IGenarator generator = new DataGenerator();
            IRepository repository = new QuerySyntaxRepository();
            int personNumber = 15;
            int age = 21;
            var persons = generator.CreatePersons(personNumber);
            //when
            var person = repository.SortByAge(persons.ToList()).ToList().FirstOrDefault();
            //then
            Assert.AreEqual(age, person.Age);
        }
    }
}
