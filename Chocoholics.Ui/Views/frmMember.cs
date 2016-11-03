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
    public partial class frmMember : Form, IMemberView
    {
        
        public frmMember()
        {
            InitializeComponent();
            MemberPresenter memPresenter = new MemberPresenter(this);
        }
        public string MemberName
        {
            get
            {
                return txtMemberName.Text;
            }
            set
            {
                txtMemberName.Text = value;
            }
        }
        public int MemberNumber
        {
            get
            {
               return Convert.ToInt32(txtMemberNum.Text);
            }
            set
            {
                int.TryParse(txtMemberNum.Text, out value);
                
            }
        }
        public string MemberAddress
        {
            get
            {
                return txtStreetAddress.Text;
            }
            set
            {
                txtStreetAddress.Text = value;
            }
        }
        public string MemberCity
        {
            get
            {
                return txtMemberCity.Text;
            }
            set
            {
                txtMemberCity.Text = value;
            }
        }
        public string MemberState
        {
            get
            {
                return txtMemberState.Text;
            }
            set
            {
                txtMemberState.Text = value;
            }
        }
        public string  MemberZipCode
        {
            get
            {
                return txtMemberZipCode.Text;
            }
            set
            {
                txtMemberZipCode.Text = value;
                
            }
        }
        public string NickName
        {
            get
            {
                return txtMemberNickName.Text;
            }
            set
            {
                txtMemberNickName.Text = value;
            }
        }
        public char PaidInFull
        {
            get
            {
                return Convert.ToChar(txtPaindInFull.Text);
            }
            set
            {
               char.TryParse( txtPaindInFull.Text, out value);
            }
        }
        public string Country
        {
            get
            {
                return txtCountry.Text;
            }
            set
            {
                txtCountry.Text = value;
            }
        }
        public string Phone
        {
            get
            {
                return txtPhone.Text;
            }
            set
            {
                txtPhone.Text = value;
            }
        }
        public string Eamil
        {
            get
            {
                return txtEmail.Text;
            }
            set
            {
                txtEmail.Text = value;
            }
        }

        public List<Member> allMember
        {
            get
            {
                List<Member> member = dataGradMember.DataSource as List<Member>;
                return member;
            }
            set
            {
                dataGradMember.DataSource = value;
            }
        }
        public int SearchMemberNum
        {
            get
            {
                return Convert.ToInt32(txtSearchMemberNum.Text);
            }
            set
            {
                int.TryParse(txtSearchMemberNum.Text, out value);
            }
        }
        public event EventHandler AddMember;
        public event EventHandler UpdateMember;
        public event EventHandler DeleteMember;
        public event EventHandler SearchMember;
        public event EventHandler SelectAllMembers; 

        public void DisplayException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandler handler = AddMember;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Fill all text boxes from GradView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGradMember_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            

            Member mem = dataGradMember.Rows[e.RowIndex].DataBoundItem as Member;
            if (mem != null)
            {
                txtMemberName.Text = mem.Name;
                txtMemberNum.Text = mem.MemberNumber.ToString();
                txtMemberNickName.Text = mem.NickName;
                txtStreetAddress.Text = mem.StreetAddress;
                txtMemberCity.Text = mem.City;
                txtMemberState.Text = mem.State;
                txtCountry.Text = mem.Country;
                txtMemberZipCode.Text = mem.ZipCode;
                txtPaindInFull.Text = mem.PaidInFull.ToString();
                txtPhone.Text = mem.PhoneNumber;
                txtEmail.Text = mem.EmailAddress;
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EventHandler handler = SearchMember;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearText();
        }

        /// <summary>
        /// To Clear all my Text
        /// </summary>
        private void clearText()
        {
            txtMemberName.Text = "";
            txtMemberNum.Text = "";
            txtMemberNickName.Text = "";
            txtStreetAddress.Text = "";
            txtMemberCity.Text = "";
            txtMemberState.Text = "";
            txtCountry.Text = "";
            txtMemberZipCode.Text = "";
            txtPaindInFull.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtSearchMemberNum.Text = "";
        }

        private void dataGradMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            EventHandler handler = UpdateMember;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            EventHandler handler = DeleteMember;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText();
        }

        private void btnSelectAllMember_Click(object sender, EventArgs e)
        {
            EventHandler handler = SelectAllMembers;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
            clearText(); 
        }
    }
}
