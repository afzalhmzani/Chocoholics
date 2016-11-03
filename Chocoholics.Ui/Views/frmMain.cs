using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chocoholics.Reports;

namespace Chocoholics.Ui.Views
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void mnuMainActionsManagerTerminal_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new frmManager());
        }

        private void reportingFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new frmReports());
        }

        private void mnuMainActionsProviderTerminal_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new frmProviderTerminal());
        }


        private void mnuMainActionsOperatorFormMemberForm_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new frmMember());
        }

        private void mnuMainActionsOperatorFormServiceForm_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new frmService());
        }

        private void mnuMainActionsOperatorFormProviderForm_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new frmProvider());
        }

        private void OpenMdiChild(Form mdiChild)
        {
            mdiChild.WindowState = FormWindowState.Maximized;
            mdiChild.MdiParent = this;
            mdiChild.Show();
        }

        private void mnuMainWindowTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuMainWindowTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuMainWindowCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuMainWindowCloseAll_Click(object sender, EventArgs e)
        {
            while (this.MdiChildren.Count() > 0)
            {
                this.MdiChildren.First().Close();
            }
        }

        private void mnuMainFileExit_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit ChocAn?", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Information);

            if (msg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
