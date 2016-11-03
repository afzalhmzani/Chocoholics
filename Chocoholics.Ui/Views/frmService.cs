using Chocoholics.Ui.Presenters;
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


namespace Chocoholics.Ui.Views
{
    public partial class frmService : Form, IServiceView
    {
        public frmService()
        {
            InitializeComponent();
            ServicePresenter sPresenter = new ServicePresenter(this); 
        }
       

        public string ServiceName
        {
            get
            {
                return txtServiceName.Text;
            }
            set
            {
                txtServiceName.Text = value;
            }
        }
        public int ServiceCode
        {
            get
            {
                return Convert.ToInt32( txtServiceCode.Text);
            }
            set
            {
                int.TryParse(txtServiceCode.Text, out value);
             
            }
        }

        public decimal ServiceFee
        {
            get
            {
                return Convert.ToDecimal(txtServiceFee.Text);
            }
            set
            {
                decimal.TryParse(txtServiceFee.Text, out value);
             
            }
        }

        public string ServiceDescription
        {
            get
            {
                return txtServDescription.Text;
            }

            set
            {
                txtServDescription.Text = value;
            }
        }
        public List<Service> allService
        {
            get
            {
                List<Service> service = datagService.DataSource as List<Service>;
                return service; 
            }
            set
            {
                datagService.DataSource = value; 
            }
        }
        public int SearchService
        {
            get
            {
                return Convert.ToInt32(txtSearchService.Text);
            }
            set
            {
                int.TryParse(txtSearchService.Text, out value); 
            }
        }
        
      
        

        public event EventHandler AddService;
        public event EventHandler UpdateService;
        public event EventHandler DeleteService;
        public event EventHandler SearchForService;
        public event EventHandler SelectAllServices; 
        

        public void DisplayException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            EventHandler handler = AddService;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText();
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            EventHandler handler = UpdateService;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            EventHandler handler = DeleteService;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText();
        }

        private void datagService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //EventHandler handler = DeleteService;
            //if (handler != null)
            //{
            //    handler(sender, EventArgs.Empty);
            //}
        }

        private void frmService_Load(object sender, EventArgs e)
        {

        }

        private void datagService_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void datagService_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            Service svc = datagService.Rows[e.RowIndex].DataBoundItem as Service;
            
            if (svc != null)
            {
                txtServDescription.Text = svc.Description;
                txtServiceCode.Text = svc.Code.ToString();
                txtServiceFee.Text = svc.Fee.ToString();
                txtServiceName.Text = svc.Name;
                txtServiceCode.Enabled = false;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnServiceSerarch_Click(object sender, EventArgs e)
        {
            EventHandler handler = SearchForService;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();

        }

        private void txtSelectAllService_Click(object sender, EventArgs e)
        {
            EventHandler handler = SelectAllServices;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText(); 
        }

        private void clearText()
        {
            txtServiceName.Text = "";
            txtServiceCode.Enabled = true;
            txtServiceCode.Text = "";
            txtServiceFee.Text = "";
            txtServDescription.Text = "";
            txtServiceName.Text = "";
            txtSearchService.Text = ""; 
            
        }
    }
}
