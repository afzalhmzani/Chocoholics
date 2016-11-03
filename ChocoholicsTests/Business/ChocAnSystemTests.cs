using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocoholics.Business.Tests
{
    [TestClass()]
    public class ChocAnSystemTests
    {
        [TestMethod()]
        public void AddTreatmentTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            Treatment t = MockTreatment();

            int nextId = system.AddTreatment(t);
            Assert.AreNotEqual(0, nextId);
            t.Id = nextId;

            // retrieve the record to see that it matches the original.
            Treatment saved = system.RetrieveTreatment(t.Id);

            Assert.IsNotNull(saved, "Saved treatment not found.");
            Assert.AreEqual(t.Comments, saved.Comments, "Comments in database differ from expected.");

            // cleanup
            int count = system.DeleteTreatment(t.Id);
            Assert.AreEqual(1, count);
        }

        [TestMethod()]
        public void UpdateTreatmentTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            Treatment t = MockTreatment();

            // insert it so it's in the database.
            int nextId = system.AddTreatment(t);
            Assert.AreNotEqual(0, nextId);
            t.Id = nextId;

            // retrieve the record to make modifications
            Treatment retrieved = system.RetrieveTreatment(t.Id);

            // modify the retrieved object.
            retrieved.MemberNumber = 1094597; // different member in db.
            retrieved.ProviderNumber = 67849;
            retrieved.ServiceDate = retrieved.ServiceDate.AddDays(-10);
            retrieved.ServiceFee += 15;
            retrieved.Comments = "modified test comments";
            retrieved.DateEntered = ((DateTime)retrieved.DateEntered).AddDays(10);

            // update in database
            int recordsUpdated = system.UpdateTreatment(retrieved);
            Assert.AreEqual(1, recordsUpdated);

            // retrieve the record to interrogate, retrievedAgain vs. retrieved.
            Treatment retrievedAgain = system.RetrieveTreatment(retrieved.Id);

            Assert.IsNotNull(retrievedAgain);
            Assert.AreEqual(retrieved.Comments, retrievedAgain.Comments, "Comments in database differ from expected.");
            Assert.AreEqual(retrieved.DateEntered, retrievedAgain.DateEntered, "Date entered in database differs from expected.");

            // cleanup
            int count = system.DeleteTreatment(t.Id);
            Assert.AreEqual(1, count);
        }

        [TestMethod()]
        public void DeleteTreatmentTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            Treatment t = MockTreatment();

            // insert it so it's in the database.
            int nextId = system.AddTreatment(t);
            Assert.AreNotEqual(0, nextId);
            t.Id = nextId;

            // retrieve the record to make modifications
            Treatment retrieved = system.RetrieveTreatment(t.Id);
            Assert.IsNotNull(retrieved, "Saved treatment not found.");

            // now delete it, and make sure it can't be retrieved.
            int recordsUpdated = system.DeleteTreatment(t.Id);
            retrieved = system.RetrieveTreatment(t.Id);

            Assert.IsNull(retrieved);

            // no cleanup needed, the treatment was deleted as part of the test.
        }

        private Treatment MockTreatment()
        {
            Treatment t = new Treatment()
            {
                Comments = "test comment",
                DateEntered = DateTime.Now,
                MemberNumber = 1003942,
                ProviderNumber = 67850,
                ServiceCode = 115,
                ServiceDate = new DateTime(2015, 10, 13, 1, 32, 0),
                ServiceFee = 500M
            };

            return t;
        }

        [TestMethod()]
        public void RetrieveServiceTest()
        {
            // a known service in the database
            int expectedCode = 115;
            string expectedName = "Group Conseling";
            string expectedDescription = "Group therapy (max 20) with a professional counselor.";
            decimal expectedFee = 49.99M;

            ChocAnSystem system = new ChocAnSystem();
            Service actual = system.RetrieveService(expectedCode);

            Assert.AreEqual(expectedCode, actual.Code, "Service codes not equal");
            Assert.AreEqual(expectedName, actual.Name, "Names not equal");
            Assert.AreEqual(expectedDescription, actual.Description, "Descriptions not equal");
            Assert.AreEqual(expectedFee, actual.Fee, "Fees not equal");
        }

        [TestMethod()]
        public void RetrieveActiveServicesTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            List<Service> services = system.RetrieveActiveServices();

            Assert.IsTrue(services.Count > 0);
        }

        [TestMethod()]
        public void AddServiceTest()
        {
            ChocAnSystem system = new ChocAnSystem();

            Service s = new Service("Dieting services", 385432, 35.00M);
            s.Description = "Training on Atkins diet.";

            int recordsAffected = system.AddService(s);
            Assert.AreEqual(1, recordsAffected);

            //lookup the service
            Service r = system.RetrieveService(s.Code);
            Assert.IsNotNull(r);
            Assert.AreEqual(s.Code, r.Code);
            Assert.AreEqual(s.Description, r.Description);
            Assert.AreEqual(s.Fee, r.Fee);
            Assert.AreEqual(s.InactiveDate, r.InactiveDate);
            Assert.AreEqual(s.Name, r.Name);

            //cleanup - can't do right now, I accidentally deleted the procedure 
            //int recordsRemoved = system.DeleteService(s.Code);
            //Assert.AreEqual(1, recordsRemoved);
        }

        [TestMethod()]
        public void UpdateServiceTest()
        {
            ChocAnSystem system = new ChocAnSystem();

            Service s = new Service("Dieting services", 385432, 35.00M);
            s.Description = "Training on Atkins diet.";

            // add a new record
            int recordsAffected = system.AddService(s);
            Assert.AreEqual(1, recordsAffected);

            // get a copy to modify
            Service r = system.RetrieveService(s.Code);

            // check that everything is equal before the changes.
            Assert.IsNotNull(r);
            Assert.AreEqual(s.Code, r.Code);
            Assert.AreEqual(s.Description, r.Description);
            Assert.AreEqual(s.Fee, r.Fee);
            Assert.AreEqual(s.InactiveDate, r.InactiveDate);
            Assert.AreEqual(s.Name, r.Name);

            // make changes, description is the only one that can be modified.
            r.Description = s.Description + " with changes.";

            // don't update InactiveDate, this should only be done in the 
            // deleteService stored procedure.  
            //r.InactiveDate = DateTime.Now;

            system.UpdateService(r);

            // retrieve from db again and make sure everying except 
            // the changed items are different.
            r = system.RetrieveService(s.Code);
            Assert.IsNotNull(r);
            Assert.AreEqual(s.Code, r.Code);
            Assert.AreNotEqual(s.Description, r.Description);
            Assert.AreEqual(s.Fee, r.Fee);
            Assert.AreEqual(s.InactiveDate, r.InactiveDate);
            Assert.AreEqual(s.Name, r.Name);

            // cleanup. - comment out until deleteService is re-added to db.
            //int recordsRemoved = system.DeleteService(s.Code);
            //Assert.AreEqual(1, recordsRemoved);
        }

        [TestMethod()]
        public void DeleteServiceTest()
        {
            ChocAnSystem system = new ChocAnSystem();

            Service s = new Service("Dieting services", 385432, 35.00M);
            s.Description = "Training on Atkins diet.";

            int recordsAffected = system.AddService(s);
            Assert.AreEqual(1, recordsAffected);

            // get rid of it.
            recordsAffected = system.DeleteService(s.Code);
            Assert.AreEqual(1, recordsAffected);

            // make sure it's not there.
            recordsAffected = system.DeleteService(s.Code);
            Assert.AreEqual(0, recordsAffected);
        }

        [TestMethod()]
        public void AddProviderTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            Provider provider = MockProvider();

            int nextId = system.AddProvider(provider);
            Assert.AreNotEqual(0, nextId);
            provider.Id = nextId;

            // retrieve
            Provider retrieved = system.RetrieveProvider(provider.Id);
            Assert.IsNotNull(retrieved);

            // cleanup
            int recordsRemoved = system.DeleteProvider(provider.Id);
            Assert.AreEqual(1, recordsRemoved);
        }

        [TestMethod()]
        public void UpdateProviderTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            int providerId = 67854;  // know good value in db.

            Provider p = system.RetrieveProvider(providerId);
            Provider p1 = system.RetrieveProvider(providerId);
            Assert.IsNotNull(p);
            Assert.IsNotNull(p1);

            // make sure these values are the same.
            Assert.AreEqual(p.City, p1.City);
            Assert.AreEqual(p.Country, p1.Country);
            Assert.AreEqual(p.EmailAddress, p1.EmailAddress);
            Assert.AreEqual(p.Name, p1.Name);
            Assert.AreEqual(p.StreetAddress, p1.StreetAddress);

            // now change these values.
            p.City = p1.City + " mod";
            p.EmailAddress = p1.EmailAddress + " mod";
            p.Name = p1.Name + " mod";
            p.StreetAddress = p1.StreetAddress + " mod";

            // update db
            system.UpdateProvider(p);

            // get the values back and make sure they are not equal
            p = system.RetrieveProvider(providerId);
            Assert.AreNotEqual(p.City, p1.City);
            Assert.AreNotEqual(p.EmailAddress, p1.EmailAddress);
            Assert.AreNotEqual(p.Name, p1.Name);
            Assert.AreNotEqual(p.StreetAddress, p1.StreetAddress);

            // reset values and resave.
            p.City = p1.City;
            p.Country = p1.Country;
            p.EmailAddress = p1.EmailAddress;
            p.Name = p1.Name;
            p.StreetAddress = p1.StreetAddress;
            system.UpdateProvider(p);

            // make sure these values are the same again.
            Assert.AreEqual(p.City, p1.City);
            Assert.AreEqual(p.Country, p1.Country);
            Assert.AreEqual(p.EmailAddress, p1.EmailAddress);
            Assert.AreEqual(p.Name, p1.Name);
            Assert.AreEqual(p.StreetAddress, p1.StreetAddress);
        }

        [TestMethod()]
        public void DeleteProviderTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            system.DeleteProvider(67856);
        }

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

        [TestMethod()]
        public void GetOperatorByIdTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            system.GetOperatorById(336);
        }

        [TestMethod()]
        public void GetMemberByIdTest()
        {
            ChocAnSystem system = new ChocAnSystem();
            system.GetMemberById(1094599);
        }

        [TestMethod()]
        public void GetActiveMembersTest()
        {
            Assert.Fail();
        }
    }
}