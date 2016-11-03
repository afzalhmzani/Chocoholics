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
    /// A report containing a list of the services 
    /// performed by the provider to ChocAn members.
    /// </summary>
    public class ActiveProviderReport
    {
        private List<Provider> activeProviders = new List<Provider>();  //List to hold active providers who have provided services
        private string dateToday;
        private ChocAnSystem chocAnSystem = new ChocAnSystem();


        public ActiveProviderReport(){} //Empty Constructor

        public string DefaultPath
        {
            get
            {
                return @"C:\POC\";
            }
        }
        public string RunReport()
        {
            activeProviders = ProviderDb.GetProvidersWhoProvidedServiceLastWeek();
            try
            {
                int reportNum = activeProviders.Count;
                for (int i = 0; i < reportNum; i++)
                {
                    CreatePDF(activeProviders[i]);
                }
                return reportNum + " Active Provider report(s) ran successfully";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: Reports.ActiveProviderReport.RunReport\n\tMessage: {0}",
                    new object[] { ex.Message });
                throw ex;
            }
        }
        public string RunReport(int provider_id)
        {
            if (provider_id.ToString().Length == 9)
            {
                if (chocAnSystem.VerifyProvider(provider_id) == "Verified")
                {
                    try
                    {
                        Provider p = new Provider();
                        p = ProviderDb.GetProviderById(provider_id);
                        CreatePDF(p);
                        return "Active Provider report ran successfully";
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(
                            "** Exception **\n\tLocation: Reports.ActiveMemberReport.RunReport\n\tMessage: {0}",
                            new object[] { ex.Message });
                        return "Report did not run - contact tech support";
                    }

                }
                else
                {
                    return string.Format("Provider [{0}] was not found.", provider_id);
                    
                }
            }
            else
            {
                return string.Format("Provider ID must be a 9 digits", provider_id);
                
            }
        }
        public string RunReport(string provider_id)
        {

            if (provider_id == "")
                return RunReport();
            else 
                return "Report not ran - check Provider ID format";
        }


        private void CreatePDF(Provider provider)
        {
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            dateToday = DateTime.Now.ToString("m");
            ReportDataSource rds = new ReportDataSource();
            try
            {
                // Setup DataSet
                DataSetProviderCharges_LWTableAdapters.rpt_providerchargesforthelastweekTableAdapter ds = new DataSetProviderCharges_LWTableAdapters.rpt_providerchargesforthelastweekTableAdapter();
                //Setup DataTable
                DataSetProviderCharges_LW.rpt_providerchargesforthelastweekDataTable dt = new DataSetProviderCharges_LW.rpt_providerchargesforthelastweekDataTable();
                //fill data table adapter with data table
                ds.Fill(dt, provider.ProviderNumber);
                // Create Report DataSource
                rds = new ReportDataSource("ProviderCharges", (System.Data.DataTable)ds.GetData(provider.ProviderNumber));
            }
            catch (Exception ex1)
            {
                Debug.WriteLine(
                   "** Exception **\n\tLocation: ActiveProviderReport.CreatePDF\n\tMessage: {0}",
                   new object[] { ex1.Message });               
            }
            Directory.CreateDirectory(DefaultPath);  //Create Directory if one doesn't exist

            try
            {
                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportEmbeddedResource = "Reports/rptProviderCharges.rdlc";
                viewer.LocalReport.ReportPath = "Reports/rptProviderCharges.rdlc";
                viewer.LocalReport.DataSources.Add(rds); // Add datasource here

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(DefaultPath + "\\" + provider.Name + "(" + provider.ProviderNumber + ")" +"_" + dateToday + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex2)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ActiveProviderReport.CreatePDF\n\tMessage: {0}",
                    new object[] { ex2.Message });
            }
        }
    }
}