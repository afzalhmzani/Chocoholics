using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace Chocoholics.Reports
{
    public partial class ReportTester : Form
    {
        bool realtime = true;  //sets boolean if we want the label to show the real time of day
        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 45);  //set the time to 11:59:45


        public ReportTester()
        {
            InitializeComponent();
        }


        private void ReportTester_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!realtime)
            {
                dt = dt.AddSeconds(1);
                lblClock.Text = dt.ToString("F");

            }
            else
            {
                lblClock.Text = DateTime.Now.ToString("F");
            }
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            realtime = false;

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblClock_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(lblClock.Text).Hour == 0 && Convert.ToDateTime(lblClock.Text).Minute == 0 && Convert.ToDateTime(lblClock.Text).Second == 0)
            {
                ActiveMemberReport amr = new ActiveMemberReport();
                ActiveProviderReport apr = new ActiveProviderReport();
                EFTReport etfr = new EFTReport();
                ServicesDirectoryReport sdr = new ServicesDirectoryReport();
                ChocAnSummaryReport csr = new ChocAnSummaryReport();

                lblResults.Text += amr.RunReport() + "\r\n";
                lblResults.Text += apr.RunReport() + "\r\n";
                lblResults.Text += etfr.RunReport() + "\r\n";
                lblResults.Text += sdr.RunReport() + "\r\n";
                lblResults.Text += csr.RunReport() + "\r\n";

            }
        }

        private void reportViewer4_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void btnActiveMember_Click(object sender, EventArgs e)
        {
            ActiveMemberReport AMR = new ActiveMemberReport();
            if (txtActiveMember.Text != null && txtActiveMember.Text != "")
            {
                int memberInt;
                if(int.TryParse(txtActiveMember.Text, out memberInt))
                {
                    lblResults.Text = AMR.RunReport(memberInt);
                }
                else
                {
                    string memberString = txtActiveMember.Text;
                    lblResults.Text = AMR.RunReport(memberString);
                }
                    
            }
            else
            {
                lblResults.Text = AMR.RunReport();
            }
        }

        private void btnActiveProvider_Click(object sender, EventArgs e)
        {
            ActiveProviderReport APR = new ActiveProviderReport();
            if (txtActiveProvider.Text != null && txtActiveProvider.Text != "")
            {
                int providerInt;
                if (int.TryParse(txtActiveProvider.Text, out providerInt))
                {
                    lblResults.Text = APR.RunReport(providerInt);
                }
                else
                {
                    string providerString = txtActiveProvider.Text;
                    lblResults.Text = APR.RunReport(providerString);
                }
            }
            else
            {
                lblResults.Text = APR.RunReport();
            }
        }


    }
}
