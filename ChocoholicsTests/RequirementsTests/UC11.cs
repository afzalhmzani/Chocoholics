using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;
using Chocoholics.Reports;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC11
    {
        /* Test Case = TC40 */
        /// <summary>
        /// Verifies that a report is created for a single Active Member
        /// </summary>
        [TestMethod()]
        public void TC40_RunSingleReportTest()
        {

            ActiveMemberReport report = new ActiveMemberReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            // make sure directory does not exist
            if (System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.Delete(dir, true);  //deletes folder and all content
                Assert.IsFalse(System.IO.Directory.Exists(dir));
            }

            // this call should both create the report and the directory.
            
            string expected = "Active Member report ran successfully";
            string actual = report.RunReport(375104333);  

            Assert.AreEqual(expected, actual);

            // cleanup
            System.IO.Directory.Delete(dir, true);
            Assert.IsFalse(System.IO.Directory.Exists(dir));
        }

        /* Test Case = TC41 */
        /// <summary>
        /// Verifies that a report is created for all Active Members
        /// </summary>
        [TestMethod()]
        public void TC41_RunAllReportTest()
        {

            ActiveMemberReport report = new ActiveMemberReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "Active Member report(s) ran successfully";
            string actual = report.RunReport();  //passing no variables creates all active members reports
            string actualTrimmed = actual.Substring(actual.Length - 40, 40); //trimmed to omit the number of reports ran

            Assert.AreEqual(expected, actualTrimmed);

            // cleanup
            if (System.IO.Directory.Exists(dir))  //Only delete directory if it exists
            {
                 System.IO.Directory.Delete(dir, true);
            }
           
            Assert.IsFalse(System.IO.Directory.Exists(dir));
        }

        /* Test Case = TC42 */
        /// <summary>
        /// Verifies that a report fails for invalid member number (correct member length)
        /// </summary>
        [TestMethod()]
        public void TC42_RunInvalidMemberID()
        {

            ActiveMemberReport report = new ActiveMemberReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "Report not ran - check Member ID";
            string actual = report.RunReport(111111111);  

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC43 */
        /// <summary>
        /// Verifies that a report fails for invalid member number length
        /// </summary>
        [TestMethod()]
        public void TC43_RunInvalidMemberIDLength()
        {

            ActiveMemberReport report = new ActiveMemberReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "Report not ran - check Member ID";
            string actual = report.RunReport(444);  

            Assert.AreEqual(expected, actual);
        }

        /* Test Case = TC44 */
        /// <summary>
        /// Verifies that a report fails for invalid member number format - using a string
        /// </summary>
        [TestMethod()]
        public void TC44_RunInvalidMemberIDFormat()
        {

            ActiveMemberReport report = new ActiveMemberReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            string expected = "[abc] is not a valid Member ID.  Member ID must be a 9 digit integer";
            string actual = report.RunReport("abc");  //passing a string

            Assert.AreEqual(expected, actual);
        }
    }
}
