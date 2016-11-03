using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC17
    {
        [TestMethod]
        public void TC82_AddNewMemberTest()
        {
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            Member member = new Member()
            {
                City = "Waukesha",
                PhoneNumber = "265-555-4141",
                Country = "USA",
                DateCreated = DateTime.Now,
                EmailAddress = "jeff5454@123.com",
                Name = "Jeff",
                StreetAddress = "106 Sunset Dr",
                State = "WI",
                ZipCode = "55464",
                NickName="Jeff",
                PaidInFull = 'Y'
            };
            string expected = "Member was added successfully";
            string actual = chocAnSystem.AddMember(member);

            Assert.AreEqual(expected, actual);

            // cleanup.
            int recordsDeleted = chocAnSystem.DeleteMember(member);
            Assert.AreEqual(1, recordsDeleted);
        }
    }
}
