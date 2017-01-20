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
            Assert.AreEqual(true, StringOperators.IsUpperString(value));
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
            Assert.AreEqual(true, StringOperators.IsLowerString(value));
        }

        [TestMethod]
        public void ShouldGenerateRandomAge()
        {
            //given
            IGenarator generator = new DataGenerator();
            //when
            int value = generator.GenerateRandomAge();
            //then
            Assert.IsTrue(value >= 1 && value <= 100);
        }

        [TestMethod]
        public void ShouldGenerateRandomEmail()
        {
            //given
            IGenarator generator = new DataGenerator();
            //when
            string value = generator.GenerateRandomEmail();
            //then
            Assert.IsTrue(StringOperators.IsValidEmailAddress(value));
        }

        [TestMethod]
        public void ShouldGenerateRandomDate()
        {
            //given
            IGenarator generator = new DataGenerator();
            DateTime firstDate = new DateTime(2015, 1, 1);
            DateTime secondDate = new DateTime(2016, 12, 30);
            //when
            DateTime value = generator.GenerateRandomDate(firstDate, secondDate);
            //then
            Assert.IsTrue(value > firstDate && value < secondDate);
        }
    }
}
