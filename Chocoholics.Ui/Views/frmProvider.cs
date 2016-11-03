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
    public partial class frmProvider : Form, IProviderView
    {
        public frmProvider()
        {
            InitializeComponent();
            ProviderPresenter providerPresenter = new ProviderPresenter(this);
        }

        public string ProviderName
        {
            get
            {
                return txtProviderName.Text;
            }
            set
            {
                txtProviderName.Text = value;
            }
        }
        public int ProviderNumber
        {
            get
            {
                return Convert.ToInt32(txtProviderNumber.Text);
            }
            set
            {
                int.TryParse(txtProviderNumber.Text, out value);
            }
        }
        public string ProviderStreetAddress
        {
            get
            {
                return txtProviderStreetAddress.Text;
            }
            set
            {
                txtProviderStreetAddress.Text = value;
            }
        }
        public string ProviderCity
        {
            get
            {
                return txtProviderCity.Text;
            }
            set
            {
                txtProviderCity.Text = value;
            }
        }
        public string ProviderState
        {
            get
            {
                return txtProviderState.Text;
            }
            set
            {
                txtProviderState.Text = value;
            }
        }
        public string ProviderCountry
        {
            get
            {
                return txtProviderCountry.Text;
            }
            set
            {
                txtProviderCountry.Text = value;
            }
        }
        public string ProviderZipCode
        {
            get
            {
                return txtProviderZipCode.Text;
            }
            set
            {
                txtProviderZipCode.Text = value;
            }
        }
        public string ProviderPhoneNumber
        {
            get
            {
                return txtProviderPhone.Text;
            }
            set
            {
                txtProviderPhone.Text = value;
            }
        }
        public string ProviderEmailAddress
        {
            get
            {
                return txtProviderEmailAddr.Text;
            }
            set
            {
                txtProviderEmailAddr.Text = value;
            }
        }
        public List<Provider> allProvider
        {
            get
            {
                List<Provider> provider = dataGridProvider.DataSource as List<Provider>;
                return provider;
            }
            set
            {
               dataGridProvider.DataSource = value;
            }
        }
        public int SearchProviderGet
        {
            get
            {
                return Convert.ToInt32(txtSearchProviderNum.Text);
            }
            set
            {
                int.TryParse(txtSearchProviderNum.Text, out value);
            }
        }

        public event EventHandler AddProvider;
        public event EventHandler UpdateProvider;
        public event EventHandler DeleteProvider;
        public event EventHandler SearchProvider;
        public event EventHandler SelectAllProviders; 

        public void DisplayException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            EventHandler handler = AddProvider;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            cleartext();
        }

        private void btnUpdateProvider_Click(object sender, EventArgs e)
        {
            EventHandler handler = UpdateProvider;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            cleartext();
        }

        private void btnDeleteProvider_Click(object sender, EventArgs e)
        {
            EventHandler handler = DeleteProvider;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            cleartext();
        }

        private void dataGridProvider_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Provider pro = dataGridProvider.Rows[e.RowIndex].DataBoundItem as Provider;
            if (pro != null)
            {
                txtProviderName.Text = pro.Name;
                txtProviderNumber.Text = pro.ProviderNumber.ToString();
                txtProviderStreetAddress.Text = pro.StreetAddress;
                txtProviderCity.Text = pro.City;
                txtProviderState.Text = pro.State;
                txtProviderCountry.Text = pro.Country;
                txtProviderZipCode.Text = pro.ZipCode;
                txtProviderPhone.Text = pro.PhoneNumber;
                txtProviderEmailAddr.Text = pro.EmailAddress;
            }
        }

        private void btnProviderSearch_Click(object sender, EventArgs e)
        {
            EventHandler handler = SearchProvider;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleartext();

        }
        private void cleartext()
        {
            txtProviderName.Text = "";
            txtProviderNumber.Text = "";
            txtProviderStreetAddress.Text = "";
            txtProviderCity.Text = "";
            txtProviderState.Text = "";
            txtProviderCountry.Text = "";
            txtProviderZipCode.Text = "";
            txtProviderPhone.Text = "";
            txtProviderEmailAddr.Text = "";
            txtSearchProviderNum.Text = "";
        }

        private void btnSelectAllProviders_Click(object sender, EventArgs e)
        {
            EventHandler handler = SelectAllProviders;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            cleartext();
        }
    }
}
