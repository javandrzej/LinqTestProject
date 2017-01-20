using LinqProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqProjectTests
{
    [TestClass]
    public class StringOperatorsTests
    {
        [TestMethod]
        public void ShuldBeUpperCaseString()
        {
            //given
            string message = "AJFKSDFFGSA";
            //when
            bool isUpper = StringOperators.IsUpperString(message);
            //when
            Assert.AreEqual(true, isUpper);
        }

        [TestMethod]
        public void ShuldBeLowerCaseString()
        {
            //given
            string message = "asdasdasdbasd";
            //when
            bool isLower = StringOperators.IsLowerString(message);
            //when
            Assert.AreEqual(true, isLower);
        }
    }
}
