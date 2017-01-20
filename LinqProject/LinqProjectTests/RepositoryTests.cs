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
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
            int personCount = 15;
            int age = 21;
            var persons = generator.CreatePersons(personCount);
            foreach (var repo in repositories)
            {
                //when
                var person = repo.SortByAge(persons.ToList()).ToList().FirstOrDefault();
                //then
                Assert.AreEqual(age, person.Age);
            }
        }

        [TestMethod]
        public void ShouldReturnYoungPersons()
        {
            //given
            IGenarator generator = new DataGenerator();
            int personCount = 15;
            var persons = generator.CreatePersonsWithRandomStrings(personCount);
            int minAge = 20;
            int maxAge = 30;
            foreach (var repo in repositories)
            {
                //when
                var person = repo.TakeYoungPerson(persons.ToList(), minAge, maxAge).ToList().FirstOrDefault();
                //then
                Assert.IsTrue(person.Age >= minAge && person.Age <= maxAge);
            }
        }
    }
}
