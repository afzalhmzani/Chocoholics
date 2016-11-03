using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chocoholics.Business;
using Chocoholics.Ui.Presenters;

namespace Chocoholics.Ui.Views
{
    public partial class frmProviderTerminal : Form, ITerminalView
    {
        public frmProviderTerminal()
        {
            InitializeComponent();
            TerminalPresenter presenter = new TerminalPresenter(this);
        }

        public string PowerStatus
        {
            get
            {
                return chbxOnOff.Text;
            }

            set
            {
                chbxOnOff.Text = value;
            }
        }

        public bool IsOn
        {
            get
            {
                return chbxOnOff.Checked;
            }

            set
            {
                chbxOnOff.Checked = value;
            }
        }

        public string TerminalText
        {
            get
            {
                return txtTerminalDisplay.Text;
            }

            set
            {
                txtTerminalDisplay.Text = value;
            }
        }

        public List<Service> AvailableServices
        {
            get
            {
                List<Service> services = dgvServices.DataSource as List<Service>;
                return services;
            }

            set
            {
                dgvServices.DataSource = value;
                FormatDgv();
            }
        }

        // make it look nice.
        private void FormatDgv()
        {
            // reorder
            dgvServices.Columns["Code"].DisplayIndex = 0;
            dgvServices.Columns["Name"].DisplayIndex = 1;
            dgvServices.Columns["Description"].DisplayIndex = 2;
            dgvServices.Columns["Fee"].DisplayIndex = 3;

            // no need show this one
            dgvServices.Columns["InactiveDate"].Visible = false;

            // this one displays money
            dgvServices.Columns["Fee"].DefaultCellStyle.Format = "C";

            // set column widths
            dgvServices.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvServices.Columns["Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvServices.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvServices.Columns["Fee"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public string Instructions
        {
            get
            {
                return lblInstructions.Text;
            }

            set
            {
                if (this.InvokeRequired && !this.IsDisposed)
                {
                    // run on main thread, for updating on non-Ui thread.
                    this.Invoke((MethodInvoker)delegate {
                        lblInstructions.Text = value;
                    });
                }
                else
                {
                    lblInstructions.Text = value;
                }
            }
        }

        public bool EntryEnabled
        {
            get
            {
                return txtTerminalDisplay.Enabled;
            }

            set
            {
                txtTerminalDisplay.Enabled = value;
            }
        }

        public bool SubmitEnabled
        {
            get
            {
                return btnSubmit.Enabled;
            }

            set
            {
                btnSubmit.Enabled = value;
            }
        }

        public bool ProviderReportRequestable
        {
            get
            {
                return btnProviderReport.Enabled;
            }

            set
            {
                btnProviderReport.Enabled = value;
            }
        }

        public string ReportStatusMessage
        {
            get
            {
                return lblReportStatus.Text;
            }
            set
            {
                lblReportStatus.Text = value;
            }
        }

        public event EventHandler RequestSubmitted;
        public event EventHandler AllServicesRequested;
        public event EventHandler PowerStateChanged;
        public event EventHandler ServicesDirectoryRequested;
        public event EventHandler ProviderReportRequested;

        public void DisplayException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            EventHandler handler = RequestSubmitted;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        private void btnRefreshServices_Click(object sender, EventArgs e)
        {
            EventHandler handler = AllServicesRequested;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        private void chbxOnOff_CheckedChanged(object sender, EventArgs e)
        {
            EventHandler handler = PowerStateChanged;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        private void btnServicesDirectory_Click(object sender, EventArgs e)
        {
            EventHandler handler = ServicesDirectoryRequested;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        private void btnProviderReport_Click(object sender, EventArgs e)
        {
            EventHandler handler = ProviderReportRequested;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        public void ShowBusy(bool isBusy)
        {
            if (isBusy)
            {
                this.Cursor = Cursors.AppStarting;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtTerminalDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSubmit_Click(sender, e);
            }
        }

        public void SelectAllTerminalText()
        {
            txtTerminalDisplay.SelectAll();
            txtTerminalDisplay.Focus();
        }
    }
}