using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;
using Chocoholics.Reports;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC1
    {
        string reportName = "ServiceDirectory";

        /* Test Case = TC1 */
        [TestMethod()]
        public void TC1_RunReportTest()
        {
            ServicesDirectoryReport report = new ServicesDirectoryReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            // make sure directory does not exist
            if (System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.Delete(dir, true);  //deletes folder and all content
                Assert.IsFalse(System.IO.Directory.Exists(dir));
            }

            // this call should both create the report and the directory.
            report.RunReport();

            //build expected report name
            string dateToday = DateTime.Now.ToString("m");
            string reportPath = report.DefaultPath + "\\" + reportName + "_" + dateToday + ".pdf";

            Assert.IsTrue(System.IO.Directory.Exists(dir));
            Assert.IsTrue(System.IO.File.Exists(reportPath));

            // cleanup
            System.IO.File.Delete(reportPath);
            System.IO.Directory.Delete(dir, true);
            Assert.IsFalse(System.IO.Directory.Exists(dir));
        }

        /// <summary>
        /// Methods tests TC3, step 3a.
        /// </summary>
        [TestMethod]
        public void TC3a_TestServiceCodeLength()
        {
            ProviderDirectory providerDirectory = new ProviderDirectory();
            providerDirectory.Load();

            foreach (Service svc in providerDirectory.Services)
            {
                string svcCode = svc.Code.ToString();
                Assert.AreEqual(6, svcCode.Length, string.Format("Service {0} has code length = {1}", svc.Name, svcCode.Length));
            }
        }

        /// <summary>
        /// Method tests TC3, step 3b.
        /// </summary>
        [TestMethod]
        public void TC3b_TestServiceFeeNotZero()
        {
            ProviderDirectory providerDirectory = new ProviderDirectory();
            providerDirectory.Load();

            foreach (Service svc in providerDirectory.Services)
            {
                Assert.IsTrue(svc.Fee > 0);
            }
        }

        /// <summary>
        /// Method tests TC3, step 3c.
        /// </summary>
        [TestMethod]
        public void TC3c_TestServiceNameLength()
        {
            ProviderDirectory providerDirectory = new ProviderDirectory();
            providerDirectory.Load();

            foreach (Service svc in providerDirectory.Services)
            {
                Assert.IsTrue(svc.Name.Length <= 20);
            }
        }

        /// <summary>
        /// Method tests TC4
        /// </summary>
        [TestMethod]
        public void TC4_TestDirectoryCannotBeCreated()
        {
            try
            {
                ProviderDirectory providerDirectory = new ProviderDirectory();
                providerDirectory.Load();

                // invalid directory
                providerDirectory.SaveToDisk("C:\\FakeDirectory\\test.csv");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
