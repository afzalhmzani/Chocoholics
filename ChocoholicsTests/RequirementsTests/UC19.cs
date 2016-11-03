using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC19
    {
        [TestMethod]
        public void TC95_DeactivateMemberTest()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            Member memberToDeactiate = chocAnSystem.GetMemberById(195107514);
            memberToDeactiate.Deactivate();

            string expected = "Update Successful";
            string actual = chocAnSystem.UpdateMember(memberToDeactiate);
            Assert.AreEqual(expected, actual);

            // cleanup
            memberToDeactiate = chocAnSystem.GetMemberById(195107514);
            memberToDeactiate.InactiveDate = null;
            actual = chocAnSystem.UpdateMember(memberToDeactiate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TC96_NonExistantMemberTest()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            string expected = "Member number 555555555 does not exist";

            try
            {
                Member memberToDeactiate = chocAnSystem.GetMemberById(555555555);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

    }
}
