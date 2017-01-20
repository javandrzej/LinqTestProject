using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.Utils
{
    public class DataGenerator : IGenarator
    {
        private static Random rand = new Random();
        public enum Letters
        {
            small, big, mix
        }
        public IEnumerable<Person> CreatePersons(int count)
        {
            return Enumerable.Range(1, count).Select(p => new Person(Guid.NewGuid(), "firstname" + p, "lastname" + p, 20 + p, "myemail" + p + p, DateTime.Now.Add(new TimeSpan(p, 0, 0, 0))));
        }

        public IEnumerable<Person> CreatePersonsWithRandomStrings(int count)
        {
            DateTime firstDate = new DateTime(2015, 1, 1);
            DateTime secondDate = new DateTime(2016, 12, 30);
            return Enumerable.Range(1, count)
                .Select(p => new Person(Guid.NewGuid(), GenerateRandomString(10, Letters.mix), GenerateRandomString(15, Letters.mix), GenerateRandomAge(), GenerateRandomEmail(), GenerateRandomDate(firstDate, secondDate)));
        }

        public string GenerateRandomString(int count, Letters letter)
        {
            switch (letter)
            {
                case Letters.big:
                    return GenereteString(count, 'A');
                case Letters.small:
                    return GenereteString(count, 'a');
                case Letters.mix:
                    return GenereteString(count, 'a', true);
                default:
                    throw new Exception("Problem with creating letters");
            }
        }

        public string GenereteString(int count, char newChar, bool mix = false)
        {
            return Enumerable.Range(1, count).Select(x => ((char)(mix ? rand.Next(1, 100) % 2 == 0 ? 'a' + rand.Next(0, 26) : 'A' + rand.Next(0, 26) : newChar + rand.Next(0, 26))).ToString()).Aggregate((m, s) => m + s);
        }

        public int GenerateRandomNumber(int min, int max)
        {
            return rand.Next(min, max);
        }

        public int GenerateRandomAge()
        {
            return rand.Next(1, 100);
        }

        public string GenerateRandomEmail()
        {
            return GenerateRandomString(10, Letters.small) + "@" + GenerateRandomString(2, Letters.small) + "." + GenerateRandomString(2, Letters.small);
        }

        public DateTime GenerateRandomDate(DateTime firstDate, DateTime secondDate)
        {
            int range = (secondDate - firstDate).Days;
            return firstDate.AddDays(rand.Next(range));
        }
    }
}
