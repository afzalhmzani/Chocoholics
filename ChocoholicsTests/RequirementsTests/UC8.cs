using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC8
    {
        /* Test Case = TC30 */
        /// <summary>
        /// Verifies that an error message will appear if the member number is too short, or a zero.
        /// </summary>
        [TestMethod()]
        public void TC30_VerifyInvalidMemberNumber(){
            //attempt to update a member using an invalid id.
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int memberId = 0;
            string expected = "Member number must be exactly 9 digits long.";
            string actual = chocAnSystem.VerifyMemberNumberRules(memberId);  //Sending a zero

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC31 */
        /// <summary>
        /// Verifies that an error message wil appear if the member number is a negative integer.
        /// </summary>
        public void TC31_VerifyNegativeMemberNumber()
        {
            //attempt to update a member using an invalid id.
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int memberId = -554;
            string expected = "Member number must be exactly 9 digits long.";
            string actual = chocAnSystem.VerifyMemberNumberRules(memberId);  //Sending a zero

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC32 */
        /// <summary>
        /// Verifies that an error message will appear when the member does not exist.
        /// </summary>
        [TestMethod]
        public void TC32_VerifyInvalidMemberNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int memberId = 999999999; // 9-digits, but not used by anyone
            string expected = "Invalid Number";
            string actual = chocAnSystem.VerifyMember(memberId);

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC33 */
        /// <summary>
        /// Verifies that an active member can be suspended
        /// </summary>
        [TestMethod]
        public void TC33_VerifySuspend_ActiveMember()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int testMember = 375104783; //Member ID will need to be updated once Db is updated

            //Make sure the member is currently not suspended
            string expected = "Validated";
            string actual = chocAnSystem.VerifyMember(testMember);

            Assert.AreEqual(expected, actual);
            
            //suspend the member
            expected = "Member Suspended";
            actual = chocAnSystem.SuspendMember(testMember);

            Assert.AreEqual(expected, actual);

            //Make sure the member is suspended after update
            expected = "Member Suspended";
            actual = chocAnSystem.VerifyMember(testMember);

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC34 */
        /// <summary>
        /// Verifies that a suspended member can be suspended
        /// </summary>
        [TestMethod()]
        public void TC34_VerifySuspend_SuspendedMember()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int testMember = 375104783;//Member ID will need to be updated once Db is updated

            //Make sure the member is currently suspended (suspended in TC33)
            string expected = "Member Suspended";
            string actual = chocAnSystem.VerifyMember(testMember);  

            Assert.AreEqual(expected, actual);

            //suspend the member
            expected = "Member Suspended";
            actual = chocAnSystem.SuspendMember(testMember);
            Assert.AreEqual(expected, actual);

            //Make sure the member is suspended after update
            expected = "Member Suspended";
            actual = chocAnSystem.VerifyMember(testMember);

            Assert.AreEqual(expected, actual);
        }
    }
}
