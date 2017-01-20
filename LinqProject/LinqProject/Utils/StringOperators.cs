using System.Linq;

namespace LinqProject.Utils
{
    public class StringOperators
    {
        public static bool isUpperString(string message)
        {
            return message.All(c => char.IsUpper(c));
        }

        public static bool isLowerString(string message)
        {
            return message.All(c => char.IsLower(c));
        }
    }
}
