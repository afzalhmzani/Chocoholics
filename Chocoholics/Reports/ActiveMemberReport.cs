using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Chocoholics.Business;
using Chocoholics.Database;

namespace Chocoholics.Reports
{
    /// <summary>
    /// A report provided to all members of Chocoholics Anonymous
    /// which details the services provided to that member.
    /// Can be requested one-at-a-time, or all at once.
    /// </summary>
    /// 
   
    public class ActiveMemberReport
    {
        private List<Member> activeMembers = new List<Member>();  //Array to hold active members who have received treatments
        private string dateToday;
        private ChocAnSystem chocAnSystem = new ChocAnSystem();

        public ActiveMemberReport() {} //Empty Constructor

        public string DefaultPath
        {
            get
            {
                return @"C:\POC\";
            }
        }

        public string RunReport()
        {

            activeMembers = MemberDb.GetMembersTreatedLastWeek();
            try
            {
                int reportNum = activeMembers.Count;
                for (int i = 0; i < activeMembers.Count; i++)
                {
                    CreatePDF(activeMembers[i]);
                }
                return reportNum + " Active Member report(s) ran successfully";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: Reports.ActiveMemberReport.RunReport\n\tMessage: {0}",
                    new object[] { ex.Message });
                throw ex;
            }
        }
        public string RunReport(int member_id)
        {
            if (member_id.ToString().Length == 9)
            {

                if (chocAnSystem.VerifyMember(member_id) == "Validated")
                {
                    try
                    {
                        Member m = new Member();
                        m = MemberDb.GetMemberById(member_id);
                        CreatePDF(m);
                        return "Active Member report ran successfully";
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
                    return string.Format("[{0}] is not valid.  Member ID must be 9 digits", member_id);

                }
            }
            else
            {
                return string.Format("Member ID must be a 9 digits", member_id);
            }
        }
        public string RunReport(string member_id)
        {
            if (member_id == "")
                return RunReport();
            else
                return "Report not ran - check Member ID format";
        }


        private void CreatePDF(Member member)
        {
            // Setup DataSet
            DataSetMemberServicesTableAdapters.rpt_servicesprovidedinthelastweekTableAdapter ds = new DataSetMemberServicesTableAdapters.rpt_servicesprovidedinthelastweekTableAdapter();
            //Setup DataTable
            DataSetMemberServices.rpt_servicesprovidedinthelastweekDataTable dt = new DataSetMemberServices.rpt_servicesprovidedinthelastweekDataTable();
            //fill data table adapter with data table
            ds.Fill(dt, member.Id);
            // Create Report DataSource
            ReportDataSource rds = new ReportDataSource("DataSetMemberServices", (System.Data.DataTable)ds.GetData(member.MemberNumber));  //Search .rdlc XML for DataSetName 

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
                viewer.LocalReport.ReportEmbeddedResource = "Reports/rptMemberServicesProvided_LW.rdlc";
                viewer.LocalReport.ReportPath = "Reports/rptMemberServicesProvided_LW.rdlc";
                viewer.LocalReport.DataSources.Add(rds); // Add datasource here

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (FileStream fs = new FileStream(DefaultPath + "\\" +member.Name + "(" + member.MemberNumber + ")" + "_" + dateToday + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "** Exception **\n\tLocation: ActiveMemberReport.CreatePDF\n\tMessage: {0}",
                    new object[] { ex.Message });
            }
        }
    }
}