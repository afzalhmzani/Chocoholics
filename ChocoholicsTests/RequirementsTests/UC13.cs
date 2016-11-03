using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;
using Chocoholics.Reports;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC13
    {
        string reportName = "ChocAnSummary";

        /* Test Case = TC50 */
        /// <summary>
        /// Verifies that a report is created for the Summary report
        /// </summary>
        [TestMethod()]
        public void TC50_RunSingleProviderReportTest()
        {

            ChocAnSummaryReport report = new ChocAnSummaryReport();
            string dir = new System.IO.DirectoryInfo(report.DefaultPath).FullName;

            // make sure directory does not exist
            if (System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.Delete(dir, true);  //deletes folder and all content
                Assert.IsFalse(System.IO.Directory.Exists(dir));
            }

            // this call should both create the report and the directory.

            string expected = "ChocAn Summary Report Completed";
            string actual = report.RunReport();

            //build expected report name
            string dateToday = DateTime.Now.ToString("m");
            string reportPath = report.DefaultPath + "\\" + reportName + "_" + dateToday + ".pdf";

            Assert.IsTrue(System.IO.Directory.Exists(dir));
            Assert.IsTrue(System.IO.File.Exists(reportPath));

            Assert.AreEqual(expected, actual);

            // cleanup
            System.IO.Directory.Delete(dir, true);
            Assert.IsFalse(System.IO.Directory.Exists(dir));
        }

    }
}
