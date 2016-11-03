using System;
using System.Collections.Generic;
using System.IO;
using Chocoholics.Business;
using Chocoholics.Database;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;

namespace Chocoholics.Reports
{
    /// <summary>
    /// A report containing a list of the Electronic Funds 
    /// that need to be transfered/paid to Providers.
    /// </summary>
    public class EFTReport
    {
        private string dateToday;

        public EFTReport(){}  //Empty Constructor

        public string DefaultPath
        {
            get
            {
                return @"C:\POC\";
            }
        }
        public string RunReport()
        {
            try
            {
                CreatePDF();
                return "EFT Extract Report Completed";
            }
            catch
            {
                return "ETF Extract Report Failed";
            }
            
        }
        private void CreatePDF()
        {
            // Setup DataSet
            DataSetETFTableAdapters.rpt_simulateEFTextractTableAdapter ds = new DataSetETFTableAdapters.rpt_simulateEFTextractTableAdapter();
            //Setup DataTable
            DataSetETF.rpt_simulateEFTextractDataTable dt = new DataSetETF.rpt_simulateEFTextractDataTable();
            //fill data table adapter with data table
            ds.Fill(dt);
            // Create Report DataSource

            ReportDataSource rds = new ReportDataSource("DataSetEFT_Extract", (System.Data.DataTable)ds.GetData());

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
                viewer.LocalReport.ReportEmbeddedResource = "Reports/rptEFT_Extract.rdlc";
                viewer.LocalReport.ReportPath = "Reports/rptEFT_Extract.rdlc";
                viewer.LocalReport.DataSources.Add(rds); // Add datasource here

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(DefaultPath + "\\EFTExtract_" + dateToday + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: EFTExtractReport.CreatePDF\n\tMessage: {0}",
                    new object[] { ex.Message });
            }
        }
    }
}
