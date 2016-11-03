using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC16
    {
        [TestMethod]
        public void TC80_DeactivateProviderTest()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            Provider providerToDeactiate = chocAnSystem.RetrieveProvider(678496784);
            providerToDeactiate.Deactivate();

            string expected = "Update Successful";
            string actual = chocAnSystem.UpdateProvider(providerToDeactiate);
            Assert.AreEqual(expected, actual);

            // cleanup
            providerToDeactiate = chocAnSystem.RetrieveProvider(678496784);
            providerToDeactiate.InactiveDate = null;
            actual = chocAnSystem.UpdateProvider(providerToDeactiate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC81_NonExistantProviderTest()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            string expected = "Provider number 111111111 does not exist";

            try
            {
                Provider providerToDeactiate = chocAnSystem.RetrieveProvider(111111111);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expected, ex.Message);               
            }          
        }

    }
}
