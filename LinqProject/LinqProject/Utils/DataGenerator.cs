using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.Utils
{
    public class DataGenerator : IGenarator
    {
        private static Random rand = new Random();
        public IEnumerable<Person> CreatePersons(int count)
        {
            return Enumerable.Range(1, count).Select(p => new Person(Guid.NewGuid(), "firstname" + p, "lastname" + p, 20 + p, "myemail" + p + p, DateTime.Now.Add(new TimeSpan(p, 0, 0, 0))));
        }

        public IEnumerable<Person> CreatePersonsWithRandomStrings(int count)
        {
            return Enumerable.Range(1, count)
                .Select(p => new Person(Guid.NewGuid(), GenerateRandomString(10, Letters.mix), GenerateRandomString(15, Letters.mix), 20 + p, "myemail@wp.pl", DateTime.Now.Add(new TimeSpan(p, 0, 0, 0))));
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

        public enum Letters
        {
            small, big, mix
        }

    }
}
