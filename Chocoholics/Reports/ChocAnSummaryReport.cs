using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.Reporting.WinForms;
using Chocoholics.Database;
using Chocoholics.Business;

namespace Chocoholics.Reports
{
    /// <summary>
    /// A summary report containing a summary of the last 7 days 
    /// performed by the provider to ChocAn members. Also includes the total number of providers who 
    /// provided services, the total number of consultations, and the overall 
    /// fee total.
    /// </summary>

    public class ChocAnSummaryReport
    {
        private string dateToday;

        public string DefaultPath
        {
            get
            {
                return @"C:\POC";
            }
        }
        public string RunReport()
        {
            try
            {
                CreatePdf();
                return "ChocAn Summary Report Completed";
            }
            catch
            {
                return "ChocAn Summary Report Failed";
            }
        }

        private void CreatePdf()
        {
            // Setup DataSet
            //DataSetServicesDirectoryTableAdapters.listServicesTableAdapter ds = new DataSetServicesDirectoryTableAdapters.listServicesTableAdapter();
            DataSetChocAnSummary_LWTableAdapters.rpt_summaryforthelastweekTableAdapter ds = new DataSetChocAnSummary_LWTableAdapters.rpt_summaryforthelastweekTableAdapter();
            // Setup DataTable
            //DataSetServicesDirectory.listServicesDataTable dt = new DataSetServicesDirectory.listServicesDataTable();
            DataSetChocAnSummary_LW.rpt_summaryforthelastweekDataTable dt = new DataSetChocAnSummary_LW.rpt_summaryforthelastweekDataTable();
            // fill data table adapter with data table
            ds.Fill(dt);

            // Create Report DataSource
            //ReportDataSource rds = new ReportDataSource("DataSetServicesDirectory", (System.Data.DataTable)ds.GetData());//Search .rdlc XML for DataSetName
            ReportDataSource rds = new ReportDataSource("ChocAnSummary_LW", (System.Data.DataTable)ds.GetData()); //Search .rdlc XML for DataSetName
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            dateToday = DateTime.Now.ToString("m");

            Directory.CreateDirectory(DefaultPath);  //Create Directory if one doesn't exist

            try
            {
                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportEmbeddedResource = "Reports/rptChocAnSummary_LW.rdlc";
                viewer.LocalReport.ReportPath = "Reports/rptChocAnSummary_LW.rdlc";
                viewer.LocalReport.DataSources.Add(rds); // Add datasource here

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(DefaultPath + "\\ChocAnSummary_" + dateToday + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ChocAnSummaryReport.CreatePDF\n\tMessage: {0}",
                    new object[] { ex.Message });
            }
        }
    }
}
