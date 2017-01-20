using System.Collections.Generic;
using static LinqProject.Utils.DataGenerator;

namespace LinqProject.Utils
{
    public interface IGenarator
    {
        IEnumerable<Person> CreatePersons(int count);
        IEnumerable<Person> CreatePersonsWithRandomStrings(int count);
        string GenerateRandomString(int count, Letters letter);
        int GenerateRandomNumber(int min, int max);
        string GenereteString(int count, char newChar, bool mix = false);

    }
}
