using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC4
    {
        [TestMethod]
        public void TC10_TestCorrectAmountForService()
        {
            ProviderDirectory directory = new ProviderDirectory();
            directory.Load();
            decimal expected = 109.99M;
            decimal actual = directory.PriceForService(100000);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC11_TestInvalidServiceCode()
        {
            ProviderDirectory directory = new ProviderDirectory();
            directory.Load();

            try
            {
                decimal actual = directory.PriceForService(123);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
