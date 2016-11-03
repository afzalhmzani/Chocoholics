using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;
using Chocoholics.Reports;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC12
    {
        /* Test Case = TC45 */
        /// <summary>
        /// Verifies that a report is created for a single Active Provider
        /// </summary>
        [TestMethod()]
        public void TC45_RunSingleProviderReportTest()
        {

            ActiveProviderReport report = new ActiveProviderReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            // make sure directory does not exist
            if (System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.Delete(dir, true);  //deletes folder and all content
                Assert.IsFalse(System.IO.Directory.Exists(dir));
            }

            // this call should both create the report and the directory.

            string expected = "Active Provider report ran successfully";
            string actual = report.RunReport(678496784);  //This Provider id will need to be changed once database is updated

            Assert.AreEqual(expected, actual);

            // cleanup
            System.IO.Directory.Delete(dir, true);
            Assert.IsFalse(System.IO.Directory.Exists(dir));
        }

        /* Test Case = TC46 */
        /// <summary>
        /// Verifies that a report is created for all Active Providers
        /// </summary>
        [TestMethod()]
        public void TC46_RunAllProviderReportTest()
        {

            ActiveProviderReport report = new ActiveProviderReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "Active Provider report(s) ran successfully";
            string actual = report.RunReport();  //passing no variables creates all active Providers reports
            string actualTrimmed = actual.Substring(actual.Length - 42, 42); //trimmed to omit the number of reports ran

            Assert.AreEqual(expected, actualTrimmed);

            // cleanup
            if (System.IO.Directory.Exists(dir))  //Only delete directory if it exists
            {
                System.IO.Directory.Delete(dir, true);
            }
            Assert.IsFalse(System.IO.Directory.Exists(dir));
        }

        /* Test Case = TC47 */
        /// <summary>
        /// Verifies that a report fails for invalid Provider number (correct Provider length)
        /// </summary>
        [TestMethod()]
        public void TC47_RunInvalidProviderID()
        {

            ActiveProviderReport report = new ActiveProviderReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "Report not ran - check Provider ID";
            string actual = report.RunReport(111111111);

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC48 */
        /// <summary>
        /// Verifies that a report fails for invalid Provider number length
        /// </summary>
        [TestMethod()]
        public void TC48_RunInvalidProviderIDLength()
        {

            ActiveProviderReport report = new ActiveProviderReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "Report not ran - check Provider ID";
            string actual = report.RunReport(444);

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC49 */
        /// <summary>
        /// Verifies that a report fails for invalid Provider number format - using a string
        /// </summary>
        [TestMethod()]
        public void TC49_RunInvalidProviderIDFormat()
        {

            ActiveProviderReport report = new ActiveProviderReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "[abc] is not a valid Provider ID.  Provider ID must be a 9 digit integer";
            string actual = report.RunReport("abc");  //passing a string

            Assert.AreEqual(expected, actual);
        }
    }
}
