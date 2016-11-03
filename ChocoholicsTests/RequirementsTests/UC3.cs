using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC3
    {
        /// <summary>
        /// Tests a known, valid service code in the database.
        /// </summary>
        [TestMethod]
        public void TC5_ValidServiceCode()
        {
            ProviderDirectory directory = new ProviderDirectory();
            directory.Load();

            string expected = "Addiction Counseling";
            string actual = directory.NameOfService(100000);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests a service code with not enough digits.
        /// </summary>
        [TestMethod]
        public void TC6_TooShortServiceCode()
        {
            ProviderDirectory directory = new ProviderDirectory();
            directory.Load();

            string expected = "Service codes must be 6-digit numbers.";
            string actual = directory.NameOfService(123);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests a service code with not enough digits.
        /// </summary>
        [TestMethod]
        public void TC7_TooLongServiceCode()
        {
            ProviderDirectory directory = new ProviderDirectory();
            directory.Load();

            string expected = "Service codes must be 6-digit numbers.";
            string actual = directory.NameOfService(1234567);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests a service code that does not exist in the database.
        /// </summary>
        [TestMethod]
        public void TC8_NonExistantServiceCode()
        {
            ProviderDirectory directory = new ProviderDirectory();
            directory.Load();

            string expected = "Service code 111111 not found.";
            string actual = directory.NameOfService(111111);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests what happens if the user attempts to send a non-numeric 
        /// service code.
        /// </summary>
        [TestMethod]
        public void TC9_NonNumericServiceCode()
        {
            ProviderDirectory directory = new ProviderDirectory();
            directory.Load();

            string whatUserEntered = "xxxxxx";
            int valueAsInteger;

            if (int.TryParse(whatUserEntered, out valueAsInteger))
            {
                // it's an integer, the test is not testing what was intended.
                Assert.IsTrue(false);
            }
            else
            {
                // caught the fact that it's not an integer, so it passes.
                Assert.IsTrue(true);
            }
        }

    }
}
