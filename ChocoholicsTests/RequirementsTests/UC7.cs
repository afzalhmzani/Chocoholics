using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;
using System.Collections.Generic;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC7
    {
        /// <summary>
        /// Simulates the recording of a payment from Acme Accounting Systems to the ChocAn System
        /// </summary>
        [TestMethod]
        public void TC19_RecordMemberPayments()
        {
            // get a list of all those that paid
            AcmeAccountingServices acctSvc = new AcmeAccountingServices();
            List<Member> membersWhoPaid = acctSvc.MembersWhoJustPaid();
            int expected = membersWhoPaid.Count;

            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int actual = 0;

            foreach (Member paidMember in membersWhoPaid)
            {
                int memberId = paidMember.MemberNumber;
                actual += chocAnSystem.RecordMemberPayment(memberId);
            }

            // make sure there are some updates
            Assert.AreNotEqual(0, expected);

            // make sure all were updated
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that an error message wil appear if the member number is too short.
        /// </summary>
        [TestMethod]
        public void TC20_VerifyTooShortMemberNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int memberId = 123; // 3-digits
            string expected = "Member number must be exactly 9 digits long.";
            string actual = chocAnSystem.VerifyMemberNumberRules(memberId);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that an error message wil appear if the member number is too long.
        /// </summary>
        [TestMethod]
        public void TC21_VerifyTooLongMemberNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int memberId = 1234567890; // 10-digits
            string expected = "Member number must be exactly 9 digits long.";
            string actual = chocAnSystem.VerifyMemberNumberRules(memberId);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that an error message will appear when the member does not exist.
        /// </summary>
        [TestMethod]
        public void TC22_VerifyInvalidMemberNumber()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            int memberId = 111111111; // 9-digits, but not used by anyone
            string expected = "Invalid Number";
            string actual = chocAnSystem.VerifyMember(memberId);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Simulates the recording of a payment from Acme Accounting Systems to the ChocAn System
        /// </summary>
        [TestMethod]
        public void TC23_VerifyMemberStatus()
        {
            // get a list of all those that paid
            AcmeAccountingServices acctSvc = new AcmeAccountingServices();
            List<Member> membersWhoPaid = acctSvc.MembersWhoJustPaid();
            ChocAnSystem chocAnSystem = new ChocAnSystem();

            foreach (Member paidMember in membersWhoPaid)
            {
                int memberId = paidMember.MemberNumber;

                // note this test will not pass until all the members are 9-digits long

                string expected = "Member Suspended";
                string actual = chocAnSystem.VerifyMember(paidMember.MemberNumber);
                Assert.AreEqual(expected, actual);

                // changes member status, but make sure this works also.
                Assert.AreEqual(1, chocAnSystem.RecordMemberPayment(memberId));

                expected = "Validated";
                actual = chocAnSystem.VerifyMember(paidMember.MemberNumber);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
