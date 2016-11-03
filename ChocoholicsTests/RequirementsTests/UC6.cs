using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC6
    {
        [TestMethod]
        public void TC15_VerifyValidProviderNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            string expected = "Verified";
            string actual = chocAnSystem.VerifyProvider(678496784);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC16_VerifyNonExistantProviderNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            string expected = "Invalid Number";
            string actual = chocAnSystem.VerifyProvider(111111111);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC17_VerifyTooShortProviderNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            string expected = "Provider number must be exactly 9 digits long.";
            string actual = chocAnSystem.VerifyProvider(123);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC18_VerifyTooLongProviderNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            string expected = "Provider number must be exactly 9 digits long.";
            string actual = chocAnSystem.VerifyProvider(1234567890);

            Assert.AreEqual(expected, actual);
        }
    }
}
