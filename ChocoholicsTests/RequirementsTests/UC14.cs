using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{    
    [TestClass]
    public class UC14
    {
        private Provider MockProvider()
        {
            Provider p = new Provider()
            {
                City = "Dallas",
                Country = null,
                DateCreated = DateTime.Now,
                EmailAddress = "provider@business.com",
                Name = "Humana Insurance",
                PhoneNumber = "807-452-8585",
                ProviderNumber = null,
                State = "TX",
                StreetAddress = "106 Optic Ct.",
                ZipCode = "28585"
            };

            return p;
        }

        /* Test Case = TC55 */
        /// <summary>
        /// Verifies that a Provider can be added
        /// </summary>
        [TestMethod()]
        public void TC55_AddProviderTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider mockProvider = MockProvider();

            int nextId = system.AddProvider(mockProvider);
            Assert.AreNotEqual(0, nextId);
            mockProvider.Id = nextId;

            // retrieve
            Provider retrieved = system.RetrieveProvider(mockProvider.Id);
            Assert.IsNotNull(retrieved);

            Assert.AreEqual(mockProvider.Name, retrieved.Name);
            Assert.AreEqual(mockProvider.PhoneNumber, retrieved.PhoneNumber);
            Assert.AreEqual(mockProvider.City, retrieved.City);
            Assert.AreEqual(mockProvider.EmailAddress, retrieved.EmailAddress);
            Assert.AreEqual(mockProvider.State, retrieved.State);
            Assert.AreEqual(mockProvider.ZipCode, retrieved.ZipCode);

            // cleanup
            int recordsRemoved = system.DeleteProvider(mockProvider.Id);
            Assert.AreEqual(1, recordsRemoved);
        }

        /* Test Case = TC56 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a blank name
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(MySql.Data.MySqlClient.MySqlException))]
        public void TC56_AddProviderTestWithBlankName()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.Name = null;

            int actual = system.AddProvider(provider);  //This should throw exception as name is null
        }

        /* Test Case = TC57 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a blank Address
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(MySql.Data.MySqlClient.MySqlException))]
        public void TC57_AddProviderTestWithBlankAddress()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.StreetAddress = null;

            int actual = system.AddProvider(provider);  //This should throw exception as Address is null
        }

        /* Test Case = TC58 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a blank State
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(MySql.Data.MySqlClient.MySqlException))]
        public void TC58_AddProviderTestWithBlankState()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.State = null;

            int actual = system.AddProvider(provider);  //This should throw exception as State is null
        }

        /* Test Case = TC59 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a blank Zipcode
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(MySql.Data.MySqlClient.MySqlException))]
        public void TC59_AddProviderTestWithBlankZip()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.ZipCode = null;

            int actual = system.AddProvider(provider);  //This should throw exception as Zip is null
        }

        /* Test Case = TC60 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a name shorter than 3 characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC60_AddProviderTestWithTooShortName()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.Name = "AA";

            int actual = system.AddProvider(provider);  //This should throw exception as the name is too short
        }

        /* Test Case = TC61 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a name consisting of all numeric characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC61_AddProviderTestWithallNumericName()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.Name = "2222";

            int actual = system.AddProvider(provider);  //This should throw exception as the name consists of all numeric characters
        }

        /* Test Case = TC62 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a name consisting of all special characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC62_AddProviderTestWithSpecialCharactersName()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.Name = "#$%^&*";

            int actual = system.AddProvider(provider);  //This should throw exception as the name consists of all special characters
        }

        /* Test Case = TC63 */
        /// <summary>
        /// Verifies that a Provider cannot be added with an address that is too short - less than 5 characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC63_AddProviderTestWithTooShortAddress()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.StreetAddress = "12Ma";

            int actual = system.AddProvider(provider);  //This should throw exception as the address is too short
        }

        /* Test Case = TC64 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a city less than 3 alpha characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC64_AddProviderTestWithTooShortCity()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.City = "Ga";

            int actual = system.AddProvider(provider);  //This should throw exception as the city is too short
        }

        /* Test Case = TC65 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a state less than 2 alpha characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC65_AddProviderTestWithTooShortState()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.State = "G";

            int actual = system.AddProvider(provider);  //This should throw exception as the state is too short
        }

        /* Test Case = TC66 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a state more than 2 alpha characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC66_AddProviderTestWithTooLongState()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.State = "GAA";

            int actual = system.AddProvider(provider);  //This should throw exception as the state is too long
        }

        /* Test Case = TC67 */
        /// <summary>
        /// Verifies that a Provider cannot be added with a zipcode less than 5 characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TC67_AddProviderTestWithTooShortZip()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();
            provider.ZipCode = "1111";

            int actual = system.AddProvider(provider);  //This should throw exception as the zipcode is too short
        }

    }
}
