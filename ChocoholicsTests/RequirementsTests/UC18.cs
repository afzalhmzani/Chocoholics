using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC18
    {
        int testMemberID = 375104783;

        /* Test Case = T91 */
        /// <summary>
        /// Verifies that a member can be updated by updating one field at a time
        /// </summary>
        [TestMethod()]
        public void TC91_UpdatememberTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            Member originalMember = new Member();
            Member updatedMember = new Member();
            Member retrieved = new Member();

            //get an existing member
            originalMember = system.GetMemberById(testMemberID);
            Assert.IsNotNull(originalMember);
            

            //Make a copy of originalmember member
            updatedMember.MemberNumber = originalMember.MemberNumber;
            updatedMember.Name = originalMember.Name;
            updatedMember.StreetAddress = originalMember.StreetAddress;
            updatedMember.City = originalMember.City;
            updatedMember.State = originalMember.State;
            updatedMember.ZipCode = originalMember.ZipCode;
            updatedMember.Country = originalMember.Country;
            updatedMember.PhoneNumber = originalMember.PhoneNumber;
            updatedMember.EmailAddress = originalMember.EmailAddress;

            Assert.IsNotNull(updatedMember);

            //change name field
            updatedMember.Name = "Johnny Storm";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.Name, retrieved.Name);

            //change address field
            updatedMember.StreetAddress = "1432 Elmwood Avenue";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.StreetAddress, retrieved.StreetAddress);

            //change city field
            updatedMember.City = "Hollywood";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.City, retrieved.City);

            //change State field
            updatedMember.State = "CA";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.State, retrieved.State);

            //change zip field
            updatedMember.ZipCode = "90210";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.ZipCode, retrieved.ZipCode);

            //change country field
            updatedMember.Country = "AU";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.Country, retrieved.Country);

            //change phone number field
            updatedMember.PhoneNumber = "767-322-1265";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID);
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.PhoneNumber, retrieved.PhoneNumber);

            //change eMail number field
            updatedMember.EmailAddress = "JohnyStorm@msn.net";
            //update database
            system.UpdateMember(updatedMember);
            // retrieve updated member
            retrieved = system.GetMemberById(testMemberID); 
            Assert.IsNotNull(retrieved);
            //Test that updates were saved in db
            Assert.AreEqual(updatedMember.EmailAddress, retrieved.EmailAddress);

            // cleanup
            system.UpdateMember(originalMember);
        }

    }
}
