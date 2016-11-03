using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Windows.Forms;
using Chocoholics.Reports;
using Chocoholics.Database;
using Chocoholics;
using System.Threading.Tasks;
using Chocoholics.Ui.Views;
using System.ComponentModel;

namespace Chocoholics.Reports
{
    public partial class frmReports : Form
    {
        bool realtime = true;  //sets boolean if we want the label to show the real time of day
        DateTime almostMidnight = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 45);  //set the time to 11:59:45
        DateTime fakeTime = new DateTime();
        BackgroundWorker reportWorker;

        public frmReports()
        {
            InitializeComponent();
            reportWorker = new BackgroundWorker();
            reportWorker.DoWork += new DoWorkEventHandler(backgroundWorkerReports_DoWork);
            reportWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerReports_ProgressChanged);
            reportWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerReports_RunWorkerCompleted);
            reportWorker.WorkerReportsProgress = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (!realtime)
            {
                fakeTime = fakeTime.AddSeconds(1);  //add 1 second to "fake time"
                lblClock.Text = fakeTime.ToString("F");
            }
            else
            {
                lblClock.Text = DateTime.Now.ToString("F");
            }
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            realtime = false;
            fakeTime = almostMidnight;
            lblResults.Text = "Please wait...";
        }

        private void lblClock_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(lblClock.Text).Hour == 0 && Convert.ToDateTime(lblClock.Text).Minute == 0 && Convert.ToDateTime(lblClock.Text).Second == 0)
            {
                progressBarReports.Visible = true;
                lblResults.Visible = true;
                backgroundWorkerReports.RunWorkerAsync();
            }
        }

        private void backgroundWorkerReports_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string result = "\r\n";
            int numOfReportsTotal = 0;
            int numOfReportsRanSoFar = 0;
            int percentComplete = 0;            
            Chocoholics.Business.ChocAnSystem sys = new Business.ChocAnSystem(); 
            ActiveMemberReport amr = new ActiveMemberReport();
            int numOfMem = sys.GetLastWeekMembersCount();
            numOfReportsTotal += numOfMem; 
            ActiveProviderReport apr = new ActiveProviderReport();

            int numOfProv = sys.GetLastWeekProvidersCount();
            numOfReportsTotal += numOfProv;
            EFTReport etfr = new EFTReport(); 
            numOfReportsTotal++;
            ServicesDirectoryReport sdr = new ServicesDirectoryReport();
            numOfReportsTotal++;
            ChocAnSummaryReport csr = new ChocAnSummaryReport(); 
            numOfReportsTotal++;

            result += amr.RunReport() + "\r\n";  //Run the Active Member Reports
            numOfReportsRanSoFar += numOfMem;
            percentComplete = Convert.ToInt32(((double)numOfReportsRanSoFar / (double)numOfReportsTotal) * 100);
            backgroundWorkerReports.ReportProgress(percentComplete);

            result += apr.RunReport() + "\r\n"; //Run the Active Provider Reports
            numOfReportsRanSoFar += numOfProv;
            percentComplete = Convert.ToInt32(((double)numOfReportsRanSoFar / (double)numOfReportsTotal) * 100);
            backgroundWorkerReports.ReportProgress(percentComplete);

            result += etfr.RunReport() + "\r\n"; //Run the Electronic Transfer Report
            numOfReportsRanSoFar++;
            percentComplete = Convert.ToInt32(((double)numOfReportsRanSoFar / (double)numOfReportsTotal) * 100);
            backgroundWorkerReports.ReportProgress(percentComplete);

            result += sdr.RunReport() + "\r\n"; //Run the Service Directory Report
            numOfReportsRanSoFar++;
            percentComplete = Convert.ToInt32(((double)numOfReportsRanSoFar / (double)numOfReportsTotal) * 100);
            backgroundWorkerReports.ReportProgress(percentComplete);

            result += csr.RunReport() + "\r\n"; //Run the ChocAn Summary Report
            numOfReportsRanSoFar++;
            percentComplete = Convert.ToInt32(((double)numOfReportsRanSoFar / (double)numOfReportsTotal) * 100);
            backgroundWorkerReports.ReportProgress(percentComplete);
            e.Result = result;
        }

        private void backgroundWorkerReports_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblResults.Text += e.Result.ToString();
        }

        private void backgroundWorkerReports_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBarReports.Value = e.ProgressPercentage;
            lblResults.Text = "Processing....." + progressBarReports.Value.ToString() + "%";
        }

        private void lblResults_Click(object sender, EventArgs e)
        {

        }


    }
}
