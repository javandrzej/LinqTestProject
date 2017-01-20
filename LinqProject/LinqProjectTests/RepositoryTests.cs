using LinqProject;
using LinqProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LinqProjectTests
{
    [TestClass]
    public class RepositoryTests
    {
        private List<IRepository> repositories = new List<IRepository>();
        [TestInitialize]
        public void Init()
        {
            repositories.Add(new MethodSyntaxRepository());
            repositories.Add(new QuerySyntaxRepository());
        }

        [TestMethod]
        public void ShouldReturnTheYoungestPerson()
        {
            //given
            IGenarator generator = new DataGenerator();
            int personNumber = 15;
            int age = 21;
            var persons = generator.CreatePersons(personNumber);
            foreach (var repo in repositories)
            {
                //when
                var person = repo.SortByAge(persons.ToList()).ToList().FirstOrDefault();
                //then
                Assert.AreEqual(age, person.Age);
            }
        }
    }
}
