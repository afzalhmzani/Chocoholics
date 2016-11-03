using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC5
    {
        [TestMethod]
        public void TC12_VerifyValidMemberNumber()
        {
            ChocAnSystem chocAn = new ChocAnSystem();

            string expected = "Validated";
            string actual = chocAn.VerifyMember(375104333);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC13_VerifySuspendedMemberNumber()
        {
            ChocAnSystem chocAn = new ChocAnSystem();

            string expected = "Member Suspended";
            string actual = chocAn.VerifyMember(375104784);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC14_InvalidMemberNumber()
        {
            ChocAnSystem chocAn = new ChocAnSystem();

            string expected = "Invalid Number";
            string actual = chocAn.VerifyMember(121212121);
            Assert.AreEqual(expected, actual);
        }
    }
}
