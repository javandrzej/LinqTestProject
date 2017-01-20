using LinqProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace LinqProjectTests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void ShouldGenerateTenPersons()
        {
            //given
            IGenarator generator = new DataGenerator();
            int personNumber = 10;
            //when
            var persons = generator.CreatePersons(personNumber);
            //then
            Assert.AreEqual(personNumber, persons.Count());
        }
    }
}
