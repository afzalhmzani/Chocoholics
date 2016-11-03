using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC15
    {
        int testProviderID = 678496784 ;

        /* Test Case = TC55 */
        /// <summary>
        /// Verifies that a Provider can be updated by updating one field at a time
        /// </summary>
        [TestMethod()]
        public void TC55_UpdateProviderTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider originalProvider = new Provider();
            Provider updatedProvider = new Provider();
            Provider retrieved = new Provider();

            //get an existing Provider
            originalProvider = system.GetProviderById(testProviderID);
            Assert.IsNotNull(originalProvider);

            //Make a copy of originalProvider provider
            updatedProvider.ProviderNumber = originalProvider.ProviderNumber;
            updatedProvider.Name = originalProvider.Name;
            updatedProvider.StreetAddress = originalProvider.StreetAddress;
            updatedProvider.City = originalProvider.City;
            updatedProvider.State = originalProvider.State;
            updatedProvider.ZipCode = originalProvider.ZipCode;
            updatedProvider.Country = originalProvider.Country;
            updatedProvider.PhoneNumber = originalProvider.PhoneNumber;
            updatedProvider.EmailAddress = originalProvider.EmailAddress;

            Assert.IsNotNull(updatedProvider);

            //change name field
            updatedProvider.Name = "Aurora";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.Name, retrieved.Name);

            //change address field
            updatedProvider.StreetAddress = "1234 Main street";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.StreetAddress, retrieved.StreetAddress);

            //change city field
            updatedProvider.City = "Oakdale";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.City, retrieved.City);

            //change State field
            updatedProvider.State = "IL";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.State, retrieved.State);

            //change zip field
            updatedProvider.ZipCode = "12345";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.ZipCode, retrieved.ZipCode);

            //change country field
            updatedProvider.Country = "UK";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.Country, retrieved.Country);

            //change phone number field
            updatedProvider.PhoneNumber = "555-111-6666";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.PhoneNumber, retrieved.PhoneNumber);

            //change eMail number field
            updatedProvider.EmailAddress = "JohnyD@aol.com";
            //update database
            system.UpdateProvider(updatedProvider);
            // retrieve updated provider
            retrieved = system.RetrieveProvider(testProviderID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedProvider.EmailAddress, retrieved.EmailAddress);

            // cleanup
            system.UpdateProvider(originalProvider);

        }
    }
}
