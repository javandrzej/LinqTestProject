using LinqProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
namespace LinqProjectTests
{
    [TestClass]
    public class GeneratorTests
    {
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

        [TestMethod]
        public void ShouldGenerateTenPersonsWithRandomStrings()
        {
            //given
            IGenarator generator = new DataGenerator();
            int personNumber = 10;
            //when
            var persons = generator.CreatePersonsWithRandomStrings(personNumber);
            persons.ToList().ForEach(Console.WriteLine);
            //then
            Assert.AreEqual(personNumber, persons.Count());
        }

        [TestMethod]
        public void ShouldGenerateNumber()
        {
            //given
            IGenarator generator = new DataGenerator();
            //when
            int value = generator.GenerateRandomNumber(1, 100);
            TestContext.WriteLine(value.ToString());
            //then
            Assert.IsTrue(value > 0 && value < 100);
        }

        [TestMethod]
        public void ShouldGenerateString()
        {
            //given
            IGenarator generator = new DataGenerator();
            int stringSize = 10;
            //when
            string value = generator.GenerateRandomString(stringSize, DataGenerator.Letters.mix);
            TestContext.WriteLine(value);
            //then
            Assert.AreEqual(stringSize, value.Length);
        }

        [TestMethod]
        public void ShouldGenerateUpperCaseString()
        {
            //given
            IGenarator generator = new DataGenerator();
            int stringSize = 10;
            //when
            string value = generator.GenerateRandomString(stringSize, DataGenerator.Letters.big);
            //then
            Assert.AreEqual(true, StringOperators.isUpperString(value));
        }

        [TestMethod]
        public void ShouldGenerateLowerCaseString()
        {
            //given
            IGenarator generator = new DataGenerator();
            int stringSize = 10;
            //when
            string value = generator.GenerateRandomString(stringSize, DataGenerator.Letters.small);
            //then
            Assert.AreEqual(true, StringOperators.isLowerString(value));
        }

    }
}
