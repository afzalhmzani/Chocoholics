using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chocoholics.Reports;
using Chocoholics.Ui.Presenters;
using System.Collections.Generic;


namespace Chocoholics.Ui.Views
{
    public partial class frmManager : Form, IManagerView
    {
        // Keeps track of what report/button was pressed
        // 0 = default, 1 = ActiveMember, 2 = ActiveProvider
        private int _activeButton = 0;  

        public frmManager()
        {
            InitializeComponent();
            ManagerPresenter presenter = new ManagerPresenter(this);
        }

        public int ActiveButton
        {
            get
            {
                return _activeButton;
            }

            set
            {
                _activeButton = value;
            }
        }

        public string OutputText
        {
            get
            {
                return txtOutput.Text;
            }

            set
            {
                txtOutput.Text = value;
                if (!dontHighlight.Contains(value))  //if value is one of the strings below, don't highlight the text
                {
                    txtOutput.SelectAll();
                    txtOutput.Focus();
                }
            }
        }

        private List<String> dontHighlight{
            get
            {
                var strings = new List<String>
                {
                    "Choose Report...",
                    "Running Report(s)...",
                    "Please select a report using buttons below"
                };
                return strings;
            }
    }

        public event EventHandler ActiveMemberInstructionsRequested;
        public event EventHandler ActiveProviderInstructionsRequested;
        public event EventHandler FetchRequestedReport;

        private void btnActiveMember_Click(object sender, EventArgs e)
        {
            EventHandler handler = ActiveMemberInstructionsRequested;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private void btnActiveProvider_Click(object sender, EventArgs e)
        {
            EventHandler handler = ActiveProviderInstructionsRequested;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            EventHandler handler = FetchRequestedReport;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private void txtManagerDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnEnter_Click(sender, e);
            }
        }
    }
}
