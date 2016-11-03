using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC9
    {
        /* Test Case = TC35 */
        /// <summary>
        /// Verifies that an suspended member can be reinstated
        /// </summary>
        [TestMethod]
        public void TC35_VerifyReinstate_SuspendedMember()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int testMember = 375104783; //Member ID will need to be updated once Db is updated

            //Make sure the member is currently suspended
            chocAnSystem.SuspendMember(testMember);  //making sure member is suspended
            string expected = "Member Suspended";
            string actual = chocAnSystem.VerifyMember(testMember);

            Assert.AreEqual(expected, actual);

            //Reinstate the member
            expected = "Member Reinstated";
            actual = chocAnSystem.ReinstateMember(testMember);

            Assert.AreEqual(expected, actual);
            
            //Make sure the member is suspended after update
            expected = "Validated";
            actual = chocAnSystem.VerifyMember(testMember);

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC36 */
        /// <summary>
        /// Verifies that a reinstated member can be reinstated
        /// </summary>
        [TestMethod()]
        public void TC36_VerifyReinstate_ReinstatedMember()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int testMember = 375104783;//Member ID will need to be updated once Db is updated

            //Make sure the member is currently reinstated (reinstated in TC35)
            string expected = "Validated";
            string actual = chocAnSystem.VerifyMember(testMember);  

            Assert.AreEqual(expected, actual);

            //Reinstate the member
            expected = "Member Reinstated";
            actual = chocAnSystem.ReinstateMember(testMember);
            Assert.AreEqual(expected, actual);

            //Make sure the member is not suspended after update
            expected = "Validated";
            actual = chocAnSystem.VerifyMember(testMember);

            Assert.AreEqual(expected, actual);
        }

    }
}
