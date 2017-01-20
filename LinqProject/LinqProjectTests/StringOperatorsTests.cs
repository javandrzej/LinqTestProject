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
            bool isUpper = StringOperators.isUpperString(message);
            //when
            Assert.AreEqual(true, isUpper);
        }

        [TestMethod]
        public void ShuldBeLowerCaseString()
        {
            //given
            string message = "asdasdasdbasd";
            //when
            bool isLower = StringOperators.isLowerString(message);
            //when
            Assert.AreEqual(true, isLower);
        }
    }
}
